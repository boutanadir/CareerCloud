using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;

namespace CareerCloud.Pocos
{
    [Table("System_Country_Codes")]
    public class SystemCountryCodePoco
    {
        [Key]
        public string Code { get; set; }
        public string Name { get; set; }

        public virtual ICollection<ApplicantProfilePoco> ApplicantProfiles { set; get; }
        public virtual ICollection<ApplicantWorkHistoryPoco> ApplicantWorkHistorys { set; get; }
        public virtual ICollection<CompanyLocationPoco> CompanyLocations { set; get; }
    }
}