namespace Kecskepasztor_megoldas
{
    internal class Program
    {
        static Random rnd = new Random();
        static int[] MagassagTMB = new int[13];
        static double[] TestSulyTMB = new double[13];
        static void Main(string[] args)
        {
            Feladat1();
            Feladat2();
            Feladat3();
            Feladat4();
            Feladat5();
            Feladat6();
            Feladat7();
            Feladat8();
            Feladat9();
        }

        private static void Feladat9()
        {
            Console.WriteLine("\nFeladat 9: Írjon programot, mely megmondja legfeljebb hány kecskének a súlyát kell összeadni, hogy a testsúlyok összege 210 kg vagy a fölötti legyen");
            double CelSuly = 0;
            int Szamlalo = 0;
            while (CelSuly < 210)
            {
                CelSuly += TestSulyTMB[Szamlalo];
                Szamlalo++;
            }
            Console.WriteLine($" Ennyi kecske kell a célig: {Szamlalo} ennyi súllya teljesült: {CelSuly:0.00}");
        }

        private static void Feladat8()
        {
            Console.WriteLine("\nFeladat 8: Rendezzük súly szerint");
            double CsereSuly;
            int CsereMagassag;
            for (int i = 0; i < MagassagTMB.Length; i++)
            {
                for (int j = 0; j < MagassagTMB.Length - 1; j++) 
                {
                    if (TestSulyTMB[j] < TestSulyTMB[j + 1])
                    {
                        CsereSuly = TestSulyTMB[j];
                        CsereMagassag = MagassagTMB[j];
                        TestSulyTMB[j] = TestSulyTMB[j + 1];
                        MagassagTMB[j] = MagassagTMB[j + 1];
                        TestSulyTMB[j + 1] = CsereSuly;
                        MagassagTMB[j + 1] = CsereMagassag;
                    }
                }
            }
            for (int i = 0; i < 13; i++)
            {
                Console.WriteLine($"{i + 1:00}. kecske -> Súly: {TestSulyTMB[i]:0.00}kg Magasság: {MagassagTMB[i]} cm");
            }
        }

        private static void Feladat7()
        {
            Console.WriteLine("\nFeladat 7: Keresés");
            Console.Write("Kérem adjon meg egy keresett testsúlyt 30 és 42,5 kg között: ");
            double KeresSuly = double.Parse(Console.ReadLine()!);
            int Szamlalo = 0;
            while (Szamlalo < TestSulyTMB.Length && KeresSuly != TestSulyTMB[Szamlalo])
            { Szamlalo++; }
            if (Szamlalo == TestSulyTMB.Length)
            { Console.WriteLine("Nem volt olyan kecske akinek a súlya megegyezik"); }
            else
            { Console.WriteLine($"Volt olyan kecske akinek a súlya megegyezik mégpedig a {Szamlalo}"); }
        }

        private static void Feladat6()
        {
            Console.WriteLine("\nFeladat 6: legalacsonyabb kecske");
            int MinMag = int.MaxValue;
            int MinHely = 0;
            for (int i = 0; i < 13; i++)
            {
                if (MagassagTMB[i] < MinMag)
                {
                    MinMag = MagassagTMB[i];
                    MinHely = i + 1;
                }
            }
            Console.WriteLine($"\nA legalacsonyabb kecske: {MinMag}");
            Console.WriteLine($"\nA kecske sorszáma: {MinHely}");
        }

        private static void Feladat5()
        {
            Console.WriteLine("\nFeladat 5: legnehezebb kecske");
            double MaxSuly = TestSulyTMB.Max();
            int MaxHely = 0;
            for (int i = 0; i < 13; i++)
            {
                if (MaxSuly == TestSulyTMB[i])
                {
                    MaxHely = i + 1;
                }
            }
            Console.WriteLine($"\nA legnehezebb kecske súlya: {MaxSuly}kg");
            Console.WriteLine($"\nA kecske sorszáma: {MaxHely}");
        }

        private static void Feladat4()
        {
            Console.WriteLine("\nFeladat 4: 36 kg feletti");
            int db36 = 0;
            for (int i = 0; i < 13; i++)
            {
                if (TestSulyTMB[i] > 36)
                {
                    db36++;
                }
            }
            Console.WriteLine($"Ennyi kecske súlya több mint 36 kg: {db36}");
        }

        private static void Feladat3()
        {
            Console.WriteLine("\nFeladat 3: Átlagok különbsége");
            int OsszMagassag = MagassagTMB.Sum();
            double AtlagMagassag = (double)OsszMagassag / TestSulyTMB.Length;
            Console.WriteLine($"A magasság átlaga: {AtlagMagassag:0.00}");
            double OsszSuly = 0;
            for (int i = 0; i < 13; i++)
            {
                OsszSuly = TestSulyTMB[i];
            }
            double AtlagSuly = OsszSuly / TestSulyTMB.Length;
            Console.WriteLine($"A súly átlaga: {AtlagSuly:0.00}");
            double Kulonbseg = AtlagMagassag - AtlagSuly;
            Console.WriteLine($"A magasság és a súly különbsége: {Kulonbseg:0.00}");
        }

        private static void Feladat2()
        {
            Console.WriteLine("\nFeladat 2: Kiiratás");
            for (int i = 0; i < 13; i++)
            {
                Console.WriteLine($"{i + 1:00}. kecske -> Súly: {TestSulyTMB[i]:0.00}kg Magasság: {MagassagTMB[i]} cm");
            }
        }

        private static void Feladat1()
        {
            Console.WriteLine("Feladat 1: tömbök feltöltése");
            for (int i = 0; i < 13; i++)
            {
                MagassagTMB[i] = rnd.Next(55, 76);
                TestSulyTMB[i] = rnd.Next(300, 426) / 10.0;
            }
        }
    }
}