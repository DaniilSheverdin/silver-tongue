using Microsoft.Extensions.DependencyInjection;
using SilverTongue.Data;
using SilverTongue.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
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
            int maxEditDistanceDictionary = 3; //максимальное расстояние редактирование (уровень ошибки)
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
                    if (word[0] >= 'a' && 'z' <= word[0])
                        throw new ArgumentException("Введите АНГЛИЙСКИЙ текст");
                    var checkNote = new Data.Models.Check
                    {
                        CreateOn = DateTime.Now,
                        UserId = id,
                        isGrammCorrect = false,
                        isSpellCorrect = true,
                        Phrase = word,
                    };
                    var old = db.Checks.SingleOrDefault(x => x.Phrase == word && x.UserId == id);
                    if (old!=null)
                        db.Checks.Remove(old);
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
                        if (suggestions.Count == 0)
                        {
                            spellCheckNote.OptionsSequence += "Упс! Система не нашла исправления";
                            checkNote.isSpellCorrect = false;

                            notesForReq.Add(spellCheckNote);
                            db.SpellChecks.Add(spellCheckNote);
                        }
                        else
                        {
                            foreach (var suggestion in suggestions)
                            {
                                spellCheckNote.OptionsSequence += suggestion.term + "/";

                                // Console.WriteLine("правильное написание: " + suggestion.term + " расстояние редактирования = " + suggestion.distance.ToString());
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

        public ServiceResponse<List<Check>> getArchive(int id)
        {
            using (var scope = scopeFactory.CreateScope())
            {
                try
                {
                    var db = scope.ServiceProvider.GetRequiredService<Data.DbContext>();

                    var archive= new List<Data.Models.Check>();
                    var archive_DB = db.Checks.Where(a=>a.UserId==id&&(!a.isSpellCorrect||!a.isGrammCorrect)).OrderByDescending(p=>p.CreateOn).ToList();

                    foreach (var n in archive_DB)
                    {
                        archive.Add(n);
                        if (archive.Count == 5)
                            break;
                    }

                    return new ServiceResponse<List<Check>>
                    {
                        Data = archive,
                        Time = DateTime.Now,
                        Message = "new archive conversion request",
                        IsSucces = true
                    };
                }
                catch (Exception e)
                {
                    return new ServiceResponse<List<Check>>
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
