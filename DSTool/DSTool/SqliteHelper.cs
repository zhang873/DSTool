using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Common;
using System.Data.SQLite;  

namespace DSTool
{
    public class SqliteHelper
    {
        public SqliteHelper(string sqlPath)
        {
        }

        private static SQLiteConnection GetConnection(string path)
        {
            SQLiteConnection conn = new SQLiteConnection(path);
            conn.Open();
            return conn;
        }

        public static int ExecuteSql(string path, string sql)
        {
            using (SQLiteConnection conn = GetConnection(path))
            {
                var cmd = new SQLiteCommand(sql, conn);
                int ret = cmd.ExecuteNonQuery();
                conn.Close();
                return ret;
            }
        }

        public static int ExecuteScalar(string path, string sql)
        {
            using (SQLiteConnection conn = GetConnection(path))
            {
                var cmd = new SQLiteCommand(sql, conn);
                object o = cmd.ExecuteScalar();
                return int.Parse(o.ToString());
            }
        }
        public static SQLiteDataReader ExecuteReader(string path, string sql)
        {
            SQLiteConnection conn = GetConnection(path);
            var cmd = new SQLiteCommand(sql, conn);
            SQLiteDataReader myReader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            return myReader;
        }
        public static DataSet ExecDataSet(string path, string sql)
        {
            using (SQLiteConnection conn = GetConnection(path))
            {
                var cmd = new SQLiteCommand(sql, conn);
                SQLiteDataAdapter da = new SQLiteDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);

                return ds;
            }
        }

    }
}

