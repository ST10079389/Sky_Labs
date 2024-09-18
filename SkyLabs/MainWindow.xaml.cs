using SkyLabs.Model;
using SkyLabs.Views;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
namespace SkyLabs
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Predisplay();
        }
        public static ObservableCollection<Requisition> requisitions = new ObservableCollection<Requisition>();

        private void homeButton_Click(object sender, RoutedEventArgs e)
        {
            Home home = new Home(requisitions);
            Container.Navigate(home);
        }
        private void Predisplay()
        {
            Home home = new Home(requisitions);
            Container.Navigate(home);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Are you sure you want to close The App?", "Log Out", MessageBoxButton.YesNo,
                    MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                try
                {
                    this.Close();
                }
                catch (Exception)
                {
                    MessageBox.Show("Sorry, could not close the app.", "Result");
                }
            }
            else
            {
                MessageBox.Show("Logging out cancelled.", "Log Out");
            }
        }

        private void iaddPatientButton_Click(object sender, RoutedEventArgs e)
        {
            Add_Patient add_Patient = new Add_Patient(requisitions);
            Container.Navigate(add_Patient);
        }

        private void enterResultsButton_Click(object sender, RoutedEventArgs e)
        {
            Enter_Results enter_Results = new Enter_Results(requisitions);
            Container.Navigate(enter_Results);
        }

        private void viewResults_Click(object sender, RoutedEventArgs e)
        {
            DisplayInformation displayInformation = new DisplayInformation(requisitions.ToList());
            Container.Navigate(displayInformation);
        }
    }
}
