public abstract class PlanteComestible : PlanteCommercialisable
{
    public PlanteComestible(string nom, Saison saisonPreferee, Terrain terrain, int espacement, int place, double besoinsEauMin, double besoinsEauMax, double besoinsLuminositeMin, double besoinsLuminositeMax, int vitesseDeCroissance, int esperanceDeVie, int croissanceMin, decimal prix, string nature = "Comestible") : base(nom, saisonPreferee, terrain, espacement, place, besoinsEauMin, besoinsEauMax, besoinsLuminositeMin, besoinsLuminositeMax, vitesseDeCroissance, esperanceDeVie, croissanceMin, prix, nature)
    { }
}