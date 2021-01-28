using MyDBService.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace MyDBService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class Service1 : IService1
    {
        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }

        public List<Patient> GetAllPatients()
        {
            Patient pat = new Patient();
            return pat.SelectAll();
        }

        public Patient GetPatientByNRIC(string nric)
        {
            Patient patient = new Patient();
            return patient.SelectByNRIC(nric);
        }

        public Patient GetPatientByEmail(string email)
        {
            Patient patient = new Patient();
            return patient.SelectByEmail(email);
        }

        public int CreatePatient(string name, string nric, DateTime dob, string gen, string nat, string addr, string medcon, string email, double phoneNo)
        {
            Patient patient = new Patient(name, nric, dob, gen, nat, addr, medcon, email, phoneNo);
            return patient.Insert();
        }

        public int UpdatePatientEmail(string currEmail, string newEmail)
        {
            Patient patient = new Patient();
            return patient.UpdateEmail(currEmail, newEmail);
        }

        public int DeletePatientByEmail(string email)
        {
            Patient patient = new Patient();
            return patient.DeletePatientByEmail(email);
        }

        // USER METHODS
        public User GetUserByEmail(string email)
        {
            User user = new User();
            return user.SelectByEmail(email);
        }

        public int CreateUser(string email, string finalHash, string salt, string key, string iv)
        {
            User user = new User(email, finalHash, salt, key, iv);
            return user.Insert();
        }

        public int UpdateUserEmail(string currEmail, string newEmail)
        {
            User user = new User();
            return user.UpdateEmail(currEmail, newEmail);
        }

        public int DeleteUserByEmail(string email)
        {
            User user = new User();
            return user.DeleteUserByEmail(email);
        }
    }
}
