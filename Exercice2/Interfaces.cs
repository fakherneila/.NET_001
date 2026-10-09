namespace Tp1.Exercice2;

public interface IVendableKg
{
    double Vendre(double quantiteKg);
}

public interface IVendablePiece
{
    double Vendre(int quantite);
}

public interface ISolde
{
    void LancerSolde(double pourcentage);
    void TerminerSolde(double pourcentage);
}

public interface IDescriptible
{
    void Decrire();
}

public interface IRendement
{
    double CalculerRendement();
}