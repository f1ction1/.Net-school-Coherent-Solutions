namespace Task6.DALEntities
{
    public class DALBook
    {
        public string? Title {  get; set; }
        public List<DALAuthor>? Authors { get; set; }
        public DALBook() { }
    }
}
