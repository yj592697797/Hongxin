using Hongxin.DAL;
using Hongxin.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hongxin.BLL.Impls
{
    public class OrderDetailBLL : IOrderDetailBLL
    {
        private IOrderDetailDAL _thisDAL;
        public OrderDetailBLL(IOrderDetailDAL thisDAL)
        {
            _thisDAL = thisDAL;
        }
        public IEnumerable<OrderDetailRecord> QueryByParent(int parentId)
        {
            var query = _thisDAL.QueryByParent(parentId);
            return query;
        }
    }
}
