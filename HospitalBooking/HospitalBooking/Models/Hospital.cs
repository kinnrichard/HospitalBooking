using System;
using System.Collections.Generic;
using System.Text;

namespace HospitalBooking.Models
{
    public class Hospital
    {
        public Guid Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string HospitalName { get; set; }
        public string HospitalLocation { get; set; }
        public string HospitalDescription { get; set; }
    }
}
