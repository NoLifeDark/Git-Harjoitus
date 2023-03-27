using System;

Console.WriteLine("Minkälainen kärki (puu, teräs vai timantti)? ");
string nuoliKärki = Console.ReadLine().ToLower();

Console.WriteLine("Minkälaiset sulat (lehti, kanansulka vai kotkansulka)? ");

string nuoliPera = Console.ReadLine().ToLower();

Console.WriteLine("Kuinka pitkän kärjen haluat (60cm - 100cm)? ");
float nuoliPituus = float.Parse(Console.ReadLine());

Nuoli nuoli = new Nuoli(nuoliKärki, nuoliPera, nuoliPituus);
Console.WriteLine("Nuolesi hinta on " + nuoli.PalautaHinta() + " kultaa");

public class Nuoli
{
    string nuoliPera;
    string nuoliKärki;
    float nuoliPituus;
    double nuoliHinta;

    public Nuoli(string NUOLIPERA, string NUOLIKARKI, float NUOLIPITUUS)
    {
        nuoliPera = NUOLIPERA;
        nuoliKärki = NUOLIKARKI;
        nuoliPituus = NUOLIPITUUS;
        if (nuoliPera == "puu")
        {
            nuoliHinta = 3;
        }
        if (nuoliPera == "teräs")
        {
            nuoliHinta += 5;
        }
        if (nuoliPera == "timantti")
        {
            nuoliHinta += 50;
        }
        if (nuoliKärki == "kanansulka")
        {
            nuoliHinta += 1;
        }
        if (nuoliKärki == "kotkansulka")
        {
            nuoliHinta += 5;
        }
        nuoliHinta = nuoliHinta + nuoliPituus * 0.05;
        return;
    }
    public double PalautaHinta()
    {
        return nuoliHinta;
    }
}


enum NuoliKärki
{
    puu = 3,
    teräs = 5,
    timantti = 5
}

enum NuoliPera
{
    lehti = 0,
    kanansulka = 1,
    kotkansulka = 2
}

