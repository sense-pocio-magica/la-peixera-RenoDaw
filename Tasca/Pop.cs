namespace Tasca;

public class Pop : Fauna
{
    private static Random _rnd = new Random();
    
    public Pop()
    {
        // Forcem que el Pop NOMÉS tingui 4 opcions (sempre hi ha un 0)
        int direccio = _rnd.Next(0, 4); 

        if (direccio == 0) 
        { 
            DirX = 0; DirY = -1; // Dalt
        } 
        else if (direccio == 1) 
        { 
            DirX = 0; DirY = 1;  // Baix
        } 
        else if (direccio == 2) 
        { 
            DirX = 1; DirY = 0;  // Dreta
        } 
        else if (direccio == 3) 
        { 
            DirX = -1; DirY = 0; // Esquerra
        }
    }
    
    
}