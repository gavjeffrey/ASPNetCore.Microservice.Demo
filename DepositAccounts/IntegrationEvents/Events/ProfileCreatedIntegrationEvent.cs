using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DepositAccounts.IntegrationEvents.Events
{
    public class ProfileCreatedIntegrationEvent : EventBus.Events.IntegrationEvent
    {
        public Guid ProfileID { get; set; }

        public string KYCStatus { get; set; }

        public ProfileCreatedIntegrationEvent(Guid ProfileID, string KYCStatus)
        {
            this.ProfileID = ProfileID;
            this.KYCStatus = KYCStatus;
        }
    }
}
