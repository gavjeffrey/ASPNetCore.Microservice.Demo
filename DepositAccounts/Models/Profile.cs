using System;

namespace DepositAccounts.Models
{
    public class Profile
    {
        public Guid ProfileID { get; set; }

        public bool AccountCreationEnabled { get; set; }
    }
}
