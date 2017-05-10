using Hongxin.Core;
using PetaPoco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hongxin.DAL
{
    public interface IDAL<T>
    {
        void BeginTransaction();
        void CompleteTransaction();
        void AbortTransaction();
        int Add(T t);
        int Update(T t);
        int Delete(T t);
        IEnumerable<T> Query();
        T Query(int id);
        Page<T> Page(long pageIndex, long pageSize);
        IEnumerable<T> Query(JqGridPager jp);
    }
}
