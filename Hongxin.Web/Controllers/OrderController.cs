﻿using System;
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
        public ActionResult AddPost()
        {
            return View();
        }
    }
}
