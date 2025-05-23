public class FruitEtoile : PlanteComestible
{
    public FruitEtoile(Terrain terrain) : base("Fruit Étoilé", Saisons.Hiver, terrain, 2, 0.5, 0.6, 0.8, 1, 1, 28, 28, 1000)
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
