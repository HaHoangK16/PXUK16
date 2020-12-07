using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PXUK16.Web.Models;

namespace PXUK16.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            List<Manufactory> manufactories = new List<Manufactory>();
            manufactories = Helper.ApiHelper<List<Manufactory>>.HttpGetAsync("api/manafactory/gets");
            return View(manufactories);
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
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CreateManufactory model)
        {
            if (ModelState.IsValid)
            {
                var result = new CreateManufactoryResult();
                result = Helper.ApiHelper<CreateManufactoryResult>.HttpPostAsync("api/manafactory/create", "POST", model);
                if (result.ManafactoryId > 0)
                {
                    return RedirectToAction("index");
                }
                ModelState.AddModelError("", result.Message);
                return View(model);
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult Update()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Update(UpdateManufactory model)
        {
            if (ModelState.IsValid)
            {
                var result = new UpdateManufactoryResult();
                result = Helper.ApiHelper<UpdateManufactoryResult>.HttpPostAsync("api/manafactory/Update", "POST", model);
                if (result.ManafactoryId > 0)
                {
                    return RedirectToAction("index");
                }
                ModelState.AddModelError("", result.Message);
                return View(model);
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult Delete()
        {
            return View();
        }

        [HttpDelete]
        public IActionResult Delete(DeleteManufactory model)
        {
            if (ModelState.IsValid)
            {
                var result = new DeleteManufactoryResult();
                result = Helper.ApiHelper<DeleteManufactoryResult>.HttpPostAsync("api/manafactory/delete", "DELETE", model);
                if (result.ManafactoryId > 0)
                {
                    return RedirectToAction("index");
                }
                ModelState.AddModelError("", result.Message);
                return View(model);
            }
            return View(model);
        }
    }
}