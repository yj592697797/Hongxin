using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hongxin.Model
{
    public class OrderDetailRecord
    {
        public int Id { get; set; }
        public int Order_Id { get; set; }
        public int SortIndex { get; set; }
        public string  Name { get; set; }
        public string Size { get; set; }
        public string Unit { get; set; }
        public int Total { get; set; }
        public int Output { get; set; }
        public string Remark { get; set; }
    }

    public class OrderDetailEqualityBy : IEqualityComparer<OrderDetailRecord>
    {
        public bool Equals(OrderDetailRecord x, OrderDetailRecord y)
        {
            return x.Id == y.Id;
        }

        public int GetHashCode(OrderDetailRecord obj)
        {
            if (obj == null)
            {
                return 0;
            }
            else 
            {
                return obj.ToString().GetHashCode();
            }
        }
    }
}
