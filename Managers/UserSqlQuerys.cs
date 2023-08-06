using MySql.Data.MySqlClient;
using NewNewProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewNewProject.Managers
{
    public class UserSqlQuerys
    {
        private const string ConnectionString = "Server=localhost; Database=wpf; user=root; Password=elbek";
        private MySqlConnection conn = new MySqlConnection(ConnectionString);

        public UserSqlQuerys()
        {
            conn.Open();
            CreateTables();
        }

        public void CreateTables()
        {
            var _command = conn.CreateCommand();
            _command.CommandText = "CREATE TABLE IF NOT EXISTS users(id INTEGER NOT NULL PRIMARY KEY AUTO_INCREMENT, name TEXT NOT NULL, password TEXT NOT NULL, rememberMe BOOLEAN)";
            _command.ExecuteNonQuery();
        }
        public List<User> GetUsers()
        {
            var users = new List<User>();
            var command = conn.CreateCommand();
            command.CommandText = "SELECT * FROM users";
            var reader = command.ExecuteReader();

            while (reader.Read())
            {
                users.Add(new User()
                {
                    UserName = reader.GetString(1),
                    Password = reader.GetString(2)
                });
            }
            reader.Close();
            return users;
        }

        public User GetUser(string username)
        {
            var user = new User();
            var command = conn.CreateCommand();
            command.CommandText = "SELECT * FROM users WHERE name = @username";
            command.Parameters.AddWithValue("username", username);
            command.Prepare();
            var reader = command.ExecuteReader();

            while (reader.Read())
            {
                user.UserName = reader.GetString(1);
                user.Password = reader.GetString(2);
                user.RememberMe = reader.GetBoolean(3);
            }
            reader.Close();
            return user;
        }

        public bool CheckUser(string username)
        {
            var user = new User();
            var command = conn.CreateCommand();
            command.CommandText = "SELECT * FROM users WHERE name = @username";
            command.Parameters.AddWithValue("username", username);
            command.Prepare();
            var reader = command.ExecuteReader();

            while (reader.Read())
            {
                user.UserName = reader.GetString(1);
            }

            reader.Close();
            if (user.UserName != null)
            {
                return true;
            }
            else { return false; }
        }

        public void CreateUser(string username, string password, bool remember = false)
        {
            var command = conn.CreateCommand();
            command.CommandText = "INSERT INTO users(name, password, rememberMe) VALUES(@username, @password, @remember)";
            command.Parameters.AddWithValue("username", username);
            command.Parameters.AddWithValue("password", password);
            command.Parameters.AddWithValue("remember", remember);
            command.Prepare();
            command.ExecuteNonQuery();
        }
    }
}
