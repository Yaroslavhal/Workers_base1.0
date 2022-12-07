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
using Workers_base1._0.ViewModels;

namespace Workers_base1._0
{
    /// <summary>
    /// Interaction logic for Authentication_page.xaml
    /// </summary>
    public partial class Authentication_page : Page
    {
        public Authentication_page(MainWindow wind)
        {
            InitializeComponent();
            DataContext = new WorkersViewModel() { window = wind };
        }
    }
}
