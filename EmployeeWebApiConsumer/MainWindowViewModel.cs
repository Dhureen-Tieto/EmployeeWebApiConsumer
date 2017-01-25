using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace EmployeeWebApiConsumer
{
    class MainWindowViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public HttpClient Client { get; set; }
        public MainWindowViewModel()
        {
            Client = new HttpClient();
            Client.BaseAddress = new Uri("http://localhost:3339");
            Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            MainWindow_Loaded();
            RefreshCommand = new SimpleCommand(OnRefreshClicked, IsRefreshClickable);
            EditCommand = new SimpleCommand(OnEditClicked, IsEditClickable);
            DeleteCommand = new SimpleCommand(OnDeleteClicked, IsDeleteClickable);
            EmployeeToBeAdded = new Employee();             
            AddCommand = new SimpleCommand(OnAddClicked, IsAddClickable);           
        }

        

        private bool IsAddClickable()
        {
            return true;
        }

        private async void OnAddClicked()
        {
            try
            {
                var response = await Client.PostAsJsonAsync("/api/employee/create", EmployeeToBeAdded);
                response.EnsureSuccessStatusCode(); // Throw on error code. 
                MessageBox.Show("Employee Added Successfully", "Result", MessageBoxButton.OK, MessageBoxImage.Information);
                EmployeeToBeAdded = null;
            }
            catch (Exception exception)
            {
                MessageBox.Show("Employee not Added");
            }
        }

        private bool IsDeleteClickable()
        {
            if (SelectedEmployee == null)
                return false;            
            else
                return true;
        }

        private async void OnDeleteClicked()
        {
            try
            {
                HttpResponseMessage response = await Client.DeleteAsync("/api/employee/delete/" + SelectedEmployee.Id);
                response.EnsureSuccessStatusCode(); // Throw on error code. 
                MessageBox.Show("Employee Successfully Deleted");
            }
            catch (Exception)
            {
                MessageBox.Show("Employee Deletion Unsuccessful");
            }
        }

        private bool IsRefreshClickable()
        {
            return true;
        }

        private bool IsEditClickable()
        {
            if (SelectedEmployee == null)
                return false;
            else
                return true;
        }

        private async void OnEditClicked()
        {
            try
            {
                SelectedEmployee.EmailId = null;             
                var response = await Client.PutAsJsonAsync("/api/employee/update", SelectedEmployee);
                response.EnsureSuccessStatusCode(); // Throw on error code. 
                MessageBox.Show("Employee updated Successfully", "Result", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch
            {
                MessageBox.Show("Can't Edit! Maybe \n1.Email Id is being edited or,\n2.First Name or Last Name is empty ");
            }
        }

        private void OnRefreshClicked()
        {
            MainWindow_Loaded();
        }

        private async void MainWindow_Loaded()
        {
            try
            {
                HttpResponseMessage response = await Client.GetAsync("/api/employees");
                response.EnsureSuccessStatusCode();
                var employees = await response.Content.ReadAsAsync<IEnumerable<Employee>>();
                EmployeeList = employees;
            }
            catch (HttpRequestException exception)
            {
                MessageBox.Show("The Server is Down:");
                return;
            }
            
        }
        private IEnumerable<Employee> _employeeList;
        public IEnumerable<Employee> EmployeeList
        {
            get { return _employeeList; }
            set
            {
                if (value != _employeeList)
                {
                    _employeeList = value;
                    if (PropertyChanged != null)
                        PropertyChanged(this, new PropertyChangedEventArgs("EmployeeList"));
                }
            }
        }
        private Employee _selectedEmployee;
        public Employee SelectedEmployee
        {
            get { return _selectedEmployee; }
            set
            {
                if (value != _selectedEmployee)
                {
                    _selectedEmployee = value;
                    if (PropertyChanged != null)
                        PropertyChanged(this, new PropertyChangedEventArgs("SelectedEmployee"));
                }
            }
        }
        private Employee _employeeToBeAdded;
        public Employee EmployeeToBeAdded
        {
            get { return _employeeToBeAdded; }
            set
            {
                if (value != _employeeToBeAdded)
                {
                    _employeeToBeAdded = value;
                    if (PropertyChanged != null)
                        PropertyChanged(this, new PropertyChangedEventArgs("EmployeeToBeAdded"));
                }
            }
        }      

        public ICommand RefreshCommand
        {
            get;
            set;
        }
        public ICommand EditCommand
        {
            get;
            set;
        }
        public ICommand DeleteCommand
        {
            get;
            set;
        }
        public ICommand AddCommand
        {
            get;
            set;
        }
        public ICommand GetCommand
        {
            get;
            set;
        }
       
    }
}
