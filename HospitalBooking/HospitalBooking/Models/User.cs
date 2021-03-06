using System;
using System.Collections.Generic;
using System.Text;

namespace HospitalBooking.Models
{
    public class User
    {
        public Guid Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public string Birthday { get; set; }
        public string Location { get; set; }
        public string ContactNumber { get; set; }
        public string ContactPerson { get; set; }
    }
}
