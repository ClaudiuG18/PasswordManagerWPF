using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;

namespace Frames_Pages
{
    public class DatabaseHelper
    {
        private static readonly string ConnectionString = "Data Source=UserData.db;Version=3;";

        public static SQLiteConnection GetSQLiteConnection()
        {
            return new SQLiteConnection(ConnectionString);
        }

        public static void CreateUserRegTables()
        {
  
            using (SQLiteConnection connection = GetSQLiteConnection())
            {
                connection.Open();

                // Create Users table
                string createUsersTableQuery = 
                @"
                    CREATE TABLE IF NOT EXISTS Users 
                       ( UserId INTEGER PRIMARY KEY AUTOINCREMENT,
                       UserName TEXT NOT NULL,
                       Password TEXT NOT NULL );
                ";

              

                using (SQLiteCommand command = new SQLiteCommand(connection))
                {
                    command.CommandText = createUsersTableQuery;
                    command.ExecuteNonQuery();

                }
            }

        }

        public static void CreateDataTables(string username)
        {

            using (SQLiteConnection connection = GetSQLiteConnection())
            {
                connection.Open();

                string tableName = username;
                // Create ÚserData table
                string createUserDataTableQuery =
                $@"   CREATE TABLE IF NOT EXISTS {tableName}
                    (UserDataId INTEGER PRIMARY KEY AUTOINCREMENT,
                    UserName TEXT NOT NULL,
                    Password TEXT NOT NULL,
                    Application TEXT);
                ";

                using (SQLiteCommand command = new SQLiteCommand(connection))
                {
               

                    command.CommandText = createUserDataTableQuery;
                    command.ExecuteNonQuery();
                }
            }

        }

        public static void InsertUser(RegUser user)
        {
            using (SQLiteConnection connection = GetSQLiteConnection())
            {
                connection.Open();

                string insertQuery = "INSERT INTO Users (UserName, Password) VALUES (@UserName, @Password);";

                using (SQLiteCommand command = new SQLiteCommand(insertQuery, connection))
                {
                    command.Parameters.AddWithValue("@UserName", user.Username);
                    command.Parameters.AddWithValue("@Password", user.Password);
                    command.ExecuteNonQuery();
                }
                
            }
        }

        public static void InsertData(UserData user, string tablename)
        {
            using (SQLiteConnection connection = GetSQLiteConnection())
            {
                connection.Open();
                
                string table = tablename;
                string insertQuery = $"INSERT INTO {table} (UserName, Password, Application) VALUES (@UserName, @Password, @Application);";

                using (SQLiteCommand command = new SQLiteCommand(insertQuery, connection))
                {
                    command.Parameters.AddWithValue("@UserName", user.Username);
                    command.Parameters.AddWithValue("@Password", user.Password);
                    command.Parameters.AddWithValue("@Application", user.Application);

                    command.ExecuteNonQuery();
                }
                connection.Close(); 
            }
        }

        public static List<RegUser> GetRegUsers()
        {
            List<RegUser> regUsers = new List<RegUser>();

            using (SQLiteConnection connection = GetSQLiteConnection())
            {
                connection.Open();

                string query = "SELECT * FROM Users;";
                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            regUsers.Add(new RegUser
                            {
                                Username = reader["Username"].ToString(),
                                Password = reader["Password"].ToString()
                            });
                        }
                    }
                }
            }

            return regUsers;
        }

        public static List<UserData> GetUserData(string tableName)
        {
            List<UserData> userData = new List<UserData>();

            using (SQLiteConnection connection = GetSQLiteConnection())
            {
                connection.Open();
                string table = tableName;

                string query = $"SELECT * FROM {table};";

                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            userData.Add(new UserData
                            {
                                Username = reader["Username"].ToString(),
                                Password = reader["Password"].ToString(),
                                Application = reader["Application"].ToString()
                            });
                        }
                    }
                }
                connection.Close(); 
            }
            
            return userData;
        }
    }

}

