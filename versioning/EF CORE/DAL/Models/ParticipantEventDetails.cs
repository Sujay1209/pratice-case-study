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
        [Table("ParticipantEventDetails")]
        public class ParticipantEventDetails
        {
            [Key]
            [Column("Id")]
            public int Id { get; set; }

            [Column("ParticipantEmailId")]
            public string ParticipantEmailId { get; set; }

            [Column("EventId")]
            public int EventId { get; set; }

            [Column("IsAttended")]
            public string IsAttended { get; set; }
        }
    }

}
