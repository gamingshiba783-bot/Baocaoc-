using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;


namespace Baibaocao.net.DataAccess
{
    public static class DbConnection
    {
        public const string connectionString =
            "Server=localhost;Port=3306;Database=library;User ID=root;Password=123456;";
    }
}
