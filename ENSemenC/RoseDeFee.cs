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

    public override string Informations =>
        $"Nom : {nom} \n"+
        $"Nature : {nature}\n" +
        $"Saison préférée : {saisonPreferee}\n"+
        "Stade d'évolution :\n"+ //ça je ne sais pas encore
        $"Age :{age}\n"+ 
        "Prix : \n"; //on le définit avant ?

    public override string AsciiArt =>
        "⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣤⡶⣂⢰⠟⠴⡂⡦⠀⠀⠀⠀⠀⠀⠀\n" +
        "⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢸⣟⢼⡇⣧⣾⠶⠖⣴⣇⠀⠀⠀⠀⠀\n" +
        "⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢸⣿⡌⠇⠽⠶⠿⠿⢗⣊⠀⠀⠀⠀⠀\n" +
        "⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢸⣿⣿⣆⠸⣿⣿⣿⣿⡿⠀⠀⠀⠀\n" +
        "⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠘⣿⣿⣿⡆⣻⣿⣿⣿⠁⠀⠀⠀⠀\n" +
        "⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠈⠻⣿⣇⣿⣿⠟⠁⠀⠀⠀⠀⠀\n" +
        "⠀⠀⠀⣾⣷⢶⣄⠀⠀⠀⠀⠀⠀⢠⡏⠉⠁⠀⠀⠀⠀⠀⠀⠀\n" +
        "⠀⠀⠀⣿⣿⣷⡙⣷⣄⠀⠀⠀⠀⣼⠃⠀⣀⣀⣀⣀⣀⣀⡀\n" +
        "⠀⠀⠀⢿⣿⣿⣿⣌⢿⣧⠀⠀⢠⣯⣶⣿⣛⣛⣛⣛⣛⣛⣛⡷⣦⡀\n" +
        "⠀⠀⠀⠈⢿⣿⣿⣿⣎⣿⡆⢀⡿⠙⠿⣿⣿⣿⣿⣿⣿⣿⣿⣿⡿⠋\n" +
        "⠀⠀⠀⠀⠀⠙⢿⣿⣿⣽⣇⣼⠁⠀⠀⠈⠙⠛⠻⠿⠿⠛⠛⠉⠀⠀\n" +
        "⠀⠀⠀⠀⠀⠀⠀⠉⠛⠻⣿⠃⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀\n" +
        "⠀⠀⠀⠀⠀⠀⠀⠀⢀⣾⠃⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀";

}