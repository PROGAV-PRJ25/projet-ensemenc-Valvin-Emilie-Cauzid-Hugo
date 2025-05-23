using System.Reflection;

public class Ratiboiseur
{
    Random rng = new Random();
    public bool actif { get; set; }
    public int[] position { get; set; }
    public DateTime derniereAction { get; set; }
    public Simulation simulation { get; set; }

    public Ratiboiseur(Simulation simulation)
    {
        this.actif = false;
        this.position = new int[2];
        this.simulation = simulation;
    }

    public void Activation()
    {
        actif = true;
        position[0] = rng.Next(0, simulation.plateau[0].Count);
        position[1] = rng.Next(0, simulation.plateau.Count);
        derniereAction = DateTime.Now;
    }

    public void Desactivation()
    {
        actif = false;
        position = new int[2];
    }

    public void EssaiMouvement()
    {
        int aleatoire = rng.Next(0, 4);
        switch (aleatoire)
        {
            case 0:
                if (position[1] - 1 >= 0)
                {
                    position[1]--;
                }
                break;

            case 1:
                if (position[0] + 1 < simulation.plateau[0].Count)
                {
                    position[0]++;
                }
                break;

            case 2:
                if (position[1] + 1 < simulation.plateau.Count)
                {
                    position[1]++;
                }
                break;

            case 3:
                if (position[0] - 1 >= 0)
                {
                    position[0]--;
                }
                break;

            default:
                break;
        }
        if (simulation.plateau[position[0]][position[1]] != null && simulation.plateau[position[0]][position[1]]!.plante != null)
        {
            simulation.plantes.Remove(simulation.plateau[position[0]][position[1]]!.plante!);
            simulation.plateau[position[0]][position[1]]!.plante = null;
        }
        derniereAction = DateTime.Now;
    }
}