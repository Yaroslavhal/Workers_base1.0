using System;
using System.Collections.Generic;
using System.Linq;
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

namespace Workers_base1._0
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            mainFrame.Content = new Authentication_page(this);
            Login = "qwerty";
            Password = "1234";
        }

        public void Renew()//RENEW WINDOW
        {
            mainFrame.Content = new Admin_page(this);
        }

        public void Back()//BACK TO Authentication_page
        {
            mainFrame.Content = new Authentication_page(this);

        }

        public string Login { get; }
        public string Password { get; }
    }
}
