public abstract class Plante
{
    public string nom { get; set; }
    public string nature { get; set; }
    public Saison saisonPreferee { get; set; }
    public Terrain terrain { get; set; }
    public int espacement { get; set; }
    public int place { get; set; } //dont elle a besoin pour grandir, faire un tableau pour voir combien en longueur et en largeur elle occupe de place
    public double[] besoinsEau { get; set; } //à mettre en pourcentage, faire liste avec valeur min et max
    public double[] besoinsLuminosite { get; set; } //pareil que eau
    public int vitesseDeCroissance { get; set; } //défini par la plante, ses conditions de vie influent dessus;
    //calcul stade de croissance à laquelle est la plante, elle //par exemple 1-2-3-4 (voir 5 quand les fruits reviennent)
    public int croissanceMin { get; set; } //stade de croissance minimale de la plante pour qu'elle produise
    public int croissance { get; set; } //stade de croissance minimale de la plante pour qu'elle produise
    public int esperanceDeVie { get; set; } //âge de la plante évolue comme la croissance, stade maximal
    public int age { get; set; } //qui augmente avec le temps qui passe
    public bool vivante { get; set; }
    public Plante(string nom, string nature, Saison saisonPreferee, Terrain terrain, int espacement, int place, double besoinsEauMin, double besoinsEauMax, double besoinsLuminositeMin, double besoinsLuminositeMax, int vitesseDeCroissance, int esperanceDeVie, int croissanceMin)
    {
        this.nom = nom;
        this.nature = nature;
        this.saisonPreferee = saisonPreferee;
        this.terrain = terrain;
        this.espacement = espacement;
        this.place = place;
        this.besoinsEau = new double[] { besoinsEauMin, besoinsEauMax };
        this.besoinsLuminosite = new double[] { besoinsLuminositeMin, besoinsLuminositeMax };
        this.vitesseDeCroissance = vitesseDeCroissance;
        croissance = 0;
        this.croissanceMin = croissanceMin;
        this.esperanceDeVie = esperanceDeVie;
        age = 0;
        vivante = true;
    }

    public virtual void Grandir(int nbVoisins)
    {
        // Possibilité de mettre la fonction dans Plante
        // Prendre pourcentage ajoutés en paramètres ?
        // + multiplieur max (si pourcentage == 100)
        Console.Write($"MAJ Croissance : {croissance} --> ");
        decimal pourcentage = 0;
        if (saisonPreferee == Terrain.saison || saisonPreferee == Saison.Toutes)
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
        /* créer méthode PossedeVoisins qui renvoie le nb de cases occupées dans le carré (diagonales inclues) de centre terrain 
        // switch case pour gérer le nb de pourcentage en + selon le nb de voisins ? 
        // problème ==> différencier tous les cas possibles selon le nb d'espacement
        // Sinon pourcentage augmente proportionnelemnt inverse au nb de voisins
        // ex : pourcentage += (1 / (nbVoisins + 1)) * 20 
        // problème ==> les plantes ayant besoin de bcp d'espace ont plus de chances de moins grandir */

        pourcentage += Math.Round(1 / Convert.ToDecimal(nbVoisins + 1), 2) * 20m;

        if (pourcentage < 50)
        {
            vivante = false;
        }
        else
        {
            croissance += Convert.ToInt32(vitesseDeCroissance * ((pourcentage + 25) / 100));
            age += 1;
        }
        // throw new NotImplementedException();
        Console.WriteLine($"{croissance}");
    }

    public void Vieillir(int annee = 1)
    {
        age += annee;
    }

    public override string ToString()
    {
        return $"La {nom} est une plante de nature {nature}, sa saison préférée est {saisonPreferee}, ";
    }


}
