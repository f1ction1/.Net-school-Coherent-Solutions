using Task5;
namespace TestTask5._2
{
    [TestClass]
    public class UnitTestIsbn
    {
        [TestMethod]
        [DataRow("978-0-30-640615-7")]
        [DataRow("9781566199094")]
        public void TestIsbnClassValidationPositive(string isbn)
        {
            Assert.IsTrue(TesterClass.CheckIsbnClassBool(isbn));
        }

        [TestMethod]
        [DataRow("978-0-30-640615-73")]
        [DataRow("97815661990942")]
        [DataRow("978156619a094")]
        [DataRow("A781566195094")]
        [DataRow("9781566195094_")]
        public void TestIsbnClassValidationNegative(string isbn)
        {
            Assert.IsFalse(TesterClass.CheckIsbnClassBool(isbn));
        }

        [TestMethod]
        [DataRow(null)]
        [DataRow("978-0-30-640615-73")]
        [DataRow("97815661990942")]
        [DataRow("978156619a094")]
        [DataRow("A781566195094")]
        [DataRow("9781566195094_")]
        public void TestIsbnClassValidationException(string isbn)
        {
            Assert.ThrowsException<ArgumentException>(() => TesterClass.CheckIsbnClassException(isbn));
        }

        [TestMethod] 
        [DataRow("9781566199094", "9781566199095")]
        [DataRow("978-0-30-640615-7", "9780306406156")]
        [DataRow("9780306406156", "978-0-30-640615-7")]
        public void TestIsbnClassValidationEqualsNegative(string isbn1, string isbn2)
        {
            var t1 = new Isbn(isbn1);
            var t2 = new Isbn(isbn2);
            Assert.IsFalse(t1.Equals(t2));
        }
    }
}
