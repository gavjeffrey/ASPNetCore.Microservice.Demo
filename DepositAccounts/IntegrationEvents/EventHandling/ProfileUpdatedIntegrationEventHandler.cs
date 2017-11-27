using DepositAccounts.IntegrationEvents.Events;
using EventBus;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace DepositAccounts.IntegrationEvents.EventHandling
{
    public class ProfileUpdatedIntegrationEventHandler : IIntegrationEventHandler<ProfileUpdatedIntegrationEvent>
    {
        private Infrastructure.AccountContext accountRepository;

        public ProfileUpdatedIntegrationEventHandler(Infrastructure.AccountContext accountRepository)
        {
            this.accountRepository = accountRepository;
        }

        public async Task Handle(ProfileUpdatedIntegrationEvent @event)
        {
            var profile = await accountRepository.Profiles.SingleOrDefaultAsync(x => x.ProfileID == @event.ProfileID);

            if (@event.KYCStatus == "ACTIVE")
            {
                profile.AccountCreationEnabled = true;
            }
            else
            {
                profile.AccountCreationEnabled = false;
            }

            accountRepository.Profiles.Attach(profile);

            await accountRepository.SaveChangesAsync();
        }
    }
}
