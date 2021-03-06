using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QR_Code_Maker.Controllers
{
    public class ReadController : Controller
    {
        // GET: ReadController
        public ActionResult Index()
        {
            return View();
        }

        // POST: ReadController
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(QR_Code_Maker.Models.QRCode upload)
        {
            if (!upload.File.ContentType.ToLower().Contains("image"))
            {
                ModelState.AddModelError(nameof(upload.File), "Error: File selected is not an image");
            }
            if (ModelState.IsValid)
            {
                using (var ms = new System.IO.MemoryStream())
                {
                    upload.File.CopyTo(ms);
                    var fileBytes = ms.ToArray();
                    upload.text = Utils.Methods.ReadQRCode(fileBytes);
                }
            }
            return View(nameof(Index), upload);
        }

        // GET: ReadController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ReadController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ReadController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ReadController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ReadController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ReadController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ReadController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
