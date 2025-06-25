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
   public class DBReceiptinfo
    {

        static string connectionString   // Connection string for SQL Server connection
      = "Data Source =centy\\SQLEXPRESS; Initial Catalog = DBReceiptDatas; Integrated Security = True; TrustServerCertificate=True;";

        static SqlConnection sqlConnection;

        public DBReceiptinfo()
        {
            sqlConnection = new SqlConnection(connectionString);
        }
        public List<DBinfos> receipt = new List<DBinfos>();

        public List<DBinfos> GetAllRecieptInfos ()  // Method to retrieve all accounts from the Receipt table
        {
            string selectQuery = "SELECT invoice, brand, address, tin, amount FROM ReceiptsInfo";
            SqlCommand command = new SqlCommand(selectQuery, sqlConnection);

            sqlConnection.Open();
            SqlDataReader reader = command.ExecuteReader();

            List<DBinfos> infos = new List<DBinfos>();

            while (reader.Read())
            {
                infos.Add(new DBinfos
                {
                   invoice = Convert.ToInt32(reader["invoice"]),
                    brand = reader["brand"].ToString(),
                    address = reader["address"].ToString(),
                    tin = Convert.ToInt32(reader["tin"]),
                    amount = Convert.ToDecimal(reader["amount"]),
                  


                });
            }

            sqlConnection.Close();
            return infos;
        }
        public DBinfos GetInvoice(int invoice)
        {
            string query = "SELECT invoice, brand, address, tin, amount FROM ReceiptsInfo WHERE invoice = @invoice";
            SqlCommand command = new SqlCommand(query, sqlConnection);
            command.Parameters.AddWithValue("@invoice", invoice);


            sqlConnection.Open();
            SqlDataReader reader = command.ExecuteReader();

            DBinfos receipt = null;

            if (reader.Read())
            {
                receipt = new DBinfos
                {
                    invoice = Convert.ToInt32(reader["invoice"]),
                    brand = reader["brand"].ToString(),
                    address = reader["address"].ToString(),
                    tin = Convert.ToInt32(reader["tin"]),
                    amount = Convert.ToDecimal(reader["amount"]),
                    
                };
               
            }
            sqlConnection.Close();
            return receipt;
        }
        public void addreceiptinfo(DBinfos receipt)
        {
            string insertQuery = "INSERT INTO ReceiptsInfo (invoice, brand, address, tin, amount) VALUES (@invoice, @brand, @address, @tin, @amount)";
            SqlCommand command = new SqlCommand(insertQuery, sqlConnection);

            command.Parameters.AddWithValue("@invoice", receipt.invoice);
            command.Parameters.AddWithValue("@brand",receipt.brand );
            command.Parameters.AddWithValue("@address", receipt.address);
            command.Parameters.AddWithValue("@tin", receipt.tin);
            command.Parameters.AddWithValue("@amount", receipt.amount);
           

            sqlConnection.Open();
            command.ExecuteNonQuery();
            sqlConnection.Close();
        }
        public void deleteReceiptInfo(DBinfos receipt)
        {
            string deleteQuery = "DELETE FROM ReceiptsInfo WHERE invoice = @invoice";
            SqlCommand command = new SqlCommand(deleteQuery, sqlConnection);

            command.Parameters.AddWithValue("@invoice", receipt.invoice);

            sqlConnection.Open();
            command.ExecuteNonQuery();
            sqlConnection.Close();
        }
        public void updatereceiptinfo(DBinfos receipt)
        {
            string updateQuery = "UPDATE ReceiptsInfo SET brand = @brand, address = @address, tin = @tin, amount = @amount WHERE invoice = @invoice";
            SqlCommand command = new SqlCommand(updateQuery, sqlConnection);

            command.Parameters.AddWithValue("@invoice", receipt.invoice);
            command.Parameters.AddWithValue("@brand", receipt.brand);
            command.Parameters.AddWithValue("@address", receipt.address);
            command.Parameters.AddWithValue("@tin", receipt.tin);
            command.Parameters.AddWithValue("@amount", receipt.amount);
            

            sqlConnection.Open();
            command.ExecuteNonQuery();
            sqlConnection.Close();
        }
        public void retrieveaccount(ReceiptAccounts account)
        {

        }
  

    }
}
