using Hongxin.BLL;
using Hongxin.ViewModel.JqData;
using Hongxin.ViewModel.Order;
using Hongxin.Web.Models;
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
        private IOrderBLL _thisBLL;
        private IOrderDetailBLL _orderDetailBLL;
        public OrderController(IOrderBLL thisBLL
                , IOrderDetailBLL orderDetailBLL)
        {
            _thisBLL = thisBLL;
            _orderDetailBLL = orderDetailBLL;
        }
        public ActionResult Index()
        {

            return View();
        }

        public JsonResult GetList() 
        {
            var form = new IndexForm();
            TryUpdateModel(form);
            var list = _thisBLL.QueryPager(form);
            var view = new IndexViewModel().GetView(list.ToList());
            var jsonData = DataToPager.Do(form, view);

            return Json(jsonData, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Add() 
        {
            return View();
        }

        [HttpPost]
        [ValidateInput(false)]
        public JsonResult AddPost(string orderstr)
        {
            AddForm form = JsonConvert.DeserializeObject<AddForm>(orderstr);
            var ri = new ResultInfo { State = 1};
            try 
            {
                _thisBLL.Add(form);
            }
            catch (Exception e) 
            {
                ri.State = 0;
                ri.Msg = e.Message;
            }

            return Json(ri, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Edit(int id)
        {
            var model = _thisBLL.Get(id);
            var childs = _orderDetailBLL.QueryByParent(id);
            var view = new EditViewModel().GetView(model, childs.ToList());
            #region 例子
            //EditViewModel model = new EditViewModel
            //{
            //    Id = 1,
            //    OrderNo = "HW-172A1",
            //    Supplier = "健祥",
            //    Phone = "18925482905",
            //    Tel = "0769-2331416",
            //    Fax = "0769-83362507",
            //    OrderDate = "2016-11-29",
            //    DeliveryDate = "2016-12-26",
            //    Remark = "延后交货",
            //    Contract = "<p>合同内容</p>"
            //};
            //model.Details = new List<ViewModel.OrderDetail.EditViewModel>
            //{
            //    new ViewModel.OrderDetail.EditViewModel
            //    {
            //        Id = 1,
            //        SortIndex = 1,
            //        Size = "强化清玻380*206*5",
            //        Unit = "PCS",
            //        Total = 700,
            //        Remark = "四边细磨斜边20留3MM(请附备品)/WQ52C4DRTB用"
            //    },
            //    new ViewModel.OrderDetail.EditViewModel
            //    {
            //        Id = 2,
            //        SortIndex = 2,
            //        Size = "强化清玻386*118*5",
            //        Unit = "PCS",
            //        Total = 600,
            //        Remark = "四边细磨斜边20留3MM(请附备品)/W44CFD用"
            //    },
            //    new ViewModel.OrderDetail.EditViewModel
            //    {
            //        Id = 3,
            //        SortIndex = 3,
            //        Size = "强化清玻386*125*5",
            //        Unit = "PCS",
            //        Total = 600,
            //        Remark = "四边细磨斜边20留3MM(请附备品)/W44CDWEFD用"
            //    }
            //};
            #endregion
            return View(view);
        }

        [HttpPost]
        [ValidateInput(false)]
        public JsonResult EditPost(string orderstr) 
        {
            EditForm form = JsonConvert.DeserializeObject<EditForm>(orderstr);
            var ri = new ResultInfo { State = 1 };
            try
            {
                _thisBLL.Edit(form);
            }
            catch (Exception e)
            {
                ri.State = 0;
                ri.Msg = e.Message;
            }

            return Json(ri, JsonRequestBehavior.AllowGet);
        }

        public ActionResult ViewOrder(int id) 
        {
            var model = _thisBLL.Get(id);
            var childs = _orderDetailBLL.QueryByParent(id);
            var view = new EditViewModel().GetView(model, childs.ToList());

            #region 例子
            //EditViewModel model = new EditViewModel
            //{
            //    Id = 1,
            //    OrderNo = "HW-172A1",
            //    Supplier = "健祥",
            //    Phone = "18925482905",
            //    Tel = "0769-2331416",
            //    Fax = "0769-83362507",
            //    OrderDate = "2016-11-29",
            //    DeliveryDate = "2016-12-26",
            //    Remark = "延后交货",
            //    Contract = "<p>合同内容</p>"
            //};
            //model.Details = new List<ViewModel.OrderDetail.EditViewModel>
            //{
            //    new ViewModel.OrderDetail.EditViewModel
            //    {
            //        Id = 1,
            //        SortIndex = 1,
            //        Size = "强化清玻380*206*5",
            //        Unit = "PCS",
            //        Total = 700,
            //        Remark = "四边细磨斜边20留3MM(请附备品)/WQ52C4DRTB用"
            //    },
            //    new ViewModel.OrderDetail.EditViewModel
            //    {
            //        Id = 2,
            //        SortIndex = 2,
            //        Size = "强化清玻386*118*5",
            //        Unit = "PCS",
            //        Total = 600,
            //        Remark = "四边细磨斜边20留3MM(请附备品)/W44CFD用"
            //    },
            //    new ViewModel.OrderDetail.EditViewModel
            //    {
            //        Id = 3,
            //        SortIndex = 3,
            //        Size = "强化清玻386*125*5",
            //        Unit = "PCS",
            //        Total = 600,
            //        Remark = "四边细磨斜边20留3MM(请附备品)/W44CDWEFD用"
            //    }
            //};
            #endregion

            return View(view);
        }

        public JsonResult Delete(int id) 
        {
            var ri = new ResultInfo { State = 1 };
            try
            {
                _thisBLL.Delete(id);
            }
            catch (Exception e)
            {
                ri.State = 0;
                ri.Msg = e.Message;
            }

            return Json(ri, JsonRequestBehavior.AllowGet);
        }


    }
}
