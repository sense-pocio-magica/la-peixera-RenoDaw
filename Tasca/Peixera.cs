namespace Tasca;

public class Peixera
{
    private int _Xpeixera;
    private int _Ypeixera;
    private List<Fauna> _llistaFauna = new List<Fauna>();
    
    public int Amplada { get { return _Xpeixera; } }
    public int Alcada { get { return _Ypeixera; } }
    public List<Fauna> Animals { get { return _llistaFauna; } }
    
    private List<(int, int)> _llistaPosicions = new List<(int, int)>();

    public Peixera(int amplada, int alcada, List<Fauna> listaFauna
    )
    {
        _Xpeixera = amplada;
        _Ypeixera = alcada;
        _llistaFauna = listaFauna;
    }

    public void RepartirAnimals()
    {
        Random rnd = new Random();

        foreach (Fauna animal in _llistaFauna)
        {
            animal.X = rnd.Next(0, _Xpeixera); 
            animal.Y = rnd.Next(0, _Ypeixera); 
        }






    }
}