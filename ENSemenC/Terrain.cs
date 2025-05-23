public abstract class Terrain
{
    private Random Rng = new Random();
    public string TypeTerrain { get; }
    public double[][] BaseTemperature;
    //Printemps = 1, Ete = 2, Automne = 3, Hiver = 4
    // Normal = 1, Soleil, Canicule, Nuageux, Pluie, Orage, Neige 
    public double Temperature { get; set; }
    public int[]? Position { get; set; }
    public double Humidite { get; set; }
    public double Retention { get; }
    private static double[] BaseLuminosite = { 0.7, 0.75, 0.90, 1, 0.5, 0.35, 0.2 };
    // La valeur default est en indice 0, les autres valeurs à ajouter se mettront à la fin de la liste et de l'énumération
    // public static int tempActuelle { get; set; }
    public double Luminosite { get; set; }
    public static Meteos Meteo { get; set; }
    public static Saisons Saison { get; set; }
    public Plante? plante { get; set; }

    public Terrain(string typeTerrain, double retention, double[][] baseTemperature)
    {
        TypeTerrain = typeTerrain;
        Retention = retention;
        BaseTemperature = baseTemperature;
        Position = new int[2];
        this.HumidificationSol(0.5); // Pour ne pas démarrer sec
        this.GererTemperature(); // Pour ne pas démarrer sans températures
        this.GererLumiere(); // Pour ne pas démarrer sans luminosité
    }

    public void HumidificationSol(double crue = 0) //donne le taux d'humidité du sol après la pluie et l'arrosage
    {
        Humidite = Math.Round(Math.Min(Humidite + crue, 1.0), 2);
        // Humidite += crue;
    }


    public void AdaptationSol() //calcule en fonction du type de terrain l'humidité qu'il reste (ex: si cailloux ou herbe)
    {
        Humidite -= (1 - Retention) * 0.01;
        // A ajuster selon si utilisation % ou valeurs chiffrées
    }

    public double GererLumiere()
    {
        // Change la lumière selon la météo pour toutes les instances
        switch (Meteo)
        {
            case Meteos.Normal:
                Luminosite = Math.Round(BaseLuminosite[1] + Math.Pow(-1, Rng.Next(0, 2)) * 0.01 * Rng.Next(0, 10), 2);
                break;

            case Meteos.Soleil:
                Luminosite = Math.Round(BaseLuminosite[2] + Math.Pow(-1, Rng.Next(0, 2)) * 0.01 * Rng.Next(0, 5), 2);
                break;

            case Meteos.Canicule:
                Luminosite = BaseLuminosite[3];
                break;

            case Meteos.Nuageux:
                Luminosite = Math.Round(BaseLuminosite[4] + Math.Pow(-1, Rng.Next(0, 2)) * 0.01 * Rng.Next(0, 20), 2);
                break;

            case Meteos.Pluie:
                Luminosite = Math.Round(BaseLuminosite[5] + Math.Pow(-1, Rng.Next(0, 2)) * 0.01 * Rng.Next(0, 10), 2);
                break;

            case Meteos.Orage:
                Luminosite = Math.Round(BaseLuminosite[6] + Math.Pow(-1, Rng.Next(0, 2)) * 0.01 * Rng.Next(0, 10), 2);
                break;

            case Meteos.Neige:
                Luminosite = Math.Round(BaseLuminosite[5] + Math.Pow(-1, Rng.Next(0, 2)) * 0.01 * Rng.Next(0, 20), 2);
                // Même valeur que Pluie
                break;

            default:
                Luminosite = BaseLuminosite[0];
                break;
        }
        return Luminosite;
    }

    virtual public void GererTemperature()
    {
        // Met à jour la température pour une instance du terrain
        switch (Saison)
        {
            case Saisons.Printemps:
                switch (Meteo)
                {
                    case Meteos.Normal:
                        Temperature = Math.Round(BaseTemperature[0][1] + Math.Pow(-1, Rng.Next(0, 2)) * 0.1 * Rng.Next(0, 10), 2);
                        break;

                    case Meteos.Soleil:
                        Temperature = Math.Round(BaseTemperature[0][2] + Math.Pow(-1, Rng.Next(0, 2)) * 0.1 * Rng.Next(0, 10), 2);
                        break;

                    case Meteos.Canicule:
                        Temperature = Math.Round(BaseTemperature[0][3] + Math.Pow(-1, Rng.Next(0, 2)) * 0.1 * Rng.Next(0, 5), 2);
                        break;

                    case Meteos.Nuageux:
                        Temperature = Math.Round(BaseTemperature[0][4] + Math.Pow(-1, Rng.Next(0, 2)) * 0.1 * Rng.Next(0, 20), 2);
                        break;

                    case Meteos.Pluie:
                        Temperature = Math.Round(BaseTemperature[0][5] + Math.Pow(-1, Rng.Next(0, 2)) * 0.1 * Rng.Next(0, 20), 2);
                        break;

                    case Meteos.Orage:
                        Temperature = Math.Round(BaseTemperature[0][6] + Math.Pow(-1, Rng.Next(0, 2)) * 0.1 * Rng.Next(0, 5), 2);
                        break;

                    case Meteos.Neige:
                        Temperature = Math.Round(BaseTemperature[0][5] + Math.Pow(-1, Rng.Next(0, 2)) * 0.1 * Rng.Next(0, 2), 2);
                        break;

                    default:
                        Temperature = BaseTemperature[0][0];
                        break;
                }
                break;
            case Saisons.Ete:
                switch (Meteo)
                {
                    case Meteos.Normal:
                        Temperature = Math.Round(BaseTemperature[1][1] + Math.Pow(-1, Rng.Next(0, 2)) * 0.1 * Rng.Next(0, 10), 2);
                        break;

                    case Meteos.Soleil:
                        Temperature = Math.Round(BaseTemperature[1][2] + Math.Pow(-1, Rng.Next(0, 2)) * 0.1 * Rng.Next(0, 5), 2);
                        break;

                    case Meteos.Canicule:
                        Temperature = Math.Round(BaseTemperature[1][3] + Math.Pow(-1, Rng.Next(0, 2)) * 0.1 * Rng.Next(0, 5), 2);
                        break;

                    case Meteos.Nuageux:
                        Temperature = Math.Round(BaseTemperature[1][4] + Math.Pow(-1, Rng.Next(0, 2)) * 0.1 * Rng.Next(0, 20), 2);
                        break;

                    case Meteos.Pluie:
                        Temperature = Math.Round(BaseTemperature[1][5] + Math.Pow(-1, Rng.Next(0, 2)) * 0.1 * Rng.Next(0, 25), 2);
                        break;

                    case Meteos.Orage:
                        Temperature = Math.Round(BaseTemperature[1][6] + Math.Pow(-1, Rng.Next(0, 2)) * 0.1 * Rng.Next(0, 10), 2);
                        break;

                    case Meteos.Neige:
                        Temperature = Math.Round(BaseTemperature[1][5] + Math.Pow(-1, Rng.Next(0, 2)) * 0.1 * Rng.Next(0, 1), 2);
                        break;

                    default:
                        Temperature = BaseTemperature[1][0];
                        break;
                }
                break;
            case Saisons.Automne:
                switch (Meteo)
                {
                    case Meteos.Normal:
                        Temperature = Math.Round(BaseTemperature[2][1] + Math.Pow(-1, Rng.Next(0, 2)) * 0.1 * Rng.Next(0, 10), 2);
                        break;

                    case Meteos.Soleil:
                        Temperature = Math.Round(BaseTemperature[2][2] + Math.Pow(-1, Rng.Next(0, 2)) * 0.1 * Rng.Next(0, 20), 2);
                        break;

                    case Meteos.Canicule:
                        Temperature = Math.Round(BaseTemperature[2][3] + Math.Pow(-1, Rng.Next(0, 2)) * 0.1 * Rng.Next(0, 5), 2);
                        break;

                    case Meteos.Nuageux:
                        Temperature = Math.Round(BaseTemperature[2][4] + Math.Pow(-1, Rng.Next(0, 2)) * 0.1 * Rng.Next(0, 20), 2);
                        break;

                    case Meteos.Pluie:
                        Temperature = Math.Round(BaseTemperature[2][5] + Math.Pow(-1, Rng.Next(0, 2)) * 0.1 * Rng.Next(0, 20), 2);
                        break;

                    case Meteos.Orage:
                        Temperature = Math.Round(BaseTemperature[2][6] + Math.Pow(-1, Rng.Next(0, 2)) * 0.1 * Rng.Next(0, 10), 2);
                        break;

                    case Meteos.Neige:
                        Temperature = Math.Round(BaseTemperature[2][5] + Math.Pow(-1, Rng.Next(0, 2)) * 0.1 * Rng.Next(0, 1), 2);
                        break;

                    default:
                        Temperature = BaseTemperature[2][0];
                        break;
                }
                break;
            case Saisons.Hiver:
                switch (Meteo)
                {
                    case Meteos.Normal:
                        Temperature = Math.Round(BaseTemperature[3][1] + Math.Pow(-1, Rng.Next(0, 2)) * 0.1 * Rng.Next(0, 10), 2);
                        break;

                    case Meteos.Soleil:
                        Temperature = Math.Round(BaseTemperature[3][2] + Math.Pow(-1, Rng.Next(0, 2)) * 0.1 * Rng.Next(0, 10), 2);
                        break;

                    case Meteos.Canicule:
                        Temperature = Math.Round(BaseTemperature[3][3] + Math.Pow(-1, Rng.Next(0, 2)) * 0.1 * Rng.Next(0, 1), 2);
                        break;

                    case Meteos.Nuageux:
                        Temperature = Math.Round(BaseTemperature[3][4] + Math.Pow(-1, Rng.Next(0, 2)) * 0.1 * Rng.Next(0, 20), 2);
                        break;

                    case Meteos.Pluie:
                        Temperature = Math.Round(BaseTemperature[3][5] + Math.Pow(-1, Rng.Next(0, 2)) * 0.1 * Rng.Next(0, 20), 2);
                        break;

                    case Meteos.Orage:
                        Temperature = Math.Round(BaseTemperature[3][6] + Math.Pow(-1, Rng.Next(0, 2)) * 0.1 * Rng.Next(0, 10), 2);
                        break;

                    case Meteos.Neige:
                        Temperature = Math.Round(BaseTemperature[3][5] + Math.Pow(-1, Rng.Next(0, 2)) * 0.1 * Rng.Next(0, 20), 2);
                        break;

                    default:
                        Temperature = BaseTemperature[3][0];
                        break;
                }
                break;
            default:
                Temperature = BaseTemperature[0][0];
                break;
        }


    }
    // A calculer selon la meteo, la saison et les bornes de temps avec des tables
    // Même température pour tous les terrains de même type --> abstract ici et redéfinition dans classes héritées ?

    abstract public void GetCouleur();
}