public abstract class PlanteCommercialisable : Plante
{
    public decimal prix { get; set; }

    public PlanteCommercialisable(string nom, Saison saisonPreferee, Terrain terrain, int espacement, int place, double besoinsEauMin, double besoinsEauMax, double besoinsLuminositeMin, double besoinsLuminositeMax, int vitesseDeCroissance, int esperanceDeVie, int croissanceMin, decimal prix, string nature = "Commercialisable") : base(nom, nature, saisonPreferee, terrain, espacement, place, besoinsEauMin, besoinsEauMax, besoinsLuminositeMin, besoinsLuminositeMax, vitesseDeCroissance, esperanceDeVie, croissanceMin)
    {
        this.prix = prix;
    }

    public override void Grandir(int nbVoisins)
    {
        // Possibilité de mettre la fonction dans Plante
        // Prendre pourcentage ajoutés en paramètres ?
        // + multiplieur max (si pourcentage == 100)
        Console.Write($"MAJ Croissance : {croissance} --> ");
        decimal pourcentage = 0;
        if (saisonPreferee == Terrain.saison)
        {
            pourcentage += 40;
        }
        if (terrain.humidite > besoinsEau[0] && terrain.humidite < besoinsEau[1])
        {
            pourcentage += 20;
        }
        else if (terrain.humidite > besoinsEau[0] * 0.95 && terrain.humidite < besoinsEau[1] * 1.05)
        {
            pourcentage += 15;
        }
        else if (terrain.humidite > besoinsEau[0] * 0.90 && terrain.humidite < besoinsEau[1] * 1.10)
        {
            pourcentage += 10;
        }
        else if (terrain.humidite > besoinsEau[0] * 0.85 && terrain.humidite < besoinsEau[1] * 1.15)
        {
            pourcentage += 5;
        }
        if (Terrain.luminosite > besoinsLuminosite[0] && Terrain.luminosite < besoinsLuminosite[1])
        {
            pourcentage += 20;
        }
        else if (Terrain.luminosite > besoinsLuminosite[0] * 0.95 && Terrain.luminosite < besoinsLuminosite[1] * 1.05)
        {
            pourcentage += 15;
        }
        else if (Terrain.luminosite > besoinsLuminosite[0] * 0.90 && Terrain.luminosite < besoinsLuminosite[1] * 1.10)
        {
            pourcentage += 10;
        }
        else if (Terrain.luminosite > besoinsLuminosite[0] * 0.85 && Terrain.luminosite < besoinsLuminosite[1] * 1.15)
        {
            pourcentage += 5;
        }
        // créer méthode PossedeVoisins qui renvoie le nb de cases occupées dans le carré (diagonales inclues) de centre terrain 
        // switch case pour gérer le nb de pourcentage en + selon le nb de voisins ? 
        // problème ==> différencier tous les cas possibles selon le nb d'espacement
        // Sinon pourcentage augmente proportionnelemnt inverse au nb de voisins
        // ex : pourcentage += (1 / (nbVoisins + 1)) * 20 
        // problème ==> les plantes ayant besoin de bcp d'espace ont plus de chances de moins grandir 
        pourcentage += Math.Round(1 / Convert.ToDecimal(nbVoisins + 1), 2) * 20m;

        if (pourcentage < 50)
        {
            vivante = false;
        }
        else
        {
            croissance += Convert.ToInt32(vitesseDeCroissance * ((pourcentage + 25) / 100));
        }
        // throw new NotImplementedException();
        Console.WriteLine($"{croissance}");
    }
}