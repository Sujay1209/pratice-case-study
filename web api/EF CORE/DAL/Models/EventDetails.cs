using System;
using System.Collections.Generic;
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
        [Table("EventDetails")]
        public class EventDetails
        {
            [Key]
            [Column("EventId")]
            public int EventId { get; set; }

            [Column("EventName")]
            [StringLength(50)]
            public string EventName { get; set; }

            [Column("EventCategory")]
            [StringLength(50)]
            public string EventCategory { get; set; }

            [Column("EventDate")]
            public DateTime EventDate { get; set; }

            [Column("Description")]
            public string? Description { get; set; }

            [Column("Status")]
            [DefaultValue("Active")]
            public string Status { get; set; }
        }
    }

}
