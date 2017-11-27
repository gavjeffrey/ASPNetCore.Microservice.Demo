using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace CustomerInformation.Models
{
    public enum Gender
    {
        [EnumMember(Value = "M")]
        Male,
        [EnumMember(Value = "F")]
        Female
    }

    public enum Status
    {
        [EnumMember(Value = "PROSPECT")]
        Prospect,
        [EnumMember(Value = "ACTIVE")]
        Active,
        [EnumMember(Value = "FRAUD")]
        Fraud,
        [EnumMember(Value = "DECEASED")]
        Deceased
    }
}
