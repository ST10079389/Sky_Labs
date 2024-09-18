using SkyLabs.Model;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
namespace SkyLabs.Views
{
    public partial class Home : Page
    {
        ObservableCollection<Requisition> requisitions = new ObservableCollection<Requisition>();
        public Home(ObservableCollection<Requisition> requisitions)
        {
            InitializeComponent();
            this.requisitions = requisitions;
        }

        private void addPatientButton_Click(object sender, RoutedEventArgs e)
        {
            Add_Patient add_Patient = new Add_Patient(requisitions);
            this.NavigationService.Navigate(add_Patient);   
        }
    }
}
