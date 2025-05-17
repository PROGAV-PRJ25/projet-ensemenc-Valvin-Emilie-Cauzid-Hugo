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

    public override string Informations =>
        $"Nom : {nom} \n"+
        $"Nature : {nature}\n" +
        $"Saison préférée : {saisonPreferee}\n"+
        "Stade d'évolution :\n"+ //ça je ne sais pas encore
        $"Age :{age}\n"+ 
        "Prix : \n"; //on le définit avant ?

    public override string AsciiArt =>
            "⠀⠀⠀⠀⠀⠀⠀⠀⠀⣠⣀⣀⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀\n" +
            "⠀⠀⠀⠀⠀⠀⠀⠀⠈⢻⣿⣿⣦⡀⠀⠀⠀⠀⢹⣶⣄⠀⠀⠀⠀⠀⠀⠀⠀\n" +
            " ⣠⣴⣶⣤⣀⣤⣶⣶⣿⣿⣿⣿⣿⣿⣶⣦⣤⣾⣿⣿⣆⠀\n" +
            " ⠚⠉⠻⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⡿⠀\n" +
            "⠀⠀⠀⣼⣿⣿⣿⣿⣿⣿⡿⠿⠿⢿⣿⣿⣿⣿⣿⣿⣿⣿⣷⡄⠀⠀⠀⢀⠀\n" +
            "⠀⠀⣸⣿⣿⣿⣿⠟⠋⠀⠀⠀⠀⠀⠈⠙⢿⣿⣿⣿⣿⣿⣿⣿⣄⣀⣀⣼⡇⠀\n" +
            "⠀⠀⣿⣿⣿⣿⠃⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠹⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⡇\n" +
            "⠀⠘⣿⣿⣿⣿⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢹⣿⣿⣿⣿⣿⣿⣿⣿⡿⠁⠀⠀\n" +
            "⠀⠀⠈⢿⣿⣿⣿⣷⣤⣤⣤⣤⣤⠂⠀⠀⠀⣰⣿⣿⣿⣿⣿⣿⣿⡇\n" +
            "⠀⠀⠀⠀⠉⠛⠿⢿⣿⡿⠿⠛⠁⠀⠀⢀⣴⣿⣿⣿⣿⣿⣿⣿⣿⡇⠀⠀\n" +
            "⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣠⣴⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⡁⠀⢀⡤⠀\n" +
            "⠀⢰⣶⣤⣤⣤⣤⣤⣤⣤⣴⣶⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⡿⠃⠀\n" +
            "⠀⢸⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⠿⠛⠁⠀\n" +
            "⠀⠘⠛⠛⠛⠛⠛⠛⠛⠛⠛⠛⠛⠛⠛⠛⠛⠛⠛⠛⠛⠁⠀\n";

}