using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkBeheerEFLayer.Model
{
    public class ParkEF
    {
        public ParkEF(string parkNaam, string locatie, List<HuisEF> huizenEF)
        {
            ParkNaam = parkNaam;
            Locatie = locatie;
            HuizenEF = huizenEF;
        }

        public ParkEF(string parkNaam, string locatie)
        {
            ParkNaam = parkNaam;
            Locatie = locatie;
        }

        [Key]
        [Column(TypeName = "nvarchar(20)")]
        public string Id { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(250)")]
        public string ParkNaam { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(500)")]
        public string Locatie { get; set; }

        public ICollection<HuisEF> HuizenEF { get; set; }

        
    }
}
