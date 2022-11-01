
namespace QueryBuilder
{
    public class Generic<T>
    {
        public T Item { get; set; }
        public string Name { get; set; }

        public Generic(T item, string name)
        {
            Item = item;
            Name = name;
        }
    }
}
