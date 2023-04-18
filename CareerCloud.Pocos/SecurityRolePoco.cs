using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;

namespace CareerCloud.Pocos
{
    [Table("Security_Roles")]
    public class SecurityRolePoco : IPoco
    {
        [Key]
        public Guid Id { get; set; }

        [Column("Role")]
        public string Role { get; set; }

        [Column("Is_Inactive")]
        public Boolean IsInactive { get; set; }

        // public virtual ICollection<SecurityLoginsLogPoco> SecurityLoginsLogs { set; get; }
        public virtual ICollection<SecurityLoginsRolePoco> SecurityLoginsRoles { set; get; }
    }
}