using DLL1._0.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL1._0.DataContext
{
    public class WorkersContext : DbContext
    {
        public WorkersContext(string connectionString) : base(connectionString) { }
        public DbSet<Worker> Workers { get; set; }
    }
}
