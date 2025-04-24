public abstract class Terrain
{
    private Random rng = new Random();
    public string typeTerrain { get; }
    public double[] echelleTemp { get; set; }
    public double humidite { get; set; }
    public double retention { get; }
    private static double[] baseLuminosite = { 0.7, 0.75, 0.90, 1, 0.5, 0.35, 0.2 };
    // La valeur default est en indice 0, les autres valeurs à ajouter se mettront à la fin de la liste et de l'énumération
    // public static int tempActuelle { get; set; }
    public static double luminosite { get; set; }
    public static Meteo meteo { get; set; }
    public static Saison saison { get; set; }

    public Terrain(string typeTerrain, double tempMin, double tempMax, double retention)
    {
        this.typeTerrain = typeTerrain;
        this.echelleTemp = new double[2] { tempMin, tempMax };
        this.retention = retention;
    }

    public void Arroser(double crue = 0)
    {
        humidite += crue;
        humidite -= (1 - retention) * 0.01;
        // A ajuster selon si utilisation % ou valeurs chiffrées
    }

    public void MAJLuminosite()
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

    abstract public void MAJTemperature();
    // A calculer selon la meteo, la saison et les bornes de temp avec des tables
    // Même température pour tous les terrains de même type --> abstract ici et redéfinition dans classes héritées ?

}