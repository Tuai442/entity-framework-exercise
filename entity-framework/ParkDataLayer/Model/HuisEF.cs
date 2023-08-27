using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ParkBusinessLayer.Interfaces;

namespace ParkBeheerEFLayer.Model
{
    public class HuisEF
    {
        public HuisEF(string straat, int nummer, bool huisActief, ParkEF parkEF)
        {
            Straat = straat;
            Nummer = nummer;
            HuisActief = huisActief;
            ParkEF = parkEF;
        }

        public HuisEF(string straat, int nummer, bool huisActief)
        {
            Straat = straat;
            Nummer = nummer;
            HuisActief = huisActief;
           
        }

        public HuisEF(int id, string straat, int nr, bool actief, ParkEF park)
        {
            Id = id;
            Straat = straat;
            Nummer = nr;
            HuisActief = actief;
            ParkEF = park;
        }

        [Key]
        public int Id { get; set; }

        
        [Column(TypeName = "nvarchar(250)")]
        public string Straat { get; set; }
        [Required]
        public int Nummer { get; set; }

        [Required]
        public bool HuisActief { get; set; }

        [ForeignKey("ParkId")]
        public ParkEF ParkEF { get; set; }

        //[ForeignKey("HuurderContractId")]
        //public HuurderContractEF HuurderContractEF { get; set; }



    }
}
