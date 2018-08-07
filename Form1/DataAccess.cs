using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;


namespace Form1
{
    class DataAccess
    {
        static string connString = ("server=localhost;user id=root;database=psm;password=Abc12345;");

        static MySqlConnection _conn = null;
        public static MySqlConnection conn
        {
            get
            {
                if (_conn == null)
                {
                    _conn = new MySqlConnection(connString);
                    _conn.Open();

                    return _conn;
                }
                else if (_conn.State != System.Data.ConnectionState.Open)
                {
                    _conn.Open();

                    return _conn;
                }
                else
                {
                    return _conn;
                }
            } 

        }
        public static DataSet GetDataSet(string sql)
        {
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            adp.Fill(ds);
            conn.Close();

            return ds;
        }

        public static DataTable GetDataTable(string sql)
        {
            DataSet ds = GetDataSet(sql);
            if (ds.Tables.Count > 0)
                return ds.Tables[0];

            return null;
        }

        public static int ExecuteSQL(string sql)
        {
            MySqlCommand cmd = new MySqlCommand(sql, conn);

            return cmd.ExecuteNonQuery();
        }
    }
}
