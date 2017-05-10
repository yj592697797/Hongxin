using Hongxin.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hongxin.DAL.Impls
{
    public class OrderDetailDAL : DAL<OrderDetailRecord>, IOrderDetailDAL
    {
        public override string TableName
        {
            get { return "[order_details]"; }
        }

        public override string Key
        {
            get { return "Id"; }
        }

        public int DeleteByParent(int parentId)
        {
            string sql = string.Format("delete from {0} where [Order_Id]=@0", TableName);
            int rows = DataBase.Execute(sql, parentId);
            return rows;
        }
        public IEnumerable<OrderDetailRecord> QueryByParent(int parentId)
        {
            string sql = string.Format("select * from {0} where [Order_Id]=@0", TableName);
            var query = DataBase.Query<OrderDetailRecord>(sql, parentId);
            return query;
        }
    }
}
