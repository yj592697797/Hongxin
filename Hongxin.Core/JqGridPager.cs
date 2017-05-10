using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hongxin.Core
{
    public class JqGridPager
    {
        /// <summary>
        /// 当前页数
        /// </summary>
        public int page { get; set; }

        /// <summary>
        /// 每页显示记录条数
        /// </summary>
        public int rows { get; set; }

        /// <summary>
        /// 查询出的总记录数
        /// </summary>
        public int records { get; set; }

        /// <summary>
        /// 总页数
        /// </summary>
        public decimal total 
        {
            get 
            {
                decimal t = 0;
                if (rows > 0)
                    t = Math.Ceiling((decimal)records / rows);
                return t;
            }
        }

        /// <summary>
        /// ？？随机数
        /// </summary>
        public string nd { get; set; }

        /// <summary>
        /// 用作分页查询时的起始记录位置
        /// </summary>
        public int displayStart 
        {
            get { return (page - 1) * rows; }
        }

        /// <summary>
        /// 排序字段
        /// </summary>
        public string sidx { get; set; }

        /// <summary>
        /// 排序规则 asc|desc
        /// </summary>
        public string sord { get; set; }
    }
}