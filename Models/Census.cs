using System;
using System.Collections.Generic;

namespace InformationServices.Models
{
    public class Census
    {
        public int Id { get; set; }

        public string Department { get; set; }

        public int PatientCount { get; set; }
       

        public DateTime DateTime { get; set; }


    }
}