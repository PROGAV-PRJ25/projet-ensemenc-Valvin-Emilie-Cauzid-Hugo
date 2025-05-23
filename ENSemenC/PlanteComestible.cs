public abstract class PlanteComestible : PlanteCommercialisable
{
    public bool AFruit { get; set; }
    public int TempsRecharge { get; set; }
    public int Recharge { get; set; }
    public PlanteComestible(string nom, Saisons saisonPreferee, Terrain terrain, int espacement, double besoinsEauMin, double besoinsEauMax, double besoinsLuminositeMin, double besoinsLuminositeMax, int vitesseDeCroissance, int esperanceDeVie, int croissanceMin, int tempsRecharge, string nature = "comestible") : base(nom, saisonPreferee, terrain, espacement, besoinsEauMin, besoinsEauMax, besoinsLuminositeMin, besoinsLuminositeMax, vitesseDeCroissance, esperanceDeVie, croissanceMin, nature)
    {
        AFruit = false;
        TempsRecharge = tempsRecharge;
        Recharge = tempsRecharge;
    }

    public void ProduireFruit()
    {
        if (Croissance >= CroissanceMin)
        {
            if (Recharge == 0)
            {
                AFruit = true;
            }
            else
            {
                Recharge--;
            }
        }
    }

    public void Cueillir()
    {
        AFruit = false;
        Recharge = TempsRecharge;
    }

    public override void Grandir(int nbVoisins)
    {
        base.Grandir(nbVoisins);
        if (!AFruit)
        {
            ProduireFruit();
        }
        // appel fonction pour fruits
    }
}