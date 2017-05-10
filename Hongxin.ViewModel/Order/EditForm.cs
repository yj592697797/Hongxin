using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hongxin.ViewModel.Order
{
    public class EditForm : BaseModel
    {
        public int Id { get; set; }
        public List<Hongxin.ViewModel.OrderDetail.EditForm> Details { get; set; }
    }
}