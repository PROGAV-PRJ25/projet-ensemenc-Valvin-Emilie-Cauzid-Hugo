//à faire : 
//partie de droite avec les infos sur les plantes et tout, trouver icones qui correspondent aux infos, une autre fonction qu'afficher plateau -> Emilie
//faire actions que peut faire joueur, à quoi il a accès <-- Bien avancé
//Mode urgence 

using System.Threading.Tasks.Dataflow;

public class Simulation
{
    Random rng = new Random();
    public List<Plante> plantes { get; set; }
    public List<List<Terrain?>> plateau { get; set; }
    public int[] positionJoueur { get; set; }
    private double[][] probaMeteo { get; }
    // Normal = 1, Soleil, Canicule, Nuageux, Pluie, Orage, Neige 
    public DateTime date { get; set; }
    public int nbTerrain { get; set; }
    public int cote { get; set; }

    public Simulation()
    {
        plantes = new List<Plante> { };
        // Initialisation en temps que terrain de taille 1x1 vide
        plateau = new List<List<Terrain?>> { new List<Terrain?> { null, null }, new List<Terrain?> { null, null } };
        // Initialisation en temps que terrain de taille 2x2 vide
        positionJoueur = new int[2] { 0, 0 };
        probaMeteo = new double[][] { new double[] { 30, 25, 1, 20, 20, 2, 2 }, new double[] { 20, 35, 15, 10, 5, 15, 0 }, new double[] { 30, 10, 3, 25, 20, 10, 2 }, new double[] { 15, 15, 0, 30, 10, 5, 25 } };
        date = DateTime.Today;
        nbTerrain = 0;
        cote = 2;
    }


    public void AgrandirPlateau2()
    {
        List<Terrain?> nouvelleLigne = new List<Terrain?> { };
        // Ajout d'une ligne de terrains vide
        for (int i = 0; i < plateau[0].Count(); i++)
        {
            nouvelleLigne.Add(null);
        }
        plateau.Add(nouvelleLigne);

        // Ajout d'une colonne de terrains vide
        for (int i = 0; i < plateau.Count(); i++)
        {
            plateau[i].Add(null);
        }
    }

    public void AjouterTerrain2(Terrain terrain)
    {
        // Ajout terrain dans le plateau + MAJ de la position du terrain dans l'itération
        plateau[positionJoueur[1]][positionJoueur[0]] = terrain;
        terrain.position![0] = positionJoueur[1];
        terrain.position![1] = positionJoueur[0];
        nbTerrain++;
        if (nbTerrain == cote * cote && cote <= 10)
        {
            AgrandirPlateau2();
            cote++;
        }
    }

    public void AjouterPlante(Plante plante)
    {
        plateau[positionJoueur[1]][positionJoueur[0]]!.plante = plante;
        plantes.Add(plante);
        // plante.terrain = plateau[positionJoueur[1]][positionJoueur[0]]!;
        // Vérifier que ce n'est pas null !!!
    }

    public void AfficherPlateau()
    {
        Console.Clear();

        //afficher la date
        DateTime thisDay = DateTime.Today;
        Console.WriteLine(thisDay.ToString("D"));
        Console.WriteLine($"Saison : {Terrain.saison}");
        Console.WriteLine($"Météo : {Terrain.meteo}");
        Console.WriteLine($"Luminosité : {Terrain.luminosite}");
        bool coulFond = true;
        int largeur = plateau.Count;
        int longueur = plateau[0].Count;
        Console.Write("\t ");
        for (int i = 0; i < longueur; i++)
        // Affichage du numéro des colonnes
        {
            Console.Write($"  {i + 1}   ");
        }

        Console.WriteLine();
        for (int i = 0; i < largeur; i++)
        {
            Console.Write(" \t[");
            for (int j = 0; j < longueur; j++)
            {
                coulFond = true;
                if (positionJoueur[0] == j && positionJoueur[1] == i)
                {
                    // Fond de couleur blanche pour indiquer l'emplacement du joueur
                    coulFond = false;
                    Console.BackgroundColor = ConsoleColor.White;
                }
                Console.Write(" ");
                // On passe ensuite dans tout le plateau en affichant les bonnes choses selon ce que la case possède
                if (plateau[i][j] != null)
                {
                    if (coulFond)
                    {
                        plateau[i][j]!.GetCouleur();
                    }
                    if (plateau[i][j]!.plante != null)
                    {
                        plateau[i][j]!.plante!.AfficherPlateau();
                        // le ! sert à affirmer que la valeur ne peux pas être null
                    }
                    else
                    {
                        Console.Write("   ");
                        Console.ResetColor();
                    }
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.Write(" X ");
                    Console.ResetColor();
                }

                // séparateur
                if (j != longueur - 1)
                {
                    if (!coulFond)
                    {
                        Console.BackgroundColor = ConsoleColor.White;
                    }
                    Console.Write($" ");
                    Console.ResetColor();
                    Console.Write($"|");
                }
            }

            // Affichage du numéro de la ligne
            if (!coulFond)
            {
                Console.BackgroundColor = ConsoleColor.White;
            }
            Console.Write($" ");
            Console.ResetColor();
            Console.WriteLine($" ] {i + 1}");
        }
    }

    public void DeplacementPlateau(Orientation orientation)
    {
        // Met à jour la position du joueur dans le plateau
        switch (orientation)
        {
            case Orientation.Nord:
                positionJoueur[1]--;
                if (positionJoueur[1] < 0)
                {
                    positionJoueur[1] = plateau.Count() - 1;
                }
                break;
            case Orientation.Est:
                positionJoueur[0]++;
                if (positionJoueur[0] >= plateau[0].Count())
                {
                    positionJoueur[0] = 0;
                }
                break;
            case Orientation.Ouest:
                positionJoueur[0]--;
                if (positionJoueur[0] < 0)
                {
                    positionJoueur[0] = plateau[0].Count() - 1;
                }
                break;
            case Orientation.Sud:
                positionJoueur[1]++;
                if (positionJoueur[1] >= plateau.Count())
                {
                    positionJoueur[1] = 0;
                }
                break;
            default:
                break;
        }
    }

    public void BoucleDeplacementPlateau()
    {
        ConsoleKey touche;
        bool fin = false;
        do
        {
            // Lit la touche pressée pour bouger dans le plateau
            AfficherPlateau();
            touche = Console.ReadKey().Key;
            if (touche == ConsoleKey.LeftArrow)
            {
                DeplacementPlateau(Orientation.Ouest);
            }
            else if (touche == ConsoleKey.RightArrow)
            {
                DeplacementPlateau(Orientation.Est);
            }
            else if (touche == ConsoleKey.UpArrow)
            {
                DeplacementPlateau(Orientation.Nord);
            }
            else if (touche == ConsoleKey.DownArrow)
            {
                DeplacementPlateau(Orientation.Sud);
            }
            else if (touche == ConsoleKey.Enter)
            {
                fin = true;
            }
        }
        while (!fin);
    }

    public int BoucleChoixAction()
    {
        int action = -1;
        char testConfirmation;
        bool confirmation;
        bool testAction = false;
        int selecteur = 0;

        //Tests afin de savoir si il y a un terrain et/ou une plante sur la position du joueur
        bool testPlante = false;
        bool testTerrain = plateau[positionJoueur[1]][positionJoueur[0]] != null;
        if (testTerrain)
        {
            testPlante = plateau[positionJoueur[1]][positionJoueur[0]]!.plante != null;
        }

        // Actions possibles
        // Arroser
        // Retirer Plante
        // Ajouter un Terrain
        // Ajouter une Plante
        // Récupérer le fruit (à faire + tard)
        // Vendre (à faire + tard)
        // Annuler
        // Quitter le jeu

        do
        {
            confirmation = false;
            Console.Clear();
            AfficherPlateau();
            Console.WriteLine();

            if (testAction)
            {
                Console.WriteLine("Action impossible\n");
                testAction = false;
            }
            Console.WriteLine("Que souhaitez-vous faire ?");

            if (selecteur == 0)
            {
                Console.Write("-->");
            }
            if (!testTerrain)
            {
                Console.ForegroundColor = ConsoleColor.Black;
            }
            Console.WriteLine("\t- Arroser le sol");
            Console.ResetColor();

            if (selecteur == 1)
            {
                Console.Write("-->");
            }
            if (!testPlante)
            {
                Console.ForegroundColor = ConsoleColor.Black;
            }
            Console.WriteLine("\t- Retirer les plantes");
            Console.ResetColor();

            if (selecteur == 2)
            {
                Console.Write("-->");
            }
            if (testTerrain)
            {
                Console.ForegroundColor = ConsoleColor.Black;
            }
            Console.WriteLine("\t- Ajouter un terrain");
            Console.ResetColor();

            if (selecteur == 3)
            {
                Console.Write("-->");
            }
            if (!testTerrain || testPlante)
            {
                Console.ForegroundColor = ConsoleColor.Black;
            }
            Console.WriteLine("\t- Ajouter une plante");
            Console.ResetColor();

            if (selecteur == 4)
            {
                Console.Write("-->");
            }
            if (!testTerrain)
            {
                Console.ForegroundColor = ConsoleColor.Black;
            }
            Console.WriteLine("\t- Afficher les informations du terrain");
            Console.ResetColor();

            if (selecteur == 5)
            {
                Console.Write("-->");
            }
            Console.WriteLine("\t- Laisser les plantes pousser");
            Console.ResetColor();

            if (selecteur == 6)
            {
                Console.Write("-->");
            }
            Console.WriteLine("\t- Retour");
            Console.ResetColor();

            if (selecteur == 7)
            {
                Console.Write("-->");
            }
            Console.WriteLine("\t- Quitter le jeu");
            Console.ResetColor();

            ConsoleKey choix = Console.ReadKey().Key;

            if (choix == ConsoleKey.UpArrow || choix == ConsoleKey.LeftArrow)
            {
                if (selecteur == 0)
                {
                    selecteur = 7;
                }
                else
                {
                    selecteur--;
                }
            }
            else if (choix == ConsoleKey.DownArrow || choix == ConsoleKey.RightArrow)
            {
                selecteur = (++selecteur) % 8;
            }
            else if (choix == ConsoleKey.Enter)
            {
                action = selecteur;
            }

            if (action == 7)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nÊtes-vous sûr de vouloir quitter la partie ?");
                Console.ResetColor();
                Console.WriteLine("Appuyez sur O ou Y pour confirmer");
                testConfirmation = char.ToUpper(Console.ReadKey().KeyChar);
                if (testConfirmation == 'Y' || testConfirmation == 'O')
                {
                    confirmation = true;
                }
            }
        }
        while ((action != 0 || !testTerrain) && (action != 1 || !testPlante) && (action != 2 || testTerrain) && (action != 3 || !testTerrain || testPlante) && (action != 4 || !testTerrain) && action != 5 && action != 6 && (action != 7 || !confirmation));

        return action;
    }

    public Terrain? ChoixTerrain()
    {
        char testConfirmation;
        bool confirmation = false;
        string typeTerrain = "Dune";
        int selecteur = 0;
        Terrain? result;
        do
        {
            Console.Clear();
            AfficherPlateau();

            if (selecteur == 0)
            {
                Console.Write("-->");
                typeTerrain = "Dune";
            }
            Console.WriteLine("\t- Dune");
            Console.ResetColor();

            if (selecteur == 1)
            {
                Console.Write("-->");
                typeTerrain = "Herbeux";
            }
            Console.WriteLine("\t- Herbeux");
            Console.ResetColor();

            if (selecteur == 2)
            {
                Console.Write("-->");
                typeTerrain = "Jungle";
            }
            Console.WriteLine("\t- Jungle");
            Console.ResetColor();

            if (selecteur == 3)
            {
                Console.Write("-->");
                typeTerrain = "Rocheux";
            }
            Console.WriteLine("\t- Rocheux");
            Console.ResetColor();

            if (selecteur == 4)
            {
                Console.Write("-->");
                typeTerrain = "Retour";
            }
            Console.WriteLine("\t- Retour");
            Console.ResetColor();

            ConsoleKey choix = Console.ReadKey().Key;

            if (choix == ConsoleKey.UpArrow || choix == ConsoleKey.LeftArrow)
            {
                if (selecteur == 0)
                {
                    selecteur = 4;
                }
                else
                {
                    selecteur--;
                }
            }
            else if (choix == ConsoleKey.DownArrow || choix == ConsoleKey.RightArrow)
            {
                selecteur = (++selecteur) % 5;
            }
            else if (choix == ConsoleKey.Enter)
            {
                if (selecteur < 4)
                {
                    Console.Write($"Êtes-vous sûr.e de vouloir mettre un terrain de type {typeTerrain} (cette action est ");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("définitive");
                    Console.ResetColor();
                    Console.WriteLine(") ?");

                    Console.WriteLine("Appuyez sur O ou Y pour confirmer");
                    testConfirmation = char.ToUpper(Console.ReadKey().KeyChar);
                    if (testConfirmation == 'Y' || testConfirmation == 'O')
                    {
                        confirmation = true;
                    }
                }
                else
                {
                    confirmation = true;
                }
            }
        }
        while (!confirmation);

        switch (selecteur)
        {
            case 0:
                result = new Dune();
                break;

            case 1:
                result = new Herbeux();
                break;

            case 2:
                result = new Jungle();
                break;

            case 3:
                result = new Rocheux();
                break;

            case 4:
                result = null;
                break;

            default:
                result = new Herbeux();
                break;
        }
        return result;
    }

    public Plante? ChoixPlante()
    {
        char testConfirmation;
        bool confirmation = false;
        string typePlante = "Branchiflore";
        int selecteur = 0;
        Plante? result;
        do
        {
            Console.Clear();
            AfficherPlateau();

            if (selecteur == 0)
            {
                Console.Write("-->");
                typePlante = "Branchiflore";
            }
            Console.WriteLine("\t- Branchiflore");
            Console.ResetColor();

            if (selecteur == 1)
            {
                Console.Write("-->");
                typePlante = "Fruit Étoilé";
            }
            Console.WriteLine("\t- Fruit Étoilé");
            Console.ResetColor();

            if (selecteur == 2)
            {
                Console.Write("-->");
                typePlante = "Mandragore";
            }
            Console.WriteLine("\t- Mandragore");
            Console.ResetColor();

            if (selecteur == 3)
            {
                Console.Write("-->");
                typePlante = "Rose de Fée";
            }
            Console.WriteLine("\t- Rose de Fée");
            Console.ResetColor();

            if (selecteur == 4)
            {
                Console.Write("-->");
                typePlante = "Retour";
            }
            Console.WriteLine("\t- Retour");
            Console.ResetColor();

            ConsoleKey choix = Console.ReadKey().Key;

            if (choix == ConsoleKey.UpArrow || choix == ConsoleKey.LeftArrow)
            {
                if (selecteur == 0)
                {
                    selecteur = 4;
                }
                else
                {
                    selecteur--;
                }
            }
            else if (choix == ConsoleKey.DownArrow || choix == ConsoleKey.RightArrow)
            {
                selecteur = (++selecteur) % 5;
            }
            else if (choix == ConsoleKey.Enter)
            {
                if (selecteur < 4)
                {
                    Console.WriteLine($"Êtes-vous sûr.e de vouloir planter une plante de type {typePlante} ?");

                    Console.WriteLine("Appuyez sur O ou Y pour confirmer");
                    testConfirmation = char.ToUpper(Console.ReadKey().KeyChar);
                    if (testConfirmation == 'Y' || testConfirmation == 'O')
                    {
                        confirmation = true;
                    }
                }
                else
                {
                    confirmation = true;
                }
            }
        }
        while (!confirmation);

        switch (selecteur)
        {
            case 0:
                result = new Branchiflore(plateau[positionJoueur[1]][positionJoueur[0]]!);
                break;

            case 1:
                result = new FruitEtoile(plateau[positionJoueur[1]][positionJoueur[0]]!);
                break;

            case 2:
                result = new Mandragore(plateau[positionJoueur[1]][positionJoueur[0]]!);
                break;

            case 3:
                result = new RoseDeFee(plateau[positionJoueur[1]][positionJoueur[0]]!);
                break;

            case 4:
                result = null;
                break;

            default:
                result = new Branchiflore(plateau[positionJoueur[1]][positionJoueur[0]]!);
                break;
        }
        return result;
    }

    public void MajMeteo()
    {
        Meteo meteo;
        Saison saison;
        int choixMeteo;
        int noSaison;
        // Calcul de la saison selon la date
        if ((date.Month == 03 && date.Day >= 21) || date.Month == 04 || date.Month == 05 || (date.Month == 06 && date.Day < 21))
        {
            noSaison = 0;
            saison = Saison.Printemps;
        }
        else if ((date.Month == 06 && date.Day >= 21) || date.Month == 07 || date.Month == 08 || (date.Month == 09 && date.Day < 21))
        {
            noSaison = 1;
            saison = Saison.Ete;
        }
        else if ((date.Month == 09 && date.Day >= 21) || date.Month == 10 || date.Month == 11 || (date.Month == 012 && date.Day < 21))
        {
            noSaison = 2;
            saison = Saison.Automne;
        }
        else
        {
            noSaison = 3;
            saison = Saison.Hiver;
        }
        Terrain.saison = saison;

        // Calcul de la meteo selon la saison
        int compteur = 0;
        double valeurMeteo = 0;
        choixMeteo = rng.Next(1, 101);
        while (compteur < probaMeteo[0].Length && valeurMeteo < choixMeteo)
        {
            valeurMeteo += probaMeteo[noSaison][compteur++];
        }
        switch (compteur)
        {
            case 0:
                meteo = Meteo.Normal;
                break;

            case 1:
                meteo = Meteo.Soleil;
                break;

            case 2:
                meteo = Meteo.Canicule;
                break;

            case 3:
                meteo = Meteo.Nuageux;
                break;

            case 4:
                meteo = Meteo.Pluie;
                break;

            case 5:
                meteo = Meteo.Orage;
                break;

            case 6:
                meteo = Meteo.Neige;
                break;

            default:
                meteo = Meteo.Normal;
                break;
        }
        Terrain.meteo = meteo;

        // Crue et ajout de l'eau sur les sols si pluie/orage/neige
        if (meteo == Meteo.Pluie || meteo == Meteo.Neige)
        {
            foreach (List<Terrain?> liste in plateau)
            {
                foreach (Terrain? terrain in liste)
                {
                    if (terrain != null)
                    {
                        terrain.HumidificationSol(0.2 + Math.Pow(-1, rng.Next(0, 2)) * rng.Next(0, 21) * 0.01);
                    }
                }
            }
        }
        else if (meteo == Meteo.Orage)
        {
            foreach (List<Terrain?> liste in plateau)
            {
                foreach (Terrain? terrain in liste)
                {
                    if (terrain != null)
                    {
                        terrain.HumidificationSol(0.4 + Math.Pow(-1, rng.Next(0, 2)) * rng.Next(0, 41) * 0.01);
                    }
                }
            }
        }
    }

    public int CalculerNbVoisins(int[] position, int espacement)
    {
        int result = 0;
        int departI = Math.Max(position[0] - espacement, 0);
        int departJ = Math.Max(position[1] - espacement, 0);
        int finI = Math.Min(position[0] + espacement, plateau.Count() - 1);
        int finJ = Math.Min(position[1] + espacement, plateau[0].Count() - 1);
        for (int i = departI; i <= finI; i++)
        {
            Console.WriteLine($"Boucle i : {i} / Position : {position[0]} / espacement : {espacement}");
            for (int j = departJ; j <= finJ; j++)
            {
                Console.WriteLine($"Boucle j : {j} / Position : {position[1]} / espacement : {espacement}");
                if ((i != position[0] || j != position[1]) && plateau[j][i] != null && plateau[j][i]!.plante != null)
                {
                    result++;
                }
            }
        }
        Console.WriteLine(result);
        System.Threading.Thread.Sleep(1000);
        return result;
    }

    public void PasserTemps(int nbJours)
    {
        for (int i = 0; i < nbJours; i++)
        {
            foreach (Plante plante in plantes)
            {
                plante.Grandir(CalculerNbVoisins(plante.terrain.position!, plante.espacement));
                plante.terrain.AdaptationSol();
            }
            date = date.AddDays(1);
            MajMeteo();
        }
        AfficherInventaire(); // Affiche la liste des plantes et leur nombre
        Console.WriteLine("Appuyer sur entrée pour continuer : ");
        Console.ReadLine();
    }

    public void Main()
    {
        int action;
        char testConfirmation;

        do
        {
            BoucleDeplacementPlateau();
            action = BoucleChoixAction();

            if (action == 0)
            {
                // Humidifier le sol
                if (plateau[positionJoueur[1]][positionJoueur[0]] != null)
                {
                    plateau[positionJoueur[1]][positionJoueur[0]]!.HumidificationSol(0.2);
                }
            }

            else if (action == 1)
            {
                // Enlever une plante
                plantes.Remove(plateau[positionJoueur[1]][positionJoueur[0]]!.plante!);
                plateau[positionJoueur[1]][positionJoueur[0]]!.plante = null;
            }

            else if (action == 2)
            {
                // Ajouter un terrain
                Terrain? nvTerrain = ChoixTerrain();
                if (nvTerrain != null)
                {
                    AjouterTerrain2(nvTerrain);
                }
            }

            else if (action == 3)
            {
                // Ajouter une plante
                Plante? nvPlante = ChoixPlante();
                if (nvPlante != null)
                {
                    AjouterPlante(nvPlante);
                }
            }

            else if (action == 4)
            {
                // Afficher infos sur le terrain et plante s'il y en a une
                Console.WriteLine($"Sur ce terrain, la température est de {plateau[positionJoueur[1]][positionJoueur[0]].temperature}, l'humidité de {plateau[positionJoueur[1]][positionJoueur[0]].humidite} et le taux de retention {plateau[positionJoueur[1]][positionJoueur[0]].retention}");
                bool testPlante = plateau[positionJoueur[1]][positionJoueur[0]]!.plante != null;
                if (testPlante)
                {
                    plateau[positionJoueur[1]][positionJoueur[0]]!.plante.AsciiArt();
                    plateau[positionJoueur[1]][positionJoueur[0]]!.plante.Informations();
                }
                

            }

            else if (action == 5)
            {
                // Passer du temps
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("\nÊtes-vous sûr de vouloir revenir plus tard ?");
                Console.ResetColor();
                Console.WriteLine("Appuyez sur O ou Y pour confirmer");
                testConfirmation = char.ToUpper(Console.ReadKey().KeyChar);
                if (testConfirmation == 'Y' || testConfirmation == 'O')
                {
                    int nbJours = -1;
                    Console.Clear();
                    while (nbJours <= 0)
                    {
                        Console.Write("Dans combien de jours souhaitez-vous revenir : ");
                        try
                        {
                            int test = Convert.ToInt32(Console.ReadLine()!);
                            nbJours = test;
                        }
                        catch (Exception)
                        {
                            Console.Clear();
                            Console.WriteLine("Écrivez une valeur numérique supérieure à 0 s'il vous plaît");
                        }
                    }
                    PasserTemps(nbJours);
                }

            }
        }
        while (action != 7);
    }
    public void AfficherInventaire()
    {
        //parcourir liste pour compter combien de chaque
        int nombreBranchiflore = 0;
        int nombreFiletDuDiable = 0;
        int nombreFruitEtoile = 0;
        int nombreMandragore = 0;
        int nombreRoseDeFee = 0;
        for (int i = 0; i < plantes.Count; i++)
        {
            if (plantes[i].nom == "Branchiflore")
            {
                nombreBranchiflore++;
            }
            else if (plantes[i].nom == "FiletDuDiable")
            {
                nombreFiletDuDiable++;
            }
            else if (plantes[i].nom == "FruitEtoile")
            {
                nombreFruitEtoile++;
            }
            else if (plantes[i].nom == "Mandragore")
            {
                nombreMandragore++;
            }
            else if (plantes[i].nom == "RoseDeFee")
            {
                nombreRoseDeFee++;
            }
        }
        Console.WriteLine("Inventaire :");
        Console.Write($"{nombreBranchiflore} 🌿");
        Console.Write($"{nombreFiletDuDiable} 👿");
        Console.Write($"{nombreFruitEtoile} ⭐");
        Console.Write($"{nombreMandragore} 🌱");
        Console.Write($"{nombreRoseDeFee} 🌷");
    }
}