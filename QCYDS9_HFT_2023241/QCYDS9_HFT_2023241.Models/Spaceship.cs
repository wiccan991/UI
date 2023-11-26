using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public int MissionId { get; set; }
        public int CheapMission { get; set; }

        public Crewnfo(int id, int cheapMission)
        {
            MissionId = id;
            CheapMission = cheapMission;
        }
    }
}
