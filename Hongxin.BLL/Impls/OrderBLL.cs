using Hongxin.DAL;
using Hongxin.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hongxin.BLL.Impls
{
    public class OrderBLL : IOrderBLL
    {
        private IOrderDAL _thisDAL;
        private IOrderDetailDAL _orderDetailDal;
        public OrderBLL(IOrderDAL thisDAL
            , IOrderDetailDAL orderDetailDal)
        {
            _thisDAL = thisDAL;
            _orderDetailDal = orderDetailDal;
        }
        public IEnumerable<OrderRecord> QueryPager(ViewModel.Order.IndexForm form)
        {
            var list = _thisDAL.Query(form);
            return list;
        }

        public OrderRecord Get(int id)
        {
            return _thisDAL.Query(id);
        }

        public void Add(ViewModel.Order.AddForm form)
        {
            var orderDate = DateTime.Now;
            var deliveryDate = DateTime.Now;
            var details = new List<OrderDetailRecord>();
            DateTime.TryParse(form.OrderDate, out orderDate);
            DateTime.TryParse(form.DeliveryDate, out deliveryDate);
            var model = new OrderRecord 
            {
                OrderNo = form.OrderNo,
                Supplier = form.Supplier,
                LinkPerson = form.LinkPerson,
                Phone = form.Phone,
                Tel = form.Tel,
                Fax = form.Fax,
                OrderDate = orderDate,
                DeliveryDate = deliveryDate,
                Finished = 0,
                CreateTime = DateTime.Now,
                ModifyTime = DateTime.Now,
                Remark = form.Remark,
                Contract = form.Contract
            };

            foreach (var det in form.Details) 
            {
                details.Add(new OrderDetailRecord 
                {
                    SortIndex = det.SortIndex,
                    Name = det.Name,
                    Size = det.Size,
                    Unit = det.Unit,
                    Total = det.Total,
                    Output = det.Output,
                    Remark = det.Remark
                });
            }
            
            try
            {
                int id = _thisDAL.Add(model);
                foreach (var det in details) 
                {
                    det.Order_Id = id;
                    _orderDetailDal.Add(det);
                }
            }
            catch(Exception e)
            {
                _thisDAL.AbortTransaction();
                throw e;
            }
        }



        public void Edit(ViewModel.Order.EditForm form)
        {
            var orderDate = DateTime.Now;
            var deliveryDate = DateTime.Now;
            DateTime.TryParse(form.OrderDate, out orderDate);
            DateTime.TryParse(form.DeliveryDate, out deliveryDate);
            var fdetails = new List<OrderDetailRecord>();

            var model = _thisDAL.Query(form.Id);
            var details = _orderDetailDal.Query();

            model.OrderNo = form.OrderNo;
            model.Supplier = form.Supplier;
            model.LinkPerson = form.LinkPerson;
            model.Phone = form.Phone;
            model.Tel = form.Tel;
            model.Fax = form.Fax;
            model.DeliveryDate = deliveryDate;
            model.ModifyTime = DateTime.Now;
            model.Remark = form.Remark;
            model.Contract = form.Contract;

            foreach(var det in form.Details)
            {
                fdetails.Add(new OrderDetailRecord
                {
                    Id = det.Id,
                    Order_Id = model.Id,
                    SortIndex = det.SortIndex,
                    Name = det.Name,
                    Size = det.Size,
                    Unit = det.Unit,
                    Total = det.Total,
                    Output = det.Output,
                    Remark = det.Remark
                });
            }
            var equal = new OrderDetailEqualityBy();
            var addDetails = fdetails.Where(w => w.Id == -1).ToList();
            var editDetails = fdetails.Intersect(details, equal).ToList();
            var delDetails = details.Except(fdetails, equal).ToList();

            try
            {
                _thisDAL.Update(model);
                foreach (var del in delDetails) 
                {
                    _orderDetailDal.Delete(del);
                }
                foreach (var edit in editDetails) 
                {
                    _orderDetailDal.Update(edit);
                }
                foreach(var add in addDetails)
                {
                    _orderDetailDal.Add(add);
                }
            }
            catch (Exception e)
            {
                _thisDAL.AbortTransaction();
                throw e;
            }
        }

        public void Delete(int id)
        {
            var del = _thisDAL.Query(id);
            try
            {
                _orderDetailDal.DeleteByParent(id);
                _thisDAL.Delete(del);
            }
            catch (Exception e)
            {
                _thisDAL.AbortTransaction();
                throw e;
            }
        }
    }
}
