public abstract class Terrain
{
    private Random rng = new Random();
    public string typeTerrain { get; }
    public int[] echelleTemp { get; set; }
    public int tempActuelle { get; set; }
    public double humidite { get; set; }
    public double retention { get; }
    public double luminosite { get; set; }
    public static Meteo meteo { get; set; }
    public static Saison saison { get; set; }

    public Terrain(string typeTerrain, int tempMin, int tempMax, double retention)
    {
        this.typeTerrain = typeTerrain;
        this.echelleTemp = new int[2] { tempMin, tempMax };
        this.retention = retention;
    }

    public void MAJHumidite(double crue = 0)
    {
        humidite += crue;
        humidite -= retention * 0.01;
        // A ajuster selon si utilisation % ou valeurs chiffrées
    }

    public void MAJLuminosite()
    {
        // A calculer selon la meteo avec des tables
    }

    public void MAJTemperature()
    {
        // A calculer selon la meteo, la saison et les bornes de temp avec des tables
    }

}