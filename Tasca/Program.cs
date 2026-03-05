namespace Tasca;

internal class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Salida Console4");
        // Inicialcio(entrada de posicio inicial)
        int amplada = 20;
        int alcada = 20;
        int NumPeix = 50;
        int NumTauron = 10;
        int NumPop = 15;
        int NumTortugue = 6;
        
        
        //que te el joc
        List<Fauna> llistajoc = new List<Fauna>();

        for (int i = 0; i < NumPeix; i++)
        {
            llistajoc.Add(new Peix());
        }

        for (int i = 0; i < NumTauron; i++)
        {
            llistajoc.Add(new Tauron());
        }

        for (int i = 0; i < NumPop; i++)
        {
            llistajoc.Add(new Pop());
        }

        for (int i = 0; i < NumTortugue; i++)
        {
            llistajoc.Add(new Tortugue());
        }
        
        
        
        Peixera _peixera = new Peixera(amplada, alcada, llistajoc );
        

        
        // cremem el joc 
        Joc joc = new Joc(
            //que te Joc
            _peixera
            );
        // ejecutem el metode jugar per iniciar el joc
        joc.Jugar(_peixera);
    }
}