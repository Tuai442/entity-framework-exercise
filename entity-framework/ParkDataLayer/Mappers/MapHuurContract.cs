using Microsoft.EntityFrameworkCore;
using ParkBeheerEFLayer.Model;
using ParkBusinessLayer.Model;
using ParkDataLayer.Exceptions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkDataLayer.Mappers
{
    public static class MapHuurContract
    {
       
        public static Huurcontract MapToDomain(HuurderContractEF huurderContractEF)
        {
            try
            {
                Huurder huurder = MapHuurder.MapToDomain(huurderContractEF.HuurderEF);
                Huis huis = MapHuis.MapToDomain(huurderContractEF.HuisEF);
                Huurperiode huurderPeriode = new Huurperiode(huurderContractEF.StartDatum, huurderContractEF.AantalDagen);
                return new Huurcontract(huurderContractEF.Id.ToString(), huurderPeriode, huurder, huis);
                
            }
            catch (Exception ex)
            {
                throw new MapperException("MapToDomain");

            }
        }

        public static HuurderContractEF MapToDB(Huurcontract huurderContract, ParkbeheerContext ctx)
        {
            try
            {

                HuurderContractEF huurderContractEF = new HuurderContractEF(huurderContract.Id, huurderContract.Huurperiode.StartDatum, huurderContract.Huurperiode.EindDatum,
                        huurderContract.Huurperiode.Aantaldagen);

                HuisEF huisEF = null;
                HuurderEF huurderEF = null;
                if (!ctx.Huis.Any(x => x.Id == huurderContract.Huis.Id))
                {
                    huisEF = MapHuis.MapToDB(huurderContract.Huis);
                    huurderContractEF.HuisEF = huisEF;
                }
                else
                {
                    huurderContractEF.HuisId = huurderContract.Huis.Id;
                }

                if (!ctx.Huurder.Any(x => x.Id == huurderContract.Huurder.Id))
                {
                    huurderEF = MapHuurder.MapToDB(huurderContract.Huurder);
                    huurderContractEF.HuurderEF = huurderEF;
                }
                else
                {
                    huurderContractEF.HuurderId = huurderContract.Huurder.Id;
                }

                return huurderContractEF;
            }
            catch (Exception ex)
            {
                throw new MapperException("MapToDB");

            }
        }
    }
}
