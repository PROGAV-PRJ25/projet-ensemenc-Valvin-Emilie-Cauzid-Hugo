public class FruitEtoile : PlanteComestible
{
    public FruitEtoile(Terrain terrain) : base("Fruit Étoilé", Saison.Hiver, terrain, 2, 0.5, 0.6, 0.8, 1, 1, 28, 28, 1000)
    { }

    public override void AfficherPlateau()
    {
        Console.ForegroundColor = ConsoleColor.DarkMagenta;
        Console.Write($" F ");
        Console.ResetColor();
    }

    public override void GetCouleur()
    {
        Console.ForegroundColor = ConsoleColor.DarkMagenta;
    }

    public override string AfficherPlateau2()
    {
        return " F ";
        // Console.ForegroundColor = ConsoleColor.DarkMagenta;
        // Console.Write($"F");
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
        Console.WriteLine("   	  ⢶⣶⣿⣶⣶⣄⠀⠀⠀⠀⠀");
        Console.WriteLine("        ⠘⣿⣿⣿⣿⣿⣷⠀⠀");
        Console.WriteLine(" 	        ⠈⠻⢿⣿⣿⣿⣧⡀⠀");
        Console.WriteLine(" 	             ⠈⠻⣼⡇⠀⠀⠀");
        Console.WriteLine(" ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠉⣦⢧⡣⠄⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀");
        Console.WriteLine(" ⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⠠⣘⣾⡍⠋⠐⢾⣟⣦⠅⡂⠀⠀⠀⠀⠀");
        Console.WriteLine(" ⠀⠀⠀⠀⠀⠀⣀⠠⣀⣂⣒⡿⡝⠁⠀⠀⠀⢩⢻⣝⣤⣃⢦⡐⣠⢀⡀⡀⢀⠀⠀⠀⠀⠀");
        Console.WriteLine(" ⠀⠄⢂⢥⣞⣵⣾⣳⣯⢷⠷⠷⠈⠀⢀⡀⠀⠀⠙⠦⠻⠯⢷⡿⠧⠍⠈⢷⣣⠌⠀⠀⠀");
        Console.WriteLine(" ⠈⠔⢫⡊⣼⡟⠊⡑⠀⠂⠈⠀⠀⢀⠾⣟⡄⠀⠀⠀⠀⠀⠀⠀⣁⠔⠁⣺⠱⠈⠀⠀⠀");
        Console.WriteLine("  ⠈⠄⠙⠹⣟⣦⡀⠀⠀⠐⠶⠼⣵⠂⠘⠒⠿⡟⠃⠀⠀⣠⣾⣟⡟⢎⠁⠂⠀");
        Console.WriteLine(" ⠀⠀⠀⠈⠐⢈⠛⠿⣳⡄⠀⠀⠀⠐⠀⠀⣰⠒⠀⠀⢀⡾⢋⠃⡜⠌⠀⠀⠀⠀⠀");
        Console.WriteLine(" ⠀⠀⠀⠀⠀⠀⡐⢰⣟⠋⠀⠀⠸⠆⠄⠀⠈⠿⠄⠀⠀⡅⠀⣠⠜⠀⠀⠀⠀⠀⠀");
        Console.WriteLine(" ⠀⠀⠀⠀⠀⢀⢀⣻⡝⠀⠀⠀⠀⠀⣀⣀⢄⠀⠀⠀⠀⠀⠘⣌⢒⠀⠀⠀");
        Console.WriteLine(" ⠀⠀ ⠀⠀⠀⠀⢯⢿⣠⣀⣤⣶⢿⡻⢟⢿⡻⣦⣤⣀⠐⠈⣜⡣⠀⠀⠀⠀⠀⠀⠀⠀");
        Console.WriteLine(" ⠀⠀⠀⠀⠀⠀⢄⡻⠞⢾⡻⡝⢎⠊⡑⠈⠂⡑⠑⢎⠻⣃⣐⣦⡛⠄⠀⠀⠀⠀⠀⠀");
        Console.WriteLine(" ⠀⠀⠀⠀⠀⠈⠤⠙⡩⢃⠡⠐⠀⠀⠀⠀⠀⠀⠀⠀⠂⠡⠘⠠⠑⠈⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀");
    }
}
