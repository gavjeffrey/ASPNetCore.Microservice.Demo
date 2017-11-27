using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace CustomerInformation.Models
{
    public class ProfileKey
    {
        [IgnoreDataMember]
        public Guid ProfileKeyID { get; set; }
        
        [StringLength(50)]
        public string ProfileKeyValue { get; set; }
    }
}
