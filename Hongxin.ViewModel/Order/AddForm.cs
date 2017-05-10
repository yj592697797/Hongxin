using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hongxin.ViewModel.Order
{
    public class AddForm : BaseModel
    {
        public List<Hongxin.ViewModel.OrderDetail.AddForm> Details { get; set; }
    }

}