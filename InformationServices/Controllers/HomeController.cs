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
            var currentYear = DateTime.Now.Year;
            var ticketCount = 0;
            var january = 0;
            var february = 0;
            var march = 0;
            var april = 0;
            var may = 0;
            var june = 0;
            var july = 0;
            var august = 0;
            var september = 0;
            var october = 0;
            var november = 0;
            var december = 0;
            

            foreach (var ticket in tickets)
            {
                ticketCount++;
                if (ticket.MonthCreated == 1 && ticket.YearCreated == currentYear)
                {
                    january++;
                }
                else if (ticket.MonthCreated == 2)
                {
                    february++;
                }
                else if (ticket.MonthCreated == 3)
                {
                    march++;
                }
                else if (ticket.MonthCreated == 4)
                {
                    april++;
                }
                else if (ticket.MonthCreated == 5)
                {
                    may++;
                }
                else if (ticket.MonthCreated == 6)
                {
                    june++;
                }
                else if (ticket.MonthCreated == 7)
                {
                    july++;
                }
                else if (ticket.MonthCreated == 8)
                {
                    august++;
                }
                else if (ticket.MonthCreated == 9)
                {
                    september++;
                }
                else if (ticket.MonthCreated == 10)
                {
                    october++;
                }
                else if (ticket.MonthCreated == 11)
                {
                    november++;
                }
                else if (ticket.MonthCreated == 12)
                {
                    december++;
                }


            }

            ViewData["TicketCount"] = ticketCount;
            ViewData["CurrentYear"] = currentYear;
            ViewData["JanuaryTicketCount"] = january;
            ViewData["FebruaryTicketCount"] = february;
            ViewData["MarchTicketCount"] = march;
            ViewData["AprilTicketCount"] = april;
            ViewData["MayTicketCount"] = may;
            ViewData["JuneTicketCount"] = june;
            ViewData["JulyTicketCount"] = july;
            ViewData["AugustTicketCount"] = august;
            ViewData["SeptemberTicketCount"] = september;
            ViewData["OctoberTicketCount"] = october;
            ViewData["NovemberTicketCount"] = november;
            ViewData["DecemberTicketCount"] = december;

            ViewData["CurrentYear"] = currentYear;



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
