namespace Tasca;

public class Fauna
{
    // Creem un Random compartit per a tots els peixos
    private static Random _rnd = new Random();
    
    public int X { get; set; }
    public int Y { get; set; }
    
    public (int X, int Y) Sentit { get; set; }

    public Fauna()
    {
        // Generem un número del 0 al 3 per triar una de les 4 direccions
        int direccio = _rnd.Next(0, 4); 

        if (direccio == 0) 
        { 
            Sentit = (0, -1); // Dalt
        } 
        else if (direccio == 1)
        {
            Sentit = (0, 1); // Baix
        } 
        else if (direccio == 2) 
        { 
            Sentit = (1, 0); // Dreta
        } 
        else if (direccio == 3) 
        { 
            Sentit = (-1, 0); // Esquerra
        }
    }
}