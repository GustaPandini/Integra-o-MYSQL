using Dapper;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Integração_do_Visual_Studio_com_MYSQL.Helpers
{
    public class DataBase
    {
        protected string conectionString = "Server=localhost;Database=testepi;User=root;Password=root;";
        protected MySqlConnection GetConnection()
        {
            return new MySqlConnection(conectionString);
        }
        protected int Execute(string sql, object obj)
        {
            using (MySqlConnection con = GetConnection())
            {
                return con.Execute(sql, obj);
            }
        }
    }
}
