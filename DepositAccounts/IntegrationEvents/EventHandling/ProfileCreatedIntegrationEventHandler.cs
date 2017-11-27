using DepositAccounts.IntegrationEvents.Events;
using EventBus;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace DepositAccounts.IntegrationEvents.EventHandling
{
    public class ProfileCreatedIntegrationEventHandler : IIntegrationEventHandler<ProfileCreatedIntegrationEvent>
    {
        private Infrastructure.AccountContext accountRepository;

        public ProfileCreatedIntegrationEventHandler(Infrastructure.AccountContext accountRepository)
        {
            this.accountRepository = accountRepository;
        }

        public async Task Handle(ProfileCreatedIntegrationEvent @event)
        {
            bool newProfile = false;

            var profile = await accountRepository.Profiles.SingleOrDefaultAsync(x => x.ProfileID == @event.ProfileID);

            if (profile == null)
            {
                newProfile = true;

                profile = new Models.Profile
                {
                    ProfileID = @event.ProfileID
                };
            }

            if (@event.KYCStatus == "ACTIVE")
            {
                profile.AccountCreationEnabled = true;
            }
            else
            {
                profile.AccountCreationEnabled = false;
            }

            if(newProfile)
                accountRepository.Profiles.Add(profile);
            else
                accountRepository.Profiles.Attach(profile);

            await accountRepository.SaveChangesAsync();            
        }
    }
}
