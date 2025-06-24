using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    namespace DAL.Models
    {
        [Table("SessionInfo")]
        public class SessionInfo
        {
            [Key]
            [Column("SessionId")]
            public int SessionId { get; set; }

            [Column("EventId")]
            public int EventId { get; set; }

            [Column("SessionTitle")]
            [StringLength(50)]
            public string SessionTitle { get; set; }

            [Column("SpeakerId")]
            public int? SpeakerId { get; set; }

            [Column("Description")]
            public string? Description { get; set; }

            [Column("SessionStart")]
            public DateTime SessionStart { get; set; }

            [Column("SessionEnd")]
            public DateTime SessionEnd { get; set; }

            [Column("SessionUrl")]
            public string? SessionUrl { get; set; }
        }
    }

}
