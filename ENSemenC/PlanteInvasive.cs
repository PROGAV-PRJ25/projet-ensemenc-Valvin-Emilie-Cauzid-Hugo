public abstract class PlanteInvasive : Plante
{
    public PlanteInvasive(string nom, Saison saisonPreferee, Terrain terrain, double besoinsEauMin, double besoinsEauMax, double besoinsLuminositeMin, double besoinsLuminositeMax, int vitesseDeCroissance, int esperanceDeVie, int croissanceMin) : base(nom, "invasive", saisonPreferee, terrain, 0, besoinsEauMin, besoinsEauMax, besoinsLuminositeMin, besoinsLuminositeMax, vitesseDeCroissance, esperanceDeVie, croissanceMin)
    { }
}