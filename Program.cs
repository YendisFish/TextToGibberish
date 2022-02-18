namespace TextToGibberish.Main
{
    public class EntryPoint
    {
        public static void Main()
        {
            Console.Write("Enter text > ");
            string phrase = Console.ReadLine();

            char[] phc = phrase.ToCharArray();

            List<char> pc = new();
            
            for (int i = phc.Length - 1; i >= 0; i--)
            {
                pc.Add(phc[i]);
            }

            string valtofac = "";
            foreach (char val in pc)
            {
                valtofac = valtofac + val;
            }

            string result = LiteralSin(EncryptionFactory(valtofac));

            Console.WriteLine(result);
            Console.ReadKey();
        }

        public static string LiteralSin(string val)
        {
            Random rand = new();
            char[] alphabet = "abcdefghijklmnopqrstuvwxyz".ToCharArray();
            List<char> c = new();
            
            for (int i = 0; i < val.ToCharArray().Length; i ++)
            {
                for (int m = 0; m < alphabet.Length; m++)
                {
                    if (alphabet[m] == val.ToCharArray()[i])
                    {
                        while (true)
                        {
                            int newindex = rand.Next(26);
                            if (newindex <= 26)
                            {
                                c.Add(alphabet[newindex]);
                                break;
                            }
                        }
                    }
                }
            }

            string ret = "";
            foreach (char v in c)
            {
                ret = ret + v;
            }

            return ret;
        }

        public static string EncryptionFactory(string val)
        {
            Random rand = new();
            List<char> converted = new();
            
            Dictionary<int, char> table = new();

            foreach (char v in val)
            {
                table.Add(rand.Next(), v);
            }

            IOrderedEnumerable<KeyValuePair<int, char>> table2 = table.OrderByDescending(x => x.Key);

            string ret = "";
            foreach (KeyValuePair<int, char> v in table2)
            {
                ret = ret + v.Value;
            }

            return ret;
        }
    }
}