using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hongxin.Web.ViewModels.OrderDetail
{
    public class BaseModel
    {
        public int SortIndex { get; set; }
        public string Size { get; set; }
        public string Unit { get; set; }
        public int Total { get; set; }
        public string Remark { get; set; }
    }
}