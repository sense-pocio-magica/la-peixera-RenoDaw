//a
namespace Tasca;

public class Joc
{
    private static Random _rnd = new Random();
    
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
        
        
        //rondas a jugar
        for (int ronda = 1; ronda <= 100; ronda++)
        {
            sentitMovimentAnimalsDinsPeixera();
            
            ProcessarInteraccions();
            
            EnvellirIMorir();
            
        }
        
        
        
        


    }
    
    
    public void EnvellirIMorir()
    {
        // 1. Augmentem l'edat de tots els animals
        foreach (Fauna animal in _peixera.Animals)
        {
            animal.Edat++;
        }

        // 2. Eliminem els taurons que tinguin 75 rondes o més
        // RemoveAll esborra de la llista tots els objectes que compleixin la condició
        _peixera.Animals.RemoveAll(animal => animal is Tauron && animal.Edat >= 75);
    }

    public void PeixeraInicial()
    {
        _peixera.RepartirAnimals();
        sentitMovimentAnimalsDinsPeixera();
    }

    public void sentitMovimentAnimalsDinsPeixera()
    {


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

    public (int Peixos, int Taurons, int Pops, int Tortugues) ObtenirResultats()
            {
                int numPeixos = 0;
                int numTaurons = 0;
                int numPops = 0;
                int numTortugues = 0;

                // Recorrem tots els animals de la llista i mirem de quina classe són
                foreach (Fauna animal in _peixera.Animals)
                {
                    if (animal is Peix) numPeixos++;
                    else if (animal is Tauron) numTaurons++;
                    else if (animal is Pop) numPops++;
                    else if (animal is Tortugue) numTortugues++;
                }
                return (numPeixos, numTaurons, numPops, numTortugues);

            }
    
    public void ProcessarInteraccions()
    {
        // 1. Creem el diccionari per agrupar els animals per posició (X, Y)
        Dictionary<(int, int), List<Fauna>> graella = new Dictionary<(int, int), List<Fauna>>();

        // 2. Omplim el diccionari amb els animals segons la seva posició actual
        foreach (Fauna animal in _peixera.Animals)
        {
            var posicio = (animal.X, animal.Y);

            // Si la casella encara no existeix al diccionari, la creem amb una llista buida
            if (!graella.ContainsKey(posicio))
            {
                graella[posicio] = new List<Fauna>();
            }

            // Afegim l'animal a la llista d'aquesta casella
            graella[posicio].Add(animal);
        }
        
        // Llista per guardar els nadons i afegir-los al final del torn
        List<Fauna> nousAnimals = new List<Fauna>();
        List<Fauna> animalsAMorir = new List<Fauna>();
        
        // 3. Revisem les caselles per veure on hi ha més d'un animal (interaccions)
        foreach (var casella in graella)
        {
            List<Fauna> animalsAQuiaquestaCasella = casella.Value;

            // Si hi ha 2 o més animals a la mateixa casella, interactuen!
            if (animalsAQuiaquestaCasella.Count > 1)
            {
                // Un registre per evitar que un animal es reprodueixi més d'un cop per torn
                HashSet<Fauna> hanInteractuat = new HashSet<Fauna>();
                
                // Comparem tots els animals de la casella entre ells
                for (int i = 0; i < animalsAQuiaquestaCasella.Count; i++)
                {
                    for (int j = i + 1; j < animalsAQuiaquestaCasella.Count; j++)
                    {
                        Fauna a1 = animalsAQuiaquestaCasella[i];
                        Fauna a2 = animalsAQuiaquestaCasella[j];

                        // Si algun dels dos ja ha criat en aquest torn, passem al següent
                        if (hanInteractuat.Contains(a1) || hanInteractuat.Contains(a2))
                            continue;

                        // Condició 1: Són de la mateixa classe (tipus d'animal) i NO són Pops
                        if (a1.GetType() == a2.GetType())
                        {
                            hanInteractuat.Add(a1);
                            hanInteractuat.Add(a2);
                            
                            if (a1 is Pop)
                            {
                                // Són Pops: Canvien de direcció i cap pren mal
                                List<(int, int)> dirA1 = new List<(int, int)> { (0, -1), (0, 1), (1, 0), (-1, 0) };
                                dirA1.Remove(a1.Sentit);
                                a1.Sentit = dirA1[_rnd.Next(dirA1.Count)];

                                List<(int, int)> dirA2 = new List<(int, int)> { (0, -1), (0, 1), (1, 0), (-1, 0) };
                                dirA2.Remove(a2.Sentit);
                                a2.Sentit = dirA2[_rnd.Next(dirA2.Count)];
                            }
                            else if (a1.Genere != a2.Genere)
                            {
                                // NO són pops i SÓN de diferent sexe: REPRODUCCIÓ
                                Sexe nouSexe = _rnd.Next(0, 2) == 0 ? Sexe.Mascle : Sexe.Femella;
                                Fauna fill = (Fauna)Activator.CreateInstance(a1.GetType(), nouSexe);
                                fill.X = a1.X;
                                fill.Y = a1.Y;

                                List<(int, int)> direccionsPossibles = new List<(int, int)> { (0, -1), (0, 1), (1, 0), (-1, 0) };
                                direccionsPossibles.Remove(a1.Sentit);
                                direccionsPossibles.Remove(a2.Sentit);
                                fill.Sentit = direccionsPossibles[_rnd.Next(direccionsPossibles.Count)];

                                nousAnimals.Add(fill);
                            }
                            else
                            {
                                // NO són pops i SÓN del mateix sexe: ES MATEN ENTRE ELLS
                                animalsAMorir.Add(a1);
                                animalsAMorir.Add(a2);
                            

                            }
                        }
                    }
                }
                
                // ==========================================
                // 2a PART: INTERACCIÓ TORTUGA I TAURÓ
                // ==========================================
                // Comprovem si en aquesta casella (on hi ha diversos animals) hi ha com a mínim una Tortuga
                bool hiHaTortuga = animalsAQuiaquestaCasella.Exists(a => a is Tortugue);

                if (hiHaTortuga)
                {
                    // Si hi ha una tortuga, busquem els taurons que hi hagi a la mateixa casella
                    foreach (Fauna animal in animalsAQuiaquestaCasella)
                    {
                        // Si és un tauró i no està mort per haver-se barallat anteriorment...
                        if (animal is Tauron && !animalsAMorir.Contains(animal))
                        {
                            List<(int, int)> novesDireccions = new List<(int, int)> { (0, -1), (0, 1), (1, 0), (-1, 0) };
                            novesDireccions.Remove(animal.Sentit);
                            animal.Sentit = novesDireccions[_rnd.Next(novesDireccions.Count)];
                        }
                    }
                }
                
                // ==========================================
                // 3a PART: TAURÓ MENJA ALTRES ESPÈCIES
                // ==========================================
                // Mirem si hi ha cap tauró viu a la casella
                bool hiHaTauron = animalsAQuiaquestaCasella.Exists(a => a is Tauron && !animalsAMorir.Contains(a));
                
                if (hiHaTauron)
                {
                    foreach (Fauna presa in animalsAQuiaquestaCasella)
                    {
                        // Si la presa NO és un tauró i NO és una tortuga, se la menja
                        if (!(presa is Tauron) && !(presa is Tortugue) && !animalsAMorir.Contains(presa))
                        {
                            animalsAMorir.Add(presa);
                        }
                    }
                }
            }
        }

        // 4. Afegim tots els animals nous nascuts a la peixera
        _peixera.Animals.RemoveAll(animal => animalsAMorir.Contains(animal));
        _peixera.Animals.AddRange(nousAnimals);
                
                
                
            }
        }

          
        
        
        
        
        

