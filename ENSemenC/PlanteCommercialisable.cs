public abstract class PlanteCommercialisable : Plante
{
    public decimal prix { get; set; }

    public PlanteCommercialisable(string nom, Saison saisonPreferee, Terrain terrain, int espacement, int place, double besoinsEauMin, double besoinsEauMax, double besoinsLuminositeMin, double besoinsLuminositeMax, int vitesseDeCroissance, int esperanceDeVie, int croissanceMin, decimal prix, string nature = "Commercialisable") : base(nom, nature, saisonPreferee, terrain, espacement, place, besoinsEauMin, besoinsEauMax, besoinsLuminositeMin, besoinsLuminositeMax, vitesseDeCroissance, esperanceDeVie, croissanceMin)
    {
        this.prix = prix;
    }

    public override void Grandir()
    {
        decimal pourcentage = 0;
        if (saisonPreferee == Terrain.saison)
        {
            pourcentage += 40;
        }
        if (terrain.humidite > besoinsEau[0] && terrain.humidite < besoinsEau[1])
        {
            pourcentage += 10;
        }
        if (pourcentage < 50)
        {
            vivante = false;
        }
        throw new NotImplementedException();
    }
}