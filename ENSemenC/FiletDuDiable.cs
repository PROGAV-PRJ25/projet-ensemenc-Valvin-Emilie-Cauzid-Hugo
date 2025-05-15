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

    public override void GetCouleur()
    {
        Console.ForegroundColor = ConsoleColor.DarkGreen;
    }

    public override string AfficherPlateau2()
    {
        return "F";
        // Console.ForegroundColor = ConsoleColor.DarkGreen;
        // Console.Write($"F");
        // Console.ResetColor();
    }
}

//Console.WriteLine("Nature : Plante invasive");
//Console.WriteLine("Saison préférée : Aucune");
//Console.WriteLine("Stade d'évolution :"); //ça je ne sais pas encore
//Console.WriteLine("Age :"); //on fait +1 chaque jour à chaque simulation
//Console.WriteLine("Prix : "); //on le définit avant ?

// Console.WriteLine("⠀⠀⠀⠀⠀⠀⠀⠀⠀⣠⣀⣀⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀");
// Console.WriteLine("⠀⠀⠀⠀⠀⠀⠀⠀⠈⢻⣿⣿⣦⡀⠀⠀⠀⠀⢹⣶⣄⠀⠀⠀⠀⠀⠀⠀⠀");
// Console.WriteLine(" ⣠⣴⣶⣤⣀⣤⣶⣶⣿⣿⣿⣿⣿⣿⣶⣦⣤⣾⣿⣿⣆⠀");
// Console.WriteLine(" ⠚⠉⠻⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⡿⠀");
// Console.WriteLine("⠀⠀⠀⣼⣿⣿⣿⣿⣿⣿⡿⠿⠿⢿⣿⣿⣿⣿⣿⣿⣿⣿⣷⡄⠀⠀⠀⢀⠀");
// Console.WriteLine("⠀⠀⣸⣿⣿⣿⣿⠟⠋⠀⠀⠀⠀⠀⠈⠙⢿⣿⣿⣿⣿⣿⣿⣿⣄⣀⣀⣼⡇⠀");
// Console.WriteLine("⠀⠀⣿⣿⣿⣿⠃⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠹⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⡇");
// Console.WriteLine("⠀⠘⣿⣿⣿⣿⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢹⣿⣿⣿⣿⣿⣿⣿⣿⡿⠁⠀⠀");
// Console.WriteLine("⠀⠀⠈⢿⣿⣿⣿⣷⣤⣤⣤⣤⣤⠂⠀⠀⠀⣰⣿⣿⣿⣿⣿⣿⣿⡇");
// Console.WriteLine("⠀⠀⠀⠀⠉⠛⠿⢿⣿⡿⠿⠛⠁⠀⠀⢀⣴⣿⣿⣿⣿⣿⣿⣿⣿⡇⠀⠀");
// Console.WriteLine("⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣠⣴⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⡁⠀⢀⡤⠀");
// Console.WriteLine("⠀⢰⣶⣤⣤⣤⣤⣤⣤⣤⣴⣶⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⡿⠃⠀");
// Console.WriteLine("⠀⢸⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⠿⠛⠁⠀");
// Console.WriteLine("⠀⠘⠛⠛⠛⠛⠛⠛⠛⠛⠛⠛⠛⠛⠛⠛⠛⠛⠛⠛⠛⠁⠀");