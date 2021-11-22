using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QR_Code_Maker.Controllers
{
    public class CreateController : Controller
    {
        // GET: CreateController
        public ActionResult Index()
        {
            return View();
        }

        // POST: CreateController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(QR_Code_Maker.Models.QRCode qrCode)
        {
            return View(nameof(Index), qrCode);
        }

        // GET: CreateController/Download/abc
        public ActionResult Download(string text, int size)
        {
            var bytes = Utils.Methods.CreateQRCode(text, size, size);
            return File(bytes, System.Net.Mime.MediaTypeNames.Image.Jpeg, $"QRCode_{size}x{size}");
        }

        // GET: CreateController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CreateController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CreateController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(QR_Code_Maker.Models.QRCode qrCode)
        {
            return View();
        }

        // GET: CreateController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CreateController/Edit/5
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

        // GET: CreateController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CreateController/Delete/5
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
