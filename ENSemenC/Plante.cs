public abstract class Plante
{
    public string nom { get; set; }
    public string nature { get; set; }
    public Saison saisonPreferee { get; set; }
    public Terrain terrain { get; set; }
    public int espacement { get; set; }
    public double[] besoinsEau { get; set; } //à mettre en pourcentage, faire liste avec valeur min et max
    public double[] besoinsLuminosite { get; set; } //pareil que eau
    public int vitesseDeCroissance { get; set; } //défini par la plante, ses conditions de vie influent dessus;
    //calcul stade de croissance à laquelle est la plante, elle //par exemple 1-2-3-4 (voir 5 quand les fruits reviennent)
    public int croissanceMin { get; set; } //stade de croissance minimale de la plante pour qu'elle produise
    public int croissance { get; set; } //stade de croissance minimale de la plante pour qu'elle produise
    public int esperanceDeVie { get; set; } //âge de la plante évolue comme la croissance, stade maximal
    public int age { get; set; } //qui augmente avec le temps qui passe
    public bool vivante { get; set; }

    public Plante(string nom, string nature, Saison saisonPreferee, Terrain terrain, int espacement, double besoinsEauMin, double besoinsEauMax, double besoinsLuminositeMin, double besoinsLuminositeMax, int vitesseDeCroissance, int esperanceDeVie, int croissanceMin)
    {
        this.nom = nom;
        this.nature = nature;
        this.saisonPreferee = saisonPreferee;
        this.terrain = terrain;
        this.espacement = espacement;
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
        // Calcul de la croissance de la plante selon un système de pourcentage 
        // Si la plante est au-dessus de 50% elle peut grandir, elle meurt sinon
        // La plante peut grandir entre 75% et 125% de sa vitesse de croissance moyenne 
        if (vivante)
        {
            decimal pourcentage = 0;
            if (saisonPreferee == Terrain.saison || saisonPreferee == Saison.Toutes)
            {
                // Console.WriteLine("Saison OK");
                pourcentage += 40;
            }

            if (terrain.humidite > besoinsEau[0] && terrain.humidite < besoinsEau[1])
            {
                // Console.WriteLine("Humidité OK");
                pourcentage += 20;
            }
            else if (terrain.humidite > besoinsEau[0] * 0.95 && terrain.humidite < besoinsEau[1] * 1.05)
            {
                // Console.WriteLine("Humidité presque OK");
                pourcentage += 15;
            }
            else if (terrain.humidite > besoinsEau[0] * 0.90 && terrain.humidite < besoinsEau[1] * 1.10)
            {
                // Console.WriteLine("Humidité moyen OK");
                pourcentage += 10;
            }
            else if (terrain.humidite > besoinsEau[0] * 0.85 && terrain.humidite < besoinsEau[1] * 1.15)
            {
                // Console.WriteLine("Humidité pas trop OK");
                pourcentage += 5;
            }

            if (terrain.luminosite > besoinsLuminosite[0] && terrain.luminosite < besoinsLuminosite[1])
            {
                // Console.WriteLine("Luminosité OK");
                pourcentage += 20;
            }
            else if (terrain.luminosite > besoinsLuminosite[0] * 0.95 && terrain.luminosite < besoinsLuminosite[1] * 1.05)
            {
                // Console.WriteLine("Luminosité presque OK");
                pourcentage += 15;
            }
            else if (terrain.luminosite > besoinsLuminosite[0] * 0.90 && terrain.luminosite < besoinsLuminosite[1] * 1.10)
            {
                // Console.WriteLine("Luminosité moyen OK");
                pourcentage += 10;
            }
            else if (terrain.luminosite > besoinsLuminosite[0] * 0.85 && terrain.luminosite < besoinsLuminosite[1] * 1.15)
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
                vivante = false;
            }
            else
            {
                // Console.Write($"MAJ Croissance : {croissance} --> ");
                croissance += Convert.ToInt32(vitesseDeCroissance * ((pourcentage + 25) / 100));
                age += 1;
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
        age += jours;
        if (age > esperanceDeVie)
        {
            vivante = false;
        }
    }

    public override string ToString()
    {
        return $"La {nom} est une plante de nature {nature}, sa saison préférée est {saisonPreferee}, ";
    }

    public virtual void AfficherPlateau()
    { }
    public abstract string AfficherPlateau2();
    public abstract void GetCouleur();
    public abstract void AsciiArt();
    public abstract void Informations();

}
