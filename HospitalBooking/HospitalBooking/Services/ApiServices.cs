using Firebase.Database;
using HospitalBooking.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
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
            firebase = new FirebaseClient("https://hospitalbooking-f0d4c-default-rtdb.firebaseio.com/");
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
              .OnceAsync<User>()).Where(a => a.Object.Username == username).Where(b => b.Object.Password == password).FirstOrDefault();

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
        #endregion

        #region Hospital

        //Check Hospital List per location [GET]
        public async Task<List<Hospital>> GetHospitalList(string location)
        {
            var GetHospital = (await firebase
              .Child("Hospital")
              .OnceAsync<Hospital>()).Where(a => a.Object.Location.ToString() == location).Select(item => new Hospital
              {
                  Hospitalname = item.Object.Hospitalname,
                  Location = item.Object.Location,
                  
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
    }
}
