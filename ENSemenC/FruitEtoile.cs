public class FruitEtoile : PlanteComestible
{
    public FruitEtoile(Terrain terrain) : base("Fruit Étoilé", Saison.Hiver, terrain, 2, 1, 0.5, 0.6, 0.8, 1, 1, 100, 28, 1000, 28)
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

    public override string Informations =>
        $"Nom : {nom} \n"+
        $"Nature : {nature}\n" +
        $"Saison préférée : {saisonPreferee}\n"+
        "Stade d'évolution :\n"+ //ça je ne sais pas encore
        $"Age :{age}\n"+ 
        "Prix : \n"; //on le définit avant ?



    public override string AsciiArt =>
        "   	  ⢶⣶⣿⣶⣶⣄⠀⠀⠀⠀⠀\n" +
        "        ⠘⣿⣿⣿⣿⣿⣷⠀⠀\n" +
        " 	        ⠈⠻⢿⣿⣿⣿⣧⡀⠀\n" +
        " 	             ⠈⠻⣼⡇⠀⠀⠀\n" +
        " ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠉⣦⢧⡣⠄⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀\n" +
        " ⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⠠⣘⣾⡍⠋⠐⢾⣟⣦⠅⡂⠀⠀⠀⠀⠀\n" +
        " ⠀⠀⠀⠀⠀⠀⣀⠠⣀⣂⣒⡿⡝⠁⠀⠀⠀⢩⢻⣝⣤⣃⢦⡐⣠⢀⡀⡀⢀⠀⠀⠀⠀⠀\n" +
        " ⠀⠄⢂⢥⣞⣵⣾⣳⣯⢷⠷⠷⠈⠀⢀⡀⠀⠀⠙⠦⠻⠯⢷⡿⠧⠍⠈⢷⣣⠌⠀⠀⠀\n" +
        " ⠈⠔⢫⡊⣼⡟⠊⡑⠀⠂⠈⠀⠀⢀⠾⣟⡄⠀⠀⠀⠀⠀⠀⠀⣁⠔⠁⣺⠱⠈⠀⠀⠀\n" +
        "  ⠈⠄⠙⠹⣟⣦⡀⠀⠀⠐⠶⠼⣵⠂⠘⠒⠿⡟⠃⠀⠀⣠⣾⣟⡟⢎⠁⠂⠀\n" +
        " ⠀⠀⠀⠈⠐⢈⠛⠿⣳⡄⠀⠀⠀⠐⠀⠀⣰⠒⠀⠀⢀⡾⢋⠃⡜⠌⠀⠀⠀⠀⠀\n" +
        " ⠀⠀⠀⠀⠀⠀⡐⢰⣟⠋⠀⠀⠸⠆⠄⠀⠈⠿⠄⠀⠀⡅⠀⣠⠜⠀⠀⠀⠀⠀⠀\n" +
        " ⠀⠀⠀⠀⠀⢀⢀⣻⡝⠀⠀⠀⠀⠀⣀⣀⢄⠀⠀⠀⠀⠀⠘⣌⢒⠀⠀⠀\n" +
        " ⠀⠀ ⠀⠀⠀⠀⢯⢿⣠⣀⣤⣶⢿⡻⢟⢿⡻⣦⣤⣀⠐⠈⣜⡣⠀⠀⠀⠀⠀⠀⠀⠀\n" +
        " ⠀⠀⠀⠀⠀⠀⢄⡻⠞⢾⡻⡝⢎⠊⡑⠈⠂⡑⠑⢎⠻⣃⣐⣦⡛⠄⠀⠀⠀⠀⠀⠀\n" +
        " ⠀⠀⠀⠀⠀⠈⠤⠙⡩⢃⠡⠐⠀⠀⠀⠀⠀⠀⠀⠀⠂⠡⠘⠠⠑⠈⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀";

}
