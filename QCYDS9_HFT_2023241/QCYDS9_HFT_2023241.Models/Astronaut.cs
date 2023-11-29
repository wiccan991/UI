using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using System.Text.Json.Serialization;

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
        public int Age { get; set; }
        public bool IsMale { get; set; }
        [JsonIgnore]
        [NotMapped]
        public virtual Mission Mission { get; set; }
        public Astronaut()
        {

        }

        public Astronaut(int astronautId, int missionId, string name, string country, int age, bool ismale)
        {
            AstronautId = astronautId;
            MissionId = missionId;
            Name = name;
            Country = country;
            Age = age;
            IsMale = ismale;
        }
        public Astronaut(int astronautId, Mission mission, string name, string country, int age, bool ismale)
        {
            AstronautId = astronautId;
            MissionId = mission.MissionId;
            Name = name;
            Country = country;
            Age = age;
            IsMale = ismale;
        }

        public override string ToString()
        {
            return $"{Name}, ({Age})";
        }
    }
}

