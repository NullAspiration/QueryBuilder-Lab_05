using Microsoft.Data.Sqlite;

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

            //Clears the database
            ClearAllFromDB();

            //reads Users.csv
            Console.WriteLine("|__________Reading Users.csv________________|" + "\n");
            var userlist = ReadUsersFromCSV();
            userlist.Sort();
            foreach (var u in userlist)
            {
                Console.WriteLine(u);
                Console.WriteLine("|___________________________________________|");
            }
            AddAllUsers(userlist);
            //reads all users from database
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
            AddAllBooks(booklist);
            //reads all Books from database
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
            AddAllAuthor(authorlist);
            //reads all Author from database
            Console.WriteLine("|__________Reading Author From DB___________|" + "\n");
            Console.WriteLine(dbOp.ReadAll<Author>());




            //reads Categories.csv
            Console.WriteLine("|__________Reading Categories.csv___________|" + "\n");
            var categorieslist = ReadCategoriesFromCSV();
            categorieslist.Sort();
            foreach (var c in categorieslist)
            {
                Console.WriteLine(c);
                Console.WriteLine("|___________________________________________|");
            }
            AddAllCategories(categorieslist);
            //reads all Categories from database
            Console.WriteLine("|__________Reading Categories From DB_______|" + "\n");
            Console.WriteLine(dbOp.ReadAll<Categories>());




            //reads BooksOutOnLoan.csv
            Console.WriteLine("|__________Reading BooksOutOnLoan.csv___________|" + "\n");
            var booksoutonloanlist = ReadBooksOutOnLoanFromCSV();
            booksoutonloanlist.Sort();
            foreach (var bol in booksoutonloanlist)
            {
                Console.WriteLine(bol);
                Console.WriteLine("|___________________________________________|");
            }
            AddAllBooksOutOnLoan(booksoutonloanlist);
            //reads all BooksOutOnLoan from database
            Console.WriteLine("|__________Reading BooksOutOnLoan From DB___|" + "\n");
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
        static List<BooksOutOnLoan> ReadBooksOutOnLoanFromCSV()
        {
            Console.WriteLine("Source Dir: " + ProjectRoot.Root + Path.DirectorySeparatorChar + "Data" + Path.DirectorySeparatorChar + "BooksOutOnLoan.csv");
            var booksoutonloanlist = new List<BooksOutOnLoan>();
            using (var reader = new StreamReader(ProjectRoot.Root + Path.DirectorySeparatorChar + "Data" + Path.DirectorySeparatorChar + "BooksOutOnLoan.csv"))
            {
                try
                {
                    while (!reader.EndOfStream)
                    {
                        // read line by line
                        var line = reader.ReadLine();

                        // split the string on the delimiter (,)
                        var values = line.Split(",");
                        booksoutonloanlist.Add(new BooksOutOnLoan(int.Parse(values[0]), values[1]));
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            } // end using

            return booksoutonloanlist;
        }

        //Add single entry of type Author to DB
        static void AddAuthorToDB(Author a)
        {
            using (var connection = new SqliteConnection(CONNECTION_STRING))
            {
                connection.Open();
                var commandText =
                    @"
                            INSERT INTO Author
                            VALUES($Id, $FirstName, $SurName)
                        ";
                using (var command = new SqliteCommand(commandText, connection))
                {
                    command.CommandType = System.Data.CommandType.Text;

                    command.Parameters.AddWithValue("$Id", a.Id).SqliteType = SqliteType.Integer;
                    command.Parameters.AddWithValue("$FirstName", a.FirstName).SqliteType = SqliteType.Text;
                    command.Parameters.AddWithValue("$SurName", a.SurName).SqliteType = SqliteType.Text;

                    command.ExecuteNonQuery();
                    connection.Close();
                }
            }


        }

        //Add single entry of type Books to DB
        static void AddBooksToDB(Books b)
        {
            using (var connection = new SqliteConnection(CONNECTION_STRING))
            {
                connection.Open();
                var commandText =
                    @"
                            INSERT INTO Books
                            VALUES($Id, $Title, $Isbn)
                        ";
                using (var command = new SqliteCommand(commandText, connection))
                {
                    command.CommandType = System.Data.CommandType.Text;

                    command.Parameters.AddWithValue("$Id", b.Id).SqliteType = SqliteType.Integer;
                    command.Parameters.AddWithValue("Title", b.Title).SqliteType = SqliteType.Text;
                    command.Parameters.AddWithValue("Isbn", b.Isbn).SqliteType = SqliteType.Text;


                    command.ExecuteNonQuery();
                    connection.Dispose();
                }
            }


        }

        //Add single entry of type BooksOutOnLoan to DB
        static void AddBooksOutOnLoanToDB(BooksOutOnLoan bol)
        {
            using (var connection = new SqliteConnection(CONNECTION_STRING))
            {
                connection.Open();
                var commandText =
                    @"
                            INSERT INTO BooksOutOnLoan
                            VALUES($Id, $BookId)
                        ";
                using (var command = new SqliteCommand(commandText, connection))
                {
                    command.CommandType = System.Data.CommandType.Text;

                    command.Parameters.AddWithValue("$Id", bol.Id).SqliteType = SqliteType.Integer;
                    command.Parameters.AddWithValue("$BookId", bol.BookId).SqliteType = SqliteType.Text;


                    command.ExecuteNonQuery();
                    connection.Dispose();
                }
            }


        }

        //Add single entry of type Categories to DB
        static void AddCategoriesToDB(Categories c)
        {
            using (var connection = new SqliteConnection(CONNECTION_STRING))
            {
                connection.Open();
                var commandText =
                    @"
                            INSERT INTO Categories
                            VALUES($Id, $Name)
                        ";
                using (var command = new SqliteCommand(commandText, connection))
                {
                    command.CommandType = System.Data.CommandType.Text;

                    command.Parameters.AddWithValue("$Id", c.Id).SqliteType = SqliteType.Integer;
                    command.Parameters.AddWithValue("$Name", c.Name).SqliteType = SqliteType.Text;


                    command.ExecuteNonQuery();
                    connection.Dispose();
                }
            }


        }

        //Add single entry of type Users to DB
        static void AddUsersToDB(Users u)
        {
            using (var connection = new SqliteConnection(CONNECTION_STRING))
            {
                connection.Open();
                var commandText =
                    @"
                            INSERT INTO Users
                            VALUES($Id, $UserName, $UserAddress, $OtherUserDetails, $AmountOfFine, $Email, $PhoneNumber)
                        ";
                using (var command = new SqliteCommand(commandText, connection))
                {
                    command.CommandType = System.Data.CommandType.Text;

                    command.Parameters.AddWithValue("$Id", u.Id).SqliteType = SqliteType.Integer;
                    command.Parameters.AddWithValue("$UserName", u.UserName).SqliteType = SqliteType.Text;
                    command.Parameters.AddWithValue("$UserAddress", u.UserAddress).SqliteType = SqliteType.Text;
                    command.Parameters.AddWithValue("$OtherUserDetails", u.OtherUserDetails).SqliteType = SqliteType.Text;
                    command.Parameters.AddWithValue("$AmountOfFine", u.AmountOfFine).SqliteType = SqliteType.Text;
                    command.Parameters.AddWithValue("$Email", u.Email).SqliteType = SqliteType.Text;
                    command.Parameters.AddWithValue("$PhoneNumber", u.PhoneNumber).SqliteType = SqliteType.Text;

                    command.ExecuteNonQuery();
                    connection.Dispose();
                }
            }


        }

        //loops through and adds all users from csv to DB
        static void AddAllUsers(List<Users> userdb)
        {
            foreach (var u in userdb)
            {
                AddUsersToDB(u);
            }
        }
        //loops through and adds all Author from csv to DB
        static void AddAllAuthor(List<Author> authordb)
        {
            foreach (var a in authordb)
            {
                AddAuthorToDB(a);
            }
        }
        //loops through and adds all users from csv to DB
        static void AddAllBooks(List<Books> bookdb)
        {
            foreach (var b in bookdb)
            {
                AddBooksToDB(b);
            }
        }
        //loops through and adds all users from csv to DB
        static void AddAllBooksOutOnLoan(List<BooksOutOnLoan> boldb)
        {
            foreach (var bol in boldb)
            {
                AddBooksOutOnLoanToDB(bol);
            }
        }
        //loops through and adds all users from csv to DB
        static void AddAllCategories(List<Categories> categoriesdb)
        {
            foreach (var c in categoriesdb)
            {
                AddCategoriesToDB(c);
            }
        }


        static void ClearAuthorFromDB()
        {
            using (var connection = new SqliteConnection(CONNECTION_STRING))
            {
                connection.Open();
                using (var command = new SqliteCommand(@"DELETE FROM Author", connection))
                {
                    command.CommandType = System.Data.CommandType.Text;
                    command.ExecuteNonQuery();
                    connection.Close();
                }
            }
        }
        static void ClearBooksFromDB()
        {
            using (var connection = new SqliteConnection(CONNECTION_STRING))
            {
                connection.Open();
                using (var command = new SqliteCommand(@"DELETE FROM Books", connection))
                {
                    command.CommandType = System.Data.CommandType.Text;
                    command.ExecuteNonQuery();
                    connection.Close();
                }
            }
        }
        static void ClearBooksOutOnLoanFromDB()
        {
            using (var connection = new SqliteConnection(CONNECTION_STRING))
            {
                connection.Open();
                using (var command = new SqliteCommand(@"DELETE FROM BooksOutOnLoan", connection))
                {
                    command.CommandType = System.Data.CommandType.Text;
                    command.ExecuteNonQuery();
                    connection.Close();
                }
            }
        }
        static void ClearCategoriesFromDB()
        {
            using (var connection = new SqliteConnection(CONNECTION_STRING))
            {
                connection.Open();
                using (var command = new SqliteCommand(@"DELETE FROM Categories", connection))
                {
                    command.CommandType = System.Data.CommandType.Text;
                    command.ExecuteNonQuery();
                    connection.Close();
                }
            }
        }
        static void ClearUsersFromDB()
        {
            using (var connection = new SqliteConnection(CONNECTION_STRING))
            {
                connection.Open();
                using (var command = new SqliteCommand(@"DELETE FROM Users", connection))
                {
                    command.CommandType = System.Data.CommandType.Text;
                    command.ExecuteNonQuery();
                    connection.Close();
                }
            }
        }
        static void ClearAllFromDB()
        {
            using (var connection = new SqliteConnection(CONNECTION_STRING))
            {
                connection.Open();
                var commandText =
                    @"
                        DELETE FROM Author;
                        DELETE FROM Books;
                        DELETE FROM BooksOutOnLoan;
                        DELETE FROM Categories;
                        DELETE FROM Users;
                     ";
                using (var command = new SqliteCommand(commandText, connection))
                {
                    command.CommandType = System.Data.CommandType.Text;
                    command.ExecuteNonQuery();
                    connection.Close();
                }
            }
        }
    }
}