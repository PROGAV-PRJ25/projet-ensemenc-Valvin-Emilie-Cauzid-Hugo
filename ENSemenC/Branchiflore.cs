public class Branchiflore : PlanteCommercialisable
{
    public Branchiflore(Terrain terrain) : base("Branchiflore", Saison.Automne, terrain, 0, 0.60, 1.0, 0.1, 0.8, 5, 70, 25)
    { }

    public override void AfficherPlateau()
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.Write($" B ");
        Console.ResetColor();
    }

    public override void GetCouleur()
    {
        Console.ForegroundColor = ConsoleColor.Green;
    }

    public override string AfficherPlateau2()
    {
        return " B ";
        // Console.ForegroundColor = ConsoleColor.Green;
        // Console.Write($"B");
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
        Console.WriteLine("⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣠⡶⠛⠉⠉⢹⡆⠀");
        Console.WriteLine("⠀⠀⠀⣀⠀⠀⠀⠀⠀⠀⠀⢰⡏⢀⡴⠀⠀⣾⠁⠀");
        Console.WriteLine("⠰⣟⠋⠉⠙⠛⢶⣄⠀⠀⢸⣷⠟⠁⣀⡼⠋⠀⠀");
        Console.WriteLine("⠀⢻⡄⠀⠰⢦⣄⣹⡆⠀⣼⠿⠛⠛⠉⠀⠀⠀");
        Console.WriteLine("⠀⠀⠻⢦⣄⣀⣈⣻⣿⢰⡏⠀⠀⠀⠀⠀⣀⠀⠀");
        Console.WriteLine("⠀⠀⠀⠀⠈⠉⠉⠉⠈⠻⣼⡇ ⢀⡴⠛⠋⠉⢙⡿");
        Console.WriteLine("⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢹⡇⢀⣾⣥⠾⠃⢀⣼⠃");
        Console.WriteLine("⠀⠀⠀⠀⣤⣤⣤⣤⣀⠀⢸⣇⣼⠿⠷⠶⠶⠛⠁");
        Console.WriteLine("⠀⠀⠀⠀⢻⡄⠀⣤⣹⣧⢸⡿⠁⠀⠀⠀⠀⠀⠀⠀");
        Console.WriteLine("⠀⠀⠀⠀⠀⠛⢶⣤⣽⣿⣿⡇⠀⠀⠀⠀⠀⠀⠀⠀");
        Console.WriteLine("⠀⠀⠀⠀⠀⠀⠀⠀⢀⣠⡼⢧⣄⡀⠀⠀⠀⠀⠀⠀");
        Console.WriteLine("⠀⠀⠀⠀⣀⣀⣤⣾⣋⣁⣀⣀⣈⣙⣷⣤⣀⣀⠀⠀");
        Console.WriteLine("⠀⠀⠀⠀⠉⠉⠉⠉⠉⠉⠉⠉⠉⠉⠉⠉⠉⠉⠀⠀");
    }
}