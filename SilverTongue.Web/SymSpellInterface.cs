using System;
using System.Collections.Generic;

namespace SilverTongue.Web
{
    public sealed class SymSpellInterface
    {
        private SymSpell symSpell;

        public SymSpellInterface()
        {
            int initialCapacity = 82765;
            int maxEditDistanceDictionary = 2; //максимальное расстояние редактирование (уровень ошибки)
            symSpell = new SymSpell(initialCapacity, maxEditDistanceDictionary);

            //загрузка словаря
            string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string dictionaryPath = baseDirectory + "frequency_dictionary_en_82_765.txt";
            int termIndex = 0; //столбец слов
            int countIndex = 1; //столбец частоты
            if (!symSpell.LoadDictionary(dictionaryPath, termIndex, countIndex))
            {
                Console.WriteLine("File not found " + dictionaryPath);
                //press any key to exit program

            }

            Console.WriteLine("SymSpellInterface was initialized. You are ready to go!");


        }

        private static readonly Lazy<SymSpellInterface> lazy = new Lazy<SymSpellInterface>(() => new SymSpellInterface());
        public static SymSpellInterface Instance
        {
            get
            {
                return lazy.Value;
            }
        }

        public List<SymSpell.SuggestItem> getSuggestions(string word, int verbosity, int distance)
        {
            try
            {

                return symSpell.Lookup(word, (SymSpell.Verbosity)verbosity, distance);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message, word, verbosity, distance);
                return new List<SymSpell.SuggestItem>();
            }


        }

        public List<SymSpell.SuggestItem> correctText(string text, int distance)
        {
            var suggestions = symSpell.LookupCompound(text, distance);
            return suggestions;
        }

        /*public (string segmentedString, string correctedString, int distanceSum, decimal probabilityLogSum) segmentText(string text, int distance)
        {
            var suggestion = symSpell.WordSegmentation(text, distance);
            return suggestion;
        }*/
    }
}
