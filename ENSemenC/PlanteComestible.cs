public abstract class PlanteComestible : PlanteCommercialisable
{
    public bool aFruit { get; set; }
    public int tempsRecharge { get; set; }
    public int recharge { get; set; }
    public PlanteComestible(string nom, Saison saisonPreferee, Terrain terrain, int espacement, int place, double besoinsEauMin, double besoinsEauMax, double besoinsLuminositeMin, double besoinsLuminositeMax, int vitesseDeCroissance, int esperanceDeVie, int croissanceMin, decimal prix, int tempsRecharge, string nature = "comestible") : base(nom, saisonPreferee, terrain, espacement, place, besoinsEauMin, besoinsEauMax, besoinsLuminositeMin, besoinsLuminositeMax, vitesseDeCroissance, esperanceDeVie, croissanceMin, prix, nature)
    {
        aFruit = false;
        this.tempsRecharge = tempsRecharge;
        recharge = tempsRecharge;
    }

    public void ProduireFruit()
    {
        if (croissance >= croissanceMin)
        {
            if (recharge == 0)
            {
                aFruit = true;
            }
            else
            {
                recharge--;
            }
        }
    }

    public void Cueillir()
    {
        aFruit = false;
        recharge = tempsRecharge;
    }

    public override void Grandir(int nbVoisins)
    {
        base.Grandir(nbVoisins);
        if (!aFruit)
        {
            ProduireFruit();
        }
        // appel fonction pour fruits
    }
}