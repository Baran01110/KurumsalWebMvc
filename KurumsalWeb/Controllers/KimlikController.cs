using KurumsalWeb.Models.DataContext;
using KurumsalWeb.Models.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace KurumsalWeb.Controllers
{
    public class KimlikController : Controller
    {
        KurumsalDBContext db = new KurumsalDBContext();
        // GET: Kimlik
        public ActionResult Index()
        {
            return View(db.Kimlik.ToList());
        }

        // GET: Kimlik/Edit/5
        public ActionResult Edit(int id)
        {
            var kimlik = db.Kimlik.Where(x => x.KimlikId == id).SingleOrDefault();
            return View(kimlik);
        }

        // POST: Kimlik/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Edit(int id, Kimlik kimlik,HttpPostedFileBase LogoURL)
        {
            if (ModelState.IsValid)
            {
                var kmlk = db.Kimlik.Where(x => x.KimlikId == id).SingleOrDefault();

                if(LogoURL != null)
                {
                    if (System.IO.File.Exists(Server.MapPath(kmlk.LogoURL)))
                    {
                        System.IO.File.Delete(Server.MapPath(kmlk.LogoURL));
                    }
                    WebImage img = new WebImage(LogoURL.InputStream);
                    FileInfo imginfo = new FileInfo(LogoURL.FileName);

                    string logoname = LogoURL.FileName + imginfo.Extension;
                    img.Resize(300, 300);
                    img.Save("~/Uploads/Kimlik/" + logoname);
                    kmlk.LogoURL = "/Uploads/Kimlik/" + logoname;
                }
                kmlk.Title = kimlik.Title;
                kmlk.Keywords = kimlik.Keywords;
                kmlk.Description = kimlik.Description;
                kmlk.Unvan = kimlik.Unvan;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(kimlik);
        }
    }
}
