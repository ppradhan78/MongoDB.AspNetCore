using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MongoDB.AspNetCore.Data.Core;
using MongoDB.AspNetCore.Data.SampleModel;
using MongoDB.AspNetCore.Models;
using MongoDB.AspNetCore.Utlity;
using Newtonsoft.Json;
using System;
using System.Diagnostics;
using System.IO;

namespace MongoDB.AspNetCore.Controllers
{
    public class EmployeeController : Controller
    {
        #region Global Variable
        private readonly ILogger<EmployeeController> _logger;
        private readonly IEmployeeCore _EmployeeCore;
        #endregion

        public EmployeeController(ILogger<EmployeeController> logger, IEmployeeCore EmployeeCore)
        {
            _logger = logger;
            _EmployeeCore = EmployeeCore;
        }

        #region Methods

        public IActionResult Index()
        {
            return View(_EmployeeCore.Gets());
        }

        public ActionResult Details(string id)
        {
            var employee = _EmployeeCore.Get(id);
            employee.Photo = ImageHelper.GetImage(Convert.ToBase64String(employee.Photo));
            return Json(employee);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public string Create(FileUpload input)
        {
            try
            {
                Employee employe = JsonConvert.DeserializeObject<Employee>(input.Employee);
                if (input.file.Length > 0)
                {
                    using (var ms = new MemoryStream())
                    {
                        input.file.CopyTo(ms);
                        var fileByteStreem = ms.ToArray();
                        employe.Photo = fileByteStreem;
                        var output = _EmployeeCore.Save(employe);
                        if (output.Id.Trim() != " ")
                        {
                            return "Save";
                        }
                    }
                }
                return "Failed To Save";
            }
            catch
            {
                return "Failed To Save";
            }
        }

        public ActionResult Edit(string id)
        {
            return View(_EmployeeCore.Get(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Employee input)
        {
            try
            {
                _EmployeeCore.Save(input);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Delete(string id)
        {
            return View(_EmployeeCore.Get(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(string id, Employee input)
        {
            try
            {
                _EmployeeCore.Delete(id);
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
