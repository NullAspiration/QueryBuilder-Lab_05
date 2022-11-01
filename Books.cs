namespace QueryBuilder
{
    internal class Books
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Isbn { get; set; }

        public Books() { }

        public Books(int id, string title, string isbn)
        {
            Id = id;
            Title = title;
            Isbn = isbn;
        }
    }
}
