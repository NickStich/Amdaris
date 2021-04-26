using System;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;

namespace ADO.NETassign
{
    public class CRUDsql
    {
        public void CreateTable(SqlConnection connection, string query)
        {
            using (var c = connection)
            {
                c.Open();
                using (var cmd = new SqlCommand(query, c))
                {
                    cmd.ExecuteNonQuery();
                }
            }
        }


        public void InsertTable(SqlConnection connection, string query)
        {
            using (var c = connection)
            {
                using (var da = new SqlDataAdapter(query, c))
                {

                    try
                    {
                        c.Open();
                        da.InsertCommand = new SqlCommand(query, c);
                        da.InsertCommand.ExecuteNonQuery();

                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.ToString());
                    }

                }
            }
        }

        public void SelectTable(SqlConnection connection, string query)
        {
            using (var c = connection)
            {
                using (DataAdapter da = new SqlDataAdapter(query, c))
                {
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    DataTable dt = ds.Tables[0];
                    foreach (DataRow dr in dt.Rows)
                    {
                        Console.WriteLine($"{dr["FirstName"]} : {dr["LastName"]}");
                    }
                }
            }
        }

        public void Update(SqlConnection connection, string query)
        {
            using (var c = connection)
            {
                using var da = new SqlDataAdapter(query, c);
                try
                {
                    c.Open();
                    da.UpdateCommand = c.CreateCommand();
                    da.UpdateCommand.CommandText = query;
                    da.UpdateCommand.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                }
            }
        }

        public void Delete(SqlConnection connection, string query)
        {
            using (var c = connection)
            {
                using var da = new SqlDataAdapter(query, c);
                try
                {
                    c.Open();
                    da.DeleteCommand = c.CreateCommand();
                    da.DeleteCommand.CommandText = query;
                    da.DeleteCommand.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                }
            }
        }
    }
}
