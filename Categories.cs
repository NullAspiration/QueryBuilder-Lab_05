namespace QueryBuilder
{
    internal class Categories
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Categories() { }
        public Categories(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
