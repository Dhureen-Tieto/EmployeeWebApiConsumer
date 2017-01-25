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
    public partial class EmployeeManagerMainWindow : Window
    {
        
        public EmployeeManagerMainWindow()
        {
            InitializeComponent();            
            this.DataContext = new EmployeeManagerMainWindowViewModel(new HttpClient(), this);
        }       
    }
}
