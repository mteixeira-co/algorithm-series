using System.Collections;

namespace AlgorithmsSeries.App.BigONotation
{
    public static class BigONotation
    {
        public static string ArrayIndexSearch()
        {
            var array = new[] { "i'm", "so", "hungry" };
            return array[2]; // find by index: 2 -> output: hungry
        }

        public static int DictionaryKeySearch()
        {
            // Storage of all people
            // The key is kind a document or something like that
            // And the value are name and age
            var dict = new Dictionary<string, (string name, int age)>
            {
                { "1265235", ("Jonh", 22) },
                { "8563256", ("Gabriel", 32) },
                { "5264125", ("Lucas", 44) },
                { "2541545", ("Fernando", 97) },
                { "6325632", ("Ronald", 52) },
                { "6526987", ("Doug", 18) }
            };

            return dict["2541545"].age; // find age by document: 2541545 -> output: 97
        }

        private static readonly string[] Names = {
                "Abigayle Ahmed", "Abraham King", "Adelaide Sweet", "Ahmet Ross", "Aine Villanueva", "Alejandro Dickson", "Alfie Roche",
                "Amelia-Grace Redfern", "Angelo Battle", "Ansh Barajas", "Areebah Caldwell", "Arthur Gilliam", "Bertha Paine", "Beth Little",
                "Bo Sexton", "Bree Buck", "Brett Gamble", "Burhan Mays", "Candice Heaton", "Carl Stafford", "Charlize Huynh", "Clodagh Pena",
                "Conrad Travis", "Dru Esquivel", "Eleanor Crawford", "Elin Santiago", "Ema Estrada", "Fabio Sparks", "Gracey Lowry", "Gruffydd Peralta",
                "Haidar Turnbull", "Hailie Ramsey", "Haley Knapp", "Harold Cortez", "Hassan Salinas", "Honey Cotton", "Huw Blaese", "Huzaifa Becker",
                "Igor Mcgill", "Ioana Ho", "Iona Brady", "Iram Odonnell", "Jade Middleton", "Jasmine Beasley", "Jordanna Bauer", "Jordyn Sumner",
                "Kajal Dean", "Kallum Daniel", "Katrina Sadler", "Kayla Graham", "Kenan Stacey", "Keon Deleon", "Kezia Lin", "Kiah Mcdaniel", "Kian Sawyer",
                "Kingsley Schneider", "Klaudia Stephens", "Konnor Hodgson", "Laith Hester", "Lauren Hodge", "Lilianna Hartman", "Lillie-May Holmes",
                "Lindsey Clay", "Lucille Hough", "Macey Harris", "Makayla Wu", "Marwah Storey", "Mathew Griffin", "Maxime Hood", "Mia Cummings",
                "Miller Bell", "Montell Bryan", "Nada Osborn", "Nichola Durham", "Nigel Collier", "Pedro Vargas", "Salim Almond", "Samual Boyer",
                "Saniya Alford", "Shannan Briggs", "Shanon Ramsay", "Shaquille Smyth", "Shelley Tierney", "Stephanie Blevins", "Susie Waters",
                "Teddy Lang", "Tessa Hall", "Theresa Abbott", "Tiegan Mathews", "Troy Talbot", "Tylor Jarvis", "Vikram Bloggs", "Vinny Soto",
                "Will Daniels", "Woody Osborne", "Zack Leal", "Zahid Villalobos", "Zakary Rodriquez", "Zarah Goulding", "Zoha Cowan",
            };

        public static int BinarySearch(string value, bool recursiveWay = false)
        {
            var idx = recursiveWay == false 
                ? LoopBinarySearch(Names, value) 
                : RecursivelyBinarySearch(Names, value, 0, Names.Length);

            Console.WriteLine(idx >= 0
                ? $"Name to find: {value} and Found name = {Names[idx]} at index = {idx}"
                : "None name found");

            return idx;
        }

        private static int LoopBinarySearch(string[] array, string value)
        {
            var low = 0; // Index to start the find
            var high = array.Length - 1; // Last index to find, always will be start with len(array) - 1

            var op = 0; // Just to count operations amount
            while (low <= high)
            {
                Console.WriteLine($"Operation amount: {++op}");

                var mid = Convert.ToInt32(decimal.Floor((low + high) / 2M));
                var el = array[mid];

                var compare = string.Compare(value, el, StringComparison.Ordinal);

                switch (compare)
                {
                    case 0:
                        return mid;
                    case > 0:
                        low = mid + 1;
                        break;
                    default:
                        high = mid - 1;
                        break;
                }
            }

            return -1;
        }

        private static int RecursivelyBinarySearch(string[] array, string value, int low, int high)
        {
            if (low > high) return -1;

            var mid = Convert.ToInt32(decimal.Floor((low + high) / 2M));
            var el = array[mid];

            var compare = string.Compare(value, el, StringComparison.Ordinal);
            if (compare == 0) return mid;

            Console.WriteLine("Operation executed");

            if (compare > 0) return RecursivelyBinarySearch(array, value, mid + 1, high);
            return RecursivelyBinarySearch(array, value, low, mid - 1);
        }
    }
}
