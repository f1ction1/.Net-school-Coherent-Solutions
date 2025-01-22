using Task5;
namespace TestTask5._2
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        [DataRow(null, "2023-11-14", new string[] { "Author1", "Author2" })]
        [DataRow("Title1", "15.11.2025", new string[] { "Author1", "Author2" })]
        [DataRow("Title1", "15.11.2023", null)]
        public void TestBookClassExeptions(string title, string publicationDate, string[] authorsArray)
        {
            DateTime? date = DateTime.Parse(publicationDate);
            var authors = new HashSet<string>(authorsArray); //Here Exeption os thrown second that's why test failed
            Assert.ThrowsException<ArgumentException>(() => TesterClass.CheckBookClass(title, date, authors));
        }
    }

}
