using Hongxin.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hongxin.DAL.Impls
{
    public class OrderDAL : DAL<OrderRecord>, IOrderDAL
    {
        public override string TableName
        {
            get { return "[order]"; }
        }

        public override string Key
        {
            get { return "Id"; }
        }
    }
}
