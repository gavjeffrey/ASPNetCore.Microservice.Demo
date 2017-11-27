using System;
using System.Collections.Generic;

namespace DepositAccounts.Models
{
    public class Account
    {
        public Guid AccountID { get; set; }

        public Guid ProfileID { get; set; }

        public string AccountOwner { get; set; }

        public string AccountType { get; set; }

        public string ProductCode { get; set; }

        public string ProductType { get; set; }

        public string ProductDisplayName { get; set; }

        public string BranchCode { get; set; }

        public string BranchName { get; set; }

        public string AccountNo { get; set; }

        public string AltAccountNo { get; set; }

        public string DisplayName { get; set; }

        public DateTime EffectiveDate { get; set; }

        public bool IsPrimary { get; set; }

        public bool Active { get; set; }

        public bool Deleted { get; set; }

        public List<Link> Links { get; internal set; }
    }
}
