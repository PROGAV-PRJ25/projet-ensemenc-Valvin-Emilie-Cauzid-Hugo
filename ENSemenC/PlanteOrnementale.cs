public abstract class PlanteOrnementale : PlanteCommercialisable
{
    public PlanteOrnementale(string nom, Saisons saisonPreferee, Terrain terrain, int espacement, double besoinsEauMin, double besoinsEauMax, double besoinsLuminositeMin, double besoinsLuminositeMax, int vitesseDeCroissance, int esperanceDeVie, int croissanceMin, string nature = "ornementale") : base(nom, saisonPreferee, terrain, espacement, besoinsEauMin, besoinsEauMax, besoinsLuminositeMin, besoinsLuminositeMax, vitesseDeCroissance, esperanceDeVie, croissanceMin, nature)
    { }
}