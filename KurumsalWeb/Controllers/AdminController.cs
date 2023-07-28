﻿using KurumsalWeb.Models;
using KurumsalWeb.Models.DataContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KurumsalWeb.Controllers
{
    public class AdminController : Controller
    {
      KurumsalDBContext db = new KurumsalDBContext();

        // GET: Admin
        public ActionResult Index()
        {
            var sorgu = db.Kategori.ToList();

            return View(sorgu);
        }
    }
}