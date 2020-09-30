using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp2
{
    class Dao
    {
        public OleDbConnection connect()
        {
            string str = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=test.accdb";
            OleDbConnection conn = new OleDbConnection(str);
            conn.Open();
            return conn;
        }

        public OleDbCommand command(string sql)
        {
            OleDbCommand cmd = connect().CreateCommand();
            cmd.CommandText = sql;
            return cmd;
        }

        public OleDbDataReader read(string sql)
        {
            return command(sql).ExecuteReader();
        }
    }
}
