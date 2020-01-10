using System.Collections.Generic;
using Web.Models;

namespace Web.Infrastructure
{
    using BrainWare;
    using System.Data;
    using System.Data.Common;
    using System.Data.SqlClient;
    using System.Diagnostics;

    public static class Database
    {
        private static string _connectionStr = @"Data Source=(LocalDb)\MSSQLLocalDB;Initial Catalog=BrainWAre;Integrated Security=SSPI;AttachDBFilename=D:\tmp\ieddie\BrainWare\Web\App_Data\BrainWare.mdf";

        public static DataSet GetOrders(int companyId)
        {
            DataSet ds = new DataSet();
            SqlConnection connection = null;
            try
            {
                connection = new SqlConnection(_connectionStr);

                using (SqlCommand command = new SqlCommand("OrdersGetByCompanyId", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@companyId", companyId));

                    using (SqlDataAdapter da = new SqlDataAdapter(command))
                    {
                        // Fill the DataSet using default values for DataTable names, etc
                        da.Fill(ds);
                    }
                }
            }
            catch (SqlException sqlEx) // let other types of exceptions "bubble up"
            {
                Debug.WriteLine(string.Concat("SqlException occured in GetOrderDetails(): ", sqlEx.Message));
                throw new BrainWareException();
            }
            finally
            {
                if (connection != null)
                {
                    connection.Close();
                }
            }

            return ds;
        }

        public static List<Company> GetCompanies()
        {
            // Get all companies, even those with no orders
            var query = @"SELECT name, company_id FROM company c";

            List<Company> companies = new List<Company>();
            SqlConnection connection = null;
            try
            {
                connection = new SqlConnection(_connectionStr);
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var row = (IDataRecord)reader;
                            companies.Add(new Company() { Name = row.GetString(0), Id = row.GetInt32(1) });
                        }
                        reader.Close();
                    }
                }
            }
            catch (SqlException sqlEx) // let other types of exceptions "bubble up"
            {
                Debug.WriteLine(string.Concat("SqlException occured in GetCompanies(): ", sqlEx.Message));
                throw new BrainWareException();
            }
            finally
            {
                if (connection != null)
                {
                    connection.Close();
                }
            }

            return companies;
        }

    }
}