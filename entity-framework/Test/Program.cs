// ---- Setup ----
using ParkBeheerEFLayer.Model;
using ParkBusinessLayer.Beheerders;
using ParkBusinessLayer.Interfaces;
using ParkBusinessLayer.Model;
using ParkDataLayer.Repositories;
using System.Diagnostics.Contracts;

IContractenRepository contractenRepository = new ContractenRepositoryEF();
IHuizenRepository huizenRepository = new HuizenRepositoryEF();
IHuurderRepository huurderRepository = new HuurderRepositoryEF();


BeheerContracten beheerContracten = new BeheerContracten(contractenRepository);
BeheerHuizen beheerHuizen = new BeheerHuizen(huizenRepository);
BeheerHuurders beheerHuurders = new BeheerHuurders(huurderRepository);
//beheerContracten.GeefContracten(new DateTime(2023, 1, 6), new DateTime(2023, 2, 6))


//Huurcontract hc = beheerContracten.GeefContract("hc4");
//hc.ZetHuis(new Huis("sss", 3, new Park("p111", "park", "loc")));
////hc.ZetHuurder(new Huurder("nn", new Contactgegevens("straat", "tel", "ad")));
//beheerContracten.UpdateContract(hc);

//beheerContracten.GeefContract("hc4");

//foreach (var i in beheerHuurders.GeefHuurders("Tuur"))
//{
//    Console.WriteLine(i);
//}


