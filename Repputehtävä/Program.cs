using System;

class Tavara
{
    public double Paino { get; }
    public double Tilavuus { get; }

    public Tavara(double paino, double tilavuus)
    {
        Paino = paino;
        Tilavuus = tilavuus;
    }
}

class Nuoli : Tavara
{
    public Nuoli() : base(0.1, 0.05) { }
}

class Jousi : Tavara
{
    public Jousi() : base(1, 4) { }
}

class Köysi : Tavara
{
    public Köysi() : base(1, 1.5) { }
}

class Vesi : Tavara
{
    public Vesi() : base(2, 2) { }
}

class RuokaAnnos : Tavara
{
    public RuokaAnnos() : base(1, 0.5) { }
}

class Miekka : Tavara
{
    public Miekka() : base(5, 3) { }
}

class Reppu
{
    private Tavara[] tavarat;
    private int maxTavaraMaara;
    private double maxKantoPaino;
    private double maxTilavuus;
    private int tavaroidenMaara;
    private double repunPaino;
    private double repunTilavuus;

    public Reppu(int maxTavaraMaara, double maxKantoPaino, double maxTilavuus)
    {
        this.maxTavaraMaara = maxTavaraMaara;
        this.maxKantoPaino = maxKantoPaino;
        this.maxTilavuus = maxTilavuus;
        tavarat = new Tavara[maxTavaraMaara];
    }

    public bool Lisää(Tavara tavara)
    {
        if (tavaroidenMaara < maxTavaraMaara &&
            repunPaino + tavara.Paino <= maxKantoPaino &&
            repunTilavuus + tavara.Tilavuus <= maxTilavuus)
        {
            tavarat[tavaroidenMaara] = tavara;
            tavaroidenMaara++;
            repunPaino += tavara.Paino;
            repunTilavuus += tavara.Tilavuus;
            return true;
        }
        return false;
    }

    public void NäytäTiedot()
    {
        Console.WriteLine($"Tavaroiden määrä: {tavaroidenMaara}/{maxTavaraMaara}");
        Console.WriteLine($"Repun paino: {repunPaino}/{maxKantoPaino}");
        Console.WriteLine($"Repun tilavuus: {repunTilavuus}/{maxTilavuus}");
        Console.WriteLine($"Jäljellä oleva kapasiteetti: {maxTavaraMaara - tavaroidenMaara} tavaraa, {maxKantoPaino - repunPaino} painoyksikköä, {maxTilavuus - repunTilavuus} tilavuusyksikköä\n");
    }
}

class Program
{
    static void Main(string[] args)
    {
        Reppu reppu = new Reppu(maxTavaraMaara: 10, maxKantoPaino: 15, maxTilavuus: 20);

        while (true)
        {
            Console.WriteLine("Valitse tavara reppuun: ");
            Console.WriteLine("1. Nuoli");
            Console.WriteLine("2. Jousi");
            Console.WriteLine("3. Köysi");
            Console.WriteLine("4. Vesi");
            Console.WriteLine("5. Ruoka-annos");
            Console.WriteLine("6. Miekka");
            Console.WriteLine("7. Juokse");

            Console.Write("Haluamasi tavara (1-7): ");
            int valinta = int.Parse(Console.ReadLine());

            Tavara uusiTavara = null;

            switch (valinta)
            {
                case 1: uusiTavara = new Nuoli(); break;
                case 2: uusiTavara = new Jousi(); break;
                case 3: uusiTavara = new Köysi(); break;
                case 4: uusiTavara = new Vesi(); break;
                case 5: uusiTavara = new RuokaAnnos(); break;
                case 6: uusiTavara = new Miekka(); break;
                case 7: return;
                default: Console.WriteLine("Virhe! Lue tehtävänanto uusiksi!\n"); 
                    break;
            }

            if (uusiTavara != null)
            {
                bool lisäysOnnistui = reppu.Lisää(uusiTavara);
                if (lisäysOnnistui)
                {
                    Console.WriteLine($"{uusiTavara.GetType().Name} lisätty reppuun.\n");
                    reppu.NäytäTiedot();
                }
                else
                {
                    Console.WriteLine("Tavaran lisääminen ei onnistunut, kapasiteetti täynnä.\n");
                }
            }
        }
    }
}
