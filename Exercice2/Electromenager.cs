namespace Tp1.Exercice2;

public class Electromenager : Article, IVendablePiece, ISolde
{
    public int NombrePieces { get; private set; } = 0;

    public void RemplirStock(int qte) => NombrePieces += qte;

    public double Vendre(int quantite)
    {
        if (quantite > NombrePieces)
            throw new InvalidOperationException("Stock insuffisant");
        NombrePieces -= quantite;
        return quantite * PrixVente;
    }

    public void LancerSolde(double pourcentage)
        => PrixVente -= PrixVente * pourcentage / 100;

    public void TerminerSolde(double pourcentage)
        => PrixVente += PrixVente * pourcentage / 100;

    public override void Decrire()
    {
        base.Decrire();
        Console.WriteLine($"   Stock: {NombrePieces} pièces");
    }
}