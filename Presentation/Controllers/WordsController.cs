using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    public class WordsController : Controller
    {
        private readonly ISearchOedQuery _oedQuery;

        public WordsController(ISearchOedQuery oedQuery)
        {
            _oedQuery = oedQuery;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Search(string query)
        {
            var model = new OedSearchResultsModel() {Query = query};
            try
            {
                model = _oedQuery.Execute(model);
            }
            catch (Exception ex)
            {
                ViewData["ErrorMessage"] = ex.Message;
            }
            return View(model);
        }

        public IActionResult History()
        {
            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
