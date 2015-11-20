using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Reflection;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;

namespace TriviaGame
{
    public class DbConnection
    {
        private SqlConnection _conn;
        private static int commandTimeout = 300;

        // Initialise Connection
        public DbConnection()
        {
        }

        // returns collection of DataTables and relations between tables 
        public DataSet executeSelectDataSet(String query, SqlParameter[] parameters, CommandType commandType)
        {
            using (SqlConnection _conn = new SqlConnection(GetConnectionStr()))
            {
                using (var adapter = new SqlDataAdapter(query, _conn))
                {
                    var table = new DataTable();
                    DataSet _dataSet = new DataSet();
                    adapter.SelectCommand.Connection = _conn;
                    adapter.SelectCommand.CommandType = commandType; // Or StoredProcedure or Text
                    adapter.SelectCommand.CommandTimeout = commandTimeout;
                    adapter.SelectCommand.Parameters.AddRange(parameters);
                    try
                    {
                        _conn.Open();
                        adapter.SelectCommand.ExecuteNonQuery();
                        adapter.Fill(_dataSet);
                    }
                    catch (SqlException e)
                    {
                        System.Diagnostics.Debug.WriteLine("cant complete SELECT operation " + e);
                    }
                    finally
                    {
                        adapter.SelectCommand.Parameters.Clear();
                        _conn.Close();
                    }
                    return _dataSet;
                }
            }
        }
   
        // returns single table from the database with It rows and columns
        public DataTable executeSelectDataTable(String query, SqlParameter[] parameters, CommandType commandType)
        {
            using (SqlConnection _conn = new SqlConnection(GetConnectionStr()))
            {
                using (var adapter = new SqlDataAdapter(query, _conn))
                {
                    var table = new DataTable();
                    DataSet _dataSet = new DataSet();
                    adapter.SelectCommand.Connection = _conn;
                    adapter.SelectCommand.CommandType = commandType; // Or StoredProcedure or Text
                    adapter.SelectCommand.CommandTimeout = commandTimeout;
                    adapter.SelectCommand.Parameters.AddRange(parameters);
                    try
                    {
                        _conn.Open();
                        adapter.SelectCommand.ExecuteNonQuery();
                        adapter.Fill(_dataSet);
                        table = _dataSet.Tables[0];
                    }
                    catch (SqlException e)
                    {
                        System.Diagnostics.Debug.WriteLine("cant complete SELECT operation " + e);
                    }
                    finally
                    {
                        adapter.SelectCommand.Parameters.Clear();
                        _conn.Close();
                    }
                    return table;
                }
            }



        }
        
        // executes Insert Update Delete Stored Procedure(CommandType=Procedure) or String Query(CommandType=Text)
        public bool executeQuery(String query, SqlParameter[] parameters, CommandType commandType)
        {
            using (SqlConnection _conn = new SqlConnection(GetConnectionStr()))
            {
                using (var adapter = new SqlDataAdapter(query, _conn))
                {
                    var table = new DataTable();
                    adapter.SelectCommand.CommandType = commandType; // Or StoredProcedure or Text
                    adapter.SelectCommand.CommandTimeout = commandTimeout;
                    adapter.SelectCommand.Parameters.AddRange(parameters);
                    try
                    {
                        _conn.Open();
                        adapter.SelectCommand.ExecuteNonQueryAsync();
                    }
                    catch (SqlException e)
                    {
                        System.Diagnostics.Debug.WriteLine("Error - in simple execute - Query:" + e);
                        return false;
                    }
                    finally
                    {
                        adapter.SelectCommand.Parameters.Clear();
                        _conn.Close();
                    }
                }
                return true;
            }
        }
        
        //ExecuteScalar gets the first column from the first row of the result set.
        public int? executeSelectScalar(String query, SqlParameter[] parameters, CommandType commandType)
        {
            int? returnValue;
            using (SqlConnection _conn = new SqlConnection(GetConnectionStr()))
            {

                using (SqlCommand _cmd = new SqlCommand(query, _conn))
                {
                    _cmd.Connection = _conn;
                    _cmd.CommandType = commandType; // Or StoredProcedure or Text
                    _cmd.Parameters.AddRange(parameters);
                    try
                    {
                        _conn.Open();
                        returnValue = Convert.ToInt32(_cmd.ExecuteScalar());
                        if (returnValue.HasValue)
                        {
                            return returnValue;
                        }

                    }
                    catch (SqlException e)
                    {
                        System.Diagnostics.Debug.WriteLine("cant complete SELECT operation " + e);
                    }
                    finally
                    {
                        _cmd.Parameters.Clear();
                        _conn.Close();
                    }
                    return null;
                }
            }
        }

        //returns simple connection string to Database
        private static string GetConnectionStr()
        {
            // To avoid storing the connection string in your code, you can retrive it from a configuration file.
            return "Data Source=pc;Initial Catalog=TRIVIA_DB;Integrated Security=True;";
        }

 

        // Async execute Insert Update Delete Statements or Stored procedure(ComandType=Procedure) or String Query(ComandType=text)
        private async Task<bool> executeAsyncQuery(string query, SqlParameter[] parameters, CommandType commandType)
        {
            using (var connection = new SqlConnection(GetAsyncConnectionStr()))
            {
                using (var adapter = new SqlDataAdapter(query, connection))
                {
                    var table = new DataTable();
                    adapter.SelectCommand.CommandType = commandType; // Or StoredProcedure or Text
                    adapter.SelectCommand.CommandTimeout = commandTimeout;
                    adapter.SelectCommand.Parameters.AddRange(parameters);

                    if (connection.State != ConnectionState.Open)
                        connection.Open();
                    await adapter.SelectCommand.ExecuteNonQueryAsync();
                    return true;
                }
            }
        }
        
        //returns asynchronous connection string  to Database
        private static string GetAsyncConnectionStr()
        {
            // To avoid storing the connection string in your code, you can retrive it from a configuration file.
            return "Data Source=pc;Initial Catalog=TRIVIA_DB;Integrated Security=True;Asynchronous Processing=true;";
        }


    }
}
