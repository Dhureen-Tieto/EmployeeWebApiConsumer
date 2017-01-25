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
    
    public class EmployeeManagerMainWindowViewModel
    {
        public HttpClient Client { get; set; }
        public EmployeeManagerMainWindow MainWindow { get; set; }
        public EmployeeManagerMainWindowViewModel(HttpClient httpClient, EmployeeManagerMainWindow mainWindow)
        {
            Client = httpClient;
            MainWindow = mainWindow;
            List<string> recordStatusList = new List<string>();
            recordStatusList.Add("Active");
            recordStatusList.Add("Inactive");
            MainWindow.cbxStatus.ItemsSource = recordStatusList;
            Client.BaseAddress = new Uri("http://localhost:3339");
            Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            MainWindow.Loaded += MainWindow_Loaded;
        }
        async void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            HttpResponseMessage response = await Client.GetAsync("/api/employees");
            response.EnsureSuccessStatusCode();
            var employees = await response.Content.ReadAsAsync<IEnumerable<Employee>>();
            MainWindow.employeeListView.ItemsSource = employees;
        }
        private async void btnGetEmployee_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                HttpResponseMessage response = await Client.GetAsync("/api/employee/" + MainWindow.txtId.Text);
                response.EnsureSuccessStatusCode(); // Throw on error code. 
                var employee = await response.Content.ReadAsAsync<Employee>();
                MainWindow.employeeDetailsPanel.Visibility = Visibility.Visible;
                MainWindow.employeeDetailsPanel.DataContext = employee;
            }
            catch (Exception)
            {
                MessageBox.Show("Employee not Found");
            }
        }
        private async void btnNewEmployee_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var employee = new Employee()
                {
                    Id = MainWindow.txtEmployeeId.Text,
                    FirstName = MainWindow.txtEmployeeFirstName.Text,
                    LastName = MainWindow.txtEmployeeLastName.Text,
                    EmailId = MainWindow.txtEmployeeEmailId.Text,
                    PhoneNumber = int.Parse(MainWindow.txtPhoneNumber.Text),
                    Age = int.Parse(MainWindow.txtAge.Text),
                    ActiveStatus = MainWindow.cbxStatus.Text
                };
                var response = await Client.PostAsJsonAsync("/api/employee/create", employee);
                response.EnsureSuccessStatusCode(); // Throw on error code. 
                MessageBox.Show("Employee Added Successfully", "Result", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception exception)
            {
                MessageBox.Show("Employee not Added, May be due to Duplicate ID");
            }
        }
        private async void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var employee = new Employee()
                {
                    Id = MainWindow.txtEmployeeId.Text,
                    FirstName = MainWindow.txtEmployeeFirstName.Text,
                    LastName = MainWindow.txtEmployeeLastName.Text,
                    EmailId = MainWindow.txtEmployeeEmailId.Text,
                    PhoneNumber = int.Parse(MainWindow.txtPhoneNumber.Text),
                    Age = int.Parse(MainWindow.txtAge.Text),
                    ActiveStatus = MainWindow.cbxStatus.Text
                };
                var response = await Client.PutAsJsonAsync("/api/employee/update", employee);
                response.EnsureSuccessStatusCode(); // Throw on error code. 
                MessageBox.Show("Employee updated Successfully", "Result", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private async void btnDeleteEmployeeClick(object sender, RoutedEventArgs e)
        {
            try
            {
                HttpResponseMessage response = await Client.DeleteAsync("/api/employee/delete/" + MainWindow.txtId.Text);
                response.EnsureSuccessStatusCode(); // Throw on error code. 
                MessageBox.Show("Employee Successfully Deleted");
            }
            catch (Exception)
            {
                MessageBox.Show("Employee Deletion Unsuccessful");
            }
        }
    }
}
