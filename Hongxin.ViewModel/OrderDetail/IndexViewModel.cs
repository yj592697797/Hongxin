using Hongxin.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hongxin.ViewModel.OrderDetail
{
    public class IndexViewModel : BaseModel
    {
        public int Id { get; set; }
        public List<IndexViewModel> GetView(List<OrderDetailRecord> list)
        {
            var view = list.Select(s => new OrderDetail.IndexViewModel
                {
                    Id = s.Id,
                    SortIndex = s.SortIndex,
                    Name = s.Name,
                    Size = s.Size,
                    Unit = s.Unit,
                    Total = s.Total,
                    Output = s.Output,
                    Remark = s.Remark
                }).ToList();
            return view;
        }
    }
}
