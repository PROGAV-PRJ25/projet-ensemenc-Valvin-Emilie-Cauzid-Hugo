public abstract class PlanteCommercialisable : Plante
{
    public PlanteCommercialisable(string nom, Saison saisonPreferee, Terrain terrain, int espacement, double besoinsEauMin, double besoinsEauMax, double besoinsLuminositeMin, double besoinsLuminositeMax, int vitesseDeCroissance, int esperanceDeVie, int croissanceMin, string nature = "commercialisable") : base(nom, nature, saisonPreferee, terrain, espacement, besoinsEauMin, besoinsEauMax, besoinsLuminositeMin, besoinsLuminositeMax, vitesseDeCroissance, esperanceDeVie, croissanceMin)
    {
    }
}