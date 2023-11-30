using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;
using System.Net.Cache;

namespace QCYDS9_HFT_2023241.Models
{
    public class Spaceship
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [MaxLength(250)]
        [Required]
        public string Name { get; set; }

        public int Speed { get; set; }

        public int MakeYear { get; set; }
        [JsonIgnore]
        public virtual IEnumerable<Mission> Missions { get; set; }
        public Spaceship()
        {

        }

        public Spaceship(int spacehipId, string name, int speed, int makeYear)
        {
            Id = spacehipId;
            Name = name;
            Speed = speed;
            MakeYear = makeYear;
        }
        

        public override string ToString()
        {
            return $"{Name}, ({Speed})";
        }

    }
    public class Crewnfo
    {
        public Crewnfo()
        {
        }

        public Crewnfo(int missionId, int millioUSD, string name)
        {
            MissionId = missionId;
            MillioUSD = millioUSD;
            SpacehshipName = name;
        }

        public int MissionId { get; set; }
        public int MillioUSD { get; set; }
        public string SpacehshipName { get; set; }

        
    }
}
