namespace QueryBuilder
{
    internal class Categories : IComparable
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Categories() { }
        public Categories(int id, string name)
        {
            Id = id;
            Name = name;
        }
        public override string ToString()
        {
            return
                $"Id:\t\t\t{Id}\n" +
                $"FirstName:\t\t{Name}\n";
                

        }
        public int CompareTo(object? obj)
        {
            Categories compareCategories = (Categories)obj;
            if (compareCategories.Id > this.Id)
                return -1;
            else if (compareCategories.Id == this.Id)
                return 0;
            else
                return 1;
        }

    }
}
