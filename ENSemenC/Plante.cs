public abstract class Plante
{
    public string Nom { get; set; }
    public string Nature { get; set; }
    public Saisons SaisonPreferee { get; set; }
    public Terrain terrain { get; set; }
    public int Espacement { get; set; }
    public double[] BesoinsEau { get; set; } //à mettre en pourcentage, faire liste avec valeur min et max
    public double[] BesoinsLuminosite { get; set; } //pareil que eau
    public int VitesseDeCroissance { get; set; } //défini par la plante, ses conditions de vie influent dessus;
    //calcul stade de croissance à laquelle est la plante, elle //par exemple 1-2-3-4 (voir 5 quand les fruits reviennent)
    public int CroissanceMin { get; set; } //stade de croissance minimale de la plante pour qu'elle produise
    public int Croissance { get; set; } //stade de croissance minimale de la plante pour qu'elle produise
    public int EsperanceDeVie { get; set; } //âge de la plante évolue comme la croissance, stade maximal
    public int Age { get; set; } //qui augmente avec le temps qui passe
    public bool Vivante { get; set; }

    public Plante(string nom, string nature, Saisons saisonPreferee, Terrain terrain, int espacement, double besoinsEauMin, double besoinsEauMax, double besoinsLuminositeMin, double besoinsLuminositeMax, int vitesseDeCroissance, int esperanceDeVie, int croissanceMin)
    {
        Nom = nom;
        Nature = nature;
        SaisonPreferee = saisonPreferee;
        this.terrain = terrain;
        Espacement = espacement;
        BesoinsEau = new double[] { besoinsEauMin, besoinsEauMax };
        BesoinsLuminosite = new double[] { besoinsLuminositeMin, besoinsLuminositeMax };
        VitesseDeCroissance = vitesseDeCroissance;
        Croissance = 0;
        CroissanceMin = croissanceMin;
        EsperanceDeVie = esperanceDeVie;
        Age = 0;
        Vivante = true;
    }

    public virtual void Grandir(int nbVoisins)
    {
        // Calcul de la croissance de la plante selon un système de pourcentage 
        // Si la plante est au-dessus de 50% elle peut grandir, elle meurt sinon
        // La plante peut grandir entre 75% et 125% de sa vitesse de croissance moyenne 
        if (Vivante)
        {
            decimal pourcentage = 0;
            if (SaisonPreferee == Terrain.Saison || SaisonPreferee == Saisons.Toutes)
            {
                // Console.WriteLine("Saison OK");
                pourcentage += 40;
            }

            if (terrain.Humidite > BesoinsEau[0] && terrain.Humidite < BesoinsEau[1])
            {
                // Console.WriteLine("Humidité OK");
                pourcentage += 20;
            }
            else if (terrain.Humidite > BesoinsEau[0] * 0.95 && terrain.Humidite < BesoinsEau[1] * 1.05)
            {
                // Console.WriteLine("Humidité presque OK");
                pourcentage += 15;
            }
            else if (terrain.Humidite > BesoinsEau[0] * 0.90 && terrain.Humidite < BesoinsEau[1] * 1.10)
            {
                // Console.WriteLine("Humidité moyen OK");
                pourcentage += 10;
            }
            else if (terrain.Humidite > BesoinsEau[0] * 0.85 && terrain.Humidite < BesoinsEau[1] * 1.15)
            {
                // Console.WriteLine("Humidité pas trop OK");
                pourcentage += 5;
            }

            if (terrain.Luminosite > BesoinsLuminosite[0] && terrain.Luminosite < BesoinsLuminosite[1])
            {
                // Console.WriteLine("Luminosité OK");
                pourcentage += 20;
            }
            else if (terrain.Luminosite > BesoinsLuminosite[0] * 0.95 && terrain.Luminosite < BesoinsLuminosite[1] * 1.05)
            {
                // Console.WriteLine("Luminosité presque OK");
                pourcentage += 15;
            }
            else if (terrain.Luminosite > BesoinsLuminosite[0] * 0.90 && terrain.Luminosite < BesoinsLuminosite[1] * 1.10)
            {
                // Console.WriteLine("Luminosité moyen OK");
                pourcentage += 10;
            }
            else if (terrain.Luminosite > BesoinsLuminosite[0] * 0.85 && terrain.Luminosite < BesoinsLuminosite[1] * 1.15)
            {
                // Console.WriteLine("Luminosité pas trop OK");
                pourcentage += 5;
            }

            // Pourcentage dégressif selon le nb de voisins
            // Console.WriteLine($"Pourcentage voisins : {Math.Round(1 / Convert.ToDecimal(nbVoisins + 1), 2) * 20m}");
            pourcentage += Math.Round(1 / Convert.ToDecimal(nbVoisins + 1), 2) * 20m;

            if (pourcentage < 50)
            {
                // Console.WriteLine("Rip");
                Vivante = false;
            }
            else
            {
                // Console.Write($"MAJ Croissance : {croissance} --> ");
                Croissance += Convert.ToInt32(VitesseDeCroissance * ((pourcentage + 25) / 100));
                Age += 1;
                // Console.WriteLine($"{croissance}");
            }
        }
        else
        {
            Console.WriteLine($"La plante est morte (RIP)");
        }
    }

    public void Vieillir(int jours = 1)
    {
        Age += jours;
        if (Age > EsperanceDeVie)
        {
            Vivante = false;
        }
    }

    public override string ToString()
    {
        return $"La {Nom} est une plante de nature {Nature}, sa saison préférée est {SaisonPreferee}, ";
    }

    public virtual void AfficherPlateau()
    { }
    public abstract string AfficherPlateau2();
    public abstract void GetCouleur();
    public abstract void AsciiArt();
    public abstract void Informations();

}
