using System.Configuration;
using Microsoft.Data.Sqlite;
internal class Database
{
    private readonly string? ConnectionString = ConfigurationManager.AppSettings.Get("connectionString");

    internal Database()
    {
        CreateDatabase();
    }
    internal void CreateDatabase()
    {
        using (var connection = new SqliteConnection(ConnectionString))
        {
            using (var command = connection.CreateCommand())
            {
                connection.Open();

                command.CommandText =
                    @"CREATE TABLE IF NOT EXISTS CodingTracker
                        (Id INTEGER PRIMARY KEY AUTOINCREMENT, StartTime STRING, EndTime STRING, Duration INTEGER);";

                command.ExecuteNonQuery();
            }
        }
    }

    internal CodingTrackerModel ReadById(int Id)
    {
        CodingTrackerModel model = new();

        using (var connection = new SqliteConnection(ConnectionString))
        {
            using (var command = connection.CreateCommand())
            {
                connection.Open();

                command.CommandText = $"SELECT * FROM CodingTracker WHERE Id={Id}";

                var reader = command.ExecuteReader();

                try
                {
                    reader.Read();

                    model = new()
                    {
                        Id = reader.GetString(0),
                        StartTime = reader.GetString(1),
                        EndTime = reader.GetString(2),
                        Duration = reader.GetString(3)
                    };
                } catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }
        }
        return model;
    }

    internal List<CodingTrackerModel> Read()
    {
        List<CodingTrackerModel> list = new();

        using (var connection = new SqliteConnection(ConnectionString))
        {
            using (var command = connection.CreateCommand())
            {
                connection.Open();

                command.CommandText =
                    @"SELECT * FROM CodingTracker";

                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    CodingTrackerModel model = new()
                    {
                        Id = reader.GetString(0),
                        StartTime = reader.GetString(1),
                        EndTime = reader.GetString(2),
                        Duration = reader.GetString(3)
                    };
                    list.Add(model);
                }
            }
        }
        return list;
    }

    internal void Insert(string startTime, string endTime, int duration)
    {
        using (var connection = new SqliteConnection(ConnectionString))
        {
            using (var command = connection.CreateCommand())
            {
                connection.Open();

                command.CommandText =
                    $@"INSERT INTO CodingTracker (StartTime, EndTime, Duration)
                        VALUES ('{startTime}', '{endTime}', {duration})";

                command.ExecuteNonQuery();
            }
        }
    }

    internal void Update(int id, string startTime, string endTime, int duration)
    {
        using (var connection = new SqliteConnection(ConnectionString))
        {
            using (var command = connection.CreateCommand())
            {
                connection.Open();

                command.CommandText =
                    $@"UPDATE CodingTracker SET 
                        StartTime='{startTime}',
                        EndTime='{endTime}',
                        Duration={duration}
                    WHERE Id={id}";

                command.ExecuteNonQuery();
            }
        }
    }

    internal void Delete(int id)
    {
        using (var connection = new SqliteConnection(ConnectionString))
        {
            using (var command = connection.CreateCommand())
            {
                connection.Open();

                command.CommandText =
                    $@"DELETE FROM CodingTracker WHERE Id={id}";

                command.ExecuteNonQuery();
            }
        }
    }
}

