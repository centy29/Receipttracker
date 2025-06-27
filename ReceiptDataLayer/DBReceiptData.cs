using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReceiptCommon;
using Microsoft.Data.Sql;
using Microsoft.Data.SqlClient;

namespace ReceiptDataLayer
{
     public class DBReceiptData : IReceiptAccounts {

        static string connectionString   // Connection string for SQL Server connection
      = "Data Source =centy\\SQLEXPRESS; Initial Catalog = DBReceiptDatas; Integrated Security = True; TrustServerCertificate=True;";

        static SqlConnection sqlConnection;
    
    public DBReceiptData() {
            sqlConnection = new SqlConnection(connectionString);
        }
        public List<ReceiptAccounts> accounts = new List<ReceiptAccounts>();

        public List<ReceiptAccounts> GetAccounts()  // Method to retrieve all accounts from the Receipt table
        {
            string selectQuery = "SELECT Pin, Name FROM Receipt";
            SqlCommand command = new SqlCommand(selectQuery, sqlConnection);

            sqlConnection.Open();
            SqlDataReader reader = command.ExecuteReader();

            List<ReceiptAccounts> accounts = new List<ReceiptAccounts>();

            while (reader.Read())
            {
                accounts.Add(new ReceiptAccounts
                {
                    pin = reader["Pin"].ToString(),
                    name = reader["Name"].ToString()
                });
            }

            sqlConnection.Close();
            return accounts;
        }
        public void createaccount(ReceiptAccounts account)
        {
            string insertQuery = "INSERT INTO Receipt (Pin, Name) VALUES (@Pin, @Name)";
            SqlCommand command = new SqlCommand(insertQuery, sqlConnection);

            command.Parameters.AddWithValue("@Pin", account.pin);
            command.Parameters.AddWithValue("@Name", account.name);

            sqlConnection.Open();
            command.ExecuteNonQuery();
            sqlConnection.Close();
        }
        public void removeaccount(ReceiptAccounts account)
        {
            string deleteQuery = "DELETE FROM Receipt WHERE Pin = @Pin";
            SqlCommand command = new SqlCommand(deleteQuery, sqlConnection);

            command.Parameters.AddWithValue("@Pin", account.pin);

            sqlConnection.Open();
            command.ExecuteNonQuery();
            sqlConnection.Close();
        }
        public void updateaccount(ReceiptAccounts account)
        {
            string updateQuery = "UPDATE Receipt SET Name = @Name WHERE Pin = @Pin";
            SqlCommand command = new SqlCommand(updateQuery, sqlConnection);

            command.Parameters.AddWithValue("@Pin", account.pin);
            command.Parameters.AddWithValue("@Name", account.name);

            sqlConnection.Open();
            command.ExecuteNonQuery();
            sqlConnection.Close();
        }
        public void retrieveaccount(ReceiptAccounts account)
        {

        }
        public bool ValidateAccount(string pin)
        {
            string query = "SELECT COUNT(*) FROM Receipt WHERE Pin = @Pin";
            SqlCommand command = new SqlCommand(query, sqlConnection);
            command.Parameters.AddWithValue("@Pin", pin);

            sqlConnection.Open();
            int count = (int)command.ExecuteScalar();
            sqlConnection.Close();

            return count > 0;
        }
        public string Getusername(string pin)
        {
            string query = "SELECT Name FROM Receipt WHERE Pin = @Pin";
            SqlCommand command = new SqlCommand(query, sqlConnection);
            command.Parameters.AddWithValue("@Pin", pin);

            sqlConnection.Open();
            string name = command.ExecuteScalar() as string;
            sqlConnection.Close();

            return name;
        }

    }
}
