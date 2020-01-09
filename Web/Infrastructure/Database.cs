using System.Collections.Generic;
using Web.Models;

namespace Web.Infrastructure
{
    using System.Data;
    using System.Data.Common;
    using System.Data.SqlClient;

    public static class Database
    {
        private static string _connectionStr = @"Data Source=(LocalDb)\MSSQLLocalDB;Initial Catalog=BrainWAre;Integrated Security=SSPI;AttachDBFilename=D:\tmp\ieddie\BrainWare\Web\App_Data\BrainWare.mdf";

        public static List<Order> GetOrderDetails()
        {
            // Get the orders
            var query = "SELECT c.name, o.description, o.order_id FROM company c INNER JOIN [order] o on c.company_id=o.company_id";

            List<Order> result = new List<Order>();

            using (SqlConnection connection = new SqlConnection(_connectionStr))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        // Call Read before accessing data.
                        while (reader.Read())
                        {
                            var row = (IDataRecord)reader;

                            result.Add(new Order(row.GetString(0), row.GetString(1), row.GetInt32(2)));
                        }

                        // Call Close when done reading.
                        reader.Close();
                    }
                }
            }

            return result;
        }

        public static List<OrderProduct> GetOrderProducts()
        {
            // Get the orders
            var query =
                @"SELECT op.price, op.order_id, op.product_id, op.quantity, p.name, p.price 
                FROM orderproduct op 
                    INNER JOIN product p on op.product_id=p.product_id";

            List<OrderProduct> result = new List<OrderProduct>();

            using (SqlConnection connection = new SqlConnection(_connectionStr))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var row = (IDataRecord)reader;
                            result.Add(new OrderProduct(row.GetInt32(1), row.GetInt32(2), row.GetDecimal(0), row.GetInt32(3), row.GetString(4), row.GetDecimal(5)));
                        }
                        reader.Close();
                    }
                }
            }

            return result;
        }
        
    }
}