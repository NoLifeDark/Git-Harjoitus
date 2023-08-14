using System;
using System.Collections.Generic;

Console.WriteLine("Kuningas on juuri nimennyt sinut ritariksi");
Console.Write("Anna nimesi: ");

Console.Clear();
Console.WriteLine("Noniin nyt päästään asiaan, kun sinulle on nimi.");
Console.WriteLine("Kuningas haluaa lähettää sinut porttien ulkopuolelle.");
Console.WriteLine("Ota tarvittavat tavarat mukaan ja lähde heti matkaan");

Console.WriteLine("Valitse numeroilla mitä haluat tehdä");
Console.WriteLine("1. Lähde matkaan");
Console.WriteLine("2. Kauppaan");
int valinta = int.Parse(Console.ReadLine());

if (valinta == 1)
{
    Console.WriteLine("Lähdet portista ulos ja aloitat seikkailusi.");
}
else if (valinta == 2)
{
    Console.WriteLine("Tervetuloa kauppaan!");
    Console.WriteLine("Täältä voit ostaa mitä tarvitset.");
    Console.WriteLine("Vien sinut portille, kun olet valmis.");
}
private void VieraileKaupassa()
{
    Console.WriteLine("Tervetuloa kauppaan!");

    kauppa.NäytäTuotteet();

    Console.WriteLine("Valitse ostos:");
    Console.WriteLine("1. Osta ase");
    Console.WriteLine("2. Osta haarniska");
    Console.WriteLine("3. Osta taikajuoma");
    Console.WriteLine("4. Poistu kaupasta");

    int valinta = int.Parse(Console.ReadLine());
}

// Yliluokka hahmolle
public abstract class Hahmo
{
    protected Ase ase;
    protected Haarniska haarniska;
    protected Parannustaikajuoma parannustaikajuoma;

    public void AsetaAse(Ase uusiAse)
    {
        ase = uusiAse;
    }

    public void AsetaHaarniska(Haarniska uusiHaarniska)
    {
        haarniska = uusiHaarniska;
    }

    public void AsetaParannustaikajuoma(Parannustaikajuoma uusiTaikajuoma)
    {
        parannustaikajuoma = uusiTaikajuoma;
    }

    public abstract void Taistele(Hahmo vastustaja);
}

// Aliluokka ritarihahmolle
public class Ritari : Hahmo
{
    public override void Taistele(Hahmo vastustaja)
    {
        Console.WriteLine("Ritari taistelee!");

        // Käytä ase
        if (ase != null)
            ase.Käytä(this);

        // Käytä haarniska
        if (haarniska != null)
            haarniska.Käytä(this);

        // Käytä parannustaikajuoma
        if (parannustaikajuoma != null)
            parannustaikajuoma.Käytä(this);

        // Tässä voit toteuttaa taistelulogiikan ritarihahmolle
    }
}

public interface Varuste
{
    void Käytä(Hahmo hahmo);
}

// Luokka aseelle
public class Ase : Varuste
{
    public void Käytä(Hahmo hahmo)
    {
        Console.WriteLine("Asetta käytetään!");
        // Tee tähän aseeseen liittyviä toimintoja hahmolle
    }
}

// Luokka haarniskalle
public class Haarniska : Varuste
{
    public void Käytä(Hahmo hahmo)
    {
        Console.WriteLine("Haarniskaa käytetään!");
        // Tee tähän haarniskaan liittyviä toimintoja hahmolle
    }
}

// Luokka parannustaikajuomille
public class Parannustaikajuoma : Varuste
{
    public void Käytä(Hahmo hahmo)
    {
        Console.WriteLine("Parannustaikajuomaa käytetään!");
        // Tee tähän parannustaikajuomaan liittyviä toimintoja hahmolle
    }
    // Luokka vihollisille
    public class Vihollinen : Hahmo
    {
        public override void Taistele(Hahmo vastustaja)
        {
            Console.WriteLine("Vihollinen taistelee!");

            // Tässä voit toteuttaa taistelulogiikan viholliselle
        }
    }

    // Luokka kaupalle
    public class Kauppa
    {
        private Ase[] aseet;
        private Haarniska[] haarniskat;
        private Parannustaikajuoma[] taikajuomat;

        public Kauppa()
        {
            // Alusta kaupan tuotteet
            aseet = new Ase[]
            {
            new Ase(),
            new Ase()
            };

            haarniskat = new Haarniska[]
            {
            new Haarniska(),
            new Haarniska()
            };

            taikajuomat = new Parannustaikajuoma[]
            {
                new Parannustaikajuoma(),
                new Parannustaikajuoma()
            };
        }

        public void NäytäTuotteet()
        {
            Console.WriteLine("Kaupan tuotteet:");

            Console.WriteLine("Aseet:");
            foreach (Ase ase in aseet)
            {
                Console.WriteLine(ase);
            }

            Console.WriteLine("Haarniskat:");
            foreach (Haarniska haarniska in haarniskat)
            {
                Console.WriteLine(haarniska);
            }

            Console.WriteLine("Taikajuomat:");
            foreach (Parannustaikajuoma taikajuoma in taikajuomat)
            {
                Console.WriteLine(taikajuoma);
            }
        }

        public Ase OstaAse(int indeksi)
        {
            if (indeksi >= 0 && indeksi < aseet.Length)
            {
                Ase ostettuAse = aseet[indeksi];
                aseet[indeksi] = null;
                return ostettuAse;
            }

            return null;
        }

        public Haarniska OstaHaarniska(int indeksi)
        {
            if (indeksi >= 0 && indeksi < haarniskat.Length)
            {
                Haarniska ostettuHaarniska = haarniskat[indeksi];
                haarniskat[indeksi] = null;
                return ostettuHaarniska;
            }

            return null;
        }

        public Parannustaikajuoma OstaTaikajuoma(int indeksi)
        {
            if (indeksi >= 0 && indeksi < taikajuomat.Length)
            {
                Parannustaikajuoma ostettuTaikajuoma = taikajuomat[indeksi];
                taikajuomat[indeksi] = null;
                return ostettuTaikajuoma;
            }

            return null;
        }
    }
}