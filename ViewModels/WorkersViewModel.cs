using BLL1._0.Models;
using BLL1._0.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Workers_base1._0.Commands;

namespace Workers_base1._0.ViewModels
{
    public class WorkersViewModel
    {
        public WorkersViewModel()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["default"].ConnectionString;
            _service = new WorkersService(connectionString);
            Workers = new ObservableCollection<WorkerDTO>(_service.GetAll());

        }
        public ObservableCollection<WorkerDTO> Workers { get; set; }

        public MainWindow window;

        public readonly WorkersService _service;
        public string FirstNameView { get; set; }
        public string LastNameView { get; set; }
        public string SalaryView { get; set; }
        public string WorkExperienceView { get; set; }

        public ObservableCollection<WorkerDTO> GetAll()
        {
            return Workers;
        }


        ///ADD WORKER
        private RelayCommand _addWorker;
        public RelayCommand AddWorker
        {
            get
            {
                return _addWorker ?? new RelayCommand(obj =>
                {
                    if (FirstNameView != null &&
                    LastNameView != null &&
                    SalaryView != null &&
                    WorkExperienceView != null)

                    {
                        WorkerDTO worker = new WorkerDTO()
                        {
                            FirstName = FirstNameView,
                            LastName = LastNameView,
                            Salary = Convert.ToDouble(SalaryView),
                            WorkExperience = Convert.ToDouble(WorkExperienceView)
                        };
                        WorkerDTO worker_find = _service.Find(worker);
                        if (worker_find.FirstName == null)
                        {
                            _service.Create(worker);
                            window.Renew();
                            System.Windows.MessageBox.Show("Worker added");
                        }
                        else
                            System.Windows.Forms.MessageBox.Show("Worker you looking for already exist in database!", "Already exist!", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    }
                }
                );
            }
        }

        ///DELETE WORKER
        private RelayCommand _deleteWorker;
        public RelayCommand DeleteWorker
        {
            get
            {
                return _deleteWorker ?? new RelayCommand(obj =>
                {
                    if (FirstNameView != null &&
                    LastNameView != null &&
                    SalaryView != null &&
                    WorkExperienceView != null)

                    {
                        WorkerDTO worker = new WorkerDTO()
                        {
                            FirstName = FirstNameView,
                            LastName = LastNameView,
                            Salary = Convert.ToDouble(SalaryView),
                            WorkExperience = Convert.ToDouble(WorkExperienceView)
                        };
                        WorkerDTO worker_find = _service.Find(worker);
                        if (worker_find.FirstName != null)
                        {
                            _service.Delete(worker);
                            window.Renew();
                            System.Windows.MessageBox.Show("Worker deleted");

                        }
                        else
                            System.Windows.Forms.MessageBox.Show("Worker you looking for is not found in database!", "Not found!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                );
            }
        }
        ///SAVE BASE OF WORKERS OR WORKER TO .txt FILE
        private RelayCommand _saveDataBaseToFile;
        public RelayCommand SaveDataBaseToFile
        {
            get
            {
                return _saveDataBaseToFile ?? new RelayCommand(obj =>
                {
                    string fileName;
                    System.Windows.Forms.OpenFileDialog openFileDialog = new System.Windows.Forms.OpenFileDialog();
                    openFileDialog.Filter = "Text documents (.txt)|*.txt";
                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        fileName = openFileDialog.FileName;
                        try
                        {
                            using (StreamWriter writer = new StreamWriter(fileName))
                            {
                                foreach (WorkerDTO worker in _service.GetAll())
                                {
                                    writer.Write($"{worker.Id} {worker.FirstName} {worker.LastName} {worker.Salary} {worker.WorkExperience}\n");
                                }
                                System.Windows.MessageBox.Show("Saved");

                            }
                        }
                        catch (Exception ex)
                        {
                            System.Windows.MessageBox.Show(ex.Message);
                        }
                    }
                });

            }
        }

        ///LOG IN LOGIC
        public string LoginView { get; set; }
        public string PasswordView { get; set; }
        private RelayCommand _logIn;
        public RelayCommand LogIn
        {
            get
            {
                return _logIn ?? new RelayCommand(obj =>
                {
                    if (LoginView == window.Login && PasswordView == window.Password)
                    {
                        window.Renew();
                    }
                    else if (LoginView == null || PasswordView == null)
                    {
                        System.Windows.Forms.MessageBox.Show("Fill all fields!", "Empty field!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        System.Windows.Forms.MessageBox.Show("Wrong pasword or login!", "!!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    }
                });
            }
        }
        ///LOG OUT LOGIC
        private RelayCommand _logOut;
        public RelayCommand LogOut
        {
            get
            {
                return _logOut ?? new RelayCommand(obj =>
                {
                    window.Back();
                });
            }
        }


        ///OPEN PAGE TO UPDATE WORKER

        private RelayCommand _openUpdatePage;
        public RelayCommand OpenUpdatePage
        {
            get
            {
                return _openUpdatePage ?? new RelayCommand(obj =>
                {
                    if (FirstNameView != null &&
                   LastNameView != null &&
                   SalaryView != null &&
                   WorkExperienceView != null)

                    {
                        WorkerDTO worker = new WorkerDTO()
                        {
                            FirstName = FirstNameView,
                            LastName = LastNameView,
                            Salary = Convert.ToDouble(SalaryView),
                            WorkExperience = Convert.ToDouble(WorkExperienceView)
                        };
                        WorkerDTO worker_find = _service.Find(worker);
                        if (worker_find.FirstName != null)
                        {
                            update = new Update_worker(worker, window);
                            update.ShowDialog();
                        }
                    }
                });
            }
        }
        ///UPDATE WORKER
        public WorkerDTO workerForUpdate;
        public string NewFirstNameView { get; set; }
        public string NewLastNameView { get; set; }
        public string NewSalaryView { get; set; }
        public string NewWorkExperienceView { get; set; }
        public Update_worker update;
        private RelayCommand _update;
        public RelayCommand UpdateWorker
        {
            get
            {
                return _update ?? new RelayCommand(obj =>
                {
                    if (NewFirstNameView != null &&
                      NewLastNameView != null &&
                      NewSalaryView != null &&
                      NewWorkExperienceView != null)
                    {
                        _service.Update(workerForUpdate, new WorkerDTO()
                        {
                            FirstName = NewFirstNameView,
                            LastName = NewLastNameView,
                            Salary = Convert.ToDouble(NewSalaryView),
                            WorkExperience = Convert.ToDouble(NewWorkExperienceView)
                        });
                        update.Close();
                        window.Renew();
                        System.Windows.MessageBox.Show("Worker updated");

                    }
                });
            }
        }

        ///OPEN FIND WORKER DIALOG
        ///    
        public Viewing_page viewing;
        public RelayCommand _findDialog;
        public RelayCommand FindDialog
        {
            get
            {
                return _findDialog ?? new RelayCommand(obj =>
                {
                    Find_worker_window find = new Find_worker_window(viewing);
                    find.ShowDialog();
                });
            }
        }

        ///FIND WORKER
        public string FindFirstNameView { get; set; }
        public string FindLastNameView { get; set; }
        public string FindSalaryView { get; set; }
        public string FindWorkExperienceView { get; set; }
        private RelayCommand _find;
        public Find_worker_window Find_Worker_Window;
        public RelayCommand FindWorker
        {
            get
            {
                return _find ?? new RelayCommand(obj =>
                {
                    if (FindFirstNameView != null &&
                     FindLastNameView != null &&
                     FindSalaryView != null &&
                     FindWorkExperienceView != null)
                    {
                        viewing.FindWorker(new WorkerDTO()
                        {
                            FirstName = FindFirstNameView,
                            LastName = FindLastNameView,
                            Salary = Convert.ToDouble(FindSalaryView),
                            WorkExperience = Convert.ToDouble(FindWorkExperienceView)
                        });
                        Find_Worker_Window.Close();

                    }
                });
            }
        }

    }
}
