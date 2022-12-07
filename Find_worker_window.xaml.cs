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
using System.Windows.Shapes;
using Workers_base1._0.ViewModels;

namespace Workers_base1._0
{
    /// <summary>
    /// Interaction logic for Find_worker_window.xaml
    /// </summary>
    public partial class Find_worker_window : Window
    {
        public Find_worker_window(Viewing_page view)
        {
            InitializeComponent();
            DataContext = new WorkersViewModel() { viewing = view, Find_Worker_Window = this };
        }
    }
}
