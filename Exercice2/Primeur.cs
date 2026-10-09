namespace Tp1.Exercice2;

public class Primeur : Article, IVendableKg
{
    public double QuantiteStock { get; private set; } = 0;

    public void RemplirStock(double qte) => QuantiteStock += qte;

    public double Vendre(double quantiteKg)
    {
        if (quantiteKg > QuantiteStock)
            throw new InvalidOperationException("Stock insuffisant");
        QuantiteStock -= quantiteKg;
        return quantiteKg * PrixVente;
    }

    public override void Decrire()
    {
        base.Decrire();
        Console.WriteLine($"   Stock: {QuantiteStock} kg");
    }
}