using Microsoft.EntityFrameworkCore;
using ParkBeheerEFLayer.Model;
using ParkBusinessLayer.Interfaces;
using ParkBusinessLayer.Model;
using ParkDataLayer.Exceptions;
using ParkDataLayer.Mappers;
using System;
using System.Collections.Generic;

namespace ParkDataLayer.Repositories
{
    public class HuurderRepositoryEF : IHuurderRepository
    {
        private ParkbeheerContext _ctx;

        public HuurderRepositoryEF()
        {
            _ctx = new ParkbeheerContext();
        }
        private void SaveAndClear()
        {
            _ctx.SaveChanges();
            _ctx.ChangeTracker.Clear();
        }

        public Huurder GeefHuurder(int id)
        {
            try
            {
                HuurderEF h = _ctx.Huurder.Where(h => h.Id == id).AsNoTracking().FirstOrDefault();
                if (h == null) throw new HuurderRepositoryException("Huurder niet gevonden");
                return MapHuurder.MapToDomain(h);
            }
            catch(HuurderRepositoryException) { throw; }
            catch (Exception ex)
            {
                throw new HuurderRepositoryException("GeefHuurder", ex);
            }
        }

        public List<Huurder> GeefHuurders(string naam)
        {
            try
            {
                List<HuurderEF> huurderEFs = _ctx.Huurder.Where(h => h.Naam == naam).Select(x => x).ToList();
                List<Huurder> result = new List<Huurder>();
                foreach(HuurderEF huurderEF in huurderEFs)
                {
                    result.Add(MapHuurder.MapToDomain(huurderEF));
                }


                return result;
            }
            catch (Exception ex)
            {
                throw new HuurderRepositoryException("GeefHuurder", ex);
            }
        }

        public bool HeeftHuurder(string naam, Contactgegevens contact)
        {
            try
            {
                return _ctx.Huurder.Any(x => x.Naam == naam && x.Telefoon == contact.Tel && x.Adres == contact.Adres && x.Email == contact.Email) ;
            }
            catch (Exception ex)
            {
                throw new HuurderRepositoryException("HeeftHuurder", ex);
            }
        }

        public bool HeeftHuurder(int id)
        {
            try
            {
                return _ctx.Huurder.Any(x => x.Id == id);
            }
            catch (Exception ex)
            {
                throw new HuurderRepositoryException("HeeftHuurder", ex);
            }
        }

        public void UpdateHuurder(Huurder huurder)
        {
            try
            {
                HuurderEF huurderEF = _ctx.Huurder.Single(x => x.Id == huurder.Id);
                huurderEF.Adres = huurder.Contactgegevens.Adres;
                huurderEF.Email = huurder.Contactgegevens.Email;
                huurderEF.Telefoon = huurder.Contactgegevens.Tel;
                huurderEF.Naam = huurder.Naam;

                SaveAndClear();
            }
            catch (Exception ex)
            {
                throw new HuurderRepositoryException("UpdateHuurder", ex);
            }
        }

        public Huurder VoegHuurderToe(Huurder h)
        {
            try
            {
                HuurderEF huurderEF = MapHuurder.MapToDB(h);
                _ctx.Huurder.Add(huurderEF);
                SaveAndClear();
                h.ZetId(huurderEF.Id);
                return h;
            }
            catch (Exception ex)
            {
                throw new HuurderRepositoryException("Huurder", ex);
            }
        }
    }
}
