using Hongxin.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hongxin.ViewModel.Order
{
    public class IndexViewModel : BaseModel
    {
        public int Id { get; set; }
        public string CreateTime { get; set; }
        public List<IndexViewModel> GetView(List<OrderRecord> model) 
        {
            var view = model.Select(s => new IndexViewModel 
            {
                Id = s.Id,
                OrderNo = s.OrderNo,
                Supplier = s.Supplier,
                LinkPerson = s.LinkPerson,
                Phone = s.Phone,
                Tel = s.Tel,
                Fax = s.Fax,
                OrderDate = s.OrderDate.ToString("yyyy-MM-dd"),
                DeliveryDate = s.DeliveryDate.ToString("yyyy-MM-dd"),
                CreateTime = s.CreateTime.ToString("yyyy-MM-dd"),
                Remark = s.Remark,
                Contract = s.Contract
            }).ToList();
            return view;
        }

    }
}
