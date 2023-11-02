using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QCYDS9_HFT_2023241.Models
{
    [Table("astornauts")]
    public class Astronaut
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AstronautId { get; set; }
        [ForeignKey(nameof(Mission))]
        public int MissionId { get; set; }
        [MaxLength(250)]
        [Required]
        public string Name { get; set; }
        public string Country { get; set; }
        public int BornYear { get; set; }
        public bool Gender { get; set; }

        [NotMapped]
        public virtual Mission Mission { get; set; }
        public Astronaut()
        {

        }

        public Astronaut(int astronautId, int missionId, string name, string country, int bornYear, bool gender)
        {
            AstronautId = astronautId;
            MissionId = missionId;
            Name = name;
            Country = country;
            BornYear = bornYear;
            Gender = gender;
        }
        public Astronaut(int astronautId, Mission mission, string name, string country, int bornYear, bool gender)
        {
            AstronautId = astronautId;
            MissionId = mission.MissionId;
            Name = name;
            Country = country;
            BornYear = bornYear;
            Gender = gender;
        }

        public override string ToString()
        {
            return $"{Name}, ({BornYear})";
        }
    }
}

