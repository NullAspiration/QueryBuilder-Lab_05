using System.Xml.Linq;

namespace QueryBuilder
{
    internal class BooksOutOnLoan : IComparable
    {
        public int Id { get; init; }
        public string BookId { get; init; }

        public BooksOutOnLoan() { }

        public BooksOutOnLoan(int id, string bookId)
        {
            Id = id;
            BookId = bookId;
        }
        public override string ToString()
        {
            return
            $"Id:\t\t\t{Id}\n" +
                $"BookId:\t\t\t{BookId}\n";


        }
        public int CompareTo(object? obj)
        {
            BooksOutOnLoan compareBooksOutOnLoan = (BooksOutOnLoan)obj;
            if (compareBooksOutOnLoan.Id > this.Id)
                return -1;
            else if (compareBooksOutOnLoan.Id == this.Id)
                return 0;
            else
                return 1;
        }

    }
}
