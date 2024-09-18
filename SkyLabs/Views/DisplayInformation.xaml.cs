using SkyLabs.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Text.Json;
namespace SkyLabs.Views
{
    public partial class DisplayInformation : Page
    {
        List<Requisition> requisitions = new List<Requisition>();
        public DisplayInformation(List<Requisition> requisitions)
        {
            this.requisitions = requisitions;
            InitializeComponent();
            populatePatients(requisitions);
        }
        private void populatePatients(List<Requisition> requisitions)
        {
            foreach (var patient in requisitions)
            {
                patientNameBox.Items.Add(patient.FirstName + " " + patient.Surname);
            }
        }
        private void exportText_Click(object sender, RoutedEventArgs e)
        {
            string fullName, firstName, Surname;
            fullName = patientNameBox.SelectedItem.ToString();
            string[] name = fullName.Split(' ');
            firstName = name[0];
            Surname = name[1];

            string projectDirectory = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.FullName;
            string relativePath = @"ExportedData\PatientData.txt";
            string fullPath = Path.Combine(projectDirectory, relativePath);
            ExportListToTextFile(firstName, Surname, fullPath);
        }
        private void exportJson_Click(object sender, RoutedEventArgs e)
        {
            string fullName, firstName, Surname;
            fullName = patientNameBox.SelectedItem.ToString();
            string[] name = fullName.Split(' ');
            firstName = name[0];
            Surname = name[1];
            ExportListToJsonFile(firstName, Surname);
        }
        private void ExportListToTextFile(string firstName, string surname, string filePath)
        {
            try
            {
                TestsAvailable testsAvailable = new TestsAvailable();
                var tests = testsAvailable.populateList();
                using (StreamWriter writer = new StreamWriter(filePath))
                {
                    var patient = requisitions.FirstOrDefault(p => p.FirstName.Equals(firstName) && p.Surname.Equals(surname));
                    if (patient != null)
                    {
                        writer.WriteLine();
                        writer.WriteLine($"Patient Details:");
                        writer.WriteLine();
                        writer.WriteLine($"Name: {patient.FirstName}");
                        writer.WriteLine($"Surname: {patient.Surname}");
                        writer.WriteLine($"Gender: {patient.Gender}");
                        writer.WriteLine($"Time Sample Taken: {patient.TimeSampleTaken}");
                        writer.WriteLine($"Date Of Birth: {patient.DateOfBirth}");
                        writer.WriteLine($"Age: {patient.Age} {patient.AgeValue}");
                        writer.WriteLine($"Mobile Number: {patient.MobileNumber}");
                        writer.WriteLine();
                        writer.WriteLine($"Requested Tests:");
                        writer.WriteLine();
                        foreach (var test in patient.RequestedTests)
                        {
                            foreach(var t1 in tests)
                            {
                                if (test.TestId.Equals(t1.TestId))
                                {
                                    writer.WriteLine($"Test Name: {t1.Description}");
                                }
                            }
                          
                            writer.WriteLine($"Result: {test.Result}");
                            writer.WriteLine($"Comment: {test.Comment}");
                            writer.WriteLine();
                        }
                        writer.WriteLine();
                    }  
                }
                MessageBox.Show("List exported successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred, please try again.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private void ExportListToJsonFile(string firstName, string surname)
        {
            try
            {
                TestsAvailable testsAvailable = new TestsAvailable();
                var tests = testsAvailable.populateList();
                var patient = requisitions.FirstOrDefault(p => p.FirstName.Equals(firstName) && p.Surname.Equals(surname));
                string jsonString = JsonSerializer.Serialize(patient, new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText("patientData.json", jsonString);
                MessageBox.Show("List exported to JSON successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred, please try again.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void patientNameBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            TestsAvailable testsAvailable = new TestsAvailable();
            var tests = testsAvailable.populateList();
            string fullName, firstName, surname;
            fullName = patientNameBox.SelectedItem.ToString();
            string[] name = fullName.Split(' ');
            firstName = name[0];
            surname = name[1];
            var patient = requisitions.FirstOrDefault(x => x.FirstName.Equals(firstName) && x.Surname.Equals(surname));
            if (patient != null)
            {
                dataGrid.ItemsSource = new List<Requisition> { patient };
            }
            else
            {
                dataGrid.ItemsSource = null;
            }
        }   
    }
}
