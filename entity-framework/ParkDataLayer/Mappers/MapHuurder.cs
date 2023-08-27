using ParkBeheerEFLayer.Model;
using ParkBusinessLayer.Model;
using ParkDataLayer.Exceptions;
using System;

namespace ParkDataLayer.Mappers
{
    public class MapHuurder
    {
        internal static HuurderEF MapToDB(Huurder huurder)
        {
            try
            {
                HuurderEF huurderEF = new HuurderEF(huurder.Naam, huurder.Contactgegevens.Tel,
                    huurder.Contactgegevens.Email, huurder.Contactgegevens.Adres);
                if (huurder.Id > 0)
                {
                    huurderEF.Id = huurder.Id;
                }
                return huurderEF;
            }
            catch (Exception ex)
            {
                throw new MapperException("MapToDB", ex);
            }
        }

        internal static Huurder MapToDomain(HuurderEF huurderEF)
        {
            try
            {
                Contactgegevens contactgegevens = new Contactgegevens(huurderEF.Email, huurderEF.Telefoon, huurderEF.Adres);

                return new Huurder(huurderEF.Id, huurderEF.Naam, contactgegevens);
            }
            catch (Exception ex)
            {
                throw new MapperException("MapToDomain", ex);
            }
        }
    } }