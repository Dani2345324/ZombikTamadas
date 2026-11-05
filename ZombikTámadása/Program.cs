namespace ZombikTámadása

{

    internal class Program
    {

        static Random r = new Random();

        static string[] NevKiosztas(int elemekSzama)

        {

            string[] nevek = new string[30]

            {

                "Adam", "Bence", "Dávid", "Erik", "Ferenc",

                "Gábor", "Hanna", "István", "János", "Kata",

                "László", "Márk", "Norbert", "Orsolya", "Péter",

                "Réka", "Sándor", "Tamás", "Viktor", "Zoltán",

                "Anna", "Boglárka", "Csaba", "Dóra", "Eszter",

                "Fanni", "Gergő", "Levente", "Máté", "Zsófia"            };


            string[] tomb = new string[elemekSzama];


            for (int i = 0; i < elemekSzama; i++)

            {

                tomb[i] = nevek[r.Next(0, nevek.Length)];

            }


            return tomb;


        }


        static void Kiir(string[] tomb)

        {

            foreach (var item in tomb)

            {

                Console.Write(item + " ");

            }

            Console.WriteLine();

        }


        static int[] LakossagEreje(int lakossagSzama)

        {

            int[] tomb = new int[lakossagSzama];

            for (int i = 0; i < lakossagSzama; i++)

            {

                tomb[i] = 100;

            }


            return tomb;

        }

        static int[] ZombiErejeKezdeti(int lakossagSzama, int sebzesMin, int sebzesMax)

        {

            int[] tomb = new int[lakossagSzama];

            for (int i = 0; i < lakossagSzama; i++)

            {

                tomb[i] = r.Next(sebzesMin, sebzesMax);

            }


            return tomb;

        }

        static void KiirSzamokat(int[] tomb)

        {

            foreach (var item in tomb)

            {

                Console.Write(item + " ");

            }

            Console.WriteLine();

        }

        private static void harc(string[] lakossag, string[] zombik, int[] lakossagEletereje, int[] zombikEreje)
        {
            for (int i = 0; i < zombik.Length; i++)
            {
                int index = r.Next(0, lakossag.Length);
                Console.WriteLine($"{zombik[i]} zombi rátámadt {zombikEreje[i]} erővel {lakossag[index]} ,akinek kezdeti életerje {lakossagEletereje[index]}");
                lakossagEletereje[index] -= zombikEreje[i];
                if (lakossagEletereje[index] <= 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"{lakossag[index]} lakos meghalt.");
                    Console.ResetColor();
                }
                else
                {
                    Console.WriteLine($"{lakossag[index]} lakos éltereje: {lakossagEletereje[index]}");
                }



            }
        }

        static void Main(string[] args)

        {

            Console.Write("Hány lakosa legyen a varosnak (1-20): ");

            int lakossagSzama = Convert.ToInt32(Console.ReadLine());

            string[] lakossag = NevKiosztas(lakossagSzama);

            string[] zombik = NevKiosztas(lakossagSzama);

            int sebzesMin = 10;

            int sebzesMax = 30;

            int[] lakossagEletereje = LakossagEreje(lakossagSzama);

            int[] zombikEreje = ZombiErejeKezdeti(lakossagSzama, sebzesMin, sebzesMax);

            Console.WriteLine("---------------------------------------------------");

            Console.Write("A lakosság: ");

            Kiir(lakossag);

            Console.Write("A lakossag eletereje: ");

            KiirSzamokat(lakossagEletereje);

            Console.WriteLine("---------------------------------------------------");

            Console.Write("A zombik: ");

            Kiir(zombik);

            Console.Write("A zombik ereje: ");

            KiirSzamokat(zombikEreje);

            Console.WriteLine("---------------------------------------------------");

            harc(lakossag, zombik, lakossagEletereje, zombikEreje);


        }

        
    }

}
