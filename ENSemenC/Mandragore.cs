public class Mandragore : PlanteCommercialisable
{
    public Mandragore(Terrain terrain) : base("Mandragore", Saison.Printemps, terrain, 1, 1, 0.25, 0.75, 0.25, 0.75, 3, 28, 15, 50)
    { }

    public override void AfficherPlateau()
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.Write($"M");
        Console.ResetColor();
    }

    public override void GetCouleur()
    {
        Console.ForegroundColor = ConsoleColor.Green;
    }

    public override string AfficherPlateau2()
    {
        return "M";
        // Console.ForegroundColor = ConsoleColor.Green;
        // Console.Write($"M");
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
            "⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠘⣷⠀⠀⠀⢀⣤⣾⠇⠀⠀⠀⠀⠀⠀⠀⠀⠀\n" +
            "⠀⠀⠀⠀⠀⠀⠀⣀⣀⣀⠀⠀⠀⠹⣧⡀⠀⣿⣿⡟⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀\n" +
            "⠀⠀⠀⠀⠀⠀⠀⠈⠻⣿⣿⣷⣦⣄⠘⣷⡀⠉⠁⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀\n" +
            "⠀⠀⠀⠀⠀⠀⠀⠀⠀⠈⠙⠛⠛⠛⠀⠘⣷⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀\n" +
            "⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢠⡿⠀⢴⣾⠿⠛⠀⠀⠀⠀⠀⠀⠀⠀\n" +
            "⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣾⠃⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀\n" +
            "⠀⠀⠒⠒⠒⠒⠒⠒⠒⠒⠒⠒⠒⢲⣶⣶⣶⡖⠒⠒⠒⠒⠒⠒⠒⠒⠒\n" +
            "⠀⠀⠀⠀⠀⢠⡶⠾⠆⠀⠀⠀⠀⣸⣿⠁⠈⠙⢷⡶⠶⣦⣄⡀⠀⠀⠀⠀⠀⠀\n" +
            "⠀⠸⠷⣦⡀⠘⢷⣄⠀⠀⠀⠀⢠⡿⣯⡀⠀⠀⠈⢿⡄⠀⠉⠁⠀⠀⣠⡄⠀⠀\n" +
            "⠀⢠⡾⠿⠛⠻⠿⠿⠶⠾⠛⢁⣸⣷⣦⣀⠀⠈⠁⠀.⣤⣾⡋⠀⠀⠀\n" +
            "⠀⣿⠁⠀⠀⠀⠀⠀⠀⠀⢀⣴⠿⣯⣀⡀⠉⠙⠛⠓⠒⠁⠈⢿⠀⠀⠀\n" +
            "⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠈⠉⠃⠀⠀⠀⠀⠀⠀⠀⠀⠀⠈⠀⠀⠀";

}
