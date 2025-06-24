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
        [Table("SpeakersDetails")]
        public class SpeakersDetails
        {
            [Key]
            [Column("SpeakerId")]
            public int SpeakerId { get; set; }

            [Column("SpeakerName")]
            [StringLength(50)]
            public string SpeakerName { get; set; }
        }
    }

}
