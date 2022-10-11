using System;
using System.Configuration;
using System.Collections.Specialized;
using Microsoft.Data.Sqlite;
internal class Database
{
    private readonly string? ConnectionString = ConfigurationManager.AppSettings.Get("connectionString");
    internal void CreateDatabase()
    {
        using (var connection = new SqliteConnection(ConnectionString))
        {
            using (var command = connection.CreateCommand())
            {
                connection.Open();

                command.CommandText =
                    @"CREATE TABLE IF NOT EXISTS CodingTracker
                        (Id int AUTO INCREMENT, StartTime string, EndTime string, Duration int);";

                command.ExecuteNonQuery();
            }
        }
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
                    CodingTrackerModel Model = new()
                    {
                        Id = reader.GetString(0),
                        StartTime = reader.GetString(1),
                        EndTime = reader.GetString(2),
                        Duration = reader.GetString(3)
                    };
                    list.Add(Model);
                }
            }
        }
        return list;
    }

    internal void Insert(string StartTime, string EndTime, int Duration)
    {
        using (var connection = new SqliteConnection(ConnectionString))
        {
            using (var command = connection.CreateCommand())
            {
                connection.Open();

                command.CommandText =
                    $@"INSERT INTO CodingTracker (StartTime, EndTime, Duration)
                        VALUES ({StartTime}, {EndTime}, {Duration})";

                command.ExecuteNonQuery();
            }
        }
    }

    internal void Update(int Id, string StartTime, string EndTime, int Duration)
    {
        using (var connection = new SqliteConnection(ConnectionString))
        {
            using (var command = connection.CreateCommand())
            {
                connection.Open();

                command.CommandText =
                    $@"UPDATE CodingTracker SET 
                        StartTime={StartTime},
                        EndTime={EndTime},
                        Duration={Duration}
                    WHERE Id={Id}";

                command.ExecuteNonQuery();
            }
        }
    }

    internal void Delete(int Id)
    {
        using (var connection = new SqliteConnection(ConnectionString))
        {
            using (var command = connection.CreateCommand())
            {
                connection.Open();

                command.CommandText =
                    $@"DELETE FROM CodingTracker WHERE Id={Id}";

                command.ExecuteNonQuery();
            }
        }
    }
}

