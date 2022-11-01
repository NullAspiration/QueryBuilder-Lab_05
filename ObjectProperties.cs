
namespace QueryBuilder
{
    public class ObjectProperties
    {
        public static string ObjectProps<T>(T obj) where T : new()
        {
            return typeof(T).Name;
        }
    }
}
