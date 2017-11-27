using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace DepositAccounts.Models
{
    [NotMapped]
    public class Link
    {
        public Uri Uri { get; set; }
        public string Rel { get; set; }
        public string Name { get; set; }
    }
}
