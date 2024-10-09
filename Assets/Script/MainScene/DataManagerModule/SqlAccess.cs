using MySql.Data.MySqlClient;
using UnityEngine;
using System;
using System.Data;
using System.Text;

namespace DataManagerModule
{
    public class SqlAccess
    {
        public static MySqlConnection dbConnection;
        public SqlAccess(string host, string port, string username, string pwd, string database)
        {
            try
            {
                string connectionString = string.Format("server = {0};port={1};database = {2};user = {3};password = {4};", host, port, database, username, pwd);
                Debug.Log("SQL info:" + connectionString);
                dbConnection = new MySqlConnection(connectionString);
                dbConnection.Open();
                Debug.Log("SQL connect succeed");
            }
            catch (Exception e)
            {
                throw new Exception("SQL connet fail!" + e.Message.ToString());
            }
        }
        // πÿ±’sql¡¨Ω”
        public void Close()
        {
            if (dbConnection != null)
            {
                dbConnection.Close();
                dbConnection.Dispose();
                dbConnection = null;
            }
        }

        public static DataSet ExecuteQuery(string sqlString)
        {
            if (dbConnection.State == ConnectionState.Open)
            {
                DataSet ds = new DataSet();
                try
                {
                    MySqlDataAdapter da = new MySqlDataAdapter(sqlString, dbConnection);
                    da.Fill(ds);
                }
                catch (Exception e)
                {
                    throw new Exception("SQL:" + sqlString + "/n" + e.Message.ToString());
                }
                return ds;
            }
            return null;
        }
    }
}
