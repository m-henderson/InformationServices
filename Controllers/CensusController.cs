using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InformationServices.Data;
using InformationServices.Models;
using Microsoft.AspNetCore.Mvc;
using SQLitePCL;

namespace InformationServices.Controllers
{
    public class CensusController : Controller
    {
        private ApplicationDbContext _context;

        public CensusController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Census census)
        { 
            var censusToSave = new Census
            {
                DateTime = DateTime.Today,
                Department = census.Department,
                PatientCount = census.PatientCount
            };

            _context.Censuses.Add(censusToSave);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}