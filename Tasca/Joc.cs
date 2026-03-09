namespace Tasca;

public class Joc
{
    private Peixera _peixera;
    private int coordX;
    private int coordY;
    private (int, int) _quadrant;
    private List<(int, int)> _llistaDeQuadratsPeixere  = new List<(int, int)>();

    
    public Joc(Peixera peixera)
    {
        _peixera = peixera;
        
    }
    
    
    
    public void Jugar(Peixera peixera)
    {
        // una peixera
        // uns animals
        // una posicio inicial
        // un sentid de moviment
        PeixeraInicial();




    }

    public void PeixeraInicial()
    {
        _peixera.RepartirAnimals();
        MovimentAnimalsDinsPeixera();
    }
    public void MovimentAnimalsDinsPeixera()
    {
        Random rnd = new Random();

        foreach (Fauna animal in _peixera.Animals)
        {
            
            // --- MOVIMENT EIX X ---
            if (animal.Sentit.X == 1)
            {
                animal.X += 1; // Mou a la dreta
            }
            else if (animal.Sentit.X == -1)
            {
                animal.X -= 1; // Mou a l'esquerra
            }

            // --- MOVIMENT EIX Y ---
            if (animal.Sentit.Y == 1)
            {
                animal.Y += 1; // Mou cap a baix
            }
            else if (animal.Sentit.Y == -1)
            {
                animal.Y -= 1; // Mou cap a dalt
            }            

            
            // Si marxa per l'esquerra (es fa negatiu), apareix per la dreta
            if (animal.X < 0) 
            {
                animal.X = _peixera.Amplada - 1; 
            }
            // Si marxa per la dreta (arriba a l'amplada màxima), apareix per l'esquerra (0)
            else if (animal.X >= _peixera.Amplada) 
            {
                animal.X = 0;
            }

            // Si marxa per dalt (es fa negatiu), apareix per baix
            if (animal.Y < 0) 
            {
                animal.Y = _peixera.Alcada - 1;
            }
            // Si marxa per baix (arriba a l'alçada màxima), apareix per dalt (0)
            else if (animal.Y >= _peixera.Alcada) 
            {
                animal.Y = 0;
            }
          
        }
            
        }
}