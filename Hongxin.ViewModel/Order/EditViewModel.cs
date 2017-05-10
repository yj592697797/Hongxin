using Hongxin.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hongxin.ViewModel.Order
{
    public class EditViewModel : BaseModel
    {
        public int Id { get; set; }
        public string CreateTime { get; set; }
        public List<Hongxin.ViewModel.OrderDetail.EditViewModel> Details { get; set; }
        public EditViewModel GetView(OrderRecord model, List<OrderDetailRecord> childs) 
        {
            var view = new EditViewModel
            {
                Id = model.Id,
                OrderNo = model.OrderNo,
                Supplier = model.Supplier,
                LinkPerson = model.LinkPerson,
                Phone = model.Phone,
                Tel = model.Tel,
                Fax = model.Fax,
                OrderDate = model.OrderDate.ToString("yyyy-MM-dd"),
                DeliveryDate = model.DeliveryDate.ToString("yyyy-MM-dd"),
                CreateTime = model.CreateTime.ToString("yyyy-MM-dd"),
                Remark = model.Remark,
                Contract = model.Contract,
                Details = childs.Select(s => new OrderDetail.EditViewModel 
                {
                    Id = s.Id,
                    SortIndex = s.SortIndex,
                    Name = s.Name,
                    Size = s.Size,
                    Unit = s.Unit,
                    Total = s.Total,
                    Output = s.Output,
                    Remark = s.Remark
                }).ToList()
            };
            return view;
        }
    }
}