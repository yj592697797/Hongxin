using PetaPoco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hongxin.Core
{
    public class DBHelper
    {
        public static Database CreateDB() 
        {
            string basePath = System.AppDomain.CurrentDomain.BaseDirectory;
            string conStr = "Data Source=" + basePath + "db\\hongxin.db";
            string provider = "System.Data.SQLite";
            return new Database(conStr, provider);
        }
    }
}
