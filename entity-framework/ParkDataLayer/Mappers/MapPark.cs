using ParkBeheerEFLayer.Model;
using ParkBusinessLayer.Model;
using ParkDataLayer.Exceptions;
using System;
using System.Collections.Generic;

namespace ParkDataLayer.Mappers
{
    public class MapPark
    {
        public static ParkEF MapToDB(Park park)
        {
            try
            {
                List<HuisEF> huizen = new List<HuisEF>();
                foreach (Huis huis in park.Huizen())
                {
                    huizen.Add(MapHuis.MapToDB(huis));
                }

                ParkEF parkEF = new ParkEF(park.Naam, park.Locatie, huizen);
                if (!string.IsNullOrEmpty(park.Id))
                {
                    parkEF.Id = park.Id;
                }
                
                return parkEF;
            }
            catch (Exception ex)
            {
                throw new MapperException("MapToDomain", ex);
            }
        }

        internal static Park MapToDomain(ParkEF parkEF)
        {
            try
            {
                List<Huis> huizen = new List<Huis>();
                //foreach(HuisEF huisEF in parkEF.HuizenEF)
                //{
                //    huizen.Add(MapHuis.MapToDomain(huisEF));
                //}
                   
                return new Park(parkEF.Id.ToString(), parkEF.ParkNaam, parkEF.Locatie,
                    huizen);
            }
            catch (Exception ex)
            {
                throw new MapperException("MapToDomain");
            }
        }
    }
}