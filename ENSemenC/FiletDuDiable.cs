public class FiletDuDiable : PlanteInvasive
{
    public FiletDuDiable(Terrain terrain) : base("Filet du Diable", Saison.Toutes, terrain, 1, 0.70, 1, 0.1, 0.5, 10, 100, 1)
    { }

    public override void AfficherPlateau()
    {
        Console.ForegroundColor = ConsoleColor.DarkGreen;
        Console.Write($"F");
        Console.ResetColor();
    }
}