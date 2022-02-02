using Microsoft.EntityFrameworkCore;
using SilverTongue.Data;
using SilverTongue.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SilverTongue.Services.Dictionary
{
    public class DictionaryService : IDictionaryService
    {
        private readonly Data.DbContext _db;
        public DictionaryService(Data.DbContext dbContext)
        {
            _db = dbContext;
        }
        /// <summary>
        /// Добавляет новую запись в БД
        /// </summary>
        /// <param name="note"></param>
        /// <returns></returns>
        public ServiceResponse<UsersDitctionary> AddNote(UsersDitctionary note)
        {
            try
            {
                _db.UsersDicts.Add(note);
                _db.SaveChanges();

                return new ServiceResponse<Data.Models.UsersDitctionary>
                {
                    Data = note,
                    Time = DateTime.UtcNow,
                    Message = "Saved new note",
                    IsSucces = true
                };
            }
            catch (Exception e)
            {
                return new ServiceResponse<Data.Models.UsersDitctionary>
                {
                    Data = note,
                    Time = DateTime.UtcNow,
                    Message = e.StackTrace,
                    IsSucces = false
                };
            }
        }
        /// <summary>
        /// Удаляет запись
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ServiceResponse<Data.Models.UsersDitctionary> DeleteNote(int id)
        {
            try
            {
                var note = _db.UsersDicts.Find(id);
                _db.UsersDicts.Remove(note);
                _db.SaveChanges();
                return new ServiceResponse<UsersDitctionary>
                {
                    Data = note,
                    Time = DateTime.UtcNow,
                    Message = "Deleted note",
                    IsSucces = true
                };
                
            }
            catch (Exception e)
            {
                return new ServiceResponse<UsersDitctionary>
                {
                    Data = null,
                    Time = DateTime.UtcNow,
                    Message = e.StackTrace,
                    IsSucces = false
                };
            }
        }

        
        /// <summary>
        /// Возвращает запись по Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<UsersDitctionary> GetByUserId(int id)
        {
            return _db.UsersDicts.Where(uds=>uds.User.Id==id).ToList();
        }


    }
}