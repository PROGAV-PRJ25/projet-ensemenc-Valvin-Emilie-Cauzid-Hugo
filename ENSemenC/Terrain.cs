public abstract class Terrain
{
    private Random rng = new Random();
    public string typeTerrain { get; }
    public double[][] baseTemperature;
    //Printemps = 1, Ete = 2, Automne = 3, Hiver = 4
    // Normal = 1, Soleil, Canicule, Nuageux, Pluie, Orage, Neige 
    public double temperature { get; set; }
    public int[]? position { get; set; }
    public double humidite { get; set; }
    public double retention { get; }
    private static double[] baseLuminosite = { 0.7, 0.75, 0.90, 1, 0.5, 0.35, 0.2 };
    // La valeur default est en indice 0, les autres valeurs à ajouter se mettront à la fin de la liste et de l'énumération
    // public static int tempActuelle { get; set; }
    public double luminosite { get; set; }
    public static Meteo meteo { get; set; }
    public static Saison saison { get; set; }
    public Plante? plante { get; set; }

    public Terrain(string typeTerrain, double retention, double[][] baseTemperature)
    {
        this.typeTerrain = typeTerrain;
        this.retention = retention;
        this.baseTemperature = baseTemperature;
        this.position = new int[2];
        this.HumidificationSol(0.5); // Pour ne pas démarrer sec
        this.GererTemperature(); // Pour ne pas démarrer sans températures
        this.GererLumiere(); // Pour ne pas démarrer sans luminosité
    }

    public void HumidificationSol(double crue = 0) //donne le taux d'humidité du sol après la pluie et l'arrosage
    {
        humidite = Math.Round(Math.Min(humidite + crue, 1.0), 2);
        // humidite += crue;
    }


    public void AdaptationSol() //calcule en fonction du type de terrain l'humidité qu'il reste (ex: si cailloux ou herbe)
    {
        humidite -= (1 - retention) * 0.01;
        // A ajuster selon si utilisation % ou valeurs chiffrées
    }

    public double GererLumiere()
    {
        // Change la lumière selon la météo pour toutes les instances
        switch (meteo)
        {
            case Meteo.Normal:
                luminosite = Math.Round(baseLuminosite[1] + Math.Pow(-1, rng.Next(0, 2)) * 0.01 * rng.Next(0, 10), 2);
                break;

            case Meteo.Soleil:
                luminosite = Math.Round(baseLuminosite[2] + Math.Pow(-1, rng.Next(0, 2)) * 0.01 * rng.Next(0, 5), 2);
                break;

            case Meteo.Canicule:
                luminosite = baseLuminosite[3];
                break;

            case Meteo.Nuageux:
                luminosite = Math.Round(baseLuminosite[4] + Math.Pow(-1, rng.Next(0, 2)) * 0.01 * rng.Next(0, 20), 2);
                break;

            case Meteo.Pluie:
                luminosite = Math.Round(baseLuminosite[5] + Math.Pow(-1, rng.Next(0, 2)) * 0.01 * rng.Next(0, 10), 2);
                break;

            case Meteo.Orage:
                luminosite = Math.Round(baseLuminosite[6] + Math.Pow(-1, rng.Next(0, 2)) * 0.01 * rng.Next(0, 10), 2);
                break;

            case Meteo.Neige:
                luminosite = Math.Round(baseLuminosite[5] + Math.Pow(-1, rng.Next(0, 2)) * 0.01 * rng.Next(0, 20), 2);
                // Même valeur que Pluie
                break;

            default:
                luminosite = baseLuminosite[0];
                break;
        }
        return luminosite;
    }

    virtual public void GererTemperature()
    {
        // Met à jour la température pour une instance du terrain
        switch (saison)
        {
            case Saison.Printemps:
                switch (meteo)
                {
                    case Meteo.Normal:
                        temperature = Math.Round(baseTemperature[0][1] + Math.Pow(-1, rng.Next(0, 2)) * 0.1 * rng.Next(0, 10), 2);
                        break;

                    case Meteo.Soleil:
                        temperature = Math.Round(baseTemperature[0][2] + Math.Pow(-1, rng.Next(0, 2)) * 0.1 * rng.Next(0, 10), 2);
                        break;

                    case Meteo.Canicule:
                        temperature = Math.Round(baseTemperature[0][3] + Math.Pow(-1, rng.Next(0, 2)) * 0.1 * rng.Next(0, 5), 2);
                        break;

                    case Meteo.Nuageux:
                        temperature = Math.Round(baseTemperature[0][4] + Math.Pow(-1, rng.Next(0, 2)) * 0.1 * rng.Next(0, 20), 2);
                        break;

                    case Meteo.Pluie:
                        temperature = Math.Round(baseTemperature[0][5] + Math.Pow(-1, rng.Next(0, 2)) * 0.1 * rng.Next(0, 20), 2);
                        break;

                    case Meteo.Orage:
                        temperature = Math.Round(baseTemperature[0][6] + Math.Pow(-1, rng.Next(0, 2)) * 0.1 * rng.Next(0, 5), 2);
                        break;

                    case Meteo.Neige:
                        temperature = Math.Round(baseTemperature[0][5] + Math.Pow(-1, rng.Next(0, 2)) * 0.1 * rng.Next(0, 2), 2);
                        break;

                    default:
                        temperature = baseTemperature[0][0];
                        break;
                }
                break;
            case Saison.Ete:
                switch (meteo)
                {
                    case Meteo.Normal:
                        temperature = Math.Round(baseTemperature[1][1] + Math.Pow(-1, rng.Next(0, 2)) * 0.1 * rng.Next(0, 10), 2);
                        break;

                    case Meteo.Soleil:
                        temperature = Math.Round(baseTemperature[1][2] + Math.Pow(-1, rng.Next(0, 2)) * 0.1 * rng.Next(0, 5), 2);
                        break;

                    case Meteo.Canicule:
                        temperature = Math.Round(baseTemperature[1][3] + Math.Pow(-1, rng.Next(0, 2)) * 0.1 * rng.Next(0, 5), 2);
                        break;

                    case Meteo.Nuageux:
                        temperature = Math.Round(baseTemperature[1][4] + Math.Pow(-1, rng.Next(0, 2)) * 0.1 * rng.Next(0, 20), 2);
                        break;

                    case Meteo.Pluie:
                        temperature = Math.Round(baseTemperature[1][5] + Math.Pow(-1, rng.Next(0, 2)) * 0.1 * rng.Next(0, 25), 2);
                        break;

                    case Meteo.Orage:
                        temperature = Math.Round(baseTemperature[1][6] + Math.Pow(-1, rng.Next(0, 2)) * 0.1 * rng.Next(0, 10), 2);
                        break;

                    case Meteo.Neige:
                        temperature = Math.Round(baseTemperature[1][5] + Math.Pow(-1, rng.Next(0, 2)) * 0.1 * rng.Next(0, 1), 2);
                        break;

                    default:
                        temperature = baseTemperature[1][0];
                        break;
                }
                break;
            case Saison.Automne:
                switch (meteo)
                {
                    case Meteo.Normal:
                        temperature = Math.Round(baseTemperature[2][1] + Math.Pow(-1, rng.Next(0, 2)) * 0.1 * rng.Next(0, 10), 2);
                        break;

                    case Meteo.Soleil:
                        temperature = Math.Round(baseTemperature[2][2] + Math.Pow(-1, rng.Next(0, 2)) * 0.1 * rng.Next(0, 20), 2);
                        break;

                    case Meteo.Canicule:
                        temperature = Math.Round(baseTemperature[2][3] + Math.Pow(-1, rng.Next(0, 2)) * 0.1 * rng.Next(0, 5), 2);
                        break;

                    case Meteo.Nuageux:
                        temperature = Math.Round(baseTemperature[2][4] + Math.Pow(-1, rng.Next(0, 2)) * 0.1 * rng.Next(0, 20), 2);
                        break;

                    case Meteo.Pluie:
                        temperature = Math.Round(baseTemperature[2][5] + Math.Pow(-1, rng.Next(0, 2)) * 0.1 * rng.Next(0, 20), 2);
                        break;

                    case Meteo.Orage:
                        temperature = Math.Round(baseTemperature[2][6] + Math.Pow(-1, rng.Next(0, 2)) * 0.1 * rng.Next(0, 10), 2);
                        break;

                    case Meteo.Neige:
                        temperature = Math.Round(baseTemperature[2][5] + Math.Pow(-1, rng.Next(0, 2)) * 0.1 * rng.Next(0, 1), 2);
                        break;

                    default:
                        temperature = baseTemperature[2][0];
                        break;
                }
                break;
            case Saison.Hiver:
                switch (meteo)
                {
                    case Meteo.Normal:
                        temperature = Math.Round(baseTemperature[3][1] + Math.Pow(-1, rng.Next(0, 2)) * 0.1 * rng.Next(0, 10), 2);
                        break;

                    case Meteo.Soleil:
                        temperature = Math.Round(baseTemperature[3][2] + Math.Pow(-1, rng.Next(0, 2)) * 0.1 * rng.Next(0, 10), 2);
                        break;

                    case Meteo.Canicule:
                        temperature = Math.Round(baseTemperature[3][3] + Math.Pow(-1, rng.Next(0, 2)) * 0.1 * rng.Next(0, 1), 2);
                        break;

                    case Meteo.Nuageux:
                        temperature = Math.Round(baseTemperature[3][4] + Math.Pow(-1, rng.Next(0, 2)) * 0.1 * rng.Next(0, 20), 2);
                        break;

                    case Meteo.Pluie:
                        temperature = Math.Round(baseTemperature[3][5] + Math.Pow(-1, rng.Next(0, 2)) * 0.1 * rng.Next(0, 20), 2);
                        break;

                    case Meteo.Orage:
                        temperature = Math.Round(baseTemperature[3][6] + Math.Pow(-1, rng.Next(0, 2)) * 0.1 * rng.Next(0, 10), 2);
                        break;

                    case Meteo.Neige:
                        temperature = Math.Round(baseTemperature[3][5] + Math.Pow(-1, rng.Next(0, 2)) * 0.1 * rng.Next(0, 20), 2);
                        break;

                    default:
                        temperature = baseTemperature[3][0];
                        break;
                }
                break;
            default:
                temperature = baseTemperature[0][0];
                break;
        }


    }
    // A calculer selon la meteo, la saison et les bornes de temps avec des tables
    // Même température pour tous les terrains de même type --> abstract ici et redéfinition dans classes héritées ?

    abstract public void GetCouleur();
}