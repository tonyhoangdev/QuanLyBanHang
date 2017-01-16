using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Finisar.SQLite;
using System.Data;

namespace QuanLyBanHang.Model
{
    public class SQLiteDatabaseAccess
    {
        // Connection string
        private SQLiteConnection _conn;

        // Constructor
        public SQLiteDatabaseAccess()
        {
            _conn = new SQLiteConnection(Properties.Settings.Default.strConnection);
        }

        // Properties
        public SQLiteConnection Conn
        {
            get
            {
                return _conn;
            }
        }

        // Open Connection
        private SQLiteConnection openConnection()
        {
            if (_conn.State == ConnectionState.Closed || _conn.State == ConnectionState.Broken)
            {
                _conn.Open();
            }
            return _conn;
        }

        // Close Connection
        private SQLiteConnection closeConnection()
        {
            if (_conn.State == ConnectionState.Open)
            {
                _conn.Close();
            }
            return _conn;
        }

        // Run select command
        public DataSet excuteQuery(SQLiteCommand cmd)
        {
            DataSet ds = new DataSet();

            // Open Connection
            openConnection();

            // Run cmd
            SQLiteDataAdapter da = new SQLiteDataAdapter(cmd);

            try
            {
                da.Fill(ds);
            }
            catch (SQLiteException ex)
            {
                Console.WriteLine(ex.Message);
            }

            // Close Connection
            closeConnection();

            // Return ds
            return ds;
        }

        // Run insert, edit, delete command
        public bool executeNonQuery(SQLiteCommand cmd)
        {
            bool retVal = true;
            // Open
            openConnection();

            // RUn cmd
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch
            {
                retVal = false;
            }

            // Close
            closeConnection();

            // Return
            return retVal;
        }
    }
}
