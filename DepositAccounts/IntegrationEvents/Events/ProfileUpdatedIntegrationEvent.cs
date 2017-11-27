using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DepositAccounts.IntegrationEvents.Events
{
    public class ProfileUpdatedIntegrationEvent : EventBus.Events.IntegrationEvent
    {
        public Guid ProfileID { get; set; }

        public string KYCStatus { get; set; }

        public ProfileUpdatedIntegrationEvent(Guid ProfileID, string KYCStatus)
        {
            this.ProfileID = ProfileID;
            this.KYCStatus = KYCStatus;
        }
    }
}
