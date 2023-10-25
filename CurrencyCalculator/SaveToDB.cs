using System;
using System.IO;
using System.Linq;
using System.Data.SQLite;

namespace CurrencyCalculator
{
    public class SaveToDB
    {
        TypeOut t = new TypeOut();
        private string connectionString = "Data Source=Customers.db;Version=3;";
        //check if database exists and create if not
        public void CheckDB()
        {
            if (!File.Exists("Customers.db"))
            {
                t.TypeFast("Database does not exist");
                SQLiteConnection.CreateFile("Customers.db");
                t.TypeFast("Database created");
            }
            else
            {
                t.TypeFast("Database exists");
            }
            //check if table exists and create if not using AccountNumber as primary key IN SQLite
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                string sql = "CREATE TABLE IF NOT EXISTS Customers (id INTEGER PRIMARY KEY, name TEXT, AccountNumber INTEGER, PIN INTEGER, Balance FLOAT)";
                SQLiteCommand command = new SQLiteCommand(sql, connection);
                command.ExecuteNonQuery();
                connection.Close();
            }
            
            

        }
        //save to database
        public void SaveToDatabase(string name, int AN, int PIN)
        {
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                string sql = $"INSERT INTO Customers (name, AccountNumber, PIN, Balance) VALUES ('{name}', {AN}, {PIN})";
                SQLiteCommand command = new SQLiteCommand(sql, connection);
                command.ExecuteNonQuery();
                connection.Close();
            }
        }        
        //check if the account number is correct
        public bool CheckAccountNumber(int AN)
        {
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                string sql = $"SELECT * FROM Customers WHERE id = {AN}";
                SQLiteCommand command = new SQLiteCommand(sql, connection);
                SQLiteDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        //get the name from the account number
        public string CustomerName(int AN)
        {
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                string sql = $"SELECT name FROM Customers WHERE id = {AN}";
                SQLiteCommand command = new SQLiteCommand(sql, connection);
                SQLiteDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        string name = reader.GetString(0);
                        return name;
                    }
                }
                else
                {
                    return "";
                }
                return "";
            }
        }
        //check if the PIN is correct
        public bool CheckPIN(int AN, int PIN)
        {
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                string sql = $"SELECT PIN FROM Customers WHERE id = {AN}";
                SQLiteCommand command = new SQLiteCommand(sql, connection);
                SQLiteDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        int pin = reader.GetInt32(0);
                        if (pin == PIN)
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                }
                else
                {
                    return false;
                }
                return false;
            }
        }
        //get the balance from the account number
        public float GetBalance(int AN)
        {
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                string sql = $"SELECT Balance FROM Customers WHERE id = {AN}";
                SQLiteCommand command = new SQLiteCommand(sql, connection);
                SQLiteDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        float balance = reader.GetFloat(0);
                        return balance;
                    }
                }
                else
                {
                    return 0;
                }
                return 0;
            }
        }
        //update the balance
        public void UpdateBalance(int AN, float balance)
        {
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                string sql = $"UPDATE Customers SET Balance = {balance} WHERE id = {AN}";
                SQLiteCommand command = new SQLiteCommand(sql, connection);
                command.ExecuteNonQuery();
                connection.Close();
            }
        }
    }
}
