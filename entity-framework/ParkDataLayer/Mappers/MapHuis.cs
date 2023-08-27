using ParkBeheerEFLayer.Model;
using ParkBusinessLayer.Model;
using ParkDataLayer.Exceptions;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkDataLayer.Mappers
{
    public class MapHuis
    {
        public static HuisEF MapToDB(Huis huis)
        {
            try
            {
                ParkEF park = MapPark.MapToDB(huis.Park);
                HuisEF huisEF = new HuisEF(huis.Straat, huis.Nr, huis.Actief, park);
                if (huis.Id > 0)
                {
                    huisEF = new HuisEF(huis.Id, huis.Straat, huis.Nr, huis.Actief, park);
                }

                return huisEF;
            }
            catch (Exception ex)
            {
                throw new MapperException("MapToDomain", ex);

            }
        }

        public static Huis MapToDomain(HuisEF huisEF)
        {
            try
            {
                Park park = MapPark.MapToDomain(huisEF.ParkEF);
                return new Huis(huisEF.Id, huisEF.Straat, huisEF.Nummer, huisEF.HuisActief, park);
            }
            catch (Exception ex)
            {
                throw new MapperException("MapToDomain");

            }
        }
    }
}
