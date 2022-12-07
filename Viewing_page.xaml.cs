using BLL1._0.Models;
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
    /// Interaction logic for Viewing_page.xaml
    /// </summary>
    public partial class Viewing_page : Page
    {
        public Viewing_page()
        {
            InitializeComponent();
            DataContext = new WorkersViewModel() { viewing = this };
            workersBoard.ItemsSource = new WorkersViewModel().GetAll();
        }

        public void BackToTable()
        {
            workersBoard.ItemsSource = new WorkersViewModel().GetAll();
        }

        public void FindWorker(WorkerDTO worker)
        {

            WorkerDTO w = new WorkersViewModel()._service.Find(worker);
            if (w.FirstName != null)
            {
                workersBoard.ItemsSource = new List<WorkerDTO>() { w };
            }
            else
            {
                MessageBox.Show("Not found");
            }
        }
    }
}
