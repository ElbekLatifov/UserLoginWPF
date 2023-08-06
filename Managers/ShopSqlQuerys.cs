using MySql.Data.MySqlClient;
using NewNewProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewNewProject.Managers
{
    public class ShopSqlQuerys
    {
        private const string ConnectionString = "Server=localhost; Database=wpf; user=root; Password=elbek";
        private MySqlConnection conn = new MySqlConnection(ConnectionString);

        public ShopSqlQuerys()
        {
            conn.Open();
            CreateTables();
        }

        public void CreateTables()
        {
            var _command = conn.CreateCommand();
            _command.CommandText = "CREATE TABLE IF NOT EXISTS shops(id INTEGER NOT NULL PRIMARY KEY AUTO_INCREMENT, name TEXT NOT NULL, discription INTEGER NOT NULL)";
            _command.ExecuteNonQuery();
        }
        public List<Shop> GetShops()
        {
            var shops = new List<Shop>();
            var command = conn.CreateCommand();
            command.CommandText = "SELECT * FROM shops";
            var reader = command.ExecuteReader();

            while (reader.Read())
            {
                shops.Add(new Shop()
                {
                    Id = reader.GetInt32(0),
                    Title = reader.GetString(1),
                    Description = (Profesion)(reader.GetInt32(2))
                });
            }
            reader.Close();
            return shops;
        }

        public Shop GetShop(int id)
        {
            var shop = new Shop();
            var command = conn.CreateCommand();
            command.CommandText = "SELECT * FROM users WHERE id = @id";
            command.Parameters.AddWithValue("id", id);
            command.Prepare();
            var reader = command.ExecuteReader();

            while (reader.Read())
            {
                shop.Id = reader.GetInt32(0);
                shop.Title = reader.GetString(1);
                shop.Description = (Profesion)reader.GetInt32(2);
            }
            reader.Close();
            return shop;
        }

        public void CreateShop(string name, int description)
        {
            var command = conn.CreateCommand();
            command.CommandText = "INSERT INTO shops(name, discription) VALUES(@username, @discription)";
            command.Parameters.AddWithValue("username", name);
            command.Parameters.AddWithValue("discription", description);
            command.Prepare();
            command.ExecuteNonQuery();
        }

        public void DeleteShop(int id)
        {
            var command = conn.CreateCommand();
            command.CommandText = "DELETE FROM shops WHERE id = @id";
            command.Parameters.AddWithValue("id", id);
            command.Prepare();
            command.ExecuteNonQuery();
        }

        public void UpdateShop(int id, string name, int discription)
        {
            var command = conn.CreateCommand();
            command.CommandText = "UPDATE shops SET name = @name, discription = @dis WHERE id = @id";
            command.Parameters.AddWithValue("id", id);
            command.Parameters.AddWithValue("name", name);
            command.Parameters.AddWithValue("dis", discription);
            command.Prepare();
            command.ExecuteNonQuery();
        }

        public List<Shop> SearchResults(string search)
        {
            var shops = new List<Shop>();
            var command = conn.CreateCommand();
            command.CommandText = "SELECT * FROM shops WHERE name = @search OR discription = @search";
            command.Parameters.AddWithValue("search", search);
            command.Prepare();
            var reader = command.ExecuteReader();

            while (reader.Read())
            {
                shops.Add(new Shop()
                {
                    Id = reader.GetInt32(0),
                    Title = reader.GetString(1),
                    Description = (Profesion)(reader.GetInt32(2))
                });
            }
            reader.Close();
            return shops;
        }

        public List<Shop> SelectResult(int selecrtItem)
        {
            var shops = new List<Shop>();
            var command = conn.CreateCommand();
            command.CommandText = "SELECT * FROM shops WHERE discription = @search";
            command.Parameters.AddWithValue("search", selecrtItem);
            command.Prepare();
            var reader = command.ExecuteReader();

            while (reader.Read())
            {
                shops.Add(new Shop()
                {
                    Id = reader.GetInt32(0),
                    Title = reader.GetString(1),
                    Description = (Profesion)(reader.GetInt32(2))
                });
            }
            reader.Close();
            return shops;
        }
    }
}
