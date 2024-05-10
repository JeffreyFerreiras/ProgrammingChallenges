namespace CheckPermutations
{
    class Program
    {
        /*
         * Given two strings, write a method to decide if one is a permutation of the other.
         */
        static void Main(string[] args)
        {   
            var sw = new System.Diagnostics.Stopwatch();
            sw.Start();
            bool isPermute10 = IsPermutation("taco cat","acto tac");
            bool isPermute11 = IsPermutation("taco cat","taco ca");
            bool isPermute12 = IsPermutation("taco cat","");
            sw.Stop();
        }
        
        //Best solution
        static bool IsPermutation(string original, string permutation)
        {
            int[] charTableOriginal = BuildCharTable(original);
            int[] charTablePermutation = BuildCharTable(permutation);
          
            for(int i = 0; i < charTableOriginal.Length; i++)
            {
                if(charTableOriginal[i] != charTablePermutation[i]) return false;
            }

            return true;
        }

        static int[] BuildCharTable(string phrase)
        {
            int [] table = new int[25];

            foreach(char c in phrase)
            {
                if(char.IsLetter(c))
                    table[(c | ' ') - 'a']++;
            }

            return table;
        }
    }
}
