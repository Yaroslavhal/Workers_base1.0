using BLL1._0.Models;
using DLL1._0.Models;
using DLL1._0.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL1._0.Services
{
    public class WorkersService
    {

        WorkersRepository repository;
        public WorkersService(string connectionString)
        {
            repository = new WorkersRepository(connectionString);
        }
        public void Create(WorkerDTO item)
        {
            if (item != null)
            { repository.Create(ConvertToWorker(item)); }
        }

        public void Delete(WorkerDTO item)
        {
            if (item.FirstName != null)
                repository.Delete(ConvertToWorker(item));
        }

        public WorkerDTO Find(WorkerDTO item)
        {
            if (item.FirstName != null)
                return ConvertToWorkerDTO(repository.Find(ConvertToWorker(item)));
            return null;
        }

        public IEnumerable<WorkerDTO> GetAll()
        {
            List<WorkerDTO> workers = new List<WorkerDTO>();
            foreach (Worker worker in repository.GetAll())
            {
                workers.Add(ConvertToWorkerDTO(worker));
            }
            return workers;
        }

        public int GetId(WorkerDTO item)
        {
            if (item != null)
                return repository.GetId(ConvertToWorker(item));
            return 0;
        }

        public void Update(WorkerDTO item, WorkerDTO item2)
        {
            if (item != null)
                repository.Update(ConvertToWorker(item), ConvertToWorker(item2));
        }
        //CONVERTERS
        public Worker ConvertToWorker(WorkerDTO workerDTO)
        {
            if (workerDTO == null)
                return null;
            return new Worker()
            {
                Id = workerDTO.Id,
                FirstName = workerDTO.FirstName,
                LastName = workerDTO.LastName,
                Salary = workerDTO.Salary,
                WorkExperience = workerDTO.WorkExperience
            };
        }

        public WorkerDTO ConvertToWorkerDTO(Worker worker)
        {
            if (worker == null)
                return null;
            return new WorkerDTO()
            {
                Id = worker.Id,
                FirstName = worker.FirstName,
                LastName = worker.LastName,
                Salary = worker.Salary,
                WorkExperience = worker.WorkExperience
            };
        }
    }
}
