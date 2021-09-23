using System;

namespace GroupAssignment1
{
    public enum GrapeVariants
    {
        CabernetSauvignon, PinotNoir, Corvina, Shiraz, Merlot, Chablis,
        Riesling, Tempranillo
    }
    public enum GrapeRegions
    {
        Bordeaux, Burgundy, Veneto, Piedmonte, RiberaDelDuero,
        NapaValley, Puglia, Pfalz
    }
    public struct Wine
    {
        public int? Year;                   // null = undefined
        public string Name;
        public GrapeVariants Grape;
        public GrapeRegions Region;

        /// <summary>
        /// Creates a string representing the content of the Wine struct
        /// </summary>
        /// <returns>string that can be printed out using Console.WriteLine</returns>
        public string StringToPrint()
        {
            return $"Wine {Year} {Name} is made of {Grape} from {Region}";
        }
    }
    class Program
    {
        private static readonly int maxNrOfBottles = 4;

        static void Main(string[] args)
        {

            Wine[] myCellar = new Wine[maxNrOfBottles];

            Console.WriteLine($"My cellar can have maximum {maxNrOfBottles} bottles.");

            Wine wine1 = new Wine { Year = 2000, Name = "Château Lafite Rothschild", Grape = GrapeVariants.CabernetSauvignon, Region = GrapeRegions.Bordeaux };
            bool bOK = InsertWine(myCellar, wine1);

            Wine wine2 = new Wine { Year = 2010, Name = "Domaine de la Romanée-Conti", Grape = GrapeVariants.PinotNoir, Region = GrapeRegions.Burgundy };
            bOK = InsertWine(myCellar, wine2);

            Wine wine3 = new Wine { Year = 2005, Name = "Giuseppe Quintarelli Amarone", Grape = GrapeVariants.Corvina, Region = GrapeRegions.Veneto };
            bOK = InsertWine(myCellar, wine3);

            Wine wine4 = new Wine { Year = 2008, Name = "Sierra Cantabria", Grape = GrapeVariants.Tempranillo, Region = GrapeRegions.RiberaDelDuero };
            bOK = InsertWine(myCellar, wine4);

            Wine wine5 = new Wine { Year = 1992, Name = "Screaming Eagle", Grape = GrapeVariants.CabernetSauvignon, Region = GrapeRegions.RiberaDelDuero };
            bOK = InsertWine(myCellar, wine5);

            //Wine wine6 = new Wine { Year = 1992, Name = "Screaming Eagle", Grape = GrapeVariants.CabernetSauvignon, Region = GrapeRegions.RiberaDelDuero };
            //bOK = InsertWine(myCellar, wine6);


            PrintWines(myCellar);
        }

        /// <summary>
        /// Inserts a wine into myCellar at first available position
        /// </summary>
        /// <param name="myCellar"></param>
        /// <param name="wine"></param>
        /// <returns>true - if insertion was possible, otherwise false</returns>
        private static bool InsertWine(Wine[] myCellar, Wine wine)
        {
            bool isAdded = false;

            for (int i = 0; i < myCellar.Length; i++)
            {
                myCellar[i] = wine;
            }

            foreach (var item in myCellar)
            {
                if (item.Equals(wine))
                {
                    isAdded = true;
                }
            }
            return isAdded;
        }

        /// <summary>
        /// Print out all the wines in myCellar
        /// </summary>
        /// <param name="myCellar"></param>
        private static void PrintWines(Wine[] myCellar)
        {
            Console.WriteLine($"My cellar has {NrOfBottles(myCellar)} bottles");
            foreach (var item in myCellar)
            {
                Console.WriteLine($"{item.StringToPrint()}");
            }
        }

        /// <summary>
        /// Counts the number of bottles in myCellar. That is all items
        /// where Year is not null 
        /// </summary>
        /// <param name="myCellar"></param>
        /// <returns>Number of bottles in myCellar</returns>
        private static int NrOfBottles(Wine[] myCellar)
        {
            int count = 0;

            foreach (var item in myCellar)
            {
                if (item.Year != null)
                {
                    count++;
                }
                else
                {
                    Console.WriteLine("Year was null");
                }
            }
            return count;
        }
    }
}
