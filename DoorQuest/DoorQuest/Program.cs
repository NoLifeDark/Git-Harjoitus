using System;
namespace EnumDemo
{
    class Ovihommeli
    {
        static bool oviLukossa = false;
        static bool oviKiinni = false;
        static bool loppu = false;
        enum Ovi
        {
            Auki = 1,
            Kiinni,
            Lukossa,
            Loppu
        };

        static void Main(string[] args)
        {
            Console.WriteLine("Ovi on " + Ovi.Auki + ". Mitä haluat tehdä?");
            while (loppu == false)
            {
                string käsky = Console.ReadLine();
                if (käsky == "Kiinni")
                {
                    Console.WriteLine("Ovi on " + Ovi.Kiinni + ". Mitä haluat tehdä?");
                    Ovihommeli.oviKiinni = true;
                    Ovihommeli.oviLukossa = false;
                }
                if (käsky == "Lukko")
                {
                    if (!Ovihommeli.oviKiinni)
                    {
                        Console.WriteLine("Sulje ovi ennen kuin lukitset oven!");
                    }
                    else
                    {
                        Console.WriteLine("Ovi on " + Ovi.Lukossa + ". Mitä haluat tehdä?");
                        Ovihommeli.oviLukossa = true;
                        Ovihommeli.oviKiinni = false;
                    }
                }
                if (käsky == "Auki")
                {
                    if (oviLukossa == true)
                    {
                        Console.WriteLine("Poista lukko!");
                    }
                    else
                    {
                        Console.WriteLine("Ovi on " + Ovi.Auki + ". Mitä haluat tehdä?");
                        Ovihommeli.oviKiinni = false;
                    }
                }
                if (käsky == "Loppu")
                {
                    loppu = true;
                }
            }
        }
    }
}