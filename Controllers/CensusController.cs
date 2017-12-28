using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using InformationServices.Data;
using InformationServices.Models;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;
using SQLitePCL;

namespace InformationServices.Controllers
{
    public class CensusController : Controller
    {
        private ApplicationDbContext _context;
        private IToastNotification _toastNotification;



        public CensusController(ApplicationDbContext context, IToastNotification toastNotification)
        {
            _toastNotification = toastNotification;
            _context = context;
        }
        
        
       
        public IActionResult Index()
        {
            _toastNotification.AddSuccessToastMessage();

            return View();
        }

        [HttpPost]
        public IActionResult Create(Census census)
        {
            string status = "";
            var censusToSave = new Census
            {
                DateTime = census.DateTime,
                Department = census.Department,
                PatientCount = census.PatientCount
            };

            _context.Censuses.Add(censusToSave);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        
    }
}