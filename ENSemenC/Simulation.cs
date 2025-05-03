public class Simulation
{
    public List<Plante> plantes { get; set; }
    public List<List<Terrain?>> plateau { get; set; }
    public List<List<Terrain?>> nouveauPlateau { get; set; }
    public List<List<string>> plateauAffiche { get; set; }
    // A afficher lorsque l'utilisateur veut ajouter un terrain 
    // Cette liste possède une colonne et une ligne de plus pour permettre au joueur d'étendre son terrain 

    public Simulation()
    {
        plantes = new List<Plante> { };
        plateau = new List<List<Terrain?>> { };
        nouveauPlateau = new List<List<Terrain?>> { new List<Terrain?> { } };
        plateauAffiche = new List<List<string>> { new List<string> { } };
    }

    public void AfficherPlateau()
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

        int largeur = plateau.Count;
        int longueur = plateau[0].Count;
        Console.Write("\t ");
        for (int i = 0; i < longueur; i++)
        // Affichage du numéro des colonnes
        {
            Console.Write($" {i + 1}  ");
        }

        Console.WriteLine();
        for (int i = 0; i < largeur; i++)
        {
            Console.Write(" \t[ ");
            for (int j = 0; j < longueur; j++)
            {
                // On passe ensuite dans tout le plateau en affichant les lettres si la case possède un terrain et s'il possède une plante
                if (plateau[i][j] != null)
                {
                    if (plateau[i][j]!.plante != null)
                    {
                        plateau[i][j]!.plante!.AfficherPlateau();
                        // le ! sert à affirmer que la valeur ne peux pas être null
                    }
                    else
                    {
                        Console.Write(" ");
                    }
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.Write("X");
                    Console.ResetColor();
                }
                /*// écriture de la valeur en i,j
                // Console.Write($"{plateauAffiche[i][j]}");
                // Console.ResetColor();*/

                // séparateur
                if (j != longueur - 1)
                {
                    Console.Write($" | ");
                }
            }

            // Affichage du numéro de la ligne
            Console.WriteLine($" ] {i + 1}");
        }
    }
}