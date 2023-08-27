using Microsoft.EntityFrameworkCore;
using ParkBeheerEFLayer.Model;
using ParkBusinessLayer.Interfaces;
using ParkBusinessLayer.Model;
using ParkDataLayer.Exceptions;
using ParkDataLayer.Mappers;
using System;

namespace ParkDataLayer.Repositories
{
    public class HuizenRepositoryEF : IHuizenRepository
    {
        private ParkbeheerContext _ctx;

        public HuizenRepositoryEF()
        {
            _ctx = new ParkbeheerContext();
        }
        private void SaveAndClear()
        {
            _ctx.SaveChanges();
            _ctx.ChangeTracker.Clear();
        }

        public Huis GeefHuis(int id)
        {
            try
            {
                var h = _ctx.Huis.Include(h => h.ParkEF).Where(h => h.Id == id).AsNoTracking().FirstOrDefault();
                if (h == null) { throw new HuisRepositoryException("Huis niet gevonden"); }
                return MapHuis.MapToDomain(h);
            }
            catch(HuisRepositoryException) { throw; }
            catch (Exception ex)
            {
                throw new HuisRepositoryException("GeefHuis", ex);
            }
        }

        public bool HeeftHuis(string straat, int nummer, Park park)
        {
            try
            {
                return _ctx.Huis.Any(x => x.Straat == straat && x.Nummer == nummer && x.ParkEF == MapPark.MapToDB(park));
            }
            catch (Exception ex)
            {
                throw new HuisRepositoryException("HeeftHuis", ex);
            }
        }

        public bool HeeftHuis(int id)
        {
            try
            {
                return _ctx.Huis.Any(x => x.Id == id);
            }
            catch (Exception ex)
            {
                throw new HuisRepositoryException("HeeftHuis", ex);
            }
        }

        public void UpdateHuis(Huis huis)
        {
            try
            {
                HuisEF huisEF = _ctx.Huis.Single(x => x.Id == huis.Id);

                huisEF.HuisActief = huis.Actief;
                huisEF.Straat = huis.Straat;
                huisEF.Nummer = huis.Nr;

                SaveAndClear();
            }
            catch (Exception ex)
            {
                throw new HuisRepositoryException("UpdateHuis", ex);
            }
        }

        public Huis VoegHuisToe(Huis h)
        {
            try
            {
                HuisEF s = MapHuis.MapToDB(h);
                _ctx.Huis.Add(s);
                SaveAndClear();
                h.ZetId(s.Id);
                return h;
            }
            catch (Exception ex)
            {
                throw new HuisRepositoryException("Huis", ex);
            }
        }
    }
}
