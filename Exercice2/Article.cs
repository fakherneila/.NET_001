namespace Tp1.Exercice2;

public abstract class Article : IDescriptible, IRendement
{
    public double PrixAchat { get; set; }
    public double PrixVente { get; set; }
    public string Nom { get; set; } = "";
    public string Fournisseur { get; set; } = "";

    public virtual double CalculerRendement()
        => (PrixVente - PrixAchat) / PrixAchat * 100;

    public virtual void Decrire()
    {
        Console.WriteLine($"Nom: {Nom} | Fournisseur: {Fournisseur} | " +
                          $"Prix achat: {PrixAchat} | Prix vente: {PrixVente} | " +
                          $"Rendement: {CalculerRendement():F2}%");
    }
}