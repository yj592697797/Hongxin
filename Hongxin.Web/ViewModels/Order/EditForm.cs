using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hongxin.Web.ViewModels.Order
{
    public class EditForm : BaseModel
    {
        public int Id { get; set; }
        public List<Hongxin.Web.ViewModels.OrderDetail.EditForm> Details { get; set; }
    }
}