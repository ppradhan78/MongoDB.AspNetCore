using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MongoDB.AspNetCore.Data.Core;
using MongoDB.AspNetCore.Data.SampleModel;
using MongoDB.AspNetCore.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace MongoDB.AspNetCore.Controllers
{
    public class HomeController : Controller
    {
        #region Global Variable
        private readonly ILogger<HomeController> _logger;
        private readonly ICategoryCore _categoryCore;
        #endregion

        public HomeController(ILogger<HomeController> logger, ICategoryCore categoryCore)
        {
            _logger = logger;
            _categoryCore = categoryCore;
        }

        #region Methods
        public IActionResult Index()
        {
            return View(_categoryCore.Gets());
        }

        public ActionResult Details(string id)
        {
            return View(_categoryCore.Get(id));
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Category input)
        {
            try
            {
                _categoryCore.Save(input);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Edit(string id)
        {
            return View(_categoryCore.Get(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Category input)
        {
            try
            {
                _categoryCore.Save(input);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Delete(string id)
        {
            return View(_categoryCore.Get(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(string id, Category input)
        {
            try
            {
                _categoryCore.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        #endregion
    }
}
