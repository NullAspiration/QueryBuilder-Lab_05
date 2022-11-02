namespace QueryBuilder
{
    internal class Books : IComparable
    {
        public int Id { get; init; }
        public string Title { get; init; }
        public string Isbn { get; init; }

        public Books() { }

        public Books(int id, string title, string isbn)
        {
            Id = id;
            Title = title;
            Isbn = isbn;
        }
        public override string ToString()
        {
            return
                $"Id:\t\t\t{Id}\n" +
                $"Title:\t\t\t{Title}\n" +
                $"ISBN:\t\t\t{Isbn}\n";
                
        }
        public int CompareTo(object? obj)
        {
            Books compareBooks = (Books)obj;
            if (compareBooks.Id > this.Id)
                return -1;
            else if (compareBooks.Id == this.Id)
                return 0;
            else
                return 1;
        }
    }
}
