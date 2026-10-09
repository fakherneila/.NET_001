namespace Tp1.Exercice1;

public class Connexion
{
    public int Id { get; set; }
    public string AdresseIP { get; set; } = "";
    public string Protocole { get; set; } = "";
    public int Port { get; set; }
    public string Pays { get; set; } = "";
    public double Duree { get; set; }
    public bool EstSuspecte { get; set; }
}