using System;
using System.Collections.Generic;

namespace SilverTongue.Services.UserTests
{
    public interface IUserTestService
    {
        /// <summary>
        /// метод возвращающий список тестов
        /// </summary>
        /// <returns></returns>
        List<Data.Models.UserTests.Test> GetAllTests();
        /// <summary>
        /// метод возращающий список кортежей вида ВОПРОС - список(ВАРИАНТ ОТВЕТА)
        /// </summary>
        /// <param name="id">идентификатор теста</param>
        /// <returns></returns>
        List<Tuple<Data.Models.UserTests.Question, List<Data.Models.UserTests.Option>>> GetOneTest(int id);
        /// <summary>
        /// Возвращает процент правильных ответов
        /// </summary>
        ServiceResponse<double> GetResult(List<int> answers, int TestID, int userID);
        
    }
}
