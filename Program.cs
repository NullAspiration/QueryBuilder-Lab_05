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

            //reads Users.csv
            Console.WriteLine("|__________Reading Users.csv________________|" + "\n");
            var userlist = ReadUsersFromCSV();
            userlist.Sort();
            foreach (var u in userlist)
            {
                Console.WriteLine(u);
                Console.WriteLine("|___________________________________________|");
            }
            Console.WriteLine("|__________Reading Users From DB____________|" + "\n");
            Console.WriteLine(dbOp.ReadAll<Users>());


            //reads Books.csv
            Console.WriteLine("|__________Reading Books.csv________________|" + "\n");
            var booklist = ReadBooksFromCSV();
            booklist.Sort();
            foreach (var b in booklist)
            {
                Console.WriteLine(b);
                Console.WriteLine("|___________________________________________|");
            }
            Console.WriteLine("|__________Reading Books From DB____________|" + "\n");
            Console.WriteLine(dbOp.ReadAll<Books>());

            //reads Authors.csv
            Console.WriteLine("|__________Reading Author.csv________________|" + "\n");
            var authorlist = ReadAuthorFromCSV();
            authorlist.Sort();
            foreach (var a in authorlist)
            {
                Console.WriteLine(a);
                Console.WriteLine("|___________________________________________|");
            }
            Console.WriteLine("|__________Reading Author From DB___________|" + "\n");
            Console.WriteLine(dbOp.ReadAll<Author>());






            //reads Categories.csv
            Console.WriteLine("|__________Reading Categories.csv___________|" + "\n");
            var categorieslist = ReadCategoriesFromCSV();
            categorieslist.Sort();
            foreach (var a in categorieslist)
            {
                Console.WriteLine(a);
                Console.WriteLine("|___________________________________________|");
            }
            Console.WriteLine("|__________Reading Categories_______________|" + "\n");
            Console.WriteLine(dbOp.ReadAll<Categories>());

            //reads BooksOutOnLoan.csv
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

        static List<Books> ReadBooksFromCSV()
        {
            Console.WriteLine("Source Dir: " + ProjectRoot.Root + Path.DirectorySeparatorChar + "Data" + Path.DirectorySeparatorChar + "Books.csv");
            var booklist = new List<Books>();
            using (var reader = new StreamReader(ProjectRoot.Root + Path.DirectorySeparatorChar + "Data" + Path.DirectorySeparatorChar + "Books.csv"))
            {
                try
                {
                    while (!reader.EndOfStream)
                    {
                        // read line by line
                        var line = reader.ReadLine();

                        // split the string on the delimiter (,)
                        var values = line.Split(",");
                        booklist.Add(new Books(int.Parse(values[0]), values[1], values[2]));
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            } // end using

            return booklist;
        }

        static List<Author> ReadAuthorFromCSV()
        {
            Console.WriteLine("Source Dir: " + ProjectRoot.Root + Path.DirectorySeparatorChar + "Data" + Path.DirectorySeparatorChar + "Author.csv");
            var authorlist = new List<Author>();
            using (var reader = new StreamReader(ProjectRoot.Root + Path.DirectorySeparatorChar + "Data" + Path.DirectorySeparatorChar + "Author.csv"))
            {
                try
                {
                    while (!reader.EndOfStream)
                    {
                        // read line by line
                        var line = reader.ReadLine();

                        // split the string on the delimiter (,)
                        var values = line.Split(",");
                        authorlist.Add(new Author(int.Parse(values[0]), values[1], values[2]));
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            } // end using

            return authorlist;
        }
        static List<Categories> ReadCategoriesFromCSV()
        {
            Console.WriteLine("Source Dir: " + ProjectRoot.Root + Path.DirectorySeparatorChar + "Data" + Path.DirectorySeparatorChar + "Categories.csv");
            var categorieslist = new List<Categories>();
            using (var reader = new StreamReader(ProjectRoot.Root + Path.DirectorySeparatorChar + "Data" + Path.DirectorySeparatorChar + "Categories.csv"))
            {
                try
                {
                    while (!reader.EndOfStream)
                    {
                        // read line by line
                        var line = reader.ReadLine();

                        // split the string on the delimiter (,)
                        var values = line.Split(",");
                        categorieslist.Add(new Categories(int.Parse(values[0]), values[1]));
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            } // end using

            return categorieslist;
        }
    }
}