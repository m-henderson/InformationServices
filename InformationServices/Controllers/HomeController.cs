using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using InformationServices.Data;
using Microsoft.AspNetCore.Mvc;
using InformationServices.Models;
using Microsoft.EntityFrameworkCore;

namespace InformationServices.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _dbContext;

        public HomeController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public enum Months
        {
            January = 1, 
            Febuary,
            March,
            April,
            May,
            June,
            July, 
            August,
            September,
            October,
            November,
            December
        }
        
        public IActionResult Index()
        {
            var tickets = _dbContext.Tickets.ToList();
            var ticketsFromSeptember = from t in tickets where t.MonthCreated.Equals(Months.September) select t;
            ViewData["TicketsFromSeptember"] = ticketsFromSeptember; 
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
