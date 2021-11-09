using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KCIBES_HFT_2021221.Models
{

    [Table("Drivers")]
    public class Driver
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [NotMapped]
        public virtual Team Team { get; set; }

        [NotMapped]
        public virtual Motor Motor { get; set; }

        [MaxLength(120)]
        public string Name { get; set; }
        public string DateofBirth { get; set; }
        public int Wins { get; set; }

        [ForeignKey(nameof(Team))]
        public int TeamId { get; set; }

        [ForeignKey(nameof(Motor))]
        public int MotorId { get; set; }


    }
}
