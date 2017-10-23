using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace InformationServices.Models.ViewModels
{
    public class TicketViewModel
    {

        public int StatusId { get; set; }

        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int? SitNumber { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? DateCreated { get; set; }
        public int? MonthCreated { get; set; }
        public int? YearCreated { get; set; }

        public Ticket Ticket { get; set; }

        public Status Status { get; set; }



        public List<SelectListItem> Statuses { get; set; } = new List<SelectListItem>
        {
            new SelectListItem { Value = "1", Text = "Open" },
            new SelectListItem { Value = "2", Text = "Closed" }
        };

        
    }
}
