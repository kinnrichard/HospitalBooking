using Firebase.Database;
using Firebase.Database.Query;
using HospitalBooking.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalBooking.Services
{
    public class ApiServices
    {
        private JsonSerializer _serializer = new JsonSerializer();
        private static ApiServices _ServiceClientInstance;
        FirebaseClient firebase;
        //FirebaseStorage firebaseStorage;

        public ApiServices()
        {
            //API Address
            firebase = new FirebaseClient("https://hostpitalbooking-default-rtdb.firebaseio.com/");
        }
        public static ApiServices ServiceClientInstance
        {
            get
            {
                if (_ServiceClientInstance == null)
                    _ServiceClientInstance = new ApiServices();
                return _ServiceClientInstance;
            }
        }

        #region Users
        //Login with clients credentials. 
        public async Task<User> LoginUser(string username, string password)
        {
            var GetPerson = (await firebase
              .Child("User")
              .OnceAsync<User>())
              .Where(a => a.Object.Username == username)
              .Where(b => b.Object.Password == password)
              .FirstOrDefault();

            if (GetPerson != null)
            {
                var content = GetPerson.Object as User;
                return content;
            }
            else
            {
                return null;
            }
        }

        public async Task<bool> RegisterUser(string username, string password, string firstname, string lastname, int age, string gender, string location)
        {
            var result = await firebase
                .Child("User")
                .PostAsync(new User() { Id = Guid.NewGuid(), Username = username, Password = password, Firstname = firstname, Lastname = lastname, Age = age, Gender = gender, Location = location });

            if (result.Object != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion

        #region Hospital
        //Check Hospital List per location [GET]
        public async Task<List<Hospital>> GetHospitalList(string location)
        {
            var GetHospital = (await firebase
              .Child("HospitalUser")
              .OnceAsync<Hospital>())
              .Where(a => a.Object.HospitalLocation.ToString() == location)
              .Select(item => new Hospital
              {
                  Id = item.Object.Id,
                  HospitalName = item.Object.HospitalName,
                  HospitalLocation = item.Object.HospitalLocation,           
              }).ToList(); ;

            if (GetHospital != null)
            {
                return new List<Hospital>(GetHospital);
            }
            else
            {
                return null;
            }
        }
        #endregion

        #region Appointment

        public async Task<User> GetPatientInfo(Guid id)
        {
            var GetPerson = (await firebase
              .Child("User")
              .OnceAsync<User>())
              .Where(a => a.Object.Id == id)
              .FirstOrDefault();

            if (GetPerson != null)
            {
                var content = GetPerson.Object as User;
                return content;
            }
            else
            {
                return null;
            }
        }

        public async Task<Hospital> GetHospitalInfo(string hospitalname)
        {
            var GetHospital = (await firebase
              .Child("HospitalUser")
              .OnceAsync<Hospital>())
              .Where(a => a.Object.HospitalName == hospitalname)
              .FirstOrDefault();

            if (GetHospital != null)
            {
                var content = GetHospital.Object as Hospital;
                return content;
            }
            else
            {
                return null;
            }
        }

        public async Task<bool> BookAppointment(
            string appointmentname, 
            string appointmentdescription, 
            string appointmentdate, 
            Guid patientid, 
            string patientname, 
            string patientlocation, 
            int patientage, 
            string patientgender,
            Guid hospitalid,
            string hospitalname,
            string hospitallocation,
            string status
            )
        {
            var result = await firebase
                .Child("Appointment")
                .PostAsync(new Appointment() { 
                    Id = Guid.NewGuid(), 
                    AppointmentName = appointmentname, 
                    AppointmentDescription = appointmentdescription, 
                    AppointmentDate = appointmentdate, 
                    PatientId = patientid,
                    PatientName = patientname, 
                    PatientLocation = patientlocation, 
                    PatientAge = patientage, 
                    PatientGender = patientgender,
                    HospitalId = hospitalid,
                    HospitalName = hospitalname,
                    HospitalLocation = hospitallocation,
                    Status = status
                });

            if (result.Object != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<List<Appointment>> GetAppointment(Guid patientid)
        {
            var GetAppointment = (await firebase
              .Child("Appointment")
              .OnceAsync<Appointment>())
              .Where(a => a.Object.PatientId == patientid)
              .Select(item => new Appointment
              {
                  Id = item.Object.Id,
                  AppointmentName = item.Object.AppointmentName,
                  AppointmentDate = item.Object.AppointmentDate,
                  AppointmentDescription = item.Object.AppointmentDescription,
                  HospitalName = item.Object.HospitalName,
                  HospitalLocation = item.Object.HospitalLocation,
                  Status = item.Object.Status
              }).ToList();

            if (GetAppointment != null)
            {
                return new List<Appointment>(GetAppointment);
            }
            else
            {
                return null;
            }
        }

        public async Task<ObservableCollection<AppointmentDetails>> GetAppointmentDetails(Guid patientid)
        {
            var GetAppointment = (await firebase
              .Child("Appointment")
              .OnceAsync<AppointmentDetails>())
              .Where(a => a.Object.PatientId == patientid)
              .Select(item => new AppointmentDetails
              {
                  Id = item.Object.Id,
                  AppointmentName = item.Object.AppointmentName,
                  AppointmentDate = item.Object.AppointmentDate,
                  AppointmentDescription = item.Object.AppointmentDescription,
                  HospitalName = item.Object.HospitalName,
                  HospitalLocation = item.Object.HospitalLocation,
                  Status = item.Object.Status
              }).ToList(); ;

            if (GetAppointment != null)
            {
                return new ObservableCollection<AppointmentDetails>(GetAppointment);
            }
            else
            {
                return null;
            }
        }

        #endregion

        #region Notification

        public async Task<bool> BookNotification(Guid hospitalid, string notification, string notificationdate)
        {
            var result = await firebase
                .Child("Notification")
                .PostAsync(new Notification() { 
                    Id = Guid.NewGuid(), 
                    HospitalId = hospitalid, 
                    NotificationDetails = notification, 
                    NotificationDate = notificationdate
                });

            if (result.Object != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<List<Notification>> GetNotification(Guid patientid)
        {
            var GetNotification = (await firebase
              .Child("Notification")
              .OnceAsync<Notification>())
              .Where(a => a.Object.PatientId == patientid)
              .Select(item => new Notification
              {
                  Id = item.Object.Id,
                  HospitalId = item.Object.HospitalId,
                  NotificationDetails = item.Object.NotificationDetails,
                  NotificationDate = item.Object.NotificationDate
              }).ToList(); ;

            if (GetNotification != null)
            {
                return new List<Notification>(GetNotification);
            }
            else
            {
                return null;
            }
        }
        #endregion
    }
}
