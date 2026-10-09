using Tp1.Exercice1;
using Tp1.Exercice2;

List<Connexion> connexions = new List<Connexion>
{
    new Connexion { Id=1, AdresseIP="192.168.1.10", Protocole="TCP", Port=80,  Pays="Tunisie",  Duree=12.5, EstSuspecte=false },
    new Connexion { Id=2, AdresseIP="10.0.0.15",    Protocole="TCP", Port=443, Pays="France",   Duree=35.2, EstSuspecte=false },
    new Connexion { Id=3, AdresseIP="172.16.0.8",   Protocole="UDP", Port=53,  Pays="Allemagne",Duree=5.8,  EstSuspecte=false },
    new Connexion { Id=4, AdresseIP="192.168.1.25", Protocole="TCP", Port=22,  Pays="Russie",   Duree=72.4, EstSuspecte=true  },
    new Connexion { Id=5, AdresseIP="10.0.0.20",    Protocole="UDP", Port=53,  Pays="Tunisie",  Duree=8.3,  EstSuspecte=false },
    new Connexion { Id=6, AdresseIP="192.168.1.30", Protocole="TCP", Port=22,  Pays="Chine",    Duree=91.7, EstSuspecte=true  },
    new Connexion { Id=7, AdresseIP="10.0.0.25",    Protocole="TCP", Port=443, Pays="Tunisie",  Duree=44.6, EstSuspecte=false },
    new Connexion { Id=8, AdresseIP="172.16.0.12",  Protocole="UDP", Port=161, Pays="France",   Duree=15.4, EstSuspecte=false }
};


Console.WriteLine("1) TCP :");
connexions.Where(c => c.Protocole == "TCP").ToList()
          .ForEach(c => Console.WriteLine($"  {c.Id} - {c.AdresseIP}:{c.Port}"));


Console.WriteLine("2) Port 22 :");
connexions.Where(c => c.Port == 22).ToList()
          .ForEach(c => Console.WriteLine($"  {c.Id} - {c.AdresseIP}"));


Console.WriteLine("3) Tunisie :");
connexions.Where(c => c.Pays == "Tunisie").ToList()
          .ForEach(c => Console.WriteLine($"  {c.Id} - {c.AdresseIP}"));


Console.WriteLine("4) Durée > 30s :");
connexions.Where(c => c.Duree > 30).ToList()
          .ForEach(c => Console.WriteLine($"  {c.Id} - {c.Duree}s"));


Console.WriteLine("5) Suspectes :");
connexions.Where(c => c.EstSuspecte).ToList()
          .ForEach(c => Console.WriteLine($"  {c.Id} - {c.AdresseIP}"));


Console.WriteLine("6) IP + Port :");
connexions.Select(c => new { c.AdresseIP, c.Port }).ToList()
          .ForEach(x => Console.WriteLine($"  {x.AdresseIP}:{x.Port}"));


Console.WriteLine("7) Durée croissante :");
connexions.OrderBy(c => c.Duree).ToList()
          .ForEach(c => Console.WriteLine($"  {c.Id} - {c.Duree}s"));


Console.WriteLine("8) Durée décroissante :");
connexions.OrderByDescending(c => c.Duree).ToList()
          .ForEach(c => Console.WriteLine($"  {c.Id} - {c.Duree}s"));


Console.WriteLine("9) Pays puis durée décroissante :");
connexions.OrderBy(c => c.Pays).ThenByDescending(c => c.Duree).ToList()
          .ForEach(c => Console.WriteLine($"  {c.Pays} - {c.Id} - {c.Duree}s"));


Console.WriteLine($"10) Total : {connexions.Count}");


Console.WriteLine($"11) Durée moyenne : {connexions.Average(c => c.Duree):F2}s");


var max = connexions.OrderByDescending(c => c.Duree).First();
Console.WriteLine($"12) Plus longue : {max.Id} ({max.Duree}s)");


var min = connexions.OrderBy(c => c.Duree).First();
Console.WriteLine($"13) Plus courte : {min.Id} ({min.Duree}s)");


Console.WriteLine($"14) Nb suspectes : {connexions.Count(c => c.EstSuspecte)}");


Console.WriteLine("15) Groupes par protocole :");
connexions.GroupBy(c => c.Protocole).ToList()
          .ForEach(g => Console.WriteLine($"  {g.Key} : {g.Count()}"));


Console.WriteLine($"16) Au moins une suspecte ? {connexions.Any(c => c.EstSuspecte)}");


Console.WriteLine($"17) Port 23 ? {connexions.Any(c => c.Port == 23)}");


Console.WriteLine($"18) Toutes < 100s ? {connexions.All(c => c.Duree < 100)}");


Console.WriteLine($"19) TCP > 40s : {connexions.Count(c => c.Protocole == "TCP" && c.Duree > 40)}");

Console.WriteLine("23/24) Alertes :");
connexions
    .Where(c => c.Port == 22 || c.Duree > 60 || c.EstSuspecte)
    .ToList()
    .ForEach(c => Console.WriteLine(
        $"ALERTE IP : {c.AdresseIP} Pays : {c.Pays} Port : {c.Port} Durée : {c.Duree} s"));


// EXERCICE 2
Console.WriteLine("\nEXERCICE 2 ");
var magasin = new Magasin();

var frigo = new Electromenager { Nom = "Frigo", Fournisseur = "Samsung", PrixAchat = 800, PrixVente = 1200 };
frigo.RemplirStock(10);
magasin.AjouterElectromenager(frigo);

var tomate = new Primeur { Nom = "Tomate", Fournisseur = "FermeTun", PrixAchat = 1.0, PrixVente = 2.5 };
tomate.RemplirStock(100);
magasin.AjouterPrimeur(tomate);

magasin.VendreElectromenager(frigo, 2);
magasin.VendrePrimeur(tomate, 15.5);

magasin.Decrire();