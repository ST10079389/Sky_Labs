using SkyLabs.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
namespace SkyLabs.Views
{
    public partial class Enter_Results : Page
    {
        ObservableCollection<Requisition> requisitions = new ObservableCollection<Requisition>();
        int v2;
        bool canSave = true;
        public Enter_Results(ObservableCollection<Requisition> requisitions)
        {
            InitializeComponent();
            this.requisitions = requisitions;
            populatePatients(requisitions.ToList());
        }
        private void populatePatients(List<Requisition> requisitions)
        {   
            foreach(var patient in requisitions)
            {
                patientNameBox.Items.Add(patient.FirstName + " " + patient.Surname);      
            }  
        }
        private void patientNameBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            requestedTestsComboBox.SelectedIndex = -1;
            requestedTestsComboBox.Items.Clear();
            TestsAvailable testsAvailable = new TestsAvailable();
            var tests = testsAvailable.populateList();
            string fullName, firstName, surname;
            fullName = patientNameBox.SelectedItem.ToString();
            string[] name = fullName.Split(' ');
            firstName = name[0];
            surname = name[1];
            var patient = requisitions.FirstOrDefault(x => x.FirstName.Equals(firstName) && x.Surname.Equals(surname));
                if(patient!=null)
                {
                  foreach(var test in patient.RequestedTests)
                  {
                    var item = tests.FirstOrDefault(y => y.TestId == test.TestId);
                            
                                if (item!=null)
                                { 
                                requestedTestsComboBox.Items.Add(item.Description);
                                } 
                  }      
                }           
        }
        private void Save_Results_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                canSave = true;
                string fullName, firstName, surname;
                fullName = patientNameBox.SelectedItem.ToString();
                TestsAvailable testsAvailable = new TestsAvailable();
                var tests = testsAvailable.populateList();
                string selected = "";
                if (requestedTestsComboBox.SelectedValue != null && !string.IsNullOrEmpty(requestedTestsComboBox.SelectedValue.ToString()))
                {
                    selected = requestedTestsComboBox.SelectedValue.ToString();
                }
                else
                {
                    canSave = false;
                    MessageBox.Show("Please select a test before proceeding.");
                }
                var filt = tests.FirstOrDefault(x => x.Description.Equals(selected));
                if (filt != null)
                {
                    v2 = filt.TestId;
                }
                string[] name = fullName.Split(' ');
                firstName = name[0];
                surname = name[1];
                checkInputBoxes();
                if (canSave)
                {
                    var patient = requisitions.FirstOrDefault(p => p.FirstName.Equals(firstName) && p.Surname.Equals(surname));

                    if (patient != null)
                    {
                        var test = patient.RequestedTests.FirstOrDefault(t => t.TestId == v2);

                        if (test != null)
                        {
                            test.Result = resultBox.Text.ToString();
                            test.Comment = commentsBox.Text.ToString();
                            MessageBox.Show("Result saved!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                        }
                    }
                    commentsBox.Text = string.Empty;
                    resultBox.Text = string.Empty;
                }
                
            }
            catch (FormatException)
            {
                MessageBox.Show("Sorry, there was an error, Please enter the correct values", "Error 312", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("Sorry, you did not input any values", "Error 313", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred, please try again.", "Error 311", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private void checkInputBoxes()
        {
            if (string.IsNullOrEmpty(resultBox.Text))
            {
                MessageBox.Show("Please enter the result.", "Input Error", MessageBoxButton.OK, MessageBoxImage.Error);
                canSave = false;
            }

            if (string.IsNullOrEmpty(commentsBox.Text))
            {
                MessageBox.Show("Please enter the comment.", "Input Error", MessageBoxButton.OK, MessageBoxImage.Error);
                canSave = false;
            }

            if (patientNameBox.SelectedItem == null)
            {
                MessageBox.Show("Please select a patient.", "Input Error", MessageBoxButton.OK, MessageBoxImage.Error);
                canSave = false;
            }

            if (requestedTestsComboBox.SelectedItem == null)
            {
                MessageBox.Show("Please select a test.", "Input Error", MessageBoxButton.OK, MessageBoxImage.Error);
                canSave = false;
            }
        }
    }
}
