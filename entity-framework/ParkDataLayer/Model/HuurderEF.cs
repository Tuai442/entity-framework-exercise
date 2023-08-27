using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ParkBusinessLayer.Model;

namespace ParkBeheerEFLayer.Model
{
    public class HuurderEF
    {
        public HuurderEF(string naam, string telefoon, string email, string adres)
        {
            //Id = id;
            Naam = naam;
            Telefoon = telefoon;
            Email = email;
            Adres = adres;
         
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(100)")]
        public string Naam { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string Telefoon { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string Email { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string Adres { get; set; }

    
        public ICollection<HuurderContractEF> HuurderContractEF { get; set; }

    }
}
