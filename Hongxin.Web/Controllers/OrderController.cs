using Hongxin.Web.ViewModels;
using Hongxin.Web.ViewModels.Order;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Hongxin.Web.Controllers
{
    public class OrderController : Controller
    {
        //
        // GET: /Order/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Add() 
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddPost(string orderstr)
        {
            AddForm form = JsonConvert.DeserializeObject<AddForm>(orderstr);
            return Json(new WebResponse { State = 1 }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Edit(int id)
        {
            EditViewModel model = new EditViewModel
            {
                Id = 1,
                OrderNo = "HW-172A1",
                Supplier = "健祥",
                Phone = "18925482905",
                Tel = "0769-2331416",
                Fax = "0769-83362507",
                OrderData = "2016-11-29",
                DeliveryDate = "2016-12-26",
                Remark = "延后交货",
                Contract = "<p>合同内容</p>"
            };
            model.Details = new List<ViewModels.OrderDetail.EditViewModel>
            {
                new ViewModels.OrderDetail.EditViewModel
                {
                    Id = 1,
                    SortIndex = 1,
                    Size = "强化清玻380*206*5",
                    Unit = "PCS",
                    Total = 700,
                    Remark = "四边细磨斜边20留3MM(请附备品)/WQ52C4DRTB用"
                },
                new ViewModels.OrderDetail.EditViewModel
                {
                    Id = 2,
                    SortIndex = 2,
                    Size = "强化清玻386*118*5",
                    Unit = "PCS",
                    Total = 600,
                    Remark = "四边细磨斜边20留3MM(请附备品)/W44CFD用"
                },
                new ViewModels.OrderDetail.EditViewModel
                {
                    Id = 3,
                    SortIndex = 3,
                    Size = "强化清玻386*125*5",
                    Unit = "PCS",
                    Total = 600,
                    Remark = "四边细磨斜边20留3MM(请附备品)/W44CDWEFD用"
                }
            };

            return View(model);
        }

        public ActionResult ViewOrder(int id) 
        {
            EditViewModel model = new EditViewModel
            {
                Id = 1,
                OrderNo = "HW-172A1",
                Supplier = "健祥",
                Phone = "18925482905",
                Tel = "0769-2331416",
                Fax = "0769-83362507",
                OrderData = "2016-11-29",
                DeliveryDate = "2016-12-26",
                Remark = "延后交货",
                Contract = "<p>合同内容</p>"
            };
            model.Details = new List<ViewModels.OrderDetail.EditViewModel>
            {
                new ViewModels.OrderDetail.EditViewModel
                {
                    Id = 1,
                    SortIndex = 1,
                    Size = "强化清玻380*206*5",
                    Unit = "PCS",
                    Total = 700,
                    Remark = "四边细磨斜边20留3MM(请附备品)/WQ52C4DRTB用"
                },
                new ViewModels.OrderDetail.EditViewModel
                {
                    Id = 2,
                    SortIndex = 2,
                    Size = "强化清玻386*118*5",
                    Unit = "PCS",
                    Total = 600,
                    Remark = "四边细磨斜边20留3MM(请附备品)/W44CFD用"
                },
                new ViewModels.OrderDetail.EditViewModel
                {
                    Id = 3,
                    SortIndex = 3,
                    Size = "强化清玻386*125*5",
                    Unit = "PCS",
                    Total = 600,
                    Remark = "四边细磨斜边20留3MM(请附备品)/W44CDWEFD用"
                }
            };

            return View(model);
        }

        public JsonResult Delete(int id) 
        {
            return Json(new WebResponse { State = 1}, JsonRequestBehavior.AllowGet);
        }


    }
}
