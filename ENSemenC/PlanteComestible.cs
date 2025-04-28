public abstract class PlanteComestible : PlanteCommercialisable
{
    public bool aFruit { get; set; }
    public PlanteComestible(string nom, Saison saisonPreferee, Terrain terrain, int espacement, int place, double besoinsEauMin, double besoinsEauMax, double besoinsLuminositeMin, double besoinsLuminositeMax, int vitesseDeCroissance, int esperanceDeVie, int croissanceMin, decimal prix, string nature = "Comestible") : base(nom, saisonPreferee, terrain, espacement, place, besoinsEauMin, besoinsEauMax, besoinsLuminositeMin, besoinsLuminositeMax, vitesseDeCroissance, esperanceDeVie, croissanceMin, prix, nature)
    {
        aFruit = false;
    }

    public override void Grandir(int nbVoisins)
    {
        base.Grandir(nbVoisins);
        // appel fonction pour fruits
    }
}