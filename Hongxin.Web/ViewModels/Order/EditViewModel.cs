using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hongxin.Web.ViewModels.Order
{
    public class EditViewModel : BaseModel
    {
        public int Id { get; set; }
        public List<Hongxin.Web.ViewModels.OrderDetail.EditViewModel> Details { get; set; }
    }
}