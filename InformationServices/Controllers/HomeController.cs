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
            DateTime currentYear = new DateTime();

            var month = DateTime.Now.Month.ToString();


            var september = 9;
            var septTicket = 0;
            var augTicketCount = 0;

            var ticketsOfSept = _dbContext.Tickets.Where(t => t.MonthCreated == september);
            var ticketsOfAug = _dbContext.Tickets.Where(t => t.MonthCreated == 8);

            foreach (var ticket in ticketsOfSept)
            {
                septTicket++;
            }

            foreach (var ticket in ticketsOfAug)
            {
                augTicketCount++;
            }
            
            var tickets = _dbContext.Tickets.ToList();
            var count = 0;

            foreach (var ticket in tickets)
            {
                count++;
            }
            ViewData["CurrentMonth"] = month;
            ViewData["TicketCount"] = count;
            ViewData["SeptemberTickets"] = septTicket;
            ViewData["AugustTickets"] = augTicketCount;


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
