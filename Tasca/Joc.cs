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
            
            // Com que tots són Fauna, tots tenen DirX i DirY.
            // Els movem a tots directament!
            animal.X += animal.DirX;
            animal.Y += animal.DirY;

            // CONTROLS DE LÍMITS: Que no s'escapin de la peixera!
            if (animal.X < 0) animal.X = 0; 
            if (animal.X >= _peixera.Amplada) animal.X = _peixera.Amplada - 1;
            if (animal.Y < 0) animal.Y = 0;
            if (animal.Y >= _peixera.Alcada) animal.Y = _peixera.Alcada - 1;
          
        }
            
        }
}