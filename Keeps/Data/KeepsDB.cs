using Keeps.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Keeps.Data
{

    public class KeepsDB:DbContext
    {
        public KeepsDB(DbContextOptions<KeepsDB> options) : base(options)
        {
        }
        public DbSet<Country> countries { get; set; }
        public DbSet<Employee> tbl_employees { get; set; }
        public DbSet<Department> tbl_departments { get; set; }
    }
}
