using System.Reflection;

public class Ratiboiseur
{
    Random Rng = new Random();
    public bool Actif { get; set; }
    public int[] Position { get; set; }
    public DateTime DerniereAction { get; set; }
    public Simulation simulation { get; set; }

    public Ratiboiseur(Simulation simulation)
    {
        Actif = false;
        Position = new int[2];
        this.simulation = simulation;
    }

    public void Activation()
    {
        Actif = true;
        Position[0] = Rng.Next(0, simulation.Plateau[0].Count);
        Position[1] = Rng.Next(0, simulation.Plateau.Count);
        DerniereAction = DateTime.Now;
    }

    public void Desactivation()
    {
        Actif = false;
        Position = new int[2];
    }

    public void EssaiMouvement()
    {
        int aleatoire = Rng.Next(0, 4);
        switch (aleatoire)
        {
            case 0:
                if (Position[1] - 1 >= 0)
                {
                    Position[1]--;
                }
                break;

            case 1:
                if (Position[0] + 1 < simulation.Plateau[0].Count)
                {
                    Position[0]++;
                }
                break;

            case 2:
                if (Position[1] + 1 < simulation.Plateau.Count)
                {
                    Position[1]++;
                }
                break;

            case 3:
                if (Position[0] - 1 >= 0)
                {
                    Position[0]--;
                }
                break;

            default:
                break;
        }
        if (simulation.Plateau[Position[0]][Position[1]] != null && simulation.Plateau[Position[0]][Position[1]]!.plante != null)
        {
            simulation.Plantes.Remove(simulation.Plateau[Position[0]][Position[1]]!.plante!);
            simulation.Plateau[Position[0]][Position[1]]!.plante = null;
        }
        DerniereAction = DateTime.Now;
    }
}