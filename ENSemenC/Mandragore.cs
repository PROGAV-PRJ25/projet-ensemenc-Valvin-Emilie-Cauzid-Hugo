public class Mandragore : PlanteCommercialisable
{
    public Mandragore(Terrain terrain) : base("Mandragore", Saisons.Printemps, terrain, 1, 0.25, 0.75, 0.25, 0.75, 3, 28, 15)
    { }

    public override void AfficherPlateau()
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.Write($" M ");
        Console.ResetColor();
    }

    public override void GetCouleur()
    {
        Console.ForegroundColor = ConsoleColor.Green;
    }

    public override string AfficherPlateau2()
    {
        return " M ";
    }

    public override void Informations()
    {
        Console.WriteLine($"Nom : {Nom}");
        Console.WriteLine($"Nature : {Nature}");
        Console.WriteLine($"Saison préférée : {SaisonPreferee}");
        Console.WriteLine($"Age : {Age} jours");
    }

    public override void AsciiArt()
    {
        Console.WriteLine("⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠘⣷⠀⠀⠀⢀⣤⣾⠇⠀⠀⠀⠀⠀⠀⠀⠀⠀");
        Console.WriteLine("⠀⠀⠀⠀⠀⠀⠀⣀⣀⣀⠀⠀⠀⠹⣧⡀⠀⣿⣿⡟⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀");
        Console.WriteLine("⠀⠀⠀⠀⠀⠀⠀⠈⠻⣿⣿⣷⣦⣄⠘⣷⡀⠉⠁⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀");
        Console.WriteLine("⠀⠀⠀⠀⠀⠀⠀⠀⠀⠈⠙⠛⠛⠛⠀⠘⣷⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀");
        Console.WriteLine("⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢠⡿⠀⢴⣾⠿⠛⠀⠀⠀⠀⠀⠀⠀⠀");
        Console.WriteLine("⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣾⠃⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀");
        Console.WriteLine("⠀⠀⠒⠒⠒⠒⠒⠒⠒⠒⠒⠒⠒⢲⣶⣶⣶⡖⠒⠒⠒⠒⠒⠒⠒⠒⠒");
        Console.WriteLine("⠀⠀⠀⠀⠀⢠⡶⠾⠆⠀⠀⠀⠀⣸⣿⠁⠈⠙⢷⡶⠶⣦⣄⡀⠀⠀⠀⠀⠀⠀");
        Console.WriteLine("⠀⠸⠷⣦⡀⠘⢷⣄⠀⠀⠀⠀⢠⡿⣯⡀⠀⠀⠈⢿⡄⠀⠉⠁⠀⠀⣠⡄⠀⠀");
        Console.WriteLine("⠀⢠⡾⠿⠛⠻⠿⠿⠶⠾⠛⢁⣸⣷⣦⣀⠀⠈⠁⠀.⣤⣾⡋⠀⠀⠀");
        Console.WriteLine("⠀⣿⠁⠀⠀⠀⠀⠀⠀⠀⢀⣴⠿⣯⣀⡀⠉⠙⠛⠓⠒⠁⠈⢿⠀⠀⠀");
        Console.WriteLine("⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠈⠉⠃⠀⠀⠀⠀⠀⠀⠀⠀⠀⠈⠀⠀⠀");
    }

}
