using System;

public class Robotti
{
    public int X { get; set; }
    public int Y { get; set; }
    public bool OnKäynnissä { get; set; }
    public RobottiKäsky?[] Käskyt { get; } = new RobottiKäsky?[3];

    public void Suorita()
    {
        foreach (RobottiKäsky? käsky in Käskyt)
        {
            käsky?.Suorita(this);
            Console.WriteLine($"[{X} {Y} {OnKäynnissä}]");
        }
    }
}

// Abstrakti RobottiKäsky-luokka
abstract class RobottiKäsky
{
    public abstract void Suorita(Robotti robotti);
}

// Robotti-luokka
class Robotti1_
{
    public bool OnKäynnissä { get; private set; }

    public void Käynnistä()
    {
        OnKäynnissä = true;
        Console.WriteLine("Robotti käynnistetty.");
    }

    public void Sammuta()
    {
        OnKäynnissä = false;
        Console.WriteLine("Robotti sammutettu.");
    }
}

// Käynnistä-luokka
class Käynnistä : RobottiKäsky
{
    public override void Suorita(Robotti robotti)
    {
        robotti.Käynnistä();
    }
}

// Sammuta-luokka
class Sammuta : RobottiKäsky
{
    public override void Suorita(Robotti robotti)
    {
        robotti.Sammuta();
    }
}

// YlösKäsky-luokka
class YlösKäsky : RobottiKäsky
{
    public override void Suorita(Robotti robotti)
    {
        if (robotti.OnKäynnissä)
        {
            Console.WriteLine("Robotti siirtyy ylös.");
        }
    }
}

// AlasKäsky-luokka
class AlasKäsky : RobottiKäsky
{
    public override void Suorita(Robotti robotti)
    {
        if (robotti.OnKäynnissä)
        {
            Console.WriteLine("Robotti siirtyy alas.");
        }
    }
}

// VasenKäsky-luokka
class VasenKäsky : RobottiKäsky
{
    public override void Suorita(Robotti robotti)
    {
        if (robotti.OnKäynnissä)
        {
            Console.WriteLine("Robotti siirtyy vasemmalle.");
        }
    }
}

// OikeaKäsky-luokka
class OikeaKäsky : RobottiKäsky
{
    public override void Suorita(Robotti robotti)
    {
        if (robotti.OnKäynnissä)
        {
            Console.WriteLine("Robotti siirtyy oikealle.");
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        Robotti robotti = new Robotti();
        RobottiKäsky[] käskyt = new RobottiKäsky[3];

        for (int i = 0; i < 3; i++)
        {
            Console.WriteLine("Syötä käsky (Käynnistä, Sammuta, Ylös, Alas, Vasen, Oikea):");
            string käsky = Console.ReadLine();

            switch (käsky.ToLower())
            {
                case "käynnistä":
                    käskyt[i] = new Käynnistä();
                    break;
                case "sammuta":
                    käskyt[i] = new Sammuta();
                    break;
                case "ylös":
                    käskyt[i] = new YlösKäsky();
                    break;
                case "alas":
                    käskyt[i] = new AlasKäsky();
                    break;
                case "vasen":
                    käskyt[i] = new VasenKäsky();
                    break;
                case "oikea":
                    käskyt[i] = new OikeaKäsky();
                    break;
                default:
                    Console.WriteLine("Tuntematon käsky, yritä uudelleen.");
                    i--;
                    break;
            }
        }

        foreach (var käsky in käskyt)
        {
            käsky.Suorita(robotti);
        }
    }
}