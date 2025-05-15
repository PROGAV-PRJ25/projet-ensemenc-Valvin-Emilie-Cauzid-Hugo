public class RoseDeFee : PlanteOrnementale
{
    public RoseDeFee(Terrain terrain) : base("Rose de Fée", Saison.Ete, terrain, 0, 1, 0.5, 1, 0.7, 1, 3, 28, 10, 200)
    { }

    public override void AfficherPlateau()
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.Write($"R");
        Console.ResetColor();
    }

    public override void GetCouleur()
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
    }

    public override string AfficherPlateau2()
    {
        return "R";
        // Console.ForegroundColor = ConsoleColor.Cyan;
        // Console.Write($"R");
        // Console.ResetColor();
    }
}

//Console.WriteLine("Nature : Plante ornementale");
//Console.WriteLine("Saison préférée : Ete");
//Console.WriteLine("Stade d'évolution :"); //ça je ne sais pas encore
//Console.WriteLine("Age :"); //on fait +1 chaque jour à chaque simulation
//Console.WriteLine("Prix : "); //on le définit avant ?

// Console.WriteLine("⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣤⡶⣂⢰⠟⠴⡂⡦⠀⠀⠀⠀⠀⠀⠀");
// Console.WriteLine("⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢸⣟⢼⡇⣧⣾⠶⠖⣴⣇⠀⠀⠀⠀⠀");
// Console.WriteLine("⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢸⣿⡌⠇⠽⠶⠿⠿⢗⣊⠀⠀⠀⠀⠀");
// Console.WriteLine("⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢸⣿⣿⣆⠸⣿⣿⣿⣿⡿⠀⠀⠀⠀");
// Console.WriteLine("⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠘⣿⣿⣿⡆⣻⣿⣿⣿⠁⠀⠀⠀⠀");
// Console.WriteLine("⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠈⠻⣿⣇⣿⣿⠟⠁⠀⠀⠀⠀⠀");
// Console.WriteLine("⠀⠀⠀⣾⣷⢶⣄⠀⠀⠀⠀⠀⠀⢠⡏⠉⠁⠀⠀⠀⠀⠀⠀⠀");
// Console.WriteLine("⠀⠀⠀⣿⣿⣷⡙⣷⣄⠀⠀⠀⠀⣼⠃⠀⣀⣀⣀⣀⣀⣀⡀");
// Console.WriteLine("⠀⠀⠀⢿⣿⣿⣿⣌⢿⣧⠀⠀⢠⣯⣶⣿⣛⣛⣛⣛⣛⣛⣛⡷⣦⡀");
// Console.WriteLine("⠀⠀⠀⠈⢿⣿⣿⣿⣎⣿⡆⢀⡿⠙⠿⣿⣿⣿⣿⣿⣿⣿⣿⣿⡿⠋");
// Console.WriteLine("⠀⠀⠀⠀⠀⠙⢿⣿⣿⣽⣇⣼⠁⠀⠀⠈⠙⠛⠻⠿⠿⠛⠛⠉⠀⠀");
// Console.WriteLine("⠀⠀⠀⠀⠀⠀⠀⠉⠛⠻⣿⠃⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀");
// Console.WriteLine("⠀⠀⠀⠀⠀⠀⠀⠀⢀⣾⠃⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀");