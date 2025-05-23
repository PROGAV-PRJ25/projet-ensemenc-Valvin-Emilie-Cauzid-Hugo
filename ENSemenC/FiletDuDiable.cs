public class FiletDuDiable : PlanteInvasive
{
    public FiletDuDiable(Terrain terrain) : base("Filet du Diable", Saison.Toutes, terrain, 1, 0.70, 1, 0.1, 0.5, 10, 100, 1)
    { }

    public override void AfficherPlateau()
    {
        Console.ForegroundColor = ConsoleColor.DarkGreen;
        Console.Write($" F ");
        Console.ResetColor();
    }

    public override void GetCouleur()
    {
        Console.ForegroundColor = ConsoleColor.DarkGreen;
    }

    public override string AfficherPlateau2()
    {
        return " F ";
        // Console.ForegroundColor = ConsoleColor.DarkGreen;
        // Console.Write($"F");
        // Console.ResetColor();
    }

    public override void Informations()
    {
        Console.WriteLine($"Nom : {nom}");
        Console.WriteLine($"Nature : {nature}");
        Console.WriteLine($"Saison préférée : {saisonPreferee}");
        Console.WriteLine("Stade d'évolution :"); //ça je ne sais pas encore
        Console.WriteLine($"Age : {age} jours");
    }
    public override void AsciiArt()
    {
        Console.WriteLine("⠀⠀⠀⠀⠀⠀⠀⠀⠀⣠⣀⣀⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀");
        Console.WriteLine("⠀⠀⠀⠀⠀⠀⠀⠀⠈⢻⣿⣿⣦⡀⠀⠀⠀⠀⢹⣶⣄⠀⠀⠀⠀⠀⠀⠀⠀");
        Console.WriteLine(" ⣠⣴⣶⣤⣀⣤⣶⣶⣿⣿⣿⣿⣿⣿⣶⣦⣤⣾⣿⣿⣆⠀");
        Console.WriteLine(" ⠚⠉⠻⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⡿⠀");
        Console.WriteLine("⠀⠀⠀⣼⣿⣿⣿⣿⣿⣿⡿⠿⠿⢿⣿⣿⣿⣿⣿⣿⣿⣿⣷⡄⠀⠀⠀⢀⠀");
        Console.WriteLine("⠀⠀⣸⣿⣿⣿⣿⠟⠋⠀⠀⠀⠀⠀⠈⠙⢿⣿⣿⣿⣿⣿⣿⣿⣄⣀⣀⣼⡇⠀");
        Console.WriteLine("⠀⠀⣿⣿⣿⣿⠃⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠹⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⡇");
        Console.WriteLine("⠀⠘⣿⣿⣿⣿⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢹⣿⣿⣿⣿⣿⣿⣿⣿⡿⠁⠀⠀");
        Console.WriteLine("⠀⠀⠈⢿⣿⣿⣿⣷⣤⣤⣤⣤⣤⠂⠀⠀⠀⣰⣿⣿⣿⣿⣿⣿⣿⡇");
        Console.WriteLine("⠀⠀⠀⠀⠉⠛⠿⢿⣿⡿⠿⠛⠁⠀⠀⢀⣴⣿⣿⣿⣿⣿⣿⣿⣿⡇⠀⠀");
        Console.WriteLine("⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣠⣴⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⡁⠀⢀⡤⠀");
        Console.WriteLine("⠀⢰⣶⣤⣤⣤⣤⣤⣤⣤⣴⣶⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⡿⠃⠀");
        Console.WriteLine("⠀⢸⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⠿⠛⠁⠀");
        Console.WriteLine("⠀⠘⠛⠛⠛⠛⠛⠛⠛⠛⠛⠛⠛⠛⠛⠛⠛⠛⠛⠛⠛⠁⠀");
    }

}