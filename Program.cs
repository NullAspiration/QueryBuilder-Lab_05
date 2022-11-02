namespace QueryBuilder
{
    public class Program
    {
        static string CONNECTION_STRING = "Data Source = " + ProjectRoot.Root + Path.DirectorySeparatorChar + "Data" + Path.DirectorySeparatorChar + "QueryBuilderDB.db";
        static void Main(string[] args)
        {
            if (args is null)
            {
                throw new ArgumentNullException(nameof(args));
            }


            //DataOPs uses IDisposeable, Dispose() is automatically called (so using is used)
            using var dbOp = new DataOperations(CONNECTION_STRING);
            
            
            Console.WriteLine("|__________Reading Users.csv________________|" + "\n");
            var userlist = ReadUsersFromCSV();
            userlist.Sort();
            foreach (var u in userlist)
            {
                Console.WriteLine(u);
                Console.WriteLine("|___________________________________________|");
            }



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
        static List<Users> ReadUsersFromCSV()
        {
            Console.WriteLine("Source Dir: " + ProjectRoot.Root + Path.DirectorySeparatorChar + "Data" + Path.DirectorySeparatorChar + "Users.csv");
            var userlist = new List<Users>();
            using (var reader = new StreamReader(ProjectRoot.Root + Path.DirectorySeparatorChar + "Data" + Path.DirectorySeparatorChar + "Users.csv"))
            {
                try
                {
                    while (!reader.EndOfStream)
                    {
                        // read line by line
                        var line = reader.ReadLine();

                        // split the string on the delimiter (,)
                        var values = line.Split(",");
                        userlist.Add(new Users(int.Parse(values[0]), values[1], values[2], values[3], values[4], values[5], values[6]));
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            } // end using

            return userlist;
        }
    }
}