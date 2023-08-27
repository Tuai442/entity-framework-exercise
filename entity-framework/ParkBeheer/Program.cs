


using Microsoft.EntityFrameworkCore.Query;
using ParkBeheerEFLayer.Model;
using ParkBusinessLayer.Beheerders;
using ParkBusinessLayer.Interfaces;
using ParkBusinessLayer.Model;
using ParkDataLayer;
using ParkDataLayer.Mappers;
using ParkDataLayer.Repositories;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.IO;



// ---- Setup ----
IContractenRepository contractenRepository = new ContractenRepositoryEF();
IHuizenRepository huizenRepository = new HuizenRepositoryEF();
IHuurderRepository huurderRepository = new HuurderRepositoryEF();


BeheerContracten beheerContracten = new BeheerContracten(contractenRepository);
BeheerHuizen beheerHuizen = new BeheerHuizen(huizenRepository);
BeheerHuurders beheerHuurders = new BeheerHuurders(huurderRepository);


// -------- SETUP ---------
int huisId = 8;
int huurderId = 4;
string huurderContractId = "huurcontract-6";
string parkId = "park-id-6";

// ---- Huis & Park Toevoegen ----
Park park = new Park(parkId, "test", "testter ");
beheerHuizen.VoegNieuwHuisToe("langelede", 42, park);

// ---- HuurContract Toevoegen ----
Contactgegevens contactgegevens = new Contactgegevens("email", "telefoon", "adres");
Huurder huurder = new Huurder("Tuur", contactgegevens);
Huurperiode huurperiode = new Huurperiode(DateTime.Now, 10);
Huis huis = beheerHuizen.GeefHuis(huisId);
beheerContracten.MaakContract(huurderContractId, huurperiode, huurder, huis);


// ---- Get Huurder ID ----
PrintTitel("Get Huurder ID");
Huurder huurderTest = beheerHuurders.GeefHuurder(huurderId);
Console.WriteLine($"Huurder: {huurderTest}");
PrintOnderscheiding();

// ---- Get Huurder Naam ----
PrintTitel("Get Huurder Naam");
List< Huurder > huurders = beheerHuurders.GeefHuurders("Tuur");
foreach(Huurder hT in huurders)
{
    Console.WriteLine($"Huurder op naam: {hT}");
}

PrintOnderscheiding();

// ---- Update Huurder ----
PrintTitel("Update Huurder");
huurderTest.ZetNaam("Jan");
Contactgegevens contactgegevensTest = new Contactgegevens("jan@email.com", "telefoon", "adres");
huurderTest.ZetContactgegevens(contactgegevensTest);
beheerHuurders.UpdateHuurder(huurderTest);
Console.WriteLine($"Huurder: {beheerHuurders.GeefHuurder(huurderId)}");
PrintOnderscheiding();

// ---- Get Huis ----
PrintTitel("Get Huis");
Huis h = beheerHuizen.GeefHuis(huisId);
Console.WriteLine($"Huis: {h}");
PrintOnderscheiding();


// ---- Update Huis ----
PrintTitel("Update Huis");
h.ZetStraat("update straat");
beheerHuizen.UpdateHuis(h);
Huis hUpdate = beheerHuizen.GeefHuis(huisId);
Console.WriteLine($"Huis Update: {hUpdate}");
PrintOnderscheiding();

// ---- Get Contract ----
PrintTitel("Get Contract");
Huurcontract contract = beheerContracten.GeefContract(huurderContractId);
Console.WriteLine($"Contract: {contract}");
PrintOnderscheiding();


// ---- Get Contract Op Begin Datum ----
PrintTitel("Get Contract Op Begin Datum");
List<Huurcontract> contracten = beheerContracten.GeefContracten(new DateTime(2022, 12, 21), null);

foreach (Huurcontract hc in contracten)
{
    Console.WriteLine($"Contract Op Datum: {hc}");
}
PrintOnderscheiding();

// ---- Get Contract Op Begin Datum & Eind Datum ----
PrintTitel("Get Contract Op Begin Datum & Eind Datum");
List<Huurcontract> contracten2 = beheerContracten.GeefContracten(new DateTime(2022, 12, 21), new DateTime(2023, 1, 4));

foreach (Huurcontract hc in contracten2)
{
    Console.WriteLine($"Contract Op Datum: {hc}");
}
PrintOnderscheiding();


// ---- Anuleer Contract ----
PrintTitel("Anuleer Contract");
beheerContracten.AnnuleerContract(contract);
PrintOnderscheiding();

// ---- Archiveer Huis ----
PrintTitel("Archiveer Huis");
beheerHuizen.ArchiveerHuis(hUpdate);
PrintOnderscheiding();



Console.WriteLine("########################### ALLE TESTEN GESLAAGD ###########################");
//--delete from huis;
//--delete from park
//--delete
//         from HuurderContract
//--delete
//         from Huurder;






static void PrintOnderscheiding()
{
    
    Console.WriteLine("----------------------------------------------------\n");
    Console.WriteLine();
}

static void PrintTitel(string titel)
{
    Console.WriteLine($"============= {titel} =============");
}