﻿using ABS.Utility.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ABS.Web.Areas.Production.Controllers
{
    public class SizingOutputEntryController : Controller
    {
        //
        // GET: /Production/SizingOutputEntry/
        [SessionTimeout]
        public ActionResult Index()
        {
            return View();
        }
	}
}