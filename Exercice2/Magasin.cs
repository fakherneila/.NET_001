namespace Tp1.Exercice2;

public class Magasin
{
    public double Depenses { get; private set; }
    public double Revenus { get; private set; }
    public List<Electromenager> Electromenagers { get; } = new();
    public List<Primeur> Primeurs { get; } = new();

    public void AjouterElectromenager(Electromenager e)
    {
        Electromenagers.Add(e);
        Depenses += e.PrixAchat;
    }

    public void AjouterPrimeur(Primeur p)
    {
        Primeurs.Add(p);
        Depenses += p.PrixAchat;
    }

    public void VendreElectromenager(Electromenager e, int quantite)
    {
        Revenus += e.Vendre(quantite);
    }

    public void VendrePrimeur(Primeur p, double quantiteKg)
    {
        Revenus += p.Vendre(quantiteKg);
    }

    public void Decrire()
    {
        Console.WriteLine(" État du magasin");
        Console.WriteLine($"Dépenses: {Depenses} | Revenus: {Revenus}");
        Console.WriteLine("-- Électroménager --");
        Electromenagers.ForEach(e => e.Decrire());
        Console.WriteLine("-- Primeurs --");
        Primeurs.ForEach(p => p.Decrire());
    }

    public double CalculerRendement()
        => (Revenus - Depenses) / Depenses * 100;
}