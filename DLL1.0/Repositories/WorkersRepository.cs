using DLL1._0.DataContext;
using DLL1._0.Interfaces;
using DLL1._0.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL1._0.Repositories
{
    public class WorkersRepository : IRepository<Worker>
    {
        WorkersContext _workersContext;
        public WorkersRepository(string connectionString)
        {
            _workersContext = new WorkersContext(connectionString);
        }
        public void Create(Worker item)
        {
            _workersContext.Workers.Add(item);
            _workersContext.SaveChanges();
        }

        public void Delete(Worker item)
        {
            _workersContext.Workers.Remove(_workersContext.Workers.First(e => e.FirstName == item.FirstName && e.LastName == item.LastName && e.Salary == item.Salary && e.WorkExperience == item.WorkExperience));
            _workersContext.SaveChanges();

        }

        public Worker Find(Worker item)
        {

            Worker worker = new Worker();
            try
            {
                worker = _workersContext.Workers.First(
                    c => c.FirstName == item.FirstName &&
                    c.LastName == item.LastName &&
                    c.Salary == item.Salary &&
                    c.WorkExperience == item.WorkExperience);
            }
            catch
            {
                return new Worker();
            }
            return worker;
        }

        public IEnumerable<Worker> GetAll()
        {
            return _workersContext.Workers;
        }

        public int GetId(Worker item)
        {
            Worker worker = _workersContext.Workers.Find(item);
            if (worker != null)
            {
                return worker.Id;
            }
            throw new InvalidOperationException();
        }

        public void Update(Worker item, Worker item2)
        {
            Worker newItem = Find(item);
            if (item.FirstName != null)
            {
                newItem.FirstName = item2.FirstName;
                newItem.LastName = item2.LastName;
                newItem.Salary = item2.Salary;
                newItem.WorkExperience = item2.WorkExperience;
            }
            _workersContext.SaveChanges();
        }

    }
}
