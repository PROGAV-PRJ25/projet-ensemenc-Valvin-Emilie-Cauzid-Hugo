public class RoseDeFee : PlanteOrnementale
{
    public RoseDeFee(Terrain terrain) : base("Rode de Fée", Saison.Ete, terrain, 0, 1, 0.5, 1, 0.7, 1, 3, 28, 10, 200)
    { }

    public override void AfficherPlateau()
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.Write($"R");
        Console.ResetColor();
    }
}