namespace Tasca;

public class Peixera
{
    private int _Xpeixera;
    private int _Ypeixera;
    private List<Fauna> _llistaFauna = new List<Fauna>(); 

    public Peixera(int amplada, int alcada, List<Fauna> listaFauna
    )
    {
        _Xpeixera = amplada;
        _Xpeixera = alcada;
        _llistaFauna = listaFauna;
    }
}