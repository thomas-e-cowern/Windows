﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyMvcApplication.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student
        public string Index()
        {
            return "This is Index action method of StudentController";
        }
    }
}