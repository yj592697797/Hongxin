using Hongxin.BLL;
using Hongxin.ViewModel.OrderDetail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Hongxin.Web.Controllers
{
    public class OrderDetailController : Controller
    {
        //
        // GET: /OrderDetail/
        private IOrderDetailBLL _orderDetailBLL;
        public OrderDetailController(IOrderDetailBLL orderDetailBLL)
        {
            _orderDetailBLL = orderDetailBLL;
        }

        public ActionResult Index(int id)
        {
            var list = _orderDetailBLL.QueryByParent(id);
            var views = new IndexViewModel().GetView(list.ToList());
            return View(views);
        }

    }
}
