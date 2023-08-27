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
    public class ContractenRepositoryEF : IContractenRepository
    {
        private ParkbeheerContext _ctx;

        public ContractenRepositoryEF()
        {
            _ctx = new ParkbeheerContext();
        }

        private void SaveAndClear()
        {
            _ctx.SaveChanges();
            _ctx.ChangeTracker.Clear();
        }

        public void AnnuleerContract(Huurcontract contract)
        {
            try
            {
                HuurderContractEF hc = _ctx.HuurderContract.Single(x => x.Id == contract.Id);
                _ctx.HuurderContract.Remove(hc);
                _ctx.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new HuurderContractRepositoryException("GeefHuurdercontract", ex);
            }
        }

        public Huurcontract GeefContract(string id)
        {
            try
            {
                var h = _ctx.HuurderContract.Include(huurder => huurder.HuurderEF).Include(huurder => huurder.HuisEF)
                    .ThenInclude(huis => huis.ParkEF)
                    .Where(h => h.Id == id).AsNoTracking().FirstOrDefault();
                if(h == null) { throw new HuurderRepositoryException("Huurcontract niet gevonden"); }

                return MapHuurContract.MapToDomain(h);
            }
            catch(HuurderRepositoryException) { throw; }
            catch (Exception ex)
            {
                throw new HuurderContractRepositoryException("GeefHuurdercontract", ex);
            }
        }

        public List<Huurcontract> GeefContracten(DateTime dtBegin, DateTime? dtEinde)
        {
            try
            {
                List<HuurderContractEF> huurderContractEFs = null;
                if (dtEinde != null)
                {
                    huurderContractEFs = _ctx.HuurderContract.Include(hc => hc.HuurderEF).Include(huurder => huurder.HuisEF)
                    .ThenInclude(huis => huis.ParkEF)
                        .Where(h => h.StartDatum >= dtBegin && h.EindDatum <= dtEinde).ToList();

                }
                else
                {
                    huurderContractEFs = _ctx.HuurderContract.Include(hc => hc.HuurderEF).Include(huurder => huurder.HuisEF)
                    .ThenInclude(huis => huis.ParkEF)
                        .Where(h => h.StartDatum >= dtBegin).ToList();
                }
                
                List<Huurcontract> result = new List<Huurcontract>();
                foreach(HuurderContractEF huurderContractEF in huurderContractEFs)
                {
                    result.Add(MapHuurContract.MapToDomain(huurderContractEF));
                }

                return result;
            }
            catch (Exception ex)
            {
                throw new HuurderContractRepositoryException("GeefHuurdercontract", ex);
            }
        }

        public bool HeeftContract(DateTime startDatum, int huurderid, int huisid)
        {
            try
            {
                return _ctx.HuurderContract.Any(x => x.StartDatum == startDatum && x.HuurderEF.Id == huurderid && x.HuisEF.Id == huisid);
            }
            catch (Exception ex)
            {
                throw new HuurderContractRepositoryException("HeeftHuurdercontract", ex);
            }
        }

        public bool HeeftContract(string id)
        {
            try
            {
                return _ctx.HuurderContract.Any(x => x.Id == id);
            }
            catch (Exception ex)
            {
                throw new HuurderContractRepositoryException("HeeftHuurdercontract", ex);
            }
        }

        public void UpdateContract(Huurcontract contract)
        {
            try
            {
                HuurderContractEF huurderContractEF = _ctx.HuurderContract.Single(x => x.Id == contract.Id);
                huurderContractEF.StartDatum = contract.Huurperiode.StartDatum;
                huurderContractEF.EindDatum = contract.Huurperiode.EindDatum;
                huurderContractEF.AantalDagen = contract.Huurperiode.Aantaldagen;
                huurderContractEF.HuurderEF = MapHuurder.MapToDB(contract.Huurder);
                huurderContractEF.HuisEF = MapHuis.MapToDB(contract.Huis);

                //if(_ctx.Park.Any(x => x.Id == contract.Huis.Park.Id))
                //{
                //    huurderContractEF.HuisEF = MapHuis.MapToDB(contract.Huis);
                //}
                

                SaveAndClear();
            }
            catch (Exception ex)
            {
                throw new HuurderContractRepositoryException("UpdateHuurdercontract", ex);
            }
        }

        public Huurcontract VoegContractToe(Huurcontract contract)
        {
            try
            {
                HuurderContractEF hc = MapHuurContract.MapToDB(contract, _ctx);
                

                _ctx.HuurderContract.Add(hc);
                SaveAndClear();
                string idString = hc.Id.ToString();
                contract.ZetId(idString);
                return contract;
            }
            catch (Exception ex)
            {
                throw new HuisRepositoryException("Huis", ex);
            }
        }
    }
}
