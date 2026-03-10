//a
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
            Sexe sexeAssignat = (i < NumPeix / 2) ? Sexe.Mascle : Sexe.Femella;
            llistajoc.Add(new Peix(sexeAssignat));
        }

        for (int i = 0; i < NumTauron; i++)
        {
            Sexe sexeAssignat = (i < NumTauron / 2) ? Sexe.Mascle : Sexe.Femella;
            llistajoc.Add(new Tauron(sexeAssignat));
        }

        for (int i = 0; i < NumPop; i++)
        {
            llistajoc.Add(new Pop());
        }

        for (int i = 0; i < NumTortugue; i++)
        {
            Sexe sexeAssignat = (i < NumTortugue / 2) ? Sexe.Mascle : Sexe.Femella;
            llistajoc.Add(new Tortugue(sexeAssignat));
        }
        
        
        
        Peixera _peixera = new Peixera(amplada, alcada, llistajoc );
        

        
        // cremem el joc 
        Joc joc = new Joc(_peixera);
        
       
        joc.Jugar(_peixera);
        
        var resultats = joc.ObtenirResultats();
         
        Console.WriteLine("\n--- RESULTATS DESPRÉS DE 100 RONDES ---");
        Console.WriteLine($"Peixos restants: {resultats.Peixos}");
        Console.WriteLine($"Taurons restants: {resultats.Taurons}");
        Console.WriteLine($"Pops restants: {resultats.Pops}");
        Console.WriteLine($"Tortugues restants: {resultats.Tortugues}");
        Console.WriteLine("---------------------------------------");
    }
}