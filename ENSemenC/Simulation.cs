using System.Threading.Tasks.Dataflow;

public class Simulation
{
    Random Rng = new Random();
    public List<Plante> Plantes { get; set; }
    public List<List<Terrain?>> Plateau { get; set; }
    public int[] PositionJoueur { get; set; }
    private double[][] ProbaMeteo { get; }
    // Normal = 1, Soleil, Canicule, Nuageux, Pluie, Orage, Neige 
    public DateTime Date { get; set; }
    public DateTime HeureUrgence { get; set; }
    public TimeSpan EcartTemps { get; set; }
    public int NbTerrain { get; set; }
    public int Cote { get; set; }
    private bool Urgence { get; set; }
    private Ratiboiseur ratiboiseur { get; set; }

    public Simulation()
    {
        Plantes = new List<Plante> { };
        // Initialisation en temps que terrain de taille 1x1 vide
        Plateau = new List<List<Terrain?>> { new List<Terrain?> { null, null }, new List<Terrain?> { null, null } };
        // Initialisation en temps que terrain de taille 2x2 vide
        PositionJoueur = new int[2] { 0, 0 };
        ProbaMeteo = new double[][] { new double[] { 30, 25, 1, 20, 20, 2, 2 }, new double[] { 20, 35, 15, 10, 5, 15, 0 }, new double[] { 30, 10, 3, 25, 20, 10, 2 }, new double[] { 15, 15, 0, 30, 10, 5, 25 } };
        Date = DateTime.Today;
        HeureUrgence = DateTime.Now;
        EcartTemps = new TimeSpan(0, 0, 5);
        NbTerrain = 0;
        Cote = 2;
        Urgence = false;
        ratiboiseur = new Ratiboiseur(this);
        MajMeteo();
    }


    public void AgrandirPlateau()
    {
        List<Terrain?> nouvelleLigne = new List<Terrain?> { };
        // Ajout d'une ligne de terrains vide
        for (int i = 0; i < Plateau[0].Count(); i++)
        {
            nouvelleLigne.Add(null);
        }
        Plateau.Add(nouvelleLigne);

        // Ajout d'une colonne de terrains vide
        for (int i = 0; i < Plateau.Count(); i++)
        {
            Plateau[i].Add(null);
        }
    }

    public void AjouterTerrain(Terrain terrain)
    {
        // Ajout terrain dans le Plateau + MAJ de la position du terrain dans l'itération
        Plateau[PositionJoueur[1]][PositionJoueur[0]] = terrain;
        terrain.Position![0] = PositionJoueur[1];
        terrain.Position![1] = PositionJoueur[0];
        NbTerrain++;
        if (NbTerrain == Cote * Cote && Cote <= 10)
        {
            AgrandirPlateau();
            Cote++;
        }
    }

    public void AjouterPlante(Plante plante)
    {
        Plateau[PositionJoueur[1]][PositionJoueur[0]]!.plante = plante;
        Plantes.Add(plante);
        // plante.terrain = Plateau[PositionJoueur[1]][PositionJoueur[0]]!;
        // Vérifier que ce n'est pas null !!!
    }

    public void AfficherPlateau()
    {
        Console.Clear();

        if (Urgence)
        {
            Console.ForegroundColor = ConsoleColor.Red;
        }

        //afficher la Date
        Console.WriteLine(Date.ToString("D"));

        if (Urgence)
        {
            if (DateTime.Now - ratiboiseur.DerniereAction > EcartTemps)
            {
                for (int i = 0; i < (DateTime.Now - ratiboiseur.DerniereAction).Divide(5).Seconds; i++)
                {
                    HeureUrgence = HeureUrgence.AddMinutes(1);
                }
            }
            // Console.WriteLine($"{HeureUrgence.Hour}h {HeureUrgence.Minute}min {HeureUrgence.Second}");
            Console.WriteLine(HeureUrgence.ToString("hh:mm:ss"));
        }

        Console.WriteLine($"Saison : {Terrain.Saison}");
        Console.WriteLine($"Météo : {Terrain.Meteo}");

        bool coulFond = true;
        int largeur = Plateau.Count;
        int longueur = Plateau[0].Count;
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
                if (PositionJoueur[0] == j && PositionJoueur[1] == i)
                {
                    // Fond de couleur blanche pour indiquer l'emplacement du joueur
                    coulFond = false;
                    Console.BackgroundColor = ConsoleColor.White;
                }
                Console.Write(" ");
                // On passe ensuite dans tout le Plateau en affichant les bonnes choses selon ce que la case possède
                if (Plateau[i][j] != null)
                {
                    if (coulFond)
                    {
                        Plateau[i][j]!.GetCouleur();
                    }
                    if (Plateau[i][j]!.plante != null)
                    {
                        Plateau[i][j]!.plante!.AfficherPlateau();
                        // le ! sert à affirmer que la valeur ne peux pas être null
                        if (Urgence)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                        }
                    }
                    else
                    {
                        Console.Write("   ");
                        Console.ResetColor();
                        if (Urgence)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                        }
                    }
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.Write(" X ");
                    Console.ResetColor();
                    if (Urgence)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                    }
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
                    if (Urgence)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                    }
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
            if (Urgence)
            {
                Console.ForegroundColor = ConsoleColor.Red;
            }
            Console.WriteLine($" ] {i + 1}");
        }
    }

    public void DeplacementPlateau(Orientation orientation)
    {
        // Met à jour la position du joueur dans le Plateau
        switch (orientation)
        {
            case Orientation.Nord:
                PositionJoueur[1]--;
                if (PositionJoueur[1] < 0)
                {
                    PositionJoueur[1] = Plateau.Count() - 1;
                }
                break;
            case Orientation.Est:
                PositionJoueur[0]++;
                if (PositionJoueur[0] >= Plateau[0].Count())
                {
                    PositionJoueur[0] = 0;
                }
                break;
            case Orientation.Ouest:
                PositionJoueur[0]--;
                if (PositionJoueur[0] < 0)
                {
                    PositionJoueur[0] = Plateau[0].Count() - 1;
                }
                break;
            case Orientation.Sud:
                PositionJoueur[1]++;
                if (PositionJoueur[1] >= Plateau.Count())
                {
                    PositionJoueur[1] = 0;
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
            // Lit la touche pressée pour bouger dans le Plateau
            AfficherPlateau();
            if (Urgence)
            {
                Console.WriteLine("ALERTE RATIBOISEUR");
            }

            if (Urgence)
            {
                if (DateTime.Now - ratiboiseur.DerniereAction > EcartTemps)
                {
                    for (int i = 0; i < (DateTime.Now - ratiboiseur.DerniereAction).Divide(5).Seconds; i++)
                    {
                        ratiboiseur.EssaiMouvement();
                        HeureUrgence = HeureUrgence.AddMinutes(1);
                    }
                    ratiboiseur.DerniereAction = DateTime.Now;
                }
            }

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
        int selecteur = 0;

        //Tests afin de savoir si il y a un terrain et/ou une plante sur la position du joueur
        bool testPlante = false;
        bool testTerrain = Plateau[PositionJoueur[1]][PositionJoueur[0]] != null;
        if (testTerrain)
        {
            testPlante = Plateau[PositionJoueur[1]][PositionJoueur[0]]!.plante != null;
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
            Console.ResetColor();

            if (Urgence)
            {
                if (DateTime.Now - ratiboiseur.DerniereAction > EcartTemps)
                {
                    for (int i = 0; i < (DateTime.Now - ratiboiseur.DerniereAction).Divide(5).Seconds; i++)
                    {
                        ratiboiseur.EssaiMouvement();
                        HeureUrgence = HeureUrgence.AddMinutes(1);
                    }
                    ratiboiseur.DerniereAction = DateTime.Now;
                }
            }

            Console.WriteLine("Que souhaitez-vous faire ?");

            if (selecteur == 0)
            {
                Console.Write("-->");
            }
            if (!testTerrain || Urgence)
            {
                Console.ForegroundColor = ConsoleColor.Black;
            }
            Console.WriteLine("\t- Arroser le sol");
            Console.ResetColor();

            if (selecteur == 1)
            {
                Console.Write("-->");
            }
            if (Urgence)
            {
                if (ratiboiseur.Position[0] == PositionJoueur[1] && ratiboiseur.Position[1] == PositionJoueur[0])
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\t- Faire fuir le ratiboiseur");
                }
            }
            else
            {
                if (!testPlante)
                {
                    Console.ForegroundColor = ConsoleColor.Black;
                }
                Console.WriteLine("\t- Retirer les Plantes");
            }
            Console.ResetColor();

            if (selecteur == 2)
            {
                Console.Write("-->");
            }
            if (testTerrain || Urgence)
            {
                Console.ForegroundColor = ConsoleColor.Black;
            }
            Console.WriteLine("\t- Ajouter un terrain");
            Console.ResetColor();

            if (selecteur == 3)
            {
                Console.Write("-->");
            }
            if (!testTerrain || testPlante || Urgence)
            {
                Console.ForegroundColor = ConsoleColor.Black;
            }
            Console.WriteLine("\t- Ajouter une plante");
            Console.ResetColor();

            if (selecteur == 4)
            {
                Console.Write("-->");
            }
            if (!testTerrain || Urgence)
            {
                Console.ForegroundColor = ConsoleColor.Black;
            }
            Console.WriteLine("\t- Afficher les informations du terrain");
            Console.ResetColor();

            if (selecteur == 5)
            {
                Console.Write("-->");
            }
            if (Urgence)
            {
                Console.ForegroundColor = ConsoleColor.Black;
            }
            Console.WriteLine("\t- Laisser les Plantes pousser");
            Console.ResetColor();

            if (selecteur == 6)
            {
                Console.Write("-->");
            }
            Console.WriteLine("\t- Retour");

            if (selecteur == 7)
            {
                Console.Write("-->");
            }
            Console.WriteLine("\t- Quitter le jeu");

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
        while ((action != 0 || !testTerrain || Urgence) && (action != 1 || !testPlante) && (action != 1 || !Urgence || ratiboiseur.Position[0] != PositionJoueur[1] || ratiboiseur.Position[1] != PositionJoueur[0]) && (action != 2 || testTerrain || Urgence) && (action != 3 || !testTerrain || testPlante) && (action != 4 || !testTerrain) && (action != 5 || Urgence) && action != 6 && (action != 7 || !confirmation));

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
                result = new Branchiflore(Plateau[PositionJoueur[1]][PositionJoueur[0]]!);
                break;

            case 1:
                result = new FruitEtoile(Plateau[PositionJoueur[1]][PositionJoueur[0]]!);
                break;

            case 2:
                result = new Mandragore(Plateau[PositionJoueur[1]][PositionJoueur[0]]!);
                break;

            case 3:
                result = new RoseDeFee(Plateau[PositionJoueur[1]][PositionJoueur[0]]!);
                break;

            case 4:
                result = null;
                break;

            default:
                result = new Branchiflore(Plateau[PositionJoueur[1]][PositionJoueur[0]]!);
                break;
        }
        return result;
    }

    public void MajMeteo()
    {
        Meteos meteo;
        Saisons saison;
        int choixMeteo;
        int noSaison;
        // Calcul de la saison selon la Date
        if ((Date.Month == 03 && Date.Day >= 21) || Date.Month == 04 || Date.Month == 05 || (Date.Month == 06 && Date.Day < 21))
        {
            noSaison = 0;
            saison = Saisons.Printemps;
        }
        else if ((Date.Month == 06 && Date.Day >= 21) || Date.Month == 07 || Date.Month == 08 || (Date.Month == 09 && Date.Day < 21))
        {
            noSaison = 1;
            saison = Saisons.Ete;
        }
        else if ((Date.Month == 09 && Date.Day >= 21) || Date.Month == 10 || Date.Month == 11 || (Date.Month == 012 && Date.Day < 21))
        {
            noSaison = 2;
            saison = Saisons.Automne;
        }
        else
        {
            noSaison = 3;
            saison = Saisons.Hiver;
        }
        Terrain.Saison = saison;

        // Calcul de la meteo selon la saison
        int compteur = 0;
        double valeurMeteo = 0;
        choixMeteo = Rng.Next(0, 100);
        while (compteur < ProbaMeteo[0].Length && valeurMeteo < choixMeteo)
        {
            valeurMeteo += ProbaMeteo[noSaison][compteur++];
        }
        switch (compteur)
        {
            case 0:
                meteo = Meteos.Normal;
                break;

            case 1:
                meteo = Meteos.Soleil;
                break;

            case 2:
                meteo = Meteos.Canicule;
                break;

            case 3:
                meteo = Meteos.Nuageux;
                break;

            case 4:
                meteo = Meteos.Pluie;
                break;

            case 5:
                meteo = Meteos.Orage;
                break;

            case 6:
                meteo = Meteos.Neige;
                break;

            default:
                meteo = Meteos.Normal;
                break;
        }
        Terrain.Meteo = meteo;

        // Crue et ajout de l'eau sur les sols si pluie/orage/neige
        foreach (List<Terrain?> liste in Plateau)
        {
            foreach (Terrain? terrain in liste)
            {
                if (meteo == Meteos.Pluie || meteo == Meteos.Neige)
                {
                    if (terrain != null)
                    {
                        terrain.HumidificationSol(0.2 + Math.Pow(-1, Rng.Next(0, 2)) * Rng.Next(0, 21) * 0.01);
                    }
                }
                else if (meteo == Meteos.Orage)
                {
                    if (terrain != null)
                    {
                        terrain.HumidificationSol(0.4 + Math.Pow(-1, Rng.Next(0, 2)) * Rng.Next(0, 41) * 0.01);
                    }
                }
                if (terrain != null)
                {
                    terrain.GererLumiere();
                }
            }
        }
    }

    public int CalculerNbVoisins(int[] position, int espacement)
    {
        int result = 0;
        int departI = Math.Max(position[0] - espacement, 0);
        int departJ = Math.Max(position[1] - espacement, 0);
        int finI = Math.Min(position[0] + espacement, Plateau.Count() - 1);
        int finJ = Math.Min(position[1] + espacement, Plateau[0].Count() - 1);
        for (int i = departI; i <= finI; i++)
        {
            // Console.WriteLine($"Boucle i : {i} / Position : {position[0]} / espacement : {espacement}");
            for (int j = departJ; j <= finJ; j++)
            {
                // Console.WriteLine($"Boucle j : {j} / Position : {position[1]} / espacement : {espacement}");
                if ((i != position[0] || j != position[1]) && Plateau[j][i] != null && Plateau[j][i]!.plante != null)
                {
                    result++;
                }
            }
        }
        // Console.WriteLine(result);
        // System.Threading.Thread.Sleep(1000);
        return result;
    }

    public void PasserTemps(int nbJours)
    {
        bool testPlanteInvasive = false;
        for (int i = 0; i < nbJours; i++)
        {
            foreach (Plante plante in Plantes)
            {
                plante.Grandir(CalculerNbVoisins(plante.terrain.Position!, plante.Espacement));
                plante.terrain.AdaptationSol();
                if (plante.GetType() == typeof(FiletDuDiable))
                {
                    testPlanteInvasive = true;
                }
            }
            Date = Date.AddDays(1);
            MajMeteo();
            foreach (List<Terrain?> liste in Plateau)
            {
                foreach (Terrain? terrain in liste)
                {
                    if (terrain != null && terrain.plante == null && Rng.Next(0, 20) == 0)
                    {
                        int[] anciennePosition = new int[2];
                        anciennePosition[0] = PositionJoueur[0];
                        anciennePosition[1] = PositionJoueur[1];
                        PositionJoueur[0] = terrain.Position![1];
                        PositionJoueur[1] = terrain.Position![0];
                        AjouterPlante(new FiletDuDiable(terrain));
                        PositionJoueur[0] = anciennePosition[0];
                        PositionJoueur[1] = anciennePosition[1];
                    }
                }
            }
            if (Plantes.Count > 5 && !testPlanteInvasive && Rng.Next(0, 33) == 0)
            {
                ratiboiseur.Activation();
                Urgence = true;
                HeureUrgence = DateTime.Now;
            }
        }
        AfficherInventaire(); // Affiche la liste des Plantes et leur nombre
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
                if (Plateau[PositionJoueur[1]][PositionJoueur[0]] != null)
                {
                    Plateau[PositionJoueur[1]][PositionJoueur[0]]!.HumidificationSol(0.2);
                }
            }

            else if (action == 1)
            {
                if (Urgence)
                {
                    ratiboiseur.Desactivation();
                    Urgence = false;
                }
                else
                {
                    // Enlever une plante
                    Plantes.Remove(Plateau[PositionJoueur[1]][PositionJoueur[0]]!.plante!);
                    Plateau[PositionJoueur[1]][PositionJoueur[0]]!.plante = null;
                }
            }

            else if (action == 2)
            {
                // Ajouter un terrain
                Terrain? nvTerrain = ChoixTerrain();
                if (nvTerrain != null)
                {
                    AjouterTerrain(nvTerrain);
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
                Console.Clear();
                AfficherPlateau();
                Console.WriteLine($"Sur ce terrain, la température est de {Plateau[PositionJoueur[1]][PositionJoueur[0]]!.Temperature}, l'humidité de {Plateau[PositionJoueur[1]][PositionJoueur[0]]!.Humidite}, le taux de retention d'eau de {Plateau[PositionJoueur[1]][PositionJoueur[0]]!.Retention} et la luminosité de {Plateau[PositionJoueur[1]][PositionJoueur[0]]!.Luminosite}");
                bool testPlante = Plateau[PositionJoueur[1]][PositionJoueur[0]]!.plante != null;
                if (testPlante)
                {
                    if (Plateau[PositionJoueur[1]][PositionJoueur[0]]!.plante!.Vivante)
                    {
                        Plateau[PositionJoueur[1]][PositionJoueur[0]]!.plante!.AsciiArt();
                        Plateau[PositionJoueur[1]][PositionJoueur[0]]!.plante!.Informations();
                    }
                    else
                    {
                        Console.WriteLine("La plante est morte...");
                    }
                }
                Console.WriteLine("Appuyer sur entrée pour continuer : ");
                Console.ReadLine();
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
        for (int i = 0; i < Plantes.Count; i++)
        {
            if (Plantes[i].Nom== "Branchiflore")
            {
                nombreBranchiflore++;
            }
            else if (Plantes[i].Nom== "FiletDuDiable")
            {
                nombreFiletDuDiable++;
            }
            else if (Plantes[i].Nom== "FruitEtoile")
            {
                nombreFruitEtoile++;
            }
            else if (Plantes[i].Nom== "Mandragore")
            {
                nombreMandragore++;
            }
            else if (Plantes[i].Nom== "RoseDeFee")
            {
                nombreRoseDeFee++;
            }
        }
        Console.WriteLine("Inventaire :");
        Console.Write($"{nombreBranchiflore} 🌿\t");
        Console.Write($"{nombreFiletDuDiable} 👿\t");
        Console.Write($"{nombreFruitEtoile} ⭐\t");
        Console.Write($"{nombreMandragore} 🌱\t");
        Console.WriteLine($"{nombreRoseDeFee} 🌷\t");
    }
}