using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HighWayCodeTraining.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace HighWayCodeTraining.Controllers
{   //Strated from empty comtroler (without using Entity Framework pages) to use DAL (Data Access Layer)
    public class AnswerController : Controller
    {
        private DBContext _context;
        private readonly IWebHostEnvironment _hostEnvironment;

        public AnswerController(DBContext context, IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            this._hostEnvironment = hostEnvironment;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Exercice()
        {

            return View();
        }

    }
}
