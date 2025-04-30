public class Simulation
{
    public List<Plante> plantes { get; set; }
    public List<List<Terrain>> plateau { get; set; }
    public List<List<Terrain>> nouveauPlateau { get; set; }
    // A afficher lorsque l'utilisateur veut ajouter un terrain 
    // Cette liste possède une colonne et une ligne de plus pour permettre au joueur d'étendre son terrain 

    public Simulation()
    {
        plantes = new List<Plante> { };
        plateau = new List<List<Terrain>> { };
        nouveauPlateau = new List<List<Terrain>> { new List<Terrain> { } };
    }

    public void AfficherPlateau()
    {
        Console.Clear();
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
                if (plateau[i][j] != null)
                {
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
                    // --> semble être la meilleure solution pour le moment 
                }
                // écriture de la valeur en i,j
                Console.Write($"{plateau[i][j]}");
                Console.ResetColor();

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