using System;

class Program
{
    static void Main(string[] args)
    {
        int lohikäärmeHP = 10;
        int kaupunkiHP = 15;
        int kierros = 1;

        Console.BackgroundColor= ConsoleColor.White;
        Console.ForegroundColor= ConsoleColor.Black;

        // Pyydä pelaajaa antamaan lohikäärmeen etäisyys kaupungista
        Console.Write("Anna lohikäärmeen etäisyys kaupungista (0-100): ");
        int dragonDistance = int.Parse(Console.ReadLine());

        Console.Clear();

        while (lohikäärmeHP > 0 && kaupunkiHP > 0)
        {
            // Laske vahingon määrä
            int damage = 1;
            if (kierros % 3 == 0 && kierros % 5 == 0)
            {
                damage = 10;
            }
            else if (kierros % 3 == 0 || kierros % 5 == 0)
            {
                damage = 3;
            }

            // Tulosta kierroksen tiedot
            Console.WriteLine("Kierros {0}: Kaupungin terveys {1}, Lohikäärmeen terveys {2}", kierros, kaupunkiHP, lohikäärmeHP);

            // Pyydä pelaajaa antamaan kohde etäisyys
            Console.Write("Anna kohde etäisyys (0-100): ");
            int targetDistance = int.Parse(Console.ReadLine());

            // Tarkista osuiko kanuuna lohikäärmeeseen
            if (targetDistance < dragonDistance)
            {
                Console.WriteLine("Osuma ali!");
            }
            else if (targetDistance > dragonDistance)
            {
                Console.WriteLine("Osuma yli!");
            }
            else
            {
                Console.WriteLine("Osuma! Lohikäärme menetti {0} terveyspistettä.", damage);
                lohikäärmeHP -= damage;
            }

            // Vähennä kaupungin terveyspisteitä jos lohikäärme on vielä hengissä
            if (lohikäärmeHP > 0)
            {
                kaupunkiHP--;
            }

            // Kasvata kierroslukua
            kierros++;
        }

        // Tulosta pelin lopputulos
        if (lohikäärmeHP <= 0)
        {
            Console.WriteLine("Onneksi olkoon, voitit pelin!");
        }
        else
        {
            Console.WriteLine("Lohikäärme voitti pelin. Parempi onni ensi kerralla!");
        }

        Console.ReadLine();
    }
}