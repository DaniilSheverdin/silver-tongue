/*using SilverTongue.Data.Models;
using System;
using System.Collections.Generic;
using System.IO;

namespace SilverTongue.Services.Checker
{
    public class SymSpellCheckerService : ISymSpellCheckerService
    {
        private readonly Data.DbContext _db;
        public SymSpellCheckerService(Data.DbContext dbContext)
        {
            _db = dbContext;
        }
        public ServiceResponse<Data.Models.SpellCheck> SpellCheck(string word, int id)
        {
            try
            {
                var note = new Data.Models.SpellCheck
                {
                    CreateOn = DateTime.Now,
                    UpdateOn = DateTime.Now,
                    InputWord = word,
                    User = _db.Users.Find(id),
                    isCorrect = false,
                    OptionsSequence = ""
                };
                //set parameters
                const int initialCapacity = 82765;
                const int maxEditDistance = 2;
                const int prefixLength = 7;
                var symSpell = new SymSpell(initialCapacity, maxEditDistance, prefixLength);

                //Load a frequency dictionary
                //wordfrequency_en.txt  ensures high correction quality by combining two data sources: 
                //Google Books Ngram data  provides representative word frequencies (but contains many entries with spelling errors)  
                //SCOWL — Spell Checker Oriented Word Lists which ensures genuine English vocabulary (but contained no word frequencies)   
                string path = AppDomain.CurrentDomain.BaseDirectory + "frequency_dictionary_en_82_765.txt"; //path referencing the SymSpell core project
                //string path = "../../frequency_dictionary_en_82_765.txt";  //path when using symspell nuget package (frequency_dictionary_en_82_765.txt is included in nuget package)
                if (!symSpell.LoadDictionary(path, 0, 1)) 
                { 
                    Console.Error.WriteLine("\rFile not found: " + Path.GetFullPath(path)); Console.ReadKey(); 
                }

                //Alternatively Create the dictionary from a text corpus (e.g. http://norvig.com/big.txt ) 
                //Make sure the corpus does not contain spelling errors, invalid terms and the word frequency is representative to increase the precision of the spelling correction.
                //You may use SymSpell.CreateDictionaryEntry() to update a (self learning) dictionary incrementally
                //To extend spelling correction beyond single words to phrases (e.g. correcting "unitedkingom" to "united kingdom") simply add those phrases with CreateDictionaryEntry(). or use  https://github.com/wolfgarbe/SymSpellCompound
                //string path = "big.txt";
                //if (!symSpell.CreateDictionary(path)) Console.Error.WriteLine("File not found: " + Path.GetFullPath(path));
                List<SymSpell.SuggestItem> suggestions = null;

                //check if input term or similar terms within edit-distance are in dictionary, return results sorted by ascending edit distance, then by descending word frequency     
                const SymSpell.Verbosity verbosity = SymSpell.Verbosity.Closest;
                suggestions = symSpell.Lookup(word, verbosity);


                //display term and frequency
                foreach (var suggestion in suggestions)
                {
                    note.OptionsSequence += suggestion.term + "/";

                    Console.WriteLine("правильное написание: " + suggestion.term + " расстояние редактирования = " + suggestion.distance.ToString());
                }
                note.isCorrect = suggestions[0].distance == 0;
                _db.SpellChecks.Add(note);
                if (note.isCorrect)
                    _db.Users.Find(id).Points += 1;

                _db.SaveChanges();
                return new ServiceResponse<SpellCheck>
                {
                    Data = note,
                    Time = DateTime.Now,
                    Message = "Saved new check",
                    IsSucces = true
                };
            }
            catch (Exception e)
            {
                return new ServiceResponse<SpellCheck>
                {
                    Data = null,
                    Time = DateTime.Now,
                    Message = e.StackTrace,
                    IsSucces = false
                };
            }
        }
    }
}
*/