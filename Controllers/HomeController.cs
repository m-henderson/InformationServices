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

            var januaryCallBacks = 0;
            var februaryCallBacks = 0;
            var marchCallBacks = 0;
            var aprilCallBacks = 0;
            var mayCallBacks = 0;
            var juneCallBacks = 0;
            var julyCallBacks = 0;
            var augustCallBacks = 0;
            var septemberCallBacks = 0;
            var octoberCallBacks = 0;
            var novemberCallBacks = 0;
            var decemberCallBacks = 0;
           
            foreach (var ticket in tickets)
            {
                ticketCount++;
                if (ticket.MonthCreated == 1 && ticket.YearCreated == currentYear) 
                {
                    january++;
                    januaryCallBacks = CountCallBacks(1);

                }
                else if (ticket.MonthCreated == 2)
                {
                    february++;
                    februaryCallBacks = CountCallBacks(2);
                }
                else if (ticket.MonthCreated == 3)
                {
                    march++;
                    marchCallBacks = CountCallBacks(3);
                }
                else if (ticket.MonthCreated == 4)
                {
                    april++;
                    aprilCallBacks = CountCallBacks(4);
                }
                else if (ticket.MonthCreated == 5)
                {
                    may++;
                    mayCallBacks = CountCallBacks(5);
                }
                else if (ticket.MonthCreated == 6)
                {
                    june++;
                    juneCallBacks = CountCallBacks(6);
                }
                else if (ticket.MonthCreated == 7)
                {
                    july++;
                    julyCallBacks = CountCallBacks(7);
                }
                else if (ticket.MonthCreated == 8)
                {
                    august++;
                    augustCallBacks = CountCallBacks(8);
                }
                else if (ticket.MonthCreated == 9)
                {
                    september++;
                    septemberCallBacks = CountCallBacks(9);
                }
                else if (ticket.MonthCreated == 10)
                {
                    october++;
                    octoberCallBacks = CountCallBacks(10);
                }
                else if (ticket.MonthCreated == 11)
                {
                    november++;
                    novemberCallBacks = CountCallBacks(11);
                }
                else if (ticket.MonthCreated == 12)
                {
                    december++;
                    decemberCallBacks = CountCallBacks(12);
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
            ViewData["JanuaryCallBacks"] = januaryCallBacks;
            ViewData["FebruaryCallBacks"] = februaryCallBacks;
            ViewData["MarchCallBacks"] = marchCallBacks;
            ViewData["AprilCallBacks"] = aprilCallBacks;
            ViewData["MayCallBacks"] = mayCallBacks;
            ViewData["JuneCallBacks"] = juneCallBacks;
            ViewData["JulyCallBacks"] = julyCallBacks;
            ViewData["AugustCallBacks"] = augustCallBacks;
            ViewData["SeptemberCallBacks"] = septemberCallBacks;
            ViewData["OctoberCallBacks"] = octoberCallBacks;
            ViewData["NovemberCallBacks"] = novemberCallBacks;
            ViewData["DecemberCallBacks"] = decemberCallBacks;

            

            return View();
        }
        public int CountCallBacks(int month)
        {

            var callBacks = _dbContext.Tickets.Where(t => t.IsCallBack == true && t.MonthCreated == month);
            
           var counter = callBacks.Count();

           return counter;
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
