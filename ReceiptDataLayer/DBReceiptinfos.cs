using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using ReceiptCommon;

namespace ReceiptDataLayer
{
    public class DBReceiptinfo
    {
        private readonly string connectionString = "Data Source=centy\\SQLEXPRESS;Initial Catalog=DBReceiptDatas;Integrated Security=True;TrustServerCertificate=True;";

        public List<DBinfos> GetAllRecieptInfos()
        {
            var infos = new List<DBinfos>();
            using (var conn = new SqlConnection(connectionString))
            {
                var query = "SELECT invoice, brand, address, tin, amount FROM ReceiptsInfo";
                var command = new SqlCommand(query, conn);

                conn.Open();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        infos.Add(new DBinfos
                        {
                            invoice = Convert.ToInt32(reader["invoice"]),
                            brand = reader["brand"].ToString(),
                            address = reader["address"].ToString(),
                            tin = Convert.ToInt32(reader["tin"]),
                            amount = Convert.ToDecimal(reader["amount"])
                        });
                    }
                }
            }
            return infos;
        }

        public DBinfos GetInvoice(int invoice)
        {
            using (var conn = new SqlConnection(connectionString))
            {
                var query = "SELECT invoice, brand, address, tin, amount FROM ReceiptsInfo WHERE invoice = @invoice";
                var command = new SqlCommand(query, conn);
                command.Parameters.AddWithValue("@invoice", invoice);

                conn.Open();
                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new DBinfos
                        {
                            invoice = Convert.ToInt32(reader["invoice"]),
                            brand = reader["brand"].ToString(),
                            address = reader["address"].ToString(),
                            tin = Convert.ToInt32(reader["tin"]),
                            amount = Convert.ToDecimal(reader["amount"])
                        };
                    }
                }
            }
            return null;
        }

        public bool AddReceipt(DBinfos receipt)
        {
            using (var conn = new SqlConnection(connectionString))
            {
                var query = "INSERT INTO ReceiptsInfo (invoice, brand, address, tin, amount) VALUES (@invoice, @brand, @address, @tin, @amount)";
                var command = new SqlCommand(query, conn);

                command.Parameters.AddWithValue("@invoice", receipt.invoice);
                command.Parameters.AddWithValue("@brand", receipt.brand);
                command.Parameters.AddWithValue("@address", receipt.address);
                command.Parameters.AddWithValue("@tin", receipt.tin);
                command.Parameters.AddWithValue("@amount", receipt.amount);

                conn.Open();
                return command.ExecuteNonQuery() > 0;
            }
        }

        public bool UpdateReceipt(DBinfos receipt)
        {
            using (var conn = new SqlConnection(connectionString))
            {
                var query = "UPDATE ReceiptsInfo SET brand = @brand, address = @address, tin = @tin, amount = @amount WHERE invoice = @invoice";
                var command = new SqlCommand(query, conn);

                command.Parameters.AddWithValue("@invoice", receipt.invoice);
                command.Parameters.AddWithValue("@brand", receipt.brand);
                command.Parameters.AddWithValue("@address", receipt.address);
                command.Parameters.AddWithValue("@tin", receipt.tin);
                command.Parameters.AddWithValue("@amount", receipt.amount);

                conn.Open();
                return command.ExecuteNonQuery() > 0;
            }
        }

        public bool DeleteReceipt(int invoice)
        {
            using (var conn = new SqlConnection(connectionString))
            {
                var query = "DELETE FROM ReceiptsInfo WHERE invoice = @invoice";
                var command = new SqlCommand(query, conn);
                command.Parameters.AddWithValue("@invoice", invoice);

                conn.Open();
                return command.ExecuteNonQuery() > 0;
            }
        }
    }
}
