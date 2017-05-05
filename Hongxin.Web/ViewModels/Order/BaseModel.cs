using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hongxin.Web.ViewModels.Order
{
    public class BaseModel
    {
        public string OrderNo { get; set; }
        public string Supplier { get; set; }
        public string Phone { get; set; }
        public string Tel { get; set; }
        public string Fax { get; set; }
        public string OrderData { get; set; }
        public string DeliveryDate { get; set; }
        public string Remark { get; set; }
        public string Contract { get; set; }
    }
}