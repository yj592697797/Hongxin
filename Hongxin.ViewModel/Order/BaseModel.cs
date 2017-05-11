using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hongxin.ViewModel.Order
{
    public class BaseModel
    {
        public string OrderNo { get; set; }
        public string Supplier { get; set; }
        public string LinkPerson { get; set; }
        public string Phone { get; set; }
        public string Tel { get; set; }
        public string Fax { get; set; }
        public string OrderDate { get; set; }
        public string DeliveryDate { get; set; }
        public string Address { get; set; }
        public string Remark { get; set; }
        public string Contract { get; set; }
    }
}