namespace QueryBuilder
{
    internal class BooksOutOnLoan
    {
        public int Id { get; set; }
        public string BookId { get; set; }

        public BooksOutOnLoan() { }

        public BooksOutOnLoan(int id, string bookId)
        {
            Id = id;
            BookId = bookId;
        }
    }
}
