using Hongxin.Core;
using Hongxin.Model;
using Hongxin.ViewModel.OrderDetail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hongxin.BLL
{
    public interface IOrderDetailBLL : IDependency
    {
        IEnumerable<OrderDetailRecord> QueryByParent(int parentId);
    }
}
