using Microsoft.Data.Sqlite;

namespace QueryBuilder
{

    public class Driver : IDisposable
    {

        private SqliteConnection connection;
        /// <summary>
        /// Opens connenction to DB upon creation of object
        /// </summary>
        public Driver(string dbPath)//path to db file 
        {
            connection = new SqliteConnection(dbPath);
            connection.Open();
        }

        /// <summary>
        /// Reads a row from db, returns obj of type T
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="id">ID of record to read</param>
        /// <returns></returns>
        public string ReadAll<T>(int id) where T : new()
        {
            var dataString = "";
            //create command
            var command = connection.CreateCommand();

            //Set command text
            command.CommandText = $"SELECT * FROM {typeof(T).Name}";

            //reader for database
            var reader = command.ExecuteReader();

            while (reader.Read())
            {
                dataString += reader.GetString(0);
            }

            return dataString;
        }


        //implements IDisposable
        public void Dispose()
        {
            //closes connection to SqliteDB
            connection.Close();
        }
    }
}
