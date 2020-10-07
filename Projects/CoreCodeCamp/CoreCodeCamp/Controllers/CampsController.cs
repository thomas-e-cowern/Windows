using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CoreCodeCamp.Controllers
{
    public class CampsController : Controller
    {
        // GET: CampsController
        public ActionResult Index()
        {
            return View();
        }

        // GET: CampsController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CampsController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CampsController/Create
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

        // GET: CampsController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CampsController/Edit/5
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

        // GET: CampsController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CampsController/Delete/5
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
