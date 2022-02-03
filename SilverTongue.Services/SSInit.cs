using System;
using System.IO;

namespace SilverTongue.Services
{
    public class SSInit
    {
        public SymSpell instance;
        public SSInit()
        {
            if (instance == null)
            {
                int initialCapacity = 82765;
                int maxEditDistance = 2;
                int prefixLength = 7;
                instance = new SymSpell(initialCapacity, maxEditDistance, prefixLength);
                string path = AppDomain.CurrentDomain.BaseDirectory + "frequency_dictionary_en_82_765.txt";
                if (!instance.LoadDictionary(path, 0, 1)) { Console.Error.WriteLine("\rFile not found: " + Path.GetFullPath(path)); Console.ReadKey(); }
            }
        }



        //string path = "../../frequency_dictionary_en_82_765.txt";  //path when using symspell nuget package (frequency_dictionary_en_82_765.txt is included in nuget package);


    }
}
