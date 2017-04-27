using Hongxin.Model;
using PetaPoco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hongxin.Test
{
    class Program
    {
        static void Main(string[] args)
        {
            string connectionString = "Data Source=" + @".\db\hongxin.db;";
            var provider = "System.Data.SQLite";
            var db = new Database(connectionString, provider);
            var sql = "select * from [order]";
            var orders = db.Query<OrderRecord>(sql);

        }
    }
}
