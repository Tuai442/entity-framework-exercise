using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkBeheerEFLayer.Model
{
    public class HuurderContractEF
    {
        public HuurderContractEF(string id, DateTime startDatum, DateTime eindDatum,
            int aantalDagen)
        {
            Id = id;
            StartDatum = startDatum;
            EindDatum = eindDatum;
            AantalDagen = aantalDagen;
            //HuurderEF = huurderEF;
            //HuisEF = huisEF;
        }


     

        public HuurderContractEF(DateTime startDatum, DateTime eindDatum,
            int aantalDagen)
        {
            StartDatum = startDatum;
            EindDatum = eindDatum;
            AantalDagen = aantalDagen;
            
        }

        [Key]
        [Column(TypeName = "nvarchar(25)")]
        public string Id { get; set; }

        [Required]
        public DateTime StartDatum { get; set; }

        [Required]
        public DateTime EindDatum { get; set; }

        [Required]
        public int AantalDagen { get; set; }

        public int HuurderId { get; set; }

        [ForeignKey("HuurderId")]
        public HuurderEF HuurderEF { get; set; }

        public int HuisId { get; set; }

        [ForeignKey("HuisId")]
        public HuisEF HuisEF { get; set; }
    }
}
