using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KCIBES_HFT_2021221.Models
{

    [Table("Teams")]
    public class Team
    {
        [Key]
        public int TeamId { get; set; }

        [NotMapped]
        public virtual ICollection<Driver> Drivers { get; set; }

        [NotMapped]
        public virtual Motor Motor { get; set; }

        [MaxLength(120)]
        public string Name { get; set; }

        [MaxLength(120)]
        public string Team_Chief { get; set; }

        [ForeignKey(nameof(Motor))]
        public int MotorId { get; set; }

        public Team()
        {
            Drivers = new HashSet<Driver>();
        }



    }
}
