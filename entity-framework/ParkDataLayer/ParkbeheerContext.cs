using Microsoft.EntityFrameworkCore;
using ParkBeheerEFLayer.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkDataLayer
{
    public class ParkbeheerContext : DbContext
    {
        public DbSet<HuisEF> Huis { get; set; }
        public DbSet<HuurderContractEF> HuurderContract { get; set; }
        public DbSet<HuurderEF> Huurder { get; set; }
        public DbSet<ParkEF> Park { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\Tuur\Documents\Gegevens\BACK_UP_LAPTOP\hogent\Programmeren gevorderd\Eind Werk\ConsoleApp1\ParkDataLayer\Database1.mdf"";Integrated Security=True");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Add-Migration
            // Update-Database

            //modelBuilder.Entity<HuurderContractEF>()
            //    .HasOne(h => h.HuurderEF)
            //    .WithMany(h => h.HuurderContractEF);


         
            //modelBuilder.Entity<HuurderContractEF>()
            //    .HasOne(h => h.HuurderEF)
            //    .WithMany(h => h.HuurderContractEF)
            //    .OnDelete(DeleteBehavior.SetNull);

            //modelBuilder.Entity<HuurderEF>()
            //    .HasMany(h => h.HuurderContractEF);


            //modelBuilder.Entity<HuurderContractEF>().
            //    HasOne(h => h.HuisEF).WithOne(hu => hu.HuurderContractenEF);
            // Huizen - Park 


            //modelBuilder.Entity<HuisEF>()
            //    .HasOne(h => h.ParkEF).WithMany(p => p.HuizenEF);


            //modelBuilder.Entity<ParkEF>()
            //    .HasMany(p => p.HuizenEF).WithOne(h => h.ParkEF);


            //modelBuilder.Entity<HuurderEF>()
            //    .HasOne(h => h.HuurderContract).WithOne(h => h.HuurderEF);

            // HuurderContracten
            //modelBuilder.Entity<HuurderContractEF>()
            //    .HasOne(hc => hc.HuurderEF).WithOne(h => h.HuurderContract).HasForeignKey<HuurderEF>(h => h.Id);

            //modelBuilder.Entity<HuurderEF>()
            //    .HasOne(h => h.HuurderContract).WithOne(hc => hc.HuurderEF).HasForeignKey<HuurderContractEF>(hc => hc.Id);


            //modelBuilder.Entity<HuurderContractEF>()
            //    .HasOne(hc => hc.HuisEF).WithMany(h => h.HuurderContractenEF);

        }
    }
}
