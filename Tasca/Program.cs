namespace Tasca;

internal class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Salida Console4");
        // Inicialcio(entrada de posicio inicial
        
        //que te el joc
        Peixera _peixera = new Peixera();
        Peix _peix = new Peix();
        Tauron _tauron = new Tauron();
        Pop _pop = new Pop();
        Tortugue _tortugue = new Tortugue();
        
        // cremem el joc 
        Joc joc = new Joc(
            //que te Joc
            _peixera, _peix, _tauron, _pop, _tortugue
            );
        joc.Jugar();
    }
}