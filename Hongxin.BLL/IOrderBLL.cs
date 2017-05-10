using Hongxin.Core;
using Hongxin.Model;
using Hongxin.ViewModel.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hongxin.BLL
{
    public interface IOrderBLL : IDependency
    {
        IEnumerable<OrderRecord> QueryPager(IndexForm form);
        OrderRecord Get(int id);
        void Add(AddForm form);
        void Edit(EditForm form);
        void Delete(int id);
    }
}
