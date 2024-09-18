using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkyLabs.Model
{
    public class Requisition
    {
        public Requisition(string requistionId, DateTime timeSampleTaken, string firstName, string surname, string gender, DateTime dateOfBirth, int age, string ageValue, string mobileNumber, List<Request> requestedTests)
        {
            RequistionId = requistionId;
            TimeSampleTaken = timeSampleTaken;
            FirstName = firstName;
            Surname = surname;
            Gender = gender;
            DateOfBirth = dateOfBirth;
            Age = age;
            this.AgeValue = ageValue;
            MobileNumber = mobileNumber;
            RequestedTests = requestedTests;
        }

        public string RequistionId { get; set; }
        public DateTime TimeSampleTaken { get; set; }
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public string Gender { get; set; }  
        public DateTime DateOfBirth { get; set; }
        public int Age { get; set; }
        public string AgeValue { get; set; }
        public string MobileNumber { get; set; }
        public List<Request> RequestedTests { get; set; }
    }
}
