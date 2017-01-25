using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Formatting;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace EmployeeWebApiConsumer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {        
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = new MainWindowViewModel();
        }
        
//        private async void btnGetEmployee_Click(object sender, RoutedEventArgs e)
//        {
//            try
//            {
//                HttpResponseMessage response = await client.GetAsync("/api/employee/" + txtId.Text);
//                response.EnsureSuccessStatusCode(); // Throw on error code. 
//                var employee = await response.Content.ReadAsAsync<Employee>();
//                employeeDetailsPanel.Visibility = Visibility.Visible;
//                employeeDetailsPanel.DataContext = employee;
//            }
//            catch (Exception)
//            {
//                MessageBox.Show("Employee not Found");
//            }
//        }
//        private async void btnNewEmployee_Click(object sender, RoutedEventArgs e)
//        {
//            try
//            {
//                var employee = new Employee()
//                {
//                    Id = txtEmployeeId.Text,
//                    FirstName = txtEmployeeFirstName.Text,
//                    LastName = txtEmployeeLastName.Text,
//                    EmailId = txtEmployeeEmailId.Text,
//                    PhoneNumber = int.Parse(txtPhoneNumber.Text),
//                    Age = int.Parse(txtAge.Text),
//                    ActiveStatus = cbxStatus.Text
//                };
//                var response = await client.PostAsJsonAsync("/api/employee/create", employee);
//                response.EnsureSuccessStatusCode(); // Throw on error code. 
//                MessageBox.Show("Employee Added Successfully", "Result", MessageBoxButton.OK, MessageBoxImage.Information);                
//            }
//            catch (Exception exception)
//            {
//                MessageBox.Show("Employee not Added");
//            }
//        }
//        private async void btnUpdate_Click(object sender, RoutedEventArgs e)
//        {
//            try
//            {
//                var employee = new Employee()
//                {
//                    Id = txtEmployeeId.Text,
//                    FirstName = txtEmployeeFirstName.Text,
//                    LastName = txtEmployeeLastName.Text,
//                    EmailId = txtEmployeeEmailId.Text,
//                    PhoneNumber = int.Parse(txtPhoneNumber.Text),
//                    Age = int.Parse(txtAge.Text),
//                    ActiveStatus = cbxStatus.Text
//                };
//                var response = await client.PutAsJsonAsync("/api/employee/update", employee);
//                response.EnsureSuccessStatusCode(); // Throw on error code. 
//                MessageBox.Show("Employee updated Successfully", "Result", MessageBoxButton.OK, MessageBoxImage.Information);
//            }
//            catch (Exception ex)
//            {
//                MessageBox.Show(ex.Message);
//            }
//        }
//        private async void btnDeleteEmployeeClick(object sender, RoutedEventArgs e)
//        {
//            try
//            {
//                HttpResponseMessage response = await client.DeleteAsync("/api/employee/delete/" + txtId.Text);
//                response.EnsureSuccessStatusCode(); // Throw on error code. 
//                MessageBox.Show("Employee Successfully Deleted");                
//            }
//            catch (Exception)
//            {
//                MessageBox.Show("Employee Deletion Unsuccessful");
//            }
//        }

//        public class Employee
//        {
//            public string Id { get; set; }
//            public string FirstName { get; set; }
//            public string LastName { get; set; }
//            public string EmailId { get; set; }
//            public int PhoneNumber { get; set; }
//            public int Age { get; set; }
//            public string ActiveStatus { get; set; }

//        }
    }
}
