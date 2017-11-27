using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Net;
using CustomerInformation.IntegrationEvents.Events;
using EventBus;

namespace CustomerInformation.Controllers
{
    [Route("api/[controller]")]
    public class CustomerProfileController : Controller
    {
        private readonly Infrastructure.ProfileContext profileRepository;
        private readonly IEventBus _eventBus;

        public CustomerProfileController(Infrastructure.ProfileContext profileRepository, IEventBus eventBus)
        {
            this.profileRepository = profileRepository;
            _eventBus = eventBus;
        }

        /// <summary>
        /// Returns all profiles
        /// </summary>
        /// <returns>list of profiles</returns>
        [HttpGet]
        public IEnumerable<Models.Profile> Get()
        {
            return profileRepository.Profiles.Include("Individual").Include("ProfileKeys").ToList();
        }

        /// <summary>
        /// Gets a single profile based on id
        /// </summary>
        /// <param name="id">The Profile unique identifier</param>
        /// <returns>Profile</returns>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Models.Profile), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Get(Guid id)
        {
            var profile = await profileRepository.Profiles.Include("Individual").Include("ProfileKeys")
                .SingleOrDefaultAsync(x => x.ProfileID == id);

            if (profile == null)
            {
                return NotFound();
            }

            return Ok(profile);            
        }

        /// <summary>
        /// Creates a Profile with a prospect status
        /// </summary>
        /// <param name="Profile">The profile to create. A unique profile key should be provided.</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> CreateProspect([FromBody]Models.Profile Profile)
        {
            if (Profile.ProfileKeys == null || Profile.ProfileKeys.Count == 0)
            {
                return BadRequest("A profile key is required.");
            }

            bool keyExists = profileRepository.ProfileKeys
                                .Any(lookup => Profile.ProfileKeys.Select(y => y.ProfileKeyValue)
                                            .Contains(lookup.ProfileKeyValue));

            if (keyExists)
            {
                return BadRequest("A profile already exists with this profile key.");
            }
            
            Profile.CreateDate = DateTime.Now;
            Profile.Status = Models.Status.Prospect;
            Profile.Individual.ProfileID = Profile.ProfileID;
            Profile.ProfileKeys.ForEach(key => key.ProfileKeyID = Guid.NewGuid());

            profileRepository.Profiles.Add(Profile);

            await profileRepository.SaveChangesAsync();

            var eventMessage = new ProfileCreatedIntegrationEvent(Profile.ProfileID, Profile.Status.ToString());
            
            _eventBus.Publish(eventMessage);

            return Created("{id:guid}", Profile);
        }

        /// <summary>
        /// Updates an existing profile
        /// </summary>
        /// <param name="Profile">The profile that needs to be updated</param>
        /// <returns>The profile as it was updated</returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> Put([FromBody]Models.Profile Profile)
        {
            var dbProfile = await profileRepository.Profiles
               .SingleOrDefaultAsync(x => x.ProfileID == Profile.ProfileID);

            if (dbProfile == null)
            {
                return NotFound();
            }

            if (dbProfile.Status != Models.Status.Prospect)
            {
                return BadRequest("Invalid KYC status for upgrade profile.");
            }

            profileRepository.Attach(Profile);

            await profileRepository.SaveChangesAsync();

            var eventMessage = new ProfileUpdatedIntegrationEvent(Profile.ProfileID, Profile.Status.ToString());

            _eventBus.Publish(eventMessage);

            return Ok(Profile);
        }        
    }
}
