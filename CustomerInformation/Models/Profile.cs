using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace CustomerInformation.Models
{
    public class Profile
    {
        public Guid ProfileID { get; set; }
                
        public string ProfileType { get; set; }

        [Column("Status"), IgnoreDataMember]
        public string StatusValue { get; set; }

        [NotMapped]
        public Status Status
        {
            get
            {
                if (string.IsNullOrWhiteSpace(StatusValue))
                {
                    return Status.Prospect;
                }
                return Extensions.GetEnumValueFromEnumMemberAttribute<Status>(StatusValue);
            }
            set
            {
                StatusValue = value.GetAttribute<EnumMemberAttribute>().Value;
            }
        }        
                
        public DateTime CreateDate { get; set; }
        
        public DateTime? EffectiveDate { get; set; }

        public Individual Individual { get; set; }

        public List<ProfileKey> ProfileKeys { get; set; }
    }
}
