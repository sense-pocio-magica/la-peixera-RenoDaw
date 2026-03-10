//a
namespace Tasca;

public class Pop : Fauna
{
    private static Random _rnd = new Random();
    
    public Pop() : base(Sexe.Neutre)
    {
        // Forcem que el Pop NOMÉS tingui 4 opcions (sempre hi ha un 0)
        int direccio = _rnd.Next(0, 4); 

        if (direccio == 0) 
        { 
            Sentit = (0, -1); // Dalt
        } 
        else if (direccio == 1) 
        { 
            Sentit = (0, 1);  // Baix
        } 
        else if (direccio == 2) 
        { 
            Sentit = (1, 0);  // Dreta
        } 
        else if (direccio == 3) 
        { 
            Sentit = (-1, 0); // Esquerra
        }
    }
    
    
}