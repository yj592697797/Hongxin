using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hongxin.Web.ViewModels.Order
{
    public class AddForm : BaseModel
    {
        public List<Hongxin.Web.ViewModels.OrderDetail.AddForm> Details { get; set; }
    }

}