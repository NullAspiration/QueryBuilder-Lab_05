namespace QueryBuilder
{
    public class Author
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

    }
}
