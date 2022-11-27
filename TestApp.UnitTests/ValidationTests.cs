using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestApp.UnitTests
{
    [TestClass]
    public class ValidationTests
    {
        [TestMethod]
        public void CheckDate_CorrectDate_ReturnsTrue()
        {
            var validation = new Validation();

            string date = "2000-01-01 12:00:00";

            var result = validation.CheckDate(date);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void CheckDate_WrongDate_ReturnsFalse()
        {
            var validation = new Validation();

            string date = "2001";

            var result = validation.CheckDate(date);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void CheckInt_CorrectNumber_ReturnsTrue()
        {
            var validation = new Validation();

            string number = "1";

            var result = validation.CheckInt(number);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void CheckInt_WrongNumber_ReturnsFalse()
        {
            var validation = new Validation();

            string number = "1zzz";

            var result = validation.CheckInt(number);

            Assert.IsFalse(result);
        }
    }
}