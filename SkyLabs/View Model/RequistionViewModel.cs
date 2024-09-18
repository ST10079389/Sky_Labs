using SkyLabs.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkyLabs.View_Model
{
    public class RequistionViewModel
    {
        public ObservableCollection<Requisition> Requisitions = new ObservableCollection<Requisition>();
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


        public void addPatient(string requistionId, DateTime timeSampleTaken, string firstName, string surname, string gender, DateTime dateOfBirth, int age, string ageValue, string mobileNumber, List<Request> requestedTests)
        {
            Requisition requisition = new Requisition(
            RequistionId, TimeSampleTaken, FirstName, Surname, Gender, DateOfBirth, Age, AgeValue, MobileNumber, RequestedTests
            );
            Requisitions.Add(requisition);
            RequistionId = requistionId;
            TimeSampleTaken = timeSampleTaken;
            FirstName = firstName;
            Surname = surname;
            Gender = gender;
            DateOfBirth = dateOfBirth;
            Age = age;
            AgeValue = ageValue;
            MobileNumber = mobileNumber;
            RequestedTests = requestedTests;
        }
    }
}
