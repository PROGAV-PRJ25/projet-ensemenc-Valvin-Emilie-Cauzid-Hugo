public class RoseDeFee : PlanteOrnementale
{
    public RoseDeFee(Terrain terrain) : base("Rose de Fée", Saisons.Ete, terrain, 0, 0.5, 1, 0.7, 1, 3, 28, 10)
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