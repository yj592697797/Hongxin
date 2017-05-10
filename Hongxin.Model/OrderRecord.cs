using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hongxin.Model
{
    public class OrderRecord
    {
        public int Id { get; set; }
        public string OrderNo { get; set; }
        public string Supplier { get; set; }
        public string LinkPerson { get; set; }
        public string Phone { get; set; }
        public string Tel { get; set; }
        public string Fax { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime DeliveryDate { get; set; }
        public int Finished { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime ModifyTime { get; set; }
        public string Remark { get; set; }
        public string Contract { get; set; }

        public override string ToString()
        {
            string model = OrderNo + ", " + Supplier + ", " + Phone;
            return model;
        }
    }
}
