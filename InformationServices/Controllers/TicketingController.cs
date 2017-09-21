using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Security.Cryptography;
using System.Threading.Tasks;
using InformationServices.Data;
using InformationServices.Models;
using InformationServices.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace InformationServices.Controllers
{
    public class TicketingController : Controller
    {
        private readonly ApplicationDbContext _dbContext;

        public TicketingController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IActionResult> Index(string sortOrder, string searchString, string currentFilter, int? page)
        {
            ViewData["CurrentSort"] = sortOrder;
            ViewData["NameSortParm"] = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewData["DateSortParm"] = sortOrder == "Date" ? "date_desc" : "Date";



            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }



            ViewData["CurrentFilter"] = searchString;


            var tickets = from s in _dbContext.Tickets.OrderByDescending(m => m.DateCreated)
                select s;

            if (!String.IsNullOrEmpty(searchString))
            {
                tickets = tickets.Where(s => s.Title.Contains(searchString)
                                               || s.Description.Contains(searchString));
            }


            switch (sortOrder)
            {
                case "name_desc":
                    tickets = tickets.OrderByDescending(s => s.Title);
                    break;
                case "Date":
                    tickets = tickets.OrderBy(s => s.Description);
                    break;
                case "date_desc":
                    tickets = tickets.OrderByDescending(s => s.Description);
                    break;
                default:
                    tickets = tickets.OrderByDescending(s => s.DateCreated);
                    break;
            }

            int pageSize = 10;
            return View(await PaginatedList<Ticket>.CreateAsync(tickets.AsNoTracking(), page ?? 1, pageSize));
        }

        public IActionResult New()
        {
            var model = new TicketViewModel();

            return View(model);
        }

        [HttpPost]
        public IActionResult SaveTicket(Ticket ticket)
        {
            var currentMonth = DateTime.Now.Month;
            var currentYear = DateTime.Now.Year;

            ticket.MonthCreated = currentMonth;
            ticket.YearCreated = currentYear;

            _dbContext.Tickets.Add(ticket);
            _dbContext.SaveChanges();

           return RedirectToAction("Index");
        }

        public IActionResult Details(int? id)
        {
            var ticket = _dbContext.Tickets
                .AsNoTracking()
                .SingleOrDefault(m => m.Id == id);

            return View(ticket);
        }

        public IActionResult Edit(int id)
        {
            var ticket = _dbContext.Tickets.Single(t => t.Id == id);

            var viewModel = new TicketViewModel
            {

                StatusId =  ticket.StatusId,
                Title = ticket.Title, 
                Id = ticket.Id,
                DateCreated = ticket.DateCreated,
                SitNumber = ticket.SitNumber,
                Description = ticket.Description
                
            }; 
          
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult UpdateTicket(Ticket ticket)
        {

            var ticketInDb = _dbContext.Tickets.SingleOrDefault(t => t.Id == ticket.Id);
            ticketInDb.Id = ticket.Id;
            ticketInDb.Title = ticket.Title;
            ticketInDb.Description = ticket.Description;
            ticketInDb.SitNumber = ticket.SitNumber;
            ticketInDb.StatusId = ticket.StatusId;
            ticketInDb.DateCreated = ticket.DateCreated;
            ticketInDb.MonthCreated = ticketInDb.MonthCreated;
            ticketInDb.YearCreated = ticketInDb.YearCreated;

            _dbContext.SaveChanges();

            return RedirectToAction("Index");

        }
    }
}