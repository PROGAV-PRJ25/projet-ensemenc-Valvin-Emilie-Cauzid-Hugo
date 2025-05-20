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
    public List<List<Terrain?>> nouveauPlateau { get; set; }
    // A afficher lorsque l'utilisateur veut ajouter un terrain 
    // Cette liste possède une colonne et une ligne vide de plus pour permettre au joueur d'étendre son terrain
    // Mettre à jour plateau après (méthode à coder)
    public List<List<string>> plateauAffiche { get; set; }
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
        nouveauPlateau = new List<List<Terrain?>> { new List<Terrain?> { null, null, null }, new List<Terrain?> { null, null, null }, new List<Terrain?> { null, null, null } };
        plateauAffiche = new List<List<string>> { new List<string> { } };
        positionJoueur = new int[2] { 0, 0 };
        probaMeteo = new double[][] { new double[] { 30, 25, 1, 20, 20, 2, 2 }, new double[] { 20, 35, 15, 10, 5, 15, 0 }, new double[] { 30, 10, 3, 25, 20, 10, 2 }, new double[] { 15, 15, 0, 30, 10, 5, 25 } };
        date = DateTime.Today;
        nbTerrain = 0;
        cote = 2;
    }

    public void AgrandirPlateau(bool ajoutLigne) // ajouter "=true" ? 
    {
        if (ajoutLigne)
        {
            List<Terrain?> nouvelleLigne = new List<Terrain?> { };
            List<Terrain?> nouvelleLigneNP = new List<Terrain?> { };
            for (int i = 0; i < nouveauPlateau[0].Count(); i++)
            {
                if (i < plateau[0].Count())
                {
                    nouvelleLigne.Add(null);
                }
                nouvelleLigneNP.Add(null);
            }
            plateau.Add(nouvelleLigne);
            nouveauPlateau.Add(nouvelleLigneNP);
        }
        else
        {
            for (int i = 0; i < nouveauPlateau.Count(); i++)
            {
                if (i < plateau.Count())
                {
                    plateau[i].Add(null);
                }
                nouveauPlateau[i].Add(null);
            }
        }
    }
    // Sert à agrandir plateau (et nouveauPlateau ?) lorsque l'utilisateur veut ajouter des plantes hors des limites déjà définies
    // Pour nouveauPlateau si ajout ligne faire boucle selon nb de valeurs puis add
    // si colonne faire une boucle dans toutes les lignes et ajouter 1 null
    // Pour plateau si ligne faire boucle selon nb de valeurs + test pour savoir bonne colonne 
    // si colonne boucle sur toutes les lignes + test pour savoir quelle colonne rajouter valeur

    public void AgrandirPlateau2() // ajouter "=true" ? 
    {
        List<Terrain?> nouvelleLigne = new List<Terrain?> { };
        for (int i = 0; i < plateau[0].Count(); i++)
        {
            nouvelleLigne.Add(null);
        }
        plateau.Add(nouvelleLigne);

        for (int i = 0; i < plateau.Count(); i++)
        {
            plateau[i].Add(null);
        }
    }

    public void AjouterTerrain(Terrain terrain)
    {
        if (positionJoueur[0] >= plateau[0].Count())
        {
            AgrandirPlateau(false);
        }
        if (positionJoueur[1] >= plateau.Count())
        {
            AgrandirPlateau(true);
        }
        plateau[positionJoueur[1]][positionJoueur[0]] = terrain;
        nouveauPlateau[positionJoueur[1]][positionJoueur[0]] = terrain;
        terrain.position![0] = positionJoueur[1];
        terrain.position![1] = positionJoueur[0];
    }

    public void AjouterTerrain2(Terrain terrain)
    {
        plateau[positionJoueur[1]][positionJoueur[0]] = terrain;
        nouveauPlateau[positionJoueur[1]][positionJoueur[0]] = terrain;
        terrain.position![0] = positionJoueur[1];
        terrain.position![1] = positionJoueur[0];
        nbTerrain++;
        if (nbTerrain == cote * cote)
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

    public void AfficherPlateau(bool nvPlateau = false)
    {
        /*
        // plateau[i][j];
        // On doit afficher la plante dans la petite case
        // Utiliser foreach (ou équivalent for) ? 
        // --> permet de passer partout de manière sûre 
        // --> comment faire si case vide sans list nullable
        // Créer un terrain vide ?
        // --> on peut passer dans toutes les cases avec la même fonction
        // --> relier terrain avec plante
        // --> bcp d'utilisatiion mémoire
        // Utiliser la liste de plante et remonter au terrain pour savoir où mettre des plantes <==
        // --> trouver comment trouver l'emplacement sur l'affichage (grâce à une liste de liste dédiée à l'affichage ?)
        // --> semble être la meilleure solution pour le moment */
        Console.Clear();
        List<List<Terrain?>> plato;
        if (nvPlateau)
        { plato = nouveauPlateau; }
        else
        { plato = plateau; }
        /*
        // Création d'une liste de listes contenant " "
        List<string> ligne = new List<string> { };
        for (int i = 0; i < plateau.Count(); i++)
        {
            for (int j = 0; j < plateau[0].Count(); j++)
            {
                ligne.Add(" ");
            }
            plateauAffiche.Add(ligne);
            ligne = new List<string> { };
        }


        // On remplit ensuite les bonnes cases contenant les plantes de la lettre qui convient
        int[] positionPlante = new int[2];
        foreach (Plante plante in plantes)
        {
            positionPlante = plante.terrain.position;
            plateauAffiche[positionPlante[0]][positionPlante[1]] = plante.AfficherPlateau2();
        } */
        bool coulFond = true;
        int largeur = plato.Count;
        int longueur = plato[0].Count;
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
                    coulFond = false;
                    Console.BackgroundColor = ConsoleColor.White;
                }
                Console.Write(" ");
                // On passe ensuite dans tout le plateau en affichant les lettres si la case possède un terrain et s'il possède une plante
                if (plato[i][j] != null)
                {
                    if (coulFond)
                    {
                        plato[i][j]!.GetCouleur();
                    }
                    if (plato[i][j]!.plante != null)
                    {
                        plato[i][j]!.plante!.AfficherPlateau();
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
                /*// écriture de la valeur en i,j
                // Console.Write($"{plateauAffiche[i][j]}");
                // Console.ResetColor();*/

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

    public void DeplacementPlateau(Orientation orientation, bool nvPlateau = false)
    {
        List<List<Terrain?>> plato;
        if (nvPlateau)
        { plato = nouveauPlateau; }
        else
        { plato = plateau; }

        switch (orientation)
        {
            case Orientation.Nord:
                positionJoueur[1]--;
                if (positionJoueur[1] < 0)
                {
                    positionJoueur[1] = plato.Count() - 1;
                }
                break;
            case Orientation.Est:
                positionJoueur[0]++;
                if (positionJoueur[0] >= plato[0].Count())
                {
                    positionJoueur[0] = 0;
                }
                break;
            case Orientation.Ouest:
                positionJoueur[0]--;
                if (positionJoueur[0] < 0)
                {
                    positionJoueur[0] = plato[0].Count() - 1;
                }
                break;
            case Orientation.Sud:
                positionJoueur[1]++;
                if (positionJoueur[1] >= plato.Count())
                {
                    positionJoueur[1] = 0;
                }
                break;
            default:
                break;
        }
    }

    public void BoucleDeplacementPlateau(bool nvPlateau = false)
    {
        ConsoleKey touche;
        bool fin = false;
        do
        {
            AfficherPlateau(nvPlateau);
            touche = Console.ReadKey().Key;
            if (touche == ConsoleKey.LeftArrow)
            {
                DeplacementPlateau(Orientation.Ouest, nvPlateau);
            }
            else if (touche == ConsoleKey.RightArrow)
            {
                DeplacementPlateau(Orientation.Est, nvPlateau);
            }
            else if (touche == ConsoleKey.UpArrow)
            {
                DeplacementPlateau(Orientation.Nord, nvPlateau);
            }
            else if (touche == ConsoleKey.DownArrow)
            {
                DeplacementPlateau(Orientation.Sud, nvPlateau);
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
            Console.WriteLine("\t- Laisser les plantes pousser");
            Console.ResetColor();

            if (selecteur == 5)
            {
                Console.Write("-->");
            }
            Console.WriteLine("\t- Retour");
            Console.ResetColor();

            if (selecteur == 6)
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
                    selecteur = 6;
                }
                else
                {
                    selecteur--;
                }
            }
            else if (choix == ConsoleKey.DownArrow || choix == ConsoleKey.RightArrow)
            {
                selecteur = (++selecteur) % 7;
            }
            else if (choix == ConsoleKey.Enter)
            {
                action = selecteur;
            }

            if (action == 6)
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
        while ((action != 0 || !testTerrain) && (action != 1 || !testPlante) && (action != 2 || testTerrain) && (action != 3 || !testTerrain || testPlante) && action != 4 && action != 5 && (action != 6 || !confirmation));

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
        }
        Console.WriteLine("Appuyer sur entrée pour continuer : ");
        Console.ReadLine();
    }

    public void Main()
    {
        int action;
        char testConfirmation;

        do
        {
            /*foreach (List<Terrain?> liste in plateau)
            {
                foreach (Terrain? terrain in liste)
                {
                    if (terrain != null)
                    {
                        Console.WriteLine($"{terrain.position![1]}, {terrain.position![0]}");
                    }
                }
            }
            System.Threading.Thread.Sleep(1000);*/
            BoucleDeplacementPlateau();
            action = BoucleChoixAction();

            if (action == 0)
            {
                if (plateau[positionJoueur[1]][positionJoueur[0]] != null)
                {
                    plateau[positionJoueur[1]][positionJoueur[0]]!.HumidificationSol(0.2);
                }
            }

            else if (action == 1)
            {
                plantes.Remove(plateau[positionJoueur[1]][positionJoueur[0]]!.plante!);
                plateau[positionJoueur[1]][positionJoueur[0]]!.plante = null;
            }

            else if (action == 2)
            {
                // BoucleDeplacementPlateau(true);
                Terrain? nvTerrain = ChoixTerrain();
                if (nvTerrain != null)
                {
                    AjouterTerrain2(nvTerrain);
                }
            }

            else if (action == 3)
            {
                Plante? nvPlante = ChoixPlante();
                if (nvPlante != null)
                {
                    AjouterPlante(nvPlante);
                }
            }

            else if (action == 4)
            {
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
        while (action != 6);
    }
    public void AfficherInventaire()
    {
        //afficher la date
        DateTime thisDay = DateTime.Today;
        Console.WriteLine(thisDay.ToString("D"));
        //parcourir liste pour compter combien de chaque
        int nombreBranchiflore = 0;
        int nombreFiletDuDiable = 0;
        int nombreFruitEtoile = 0;
        int nombreMandragore = 0;
        int nombreRoseDeFee = 0;
        for (int i = 0; i < plantes.Count; i++) {
            if (plantes[i].nom=="Branchiflore") {
                nombreBranchiflore++;
            }
            else if (plantes[i].nom=="FiletDuDiable") {
                nombreFiletDuDiable++;
            }
            else if (plantes[i].nom=="FruitEtoile") {
                nombreFruitEtoile++;
            }
            else if (plantes[i].nom=="Mandragore") {
                nombreMandragore++;
            }
            else if (plantes[i].nom=="RoseDeFee") {
                nombreRoseDeFee++;
            }
        }
        Console.WriteLine("Inventaire :");
        if (nombreBranchiflore>0) {
            Console.Write($"{nombreBranchiflore} 🌿");
        }
        else if (nombreFiletDuDiable>0) {
            Console.Write($"{nombreFiletDuDiable} 👿");
        }
        else if (nombreFruitEtoile>0) {
            Console.Write($"{nombreFruitEtoile} ⭐");
        }
        else if (nombreMandragore>0) {
            Console.Write($"{nombreMandragore} 🌱");
        }
        else if (nombreRoseDeFee>0) {
            Console.Write($"{nombreRoseDeFee} 🌷");
        }
    }
    

}