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

    public override void GetCouleur()
    {
        Console.ForegroundColor = ConsoleColor.Green;
    }

    public override string AfficherPlateau2()
    {
        return "M";
        // Console.ForegroundColor = ConsoleColor.Green;
        // Console.Write($"M");
        // Console.ResetColor();
    }
}

//Console.WriteLine("Nature : Plante commercialisable");
//Console.WriteLine("Saison préférée : Printemps");
//Console.WriteLine("Stade d'évolution :"); //ça je ne sais pas encore
//Console.WriteLine("Age :"); //on fait +1 chaque jour à chaque simulation
//Console.WriteLine("Prix : "); //on le définit avant ?

// Console.WriteLine("⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠘⣷⠀⠀⠀⢀⣤⣾⠇⠀⠀⠀⠀⠀⠀⠀⠀⠀");
// Console.WriteLine("⠀⠀⠀⠀⠀⠀⠀⣀⣀⣀⠀⠀⠀⠹⣧⡀⠀⣿⣿⡟⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀");
// Console.WriteLine("⠀⠀⠀⠀⠀⠀⠀⠈⠻⣿⣿⣷⣦⣄⠘⣷⡀⠉⠁⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀");
// Console.WriteLine("⠀⠀⠀⠀⠀⠀⠀⠀⠀⠈⠙⠛⠛⠛⠀⠘⣷⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀");
// Console.WriteLine("⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢠⡿⠀⢴⣾⠿⠛⠀⠀⠀⠀⠀⠀⠀⠀");
// Console.WriteLine("⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣾⠃⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀");
// Console.WriteLine("⠀⠀⠒⠒⠒⠒⠒⠒⠒⠒⠒⠒⠒⢲⣶⣶⣶⡖⠒⠒⠒⠒⠒⠒⠒⠒⠒");
// Console.WriteLine("⠀⠀⠀⠀⠀⢠⡶⠾⠆⠀⠀⠀⠀⣸⣿⠁⠈⠙⢷⡶⠶⣦⣄⡀⠀⠀⠀⠀⠀⠀");
// Console.WriteLine("⠀⠸⠷⣦⡀⠘⢷⣄⠀⠀⠀⠀⢠⡿⣯⡀⠀⠀⠈⢿⡄⠀⠉⠁⠀⠀⣠⡄⠀⠀");
// Console.WriteLine("⠀⢠⡾⠿⠛⠻⠿⠿⠶⠾⠛⢁⣸⣷⣦⣀⠀⠈⠁⠀.⣤⣾⡋⠀⠀⠀");
// Console.WriteLine("⠀⣿⠁⠀⠀⠀⠀⠀⠀⠀⢀⣴⠿⣯⣀⡀⠉⠙⠛⠓⠒⠁⠈⢿⠀⠀⠀");
// Console.WriteLine("⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠈⠉⠃⠀⠀⠀⠀⠀⠀⠀⠀⠀⠈⠀⠀⠀");
