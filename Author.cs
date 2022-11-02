namespace QueryBuilder
{
    public class Author : IComparable
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string SurName { get; set; }

        public Author() { }
        public Author(int id, string firstname, string surname)
        {
            Id = id;
            FirstName = firstname;
            SurName = surname;
        }
        public override string ToString()
        {
            return
                $"Id:\t\t\t{Id}\n" +
                $"FirstName:\t\t{FirstName}\n" +
                $"SurName:\t\t{SurName}\n";

        }
        public int CompareTo(object? obj)
        {
            Author compareAuthor = (Author)obj;
            if (compareAuthor.Id > this.Id)
                return -1;
            else if (compareAuthor.Id == this.Id)
                return 0;
            else
                return 1;
        }

    }
}
