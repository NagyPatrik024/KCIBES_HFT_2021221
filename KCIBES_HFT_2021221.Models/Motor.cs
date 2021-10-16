using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KCIBES_HFT_2021221.Models
{
    
        [Table("Motors")]
        public class Motor
        {
            [Key]
            public int MotorId { get; set; }

            [NotMapped]
            public virtual ICollection<Team> Teams { get; set; }

            [MaxLength(120)]
            public string Type { get; set; }

        public Motor()
        {
            Teams = new HashSet<Team>();
        }


    }
}
