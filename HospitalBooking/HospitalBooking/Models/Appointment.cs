using System;
using System.Collections.Generic;
using System.Text;

namespace HospitalBooking.Models
{
    public class Appointment
    {
        public Guid Id { get; set; }
        public string AppointmentName { get; set; }
        public string AppointmentDescription { get; set; }
        public string AppointmentDate { get; set; }
        public Guid PatientId { get; set; }
        public string PatientName { get; set; }
        public string PatientLocation { get; set; }
        public int PatientAge { get; set; }
        public string PatientGender { get; set; }
        public Guid HospitalId { get; set; }
        public string HospitalName { get; set; }
        public string HospitalLocation { get; set; }
    }
}
