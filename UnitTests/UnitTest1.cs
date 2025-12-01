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
        public void ReturnCorrectPostgraduate_()
        {
            string input = "Студент \"Иванов В.\" Тема \"Типы моделей\" дата 2025.01.01";
            Student result = StudentParser.ParsePostgraduate(input);
            DateTime d = DateTime.Parse("01.01.2025 0:00:00");

            Assert.AreEqual("Иванов В.", result.Name);
            Assert.AreEqual("Типы моделей", result.Theme);
            Assert.AreEqual(d, result.Date);
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
        [TestMethod]
        public void ReturnCorrectBachelor()
        {
            string input = "Студент \"Зайцева Д.\" Тема \"Инкапсуляция\" Интерес \"Баскетбол\" Срок \"2\" дата 2025.08.08";
            Student result = StudentParser.ParseBachelor(input);
            DateTime d = DateTime.Parse("08.08.2025 0:00:00");
            Assert.AreEqual("Зайцева Д.", result.Name);
            Assert.AreEqual("Инкапсуляция", result.Theme);
            Assert.AreEqual(d, result.Date);
            Assert.AreEqual("Баскетбол", result.Interest);

        }
        [TestMethod]
        public void TestReturnCorrectArray()
        {
            int[] array = { 1, 2, 0, 7, 8, 4 };
            var result = StudentParser.SumEvenNumbers(3, 5, array);
            int expected_result = 12;
            Assert.AreEqual(expected_result, result, "Not working correctly");
        }
        [TestMethod]
        public void TestWithoutEvenNumbers()
        {
            int[] array = {1, 3, 5, 8, 3, 11, 11, 11};
            var result = StudentParser.SumEvenNumbers(3, 5, array);
            int expected_result = 0;
            Assert.AreEqual(expected_result, result, "Not working correctly");
        }
        [TestMethod]
        public void TestWithoutNumbers()
        {
            int[] array = { };
            var result = StudentParser.SumEvenNumbers(3, 5, array);
            int expected_result = 0;
            Assert.AreEqual(expected_result, result, "Not working correctly");
        }



    }
    }

