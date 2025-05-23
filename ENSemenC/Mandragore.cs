public class Mandragore : PlanteCommercialisable
{
    public Mandragore(Terrain terrain) : base("Mandragore", Saison.Printemps, terrain, 1, 0.25, 0.75, 0.25, 0.75, 3, 28, 15)
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
        // Console.ForegroundColor = ConsoleColor.Green;
        // Console.Write($"M");
        // Console.ResetColor();
    }

    public override void Informations()
    {
        Console.WriteLine($"Nom : {nom}");
        Console.WriteLine($"Nature : {nature}");
        Console.WriteLine($"Saison préférée : {saisonPreferee}");
        Console.WriteLine($"Age : {age} jours");
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
