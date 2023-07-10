using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;

namespace SchoolPlatform.Models.DataAccessLayer
{
    public class DALHelper
    {
        public static NpgsqlConnection connection = new NpgsqlConnection(@"Server=localhost;Port=5432;User Id=postgres;Password=1234;Database=demo;");
        //public static NpgsqlConnection connection = new NpgsqlConnection(@"Server=localhost;Port=5432;User Id=postgres;Password=facultatheobrasov2002;Database=demo1;");
        public static NpgsqlConnection Connection
        {
            get
            {
                return connection;
            }
        }
    }
}
