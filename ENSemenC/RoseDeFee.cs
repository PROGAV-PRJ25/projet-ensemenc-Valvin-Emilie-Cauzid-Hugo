public class RoseDeFee : PlanteOrnementale
{
    public RoseDeFee(Terrain terrain) : base("Rose de Fée", Saison.Ete, terrain, 0, 1, 0.5, 1, 0.7, 1, 3, 28, 10, 200)
    { }

    public override void AfficherPlateau()
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.Write($" R ");
        Console.ResetColor();
    }

    public override void GetCouleur()
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
    }

    public override string AfficherPlateau2()
    {
        return " R ";
        // Console.ForegroundColor = ConsoleColor.Cyan;
        // Console.Write($"R");
        // Console.ResetColor();
    }

    public override void Informations()
    {
        Console.WriteLine($"Nom : {nom}");
        Console.WriteLine($"Nature : {nature}");
        Console.WriteLine($"Saison préférée : {saisonPreferee}");
        Console.WriteLine("Stade d'évolution :"); //ça je ne sais pas encore
        Console.WriteLine($"Age : {age} jours");
        Console.WriteLine("Prix : "); //on le définit avant ?
    }

    public override void AsciiArt()
    {
        Console.WriteLine("⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣤⡶⣂⢰⠟⠴⡂⡦⠀⠀⠀⠀⠀⠀⠀");
        Console.WriteLine("⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢸⣟⢼⡇⣧⣾⠶⠖⣴⣇⠀⠀⠀⠀⠀");
        Console.WriteLine("⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢸⣿⡌⠇⠽⠶⠿⠿⢗⣊⠀⠀⠀⠀⠀");
        Console.WriteLine("⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢸⣿⣿⣆⠸⣿⣿⣿⣿⡿⠀⠀⠀⠀");
        Console.WriteLine("⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠘⣿⣿⣿⡆⣻⣿⣿⣿⠁⠀⠀⠀⠀");
        Console.WriteLine("⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠈⠻⣿⣇⣿⣿⠟⠁⠀⠀⠀⠀⠀");
        Console.WriteLine("⠀⠀⠀⣾⣷⢶⣄⠀⠀⠀⠀⠀⠀⢠⡏⠉⠁⠀⠀⠀⠀⠀⠀⠀");
        Console.WriteLine("⠀⠀⠀⣿⣿⣷⡙⣷⣄⠀⠀⠀⠀⣼⠃⠀⣀⣀⣀⣀⣀⣀⡀");
        Console.WriteLine("⠀⠀⠀⢿⣿⣿⣿⣌⢿⣧⠀⠀⢠⣯⣶⣿⣛⣛⣛⣛⣛⣛⣛⡷⣦⡀");
        Console.WriteLine("⠀⠀⠀⠈⢿⣿⣿⣿⣎⣿⡆⢀⡿⠙⠿⣿⣿⣿⣿⣿⣿⣿⣿⣿⡿⠋");
        Console.WriteLine("⠀⠀⠀⠀⠀⠙⢿⣿⣿⣽⣇⣼⠁⠀⠀⠈⠙⠛⠻⠿⠿⠛⠛⠉⠀⠀");
        Console.WriteLine("⠀⠀⠀⠀⠀⠀⠀⠉⠛⠻⣿⠃⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀");
        Console.WriteLine("⠀⠀⠀⠀⠀⠀⠀⠀⢀⣾⠃⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀");
    }

}