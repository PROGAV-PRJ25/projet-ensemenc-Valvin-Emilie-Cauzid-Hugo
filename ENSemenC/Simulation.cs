//à faire : 
//tester si plateau marche, le rendre joli avec curseur -> Hugo
//partie de droite avec les infos sur les plantes et tout, trouver icones qui correspondent aux infos, une autre fonction qu'afficher plateau -> Emilie
//faire actions que peut faire joueur, à quoi il a accès

public class Simulation
{
    public List<Plante> plantes { get; set; }
    public List<List<Terrain?>> plateau { get; set; }
    public List<List<Terrain?>> nouveauPlateau { get; set; }
    // A afficher lorsque l'utilisateur veut ajouter un terrain 
    // Cette liste possède une colonne et une ligne vide de plus pour permettre au joueur d'étendre son terrain
    // Mettre à jour plateau après (méthode à coder)
    public List<List<string>> plateauAffiche { get; set; }
    public int[] positionJoueur { get; set; }

    public Simulation()
    {
        plantes = new List<Plante> { };
        // Initialisation en temps que terrain de taille 1x1 vide
        plateau = new List<List<Terrain?>> { new List<Terrain?> { null, null }, new List<Terrain?> { null, null } };
        // Initialisation en temps que terrain de taille 2x2 vide
        nouveauPlateau = new List<List<Terrain?>> { new List<Terrain?> { null, null, null }, new List<Terrain?> { null, null, null }, new List<Terrain?> { null, null, null } };
        plateauAffiche = new List<List<string>> { new List<string> { } };
        positionJoueur = new int[2] { 0, 0 };
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

    public void AjouterTerrain(int[] position, Terrain terrain)
    {
        if (position[0] > plateau[0].Count())
        {
            AgrandirPlateau(false);
        }
        else if (position[1] > plateau.Count())
        {
            AgrandirPlateau(true);
        }
        plateau[position[1]][position[0]] = terrain;
        nouveauPlateau[position[1]][position[0]] = terrain;
    }

    public void AjouterPlante(int[] position, Plante plante)
    {
        plateau[position[1]][position[0]]!.plante = plante;
        plante.terrain = plateau[position[1]][position[0]]!;
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

    public void DeplacementPlateau(Orientation orientation)
    {
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

    public int BoucleChoixAction()
    {
        int action = 0;
        // Actions possibles 
        // Arroser 
        // Retirer Plante 
        // Ajouter un Terrain 
        // Récupérer le fruit 
        // Vendre 
        // Annuler 
        // Quitter le jeu
        return action;
    }
}