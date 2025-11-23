using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using PIS2;

namespace UnitTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestFormatException_StrToInt()
        {
            string input = "Студент \"Зайцева Д.\" Тема \"Инкапсуляция\" Интерес \"Баскетбол\" Срок \"два\" дата 2025.08.08";
            Student result = StudentParser.ParseBachelor(input);
            Assert.IsNull(result);
        }
        [TestMethod]
        public void TestFormatException_IncorrectDate()
        {
            string input = "Студент \"Вологдов В.\" Тема \"Определение системы\" дата 2025.32.32";
            Student result = StudentParser.ParseBachelor(input);
            Assert.IsNull(result);
        }
        [TestMethod]
        public void ReturnCorrectArray()
        {
            string input = "Студент \"Иванов В.\" Тема \"Типы моделей\" дата 2025.01.01";
            string[] result = StudentParser.SplitText(input);

            Assert.AreEqual(5, result.Length);
            Assert.AreEqual("Студент ", result[0]);
            Assert.AreEqual("Иванов В.", result[1]);
            Assert.AreEqual(" Тема ", result[2]);
            Assert.AreEqual("Типы моделей", result[3]);
            Assert.AreEqual(" дата 2025.01.01", result[4]);
        }
        [TestMethod]
        public void ContainsIndividialProperties()
        {
            string input = "Студент \"Зайцева Д.\" Тема \"Инкапсуляция\" Интерес \"Баскетбол\" Стажировка \"Тинькофф\" Срок \"2\" дата 2025.08.08";
            Student result = StudentParser.ParseMaster(input);
            Assert.IsNull(result);
        }
        [TestMethod]
        public void WrongPartsCount()
        {
            string input = "Студент \"Орлова К.\" Тема \"Дизайн рабочего кабинета\" дата 2025.05.15";
            Student result = StudentParser.ParseMaster(input);
            Assert.IsNull(result);
        }
    }
}
