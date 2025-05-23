public class FiletDuDiable : PlanteInvasive
{
    public FiletDuDiable(Terrain terrain) : base("Filet du Diable", Saisons.Toutes, terrain, 0.70, 1, 0.1, 0.5, 10, 100, 1)
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