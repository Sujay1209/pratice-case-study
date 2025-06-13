using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    namespace DAL.Models
    {
        [Table("UserInfo")]
        public class UserInfo
        {
            [Key]
            [Column("EmailId")]
            [StringLength(100, MinimumLength = 2)]
            public string EmailId { get; set; }

            [Column("UserName")]
            [Required]
            [StringLength(50, MinimumLength = 1)]
            public string UserName { get; set; }

            [Column("Role")]
            [Required]
            [StringLength(20)]
            [DefaultValue("Participant")]
            public string Role { get; set; }

            [Column("Password")]
            [Required]
            [StringLength(20, MinimumLength = 6)]
            public string Password { get; set; }
        }
    }


}
