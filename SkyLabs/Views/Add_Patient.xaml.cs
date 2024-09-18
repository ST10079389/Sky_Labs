using SkyLabs.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace SkyLabs.Views
{
    public partial class Add_Patient : Page
    {
        ObservableCollection<Requisition> requisitions = new ObservableCollection<Requisition>();
        bool canSave = true;
        public Add_Patient(ObservableCollection<Requisition> requisitions)
        {
            InitializeComponent();
            populateCheckBoxes();
            this.requisitions = requisitions;

        }
        private void populateCheckBoxes()
        {
            TestsAvailable testsAvailable = new TestsAvailable();
            List<Test> test = testsAvailable.populateList();
            foreach (var item in test)
            {
                CheckBox checkBox = new CheckBox();
                checkBox.FontSize = 16;
                checkBox.Foreground = new SolidColorBrush(Colors.White);
                checkBox.Content = item.Description;
                CheckboxContainer.Children.Add(checkBox);
            }
        }
        private void Save_Patient_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                canSave = true;
                string RequistionId, FirstName, Surname, Gender, MobileNumber, AgeValue;
                DateTime TimeSampleTaken, DateOfBirth;
                int Age;
                List<string> tests = new List<string>();
                RequistionId = generateID();
                validateInputBoxes();
                if (RequistionId.Equals(null))
                {
                    MessageBox.Show("Sorry, the requisition ID has exceeded the limit.", "Error 300", MessageBoxButton.OK, MessageBoxImage.Error);
                    
                }
                checkTests();
                TimeSampleTaken = DateTime.Now;
                FirstName = firstNameBox.Text.ToString();
                Surname = surnameBox.Text.ToString();
                Gender = (genderComboBox.SelectedItem as ComboBoxItem)?.Content.ToString(); 
                DateOfBirth = dateOfBirthPicker.SelectedDate.Value;
                checkDate(DateOfBirth, TimeSampleTaken);
                Age = calculateAge(DateOfBirth, TimeSampleTaken).Item1;
                AgeValue = calculateAge(DateOfBirth, TimeSampleTaken).Item2;
                MobileNumber = mobileNumberBox.Text.ToString();
                List<Request> requestedTests = populateRequestedTests();
                if (requestedTests.Count <= 0)
                {
                    MessageBox.Show("Please select some tests");
                    canSave = false;
                }

                if (canSave)
                {
                    Requisition requisition = new Requisition(
                                    RequistionId, TimeSampleTaken, FirstName, Surname, Gender, DateOfBirth, Age, AgeValue, MobileNumber, requestedTests
                                    );
                    requisitions.Add(requisition);
                    MessageBox.Show("The patients details, has been saved!", "Patient Saved!", MessageBoxButton.OK, MessageBoxImage.Information);
                    firstNameBox.Text = "";
                    surnameBox.Text = "";
                    dateOfBirthPicker.Text = "";
                    TimePicker.Text = "";
                    mobileNumberBox.Text = "+27 ";
                    genderComboBox.SelectedIndex = -1;
                    unCheckBoxes();
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
        private void validateInputBoxes()
        {
            if (string.IsNullOrEmpty(firstNameBox.Text))
            {
                MessageBox.Show("Please enter the first name.", "Input Error", MessageBoxButton.OK, MessageBoxImage.Error);
                canSave = false;
            }

            if (string.IsNullOrEmpty(surnameBox.Text))
            {
                MessageBox.Show("Please enter the surname.", "Input Error", MessageBoxButton.OK, MessageBoxImage.Error);
                canSave = false;
            }

            if (genderComboBox.SelectedItem == null)
            {
                MessageBox.Show("Please select a gender.", "Input Error", MessageBoxButton.OK, MessageBoxImage.Error);
                canSave = false;
            }

            if (dateOfBirthPicker.SelectedDate == null)
            {
                MessageBox.Show("Please select a date of birth.", "Input Error", MessageBoxButton.OK, MessageBoxImage.Error);
                canSave = false;
            }

            if (string.IsNullOrEmpty(mobileNumberBox.Text))
            {
                MessageBox.Show("Please enter a valid mobile number.", "Input Error", MessageBoxButton.OK, MessageBoxImage.Error);
                canSave = false;
            }
        }
        private void checkDate(DateTime dateOfBirth, DateTime timeSampleWasTaken)
        {
            if(dateOfBirth >= timeSampleWasTaken)
            {
                MessageBox.Show("Please enter a valid date of birth", "Input Error", MessageBoxButton.OK, MessageBoxImage.Error);
                canSave = false;
            }
        }
        private void checkTests()
        {
            foreach (var item in CheckboxContainer.Children)
            {
                if (item is CheckBox checkBox)
                {
                    if (checkBox.IsChecked == true )
                    {
                        if (checkBox.Content.ToString().Equals(" Urine-Createnine"))
                        {
                            MessageBox.Show("Sorry, this test is inactive", "Test Inactive", MessageBoxButton.OK, MessageBoxImage.Error);
                            canSave = false;
                        }
                        else if(checkBox.Content.ToString().Equals(" Sodium") && checkBox.Content.ToString().Equals(" Createnine") && checkBox.Content.ToString().Equals(" Urea") && checkBox.Content.ToString().Equals(" Urea+Createnine+Electrolytes") && checkBox.Content.ToString().Equals("  Sodium"))
                        {
                            MessageBox.Show("Sorry, these tests cannot be requisted together", "Test Selection", MessageBoxButton.OK, MessageBoxImage.Error);
                            canSave = false;
                        } 
                    }
                }
            }
        }
        private void unCheckBoxes()
        {
            foreach(var item in CheckboxContainer.Children)
            {
                if(item is CheckBox check)
                {
                    check.IsChecked = false;    
                }
            }
        }
        private string generateID()
        {
            int ID = requisitions.Count + 1;

            if (Enumerable.Range(1, 9999).Contains(ID))
            {
                return ID.ToString("0000");
            }
            else
            {
                return null;
            }
        }
        public List<Request> populateRequestedTests()
        {
            List<Request> RequestedTests = new List<Request>();
            int TestId;
            string Result, Comment;
            TestsAvailable testsAvailable = new TestsAvailable();
            var testAvailable = testsAvailable.populateList();
            foreach (var item in CheckboxContainer.Children)
            {
                if(item is CheckBox checkBox)
                {
                    if(checkBox.IsChecked == true) {
                        
                        foreach (var test in testAvailable)
                        {
                            if (checkBox.Content.ToString().Equals(test.Description))
                            {
                                    TestId = test.TestId;
                                    Result = string.Empty;
                                    Comment = string.Empty;
                                    Request request = new Request(TestId, Result, Comment);
                                    RequestedTests.Add(request); 
                            }
                        }
                    }
                }
            }
            return RequestedTests;
        }
        private (int, string) calculateAge(DateTime dateOfBirth, DateTime timeSampleTaken)
        {
            int age = timeSampleTaken.Year - dateOfBirth.Year;
            string ageValue = "Years Old";
            if(age <= 0)
            {
                age = timeSampleTaken.Month - dateOfBirth.Month;
                ageValue = "Months Old";
                if(age <= 0)
                {
                    age = timeSampleTaken.Day - dateOfBirth.Day;
                    ageValue = "Days Old";
                }
            }
            return (age, ageValue);
        }
    }
}
