using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace InformationServices.Models.ViewModels
{
    public class TicketViewModel
    {
        public Ticket Ticket { get; set; }

        public string Status { get; set; }


        public List<SelectListItem> Statuses { get; } = new List<SelectListItem>
        {
            new SelectListItem { Value = "True", Text = "Open" },
            new SelectListItem { Value = "False", Text = "Closed" }
        };
    }
}
