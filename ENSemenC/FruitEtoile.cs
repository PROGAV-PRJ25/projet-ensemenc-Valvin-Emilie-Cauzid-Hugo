public class FruitEtoile : PlanteComestible
{
    public FruitEtoile(Terrain terrain) : base("Fruit Étoilé", Saison.Hiver, terrain, 2, 1, 0.5, 0.6, 0.8, 1, 1, 100, 28, 1000, 28)
    { }

    public override void AfficherPlateau()
    {
        Console.ForegroundColor = ConsoleColor.DarkMagenta;
        Console.Write($"F");
        Console.ResetColor();
    }
}