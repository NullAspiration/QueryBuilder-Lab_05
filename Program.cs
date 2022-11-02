namespace QueryBuilder
{
    public class Program
    {
        static string CONNECTION_STRING = "Data Source = " + ProjectRoot.Root + Path.DirectorySeparatorChar + "Data" + Path.DirectorySeparatorChar + "QueryBuilderDB.db";
        static void Main(String[] args)
        {
            //Helper uses IDisposeable, Dispose() is automatically called (so using is used)
            using (var dbOp = new DataOperations(CONNECTION_STRING))
            {
                
                Console.WriteLine("|__________Reading Users____________________|" + "\n");
                Console.WriteLine(dbOp.ReadAll<Users>());
               
                Console.WriteLine("|__________Reading Books____________________|" + "\n");
                Console.WriteLine(dbOp.ReadAll<Books>());
                
                Console.WriteLine("|__________Reading Author___________________|" + "\n");
                Console.WriteLine(dbOp.ReadAll<Author>());
                
                Console.WriteLine("|__________Reading Categories_______________|" + "\n");
                Console.WriteLine(dbOp.ReadAll<Categories>());
                
                Console.WriteLine("|__________Reading BooksOutOnLoan___________|" + "\n");
                Console.WriteLine(dbOp.ReadAll<BooksOutOnLoan>());
            }
        }
    }
}
