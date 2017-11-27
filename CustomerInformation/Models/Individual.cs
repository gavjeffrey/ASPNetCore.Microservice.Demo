using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace CustomerInformation.Models
{
    public class Individual
    {
        [IgnoreDataMember]
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid? ProfileID { get; set; }

        [StringLength(50)]
        public string Title { get; set; }

        [StringLength(50)]
        public string MaritalStatus { get; set; }

        [StringLength(50)]
        public string HomeLanguage { get; set; }

        [StringLength(256), Column(TypeName = "nvarchar(256)")]
        public string FirstName { get; set; }

        [StringLength(256), Column(TypeName = "nvarchar(256)")]
        public string MiddleNames { get; set; }

        [StringLength(256), Column(TypeName = "nvarchar(256)")]
        public string LastName { get; set; }

        [StringLength(256), Column(TypeName = "nvarchar(256)")]
        public string KnownAs { get; set; }

        [StringLength(256), Column(TypeName = "nvarchar(256)")]
        public string Initials { get; set; }

        [StringLength(256), Column(TypeName = "nvarchar(256)")]
        public string MaidenName { get; set; }

        public DateTime? DateOfBirth { get; set; }

        [Column("Gender"), IgnoreDataMember, StringLength(1)]
        public string GenderValue { get; set; }

        [NotMapped]
        public Gender Gender
        {
            get
            {
                if (string.IsNullOrWhiteSpace(GenderValue))
                {
                    return Gender.Male;
                }
                return Extensions.GetEnumValueFromEnumMemberAttribute<Gender>(GenderValue);                
            }
            set
            {
                GenderValue = value.GetAttribute<EnumMemberAttribute>().Value;
            }
        } 

        public DateTime? MarriageDate { get; set; }

        [StringLength(20)]
        public string TaxNumber { get; set; }
    }
}
