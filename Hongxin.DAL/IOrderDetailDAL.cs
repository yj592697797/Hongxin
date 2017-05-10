using Hongxin.Core;
using Hongxin.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hongxin.DAL
{
    public interface IOrderDetailDAL : IDAL<OrderDetailRecord>, IDependency
    {
        IEnumerable<OrderDetailRecord> QueryByParent(int parentId);
        int DeleteByParent(int parentId);
    }
}
