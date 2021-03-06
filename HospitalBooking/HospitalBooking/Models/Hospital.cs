using System;
using System.Collections.Generic;
using System.Text;

namespace HospitalBooking.Models
{
    public class Hospital
    {
        public Guid Id { get; set; }
        public string Hospitalname { get; set; }
        public string Location { get; set; }

    }
}
