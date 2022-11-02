using Microsoft.Data.Sqlite;

public class DataOperations : IDisposable
{
    private readonly SqliteConnection connection;
    /// <summary>
    /// Opens connenction to DB upon creation of object
    /// </summary>
    public DataOperations(string dbPath)//path to db file 
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
    public string ReadAll<T>() where T : new()
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
            dataString += typeof(T).Name + " " + reader.GetString(0) + "\n";
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