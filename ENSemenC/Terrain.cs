public abstract class Terrain
{
    private Random rng = new Random();
    public string typeTerrain { get; }
    public static double[][] baseTemperature = {new double[]{12.1, 18.0, 25.0, 12.5, 10.0, 12.0, 0.0}, new double[] {20.4, 30.0, 45.0, 22.0, 19.5, 28.0, 0.0}, new double[] {13.4, 25.0, 30.0, 15.0, 16.5, 20.0, 0.0}, new double[] {0.7, 10.0,20.0,5.0,8.0,12.0,0.0},};
    //Printemps = 1, Ete = 2, Automne = 3, Hiver = 4
    // Normal = 1, Soleil, Canicule, Nuageux, Pluie, Orage, Neige 
    public static double temperature  {get;set;}

    public double humidite { get; set; }
    public double retention { get; }
    private static double[] baseLuminosite = { 0.7, 0.75, 0.90, 1, 0.5, 0.35, 0.2 };
    // La valeur default est en indice 0, les autres valeurs à ajouter se mettront à la fin de la liste et de l'énumération
    // public static int tempActuelle { get; set; }
    public static double luminosite { get; set; }
    public static Meteo meteo { get; set; }
    public static Saison saison { get; set; }

    public Terrain(string typeTerrain, double retention)
    {
        this.typeTerrain = typeTerrain;
        this.retention = retention;
    }

    public void HumidificationSol(double crue = 0)
    {
        humidite += crue;
    }

    public void AdaptationSol()
    {
        humidite -= (1 - retention) * 0.01;
        // A ajuster selon si utilisation % ou valeurs chiffrées
    }

    public void GererLumiere()
    {

        switch (meteo)
        {
            case Meteo.Normal:
                luminosite = baseLuminosite[1] + Math.Pow(-1, rng.Next(0, 1)) * 0.01 * rng.Next(0, 10);
                // A ajuster selon si utilisation % ou valeurs chiffrées
                break;

            case Meteo.Soleil:
                luminosite = baseLuminosite[2] + Math.Pow(-1, rng.Next(0, 1)) * 0.01 * rng.Next(0, 5);
                // A ajuster selon si utilisation % ou valeurs chiffrées
                break;

            case Meteo.Canicule:
                luminosite = baseLuminosite[3];
                // A ajuster selon si utilisation % ou valeurs chiffrées
                break;

            case Meteo.Nuageux:
                luminosite = baseLuminosite[4] + Math.Pow(-1, rng.Next(0, 1)) * 0.01 * rng.Next(0, 20);
                // A ajuster selon si utilisation % ou valeurs chiffrées
                break;

            case Meteo.Pluie:
                luminosite = baseLuminosite[5] + Math.Pow(-1, rng.Next(0, 1)) * 0.01 * rng.Next(0, 10);
                // A ajuster selon si utilisation % ou valeurs chiffrées
                break;

            case Meteo.Orage:
                luminosite = baseLuminosite[6] + Math.Pow(-1, rng.Next(0, 1)) * 0.01 * rng.Next(0, 10);
                // A ajuster selon si utilisation % ou valeurs chiffrées
                break;

            case Meteo.Neige:
                luminosite = baseLuminosite[5] + Math.Pow(-1, rng.Next(0, 1)) * 0.01 * rng.Next(0, 20);
                // Même valeur que Pluie
                // A ajuster selon si utilisation % ou valeurs chiffrées
                break;

            default:
                luminosite = baseLuminosite[0];
                break;
        }
        // A calculer selon la meteo avec des tables
    }

    abstract public void GererTemperature()
    {
        switch (saison)
        {
            case Saison.Printemps:
                switch (meteo)
                {
                    case Meteo.Normal:
                        temperature = baseTemperature[1] + Math.Pow(-1, rng.Next(0, 1)) * 0.1 * rng.Next(0, 10);
                        break;

                    case Meteo.Soleil:
                        temperature = baseTemperature[2] + Math.Pow(-1, rng.Next(0, 1)) * 0.1 * rng.Next(0, 10);
                        break;

                    case Meteo.Canicule:
                        temperature = baseTemperature[3] + Math.Pow(-1, rng.Next(0, 1)) * 0.1 * rng.Next(0, 5);
                        break;

                    case Meteo.Nuageux:
                        temperature = baseTemperature[4] + Math.Pow(-1, rng.Next(0, 1)) * 0.1 * rng.Next(0, 20);
                        break;

                    case Meteo.Pluie:
                        temperature = baseTemperature[5] + Math.Pow(-1, rng.Next(0, 1)) * 0.1 * rng.Next(0, 20);
                        break;

                    case Meteo.Orage:
                        temperature = baseTemperature[6] + Math.Pow(-1, rng.Next(0, 1)) * 0.1 * rng.Next(0, 5);
                        break;

                    case Meteo.Neige:
                        temperature = baseTemperature[7] + Math.Pow(-1, rng.Next(0, 1)) * 0.1 * rng.Next(0, 2);
                        break;

                    default:
                        temperature = baseTemperature[0];
                        break;
                }
            case Saison.Ete:
                switch (meteo)
                {
                    case Meteo.Normal:
                        temperature = baseTemperature[1] + Math.Pow(-1, rng.Next(0, 1)) * 0.1 * rng.Next(0, 10);
                        break;

                    case Meteo.Soleil:
                        temperature = baseTemperature[2] + Math.Pow(-1, rng.Next(0, 1)) * 0.1 * rng.Next(0, 5);
                        break;

                    case Meteo.Canicule:
                        temperature = baseTemperature[3] + Math.Pow(-1, rng.Next(0, 1)) * 0.1 * rng.Next(0, 5);
                        break;

                    case Meteo.Nuageux:
                        temperature = baseTemperature[4] + Math.Pow(-1, rng.Next(0, 1)) * 0.1 * rng.Next(0, 20);
                        break;

                    case Meteo.Pluie:
                        temperature = baseTemperature[5] + Math.Pow(-1, rng.Next(0, 1)) * 0.1 * rng.Next(0, 25);
                        break;

                    case Meteo.Orage:
                        temperature = baseTemperature[6] + Math.Pow(-1, rng.Next(0, 1)) * 0.1 * rng.Next(0, 10);
                        break;

                    case Meteo.Neige:
                        temperature = baseTemperature[7] + Math.Pow(-1, rng.Next(0, 1)) * 0.1 * rng.Next(0, 1);
                        // Même valeur que Pluie
                        break;

                    default:
                        temperature = baseTemperature[0];
                        break;
                }
            case Saison.Automne:
                switch (meteo)
                {
                    case Meteo.Normal:
                        temperature = baseTemperature[1] + Math.Pow(-1, rng.Next(0, 1)) * 0.1 * rng.Next(0, 10);
                        break;

                    case Meteo.Soleil:
                        temperature = baseTemperature[2] + Math.Pow(-1, rng.Next(0, 1)) * 0.1 * rng.Next(0, 20);
                        break;

                    case Meteo.Canicule:
                        temperature = baseTemperature[3] + Math.Pow(-1, rng.Next(0, 1)) * 0.1 * rng.Next(0, 5);
                        break;

                    case Meteo.Nuageux:
                        temperature = baseTemperature[4] + Math.Pow(-1, rng.Next(0, 1)) * 0.1 * rng.Next(0, 20);
                        break;

                    case Meteo.Pluie:
                        temperature = baseTemperature[5] + Math.Pow(-1, rng.Next(0, 1)) * 0.1 * rng.Next(0, 20);
                        break;

                    case Meteo.Orage:
                        temperature = baseTemperature[6] + Math.Pow(-1, rng.Next(0, 1)) * 0.1 * rng.Next(0, 10);
                        break;

                    case Meteo.Neige:
                        temperature = baseTemperature[7] + Math.Pow(-1, rng.Next(0, 1)) * 0.1 * rng.Next(0, 1);
                        // Même valeur que Pluie
                        break;

                    default:
                        temperature = baseTemperature[0];
                        break;
                }
            case Saison.Hiver:
                switch (meteo)
                {
                    case Meteo.Normal:
                        temperature = baseTemperature[1] + Math.Pow(-1, rng.Next(0, 1)) * 0.1 * rng.Next(0, 10);
                        break;

                    case Meteo.Soleil:
                        temperature = baseTemperature[2] + Math.Pow(-1, rng.Next(0, 1)) * 0.1 * rng.Next(0, 10);
                        break;

                    case Meteo.Canicule:
                        temperature = baseTemperature[3] + Math.Pow(-1, rng.Next(0, 1)) * 0.1 * rng.Next(0, 1);
                        break;

                    case Meteo.Nuageux:
                        temperature = baseTemperature[4] + Math.Pow(-1, rng.Next(0, 1)) * 0.1 * rng.Next(0, 20);
                        break;

                    case Meteo.Pluie:
                        temperature = baseTemperature[5] + Math.Pow(-1, rng.Next(0, 1)) * 0.1 * rng.Next(0, 20);
                        break;

                    case Meteo.Orage:
                        temperature = baseTemperature[6] + Math.Pow(-1, rng.Next(0, 1)) * 0.1 * rng.Next(0, 10);
                        break;

                    case Meteo.Neige:
                        temperature = baseTemperature[7] + Math.Pow(-1, rng.Next(0, 1)) * 0.1 * rng.Next(0, 20);
                        // Même valeur que Pluie
                        break;

                    default:
                        temperature = baseTemperature[0];
                        break;
                }
            default:
                temperature = baseTemperature[0];
                break;
        }
    
        
    }
    // A calculer selon la meteo, la saison et les bornes de temp avec des tables
    // Même température pour tous les terrains de même type --> abstract ici et redéfinition dans classes héritées ?

}