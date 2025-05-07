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
    public static double luminosite { get; set; }
    public static Meteo meteo { get; set; }
    public static Saison saison { get; set; }
    public Plante? plante { get; set; }

    public Terrain(string typeTerrain, double retention, double[][] baseTemperature)
    {
        this.typeTerrain = typeTerrain;
        this.retention = retention;
        this.baseTemperature = baseTemperature;
        this.position = new int[2];
    }

    public void HumidificationSol(double crue = 0) //donne le taux d'humidité du sol après la pluie et l'arrosage
    {
        humidite += crue;
    }


    public void AdaptationSol() //calcule en fonction du type de terrain l'humidité qu'il reste (ex: si cailloux ou herbe)
    {
        humidite -= (1 - retention) * 0.01;
        // A ajuster selon si utilisation % ou valeurs chiffrées
    }

    public void GererLumiere()
    {

        switch (meteo)
        {
            case Meteo.Normal:
                luminosite = baseLuminosite[1] + Math.Pow(-1, rng.Next(0, 2)) * 0.01 * rng.Next(0, 10);
                // A ajuster selon si utilisation % ou valeurs chiffrées
                break;

            case Meteo.Soleil:
                luminosite = baseLuminosite[2] + Math.Pow(-1, rng.Next(0, 2)) * 0.01 * rng.Next(0, 5);
                // A ajuster selon si utilisation % ou valeurs chiffrées
                break;

            case Meteo.Canicule:
                luminosite = baseLuminosite[3];
                // A ajuster selon si utilisation % ou valeurs chiffrées
                break;

            case Meteo.Nuageux:
                luminosite = baseLuminosite[4] + Math.Pow(-1, rng.Next(0, 2)) * 0.01 * rng.Next(0, 20);
                // A ajuster selon si utilisation % ou valeurs chiffrées
                break;

            case Meteo.Pluie:
                luminosite = baseLuminosite[5] + Math.Pow(-1, rng.Next(0, 2)) * 0.01 * rng.Next(0, 10);
                // A ajuster selon si utilisation % ou valeurs chiffrées
                break;

            case Meteo.Orage:
                luminosite = baseLuminosite[6] + Math.Pow(-1, rng.Next(0, 2)) * 0.01 * rng.Next(0, 10);
                // A ajuster selon si utilisation % ou valeurs chiffrées
                break;

            case Meteo.Neige:
                luminosite = baseLuminosite[5] + Math.Pow(-1, rng.Next(0, 2)) * 0.01 * rng.Next(0, 20);
                // Même valeur que Pluie
                // A ajuster selon si utilisation % ou valeurs chiffrées
                break;

            default:
                luminosite = baseLuminosite[0];
                break;
        }
        // A calculer selon la meteo avec des tables
    }

    //abstract ; je sais pas si je dois le mettre parce que ça fait des problèmes avec et sans
    virtual public void GererTemperature()
    {
        switch (saison)
        {
            case Saison.Printemps:
                switch (meteo)
                {
                    case Meteo.Normal:
                        temperature = baseTemperature[0][1] + Math.Pow(-1, rng.Next(0, 2)) * 0.1 * rng.Next(0, 10);
                        break;

                    case Meteo.Soleil:
                        temperature = baseTemperature[0][2] + Math.Pow(-1, rng.Next(0, 2)) * 0.1 * rng.Next(0, 10);
                        break;

                    case Meteo.Canicule:
                        temperature = baseTemperature[0][3] + Math.Pow(-1, rng.Next(0, 2)) * 0.1 * rng.Next(0, 5);
                        break;

                    case Meteo.Nuageux:
                        temperature = baseTemperature[0][4] + Math.Pow(-1, rng.Next(0, 2)) * 0.1 * rng.Next(0, 20);
                        break;

                    case Meteo.Pluie:
                        temperature = baseTemperature[0][5] + Math.Pow(-1, rng.Next(0, 2)) * 0.1 * rng.Next(0, 20);
                        break;

                    case Meteo.Orage:
                        temperature = baseTemperature[0][6] + Math.Pow(-1, rng.Next(0, 2)) * 0.1 * rng.Next(0, 5);
                        break;

                    case Meteo.Neige:
                        temperature = baseTemperature[0][7] + Math.Pow(-1, rng.Next(0, 2)) * 0.1 * rng.Next(0, 2);
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
                        temperature = baseTemperature[1][1] + Math.Pow(-1, rng.Next(0, 2)) * 0.1 * rng.Next(0, 10);
                        break;

                    case Meteo.Soleil:
                        temperature = baseTemperature[1][2] + Math.Pow(-1, rng.Next(0, 2)) * 0.1 * rng.Next(0, 5);
                        break;

                    case Meteo.Canicule:
                        temperature = baseTemperature[1][3] + Math.Pow(-1, rng.Next(0, 2)) * 0.1 * rng.Next(0, 5);
                        break;

                    case Meteo.Nuageux:
                        temperature = baseTemperature[1][4] + Math.Pow(-1, rng.Next(0, 2)) * 0.1 * rng.Next(0, 20);
                        break;

                    case Meteo.Pluie:
                        temperature = baseTemperature[1][5] + Math.Pow(-1, rng.Next(0, 2)) * 0.1 * rng.Next(0, 25);
                        break;

                    case Meteo.Orage:
                        temperature = baseTemperature[1][6] + Math.Pow(-1, rng.Next(0, 2)) * 0.1 * rng.Next(0, 10);
                        break;

                    case Meteo.Neige:
                        temperature = baseTemperature[1][7] + Math.Pow(-1, rng.Next(0, 2)) * 0.1 * rng.Next(0, 1);
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
                        temperature = baseTemperature[2][1] + Math.Pow(-1, rng.Next(0, 2)) * 0.1 * rng.Next(0, 10);
                        break;

                    case Meteo.Soleil:
                        temperature = baseTemperature[2][2] + Math.Pow(-1, rng.Next(0, 2)) * 0.1 * rng.Next(0, 20);
                        break;

                    case Meteo.Canicule:
                        temperature = baseTemperature[2][3] + Math.Pow(-1, rng.Next(0, 2)) * 0.1 * rng.Next(0, 5);
                        break;

                    case Meteo.Nuageux:
                        temperature = baseTemperature[2][4] + Math.Pow(-1, rng.Next(0, 2)) * 0.1 * rng.Next(0, 20);
                        break;

                    case Meteo.Pluie:
                        temperature = baseTemperature[2][5] + Math.Pow(-1, rng.Next(0, 2)) * 0.1 * rng.Next(0, 20);
                        break;

                    case Meteo.Orage:
                        temperature = baseTemperature[2][6] + Math.Pow(-1, rng.Next(0, 2)) * 0.1 * rng.Next(0, 10);
                        break;

                    case Meteo.Neige:
                        temperature = baseTemperature[2][7] + Math.Pow(-1, rng.Next(0, 2)) * 0.1 * rng.Next(0, 1);
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
                        temperature = baseTemperature[3][1] + Math.Pow(-1, rng.Next(0, 2)) * 0.1 * rng.Next(0, 10);
                        break;

                    case Meteo.Soleil:
                        temperature = baseTemperature[3][2] + Math.Pow(-1, rng.Next(0, 2)) * 0.1 * rng.Next(0, 10);
                        break;

                    case Meteo.Canicule:
                        temperature = baseTemperature[3][3] + Math.Pow(-1, rng.Next(0, 2)) * 0.1 * rng.Next(0, 1);
                        break;

                    case Meteo.Nuageux:
                        temperature = baseTemperature[3][4] + Math.Pow(-1, rng.Next(0, 2)) * 0.1 * rng.Next(0, 20);
                        break;

                    case Meteo.Pluie:
                        temperature = baseTemperature[3][5] + Math.Pow(-1, rng.Next(0, 2)) * 0.1 * rng.Next(0, 20);
                        break;

                    case Meteo.Orage:
                        temperature = baseTemperature[3][6] + Math.Pow(-1, rng.Next(0, 2)) * 0.1 * rng.Next(0, 10);
                        break;

                    case Meteo.Neige:
                        temperature = baseTemperature[3][7] + Math.Pow(-1, rng.Next(0, 2)) * 0.1 * rng.Next(0, 20);
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

}