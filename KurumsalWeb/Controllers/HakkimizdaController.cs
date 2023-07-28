using KurumsalWeb.Models.DataContext;
using KurumsalWeb.Models.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KurumsalWeb.Controllers
{
    public class HakkimizdaController : Controller
    {
        KurumsalDBContext db = new KurumsalDBContext();
        // GET: Hakkimizda
        public ActionResult Index()
        {
            var hak = db.Hakkimizda.ToList();
            return View(hak);
        }
        public ActionResult Edit(int id)
        {
            var hak = db.Hakkimizda.Where(x => x.HakkimizdaId == id).FirstOrDefault();
            return View(hak);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Edit(int id, Hakkimizda hak)
        {
            if (ModelState.IsValid)
            {
                var hakkimizda = db.Hakkimizda.Where(x => x.HakkimizdaId == id).SingleOrDefault();
                hakkimizda.Aciklama = hak.Aciklama;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(hak);
        }
    }
}