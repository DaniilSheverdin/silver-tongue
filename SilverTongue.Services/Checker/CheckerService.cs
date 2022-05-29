using Microsoft.Extensions.DependencyInjection;
using SilverTongue.Data;
using SilverTongue.Data.Models;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace SilverTongue.Services.Checker
{
    public class CheckerService : ICheckerService
    {
        private readonly SymSpell symSpell;//объект для работы с симметричной проверкой орфографии
                                           //  private readonly Data.DbContext _db;
        private readonly Microsoft.Office.Interop.Word.Application M_word;
        private readonly IServiceScopeFactory scopeFactory;

        public CheckerService(IServiceScopeFactory scopeFactory)
        {
            this.scopeFactory = scopeFactory;

            M_word= new Microsoft.Office.Interop.Word.Application();
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


        public ServiceResponse<Tuple<List<SpellCheck>, Check>> Check(string word, int id)
        {
            using (var scope = scopeFactory.CreateScope())
            {
                var db = scope.ServiceProvider.GetRequiredService<Data.DbContext>();
                try
                {

                    var checkNote = new Data.Models.Check
                    {
                        CreateOn = DateTime.Now,
                        UserId = id,
                        isGrammCorrect = false,
                        isSpellCorrect = true,
                        Phrase = word,
                    };
                    db.Checks.Add(checkNote);
                    var clearText = Regex.Replace(word, "[-.?!)(,:]", "");
                    string[] splittedText = clearText.Split(' ');
                    List<SpellCheck> notesForReq = new List<SpellCheck>();
                    List<SymSpell.SuggestItem> suggestions = null;
                    foreach (var sT in splittedText)
                    {
                        var spellCheckNote = new Data.Models.SpellCheck
                        {
                            CreateOn = DateTime.Now,
                            Word = sT,
                            Check = checkNote,
                            OptionsSequence = "",
                        };

                        suggestions = symSpell.Lookup(sT, (SymSpell.Verbosity)2, 1);
                        foreach (var suggestion in suggestions)
                        {
                            spellCheckNote.OptionsSequence += suggestion.term + "/";

                            Console.WriteLine("правильное написание: " + suggestion.term + " расстояние редактирования = " + suggestion.distance.ToString());
                        }
                        if (suggestions[0].distance != 0)
                        {
                            checkNote.isSpellCorrect = false;

                            notesForReq.Add(spellCheckNote);
                            db.SpellChecks.Add(spellCheckNote);
                        }
                        else
                            db.Users.Find(id).Points += 1;
                        
                        
                    }
                    checkNote.isGrammCorrect = M_word.CheckGrammar(word);
                    db.SaveChanges();

                    return new ServiceResponse<Tuple<List<SpellCheck>, Check>>
                    {
                        Data = new Tuple <List<SpellCheck>, Check>(notesForReq,checkNote),
                        Time = DateTime.Now,
                        Message = "Saved new check",
                        IsSucces = true
                    };
                }
                catch (Exception e)
                {
                    return new ServiceResponse<Tuple<List<SpellCheck>, Check>>
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
}
