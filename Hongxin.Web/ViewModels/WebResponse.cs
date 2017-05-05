using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hongxin.Web.ViewModels
{
    public class WebResponse
    {
        /// <summary>
        /// 状态 false:0   true:1
        /// </summary>
        public int State { get; set; }
        public string Msg { get; set; }
        public object Data { get; set; }
    }
}