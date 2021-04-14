using System;
using System.Collections.Generic;
using System.Text;

namespace HospitalBooking.Models
{
    public class Notification
    {
        public Guid Id { get; set; }
        public Guid PatientId { get; set; }
        public Guid HospitalId { get; set; }
        public string NotificationDetails { get; set; }
        public DateTime NotificationDate { get; set; }
        public string NotificationFlag { get; set; }
    }
}
