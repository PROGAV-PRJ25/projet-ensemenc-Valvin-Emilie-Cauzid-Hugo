public class Mandragore : PlanteCommercialisable
{
    public Mandragore(Terrain terrain) : base("Mandragore", Saison.Printemps, terrain, 1, 1, 0.25, 0.75, 0.25, 0.75, 3, 28, 15, 50)
    { }

    public override void AfficherPlateau()
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.Write($"M");
        Console.ResetColor();
    }
}