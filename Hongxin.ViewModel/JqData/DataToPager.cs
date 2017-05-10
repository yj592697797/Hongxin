using Hongxin.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hongxin.ViewModel.JqData
{
    public class DataToPager
    {
        public static object Do(JqGridPager jp, object data) 
        {
            var jsonData = new
            {
                total = jp.total,
                page = jp.page,
                records = jp.records,
                rows = data
            };

            return jsonData;
        }
    }
}
