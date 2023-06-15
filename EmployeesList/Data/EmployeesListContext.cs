using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using EmployeesList.Models;

namespace EmployeesList.Data
{
    public class EmployeesListContext : DbContext
    {
        public EmployeesListContext (DbContextOptions<EmployeesListContext> options)
            : base(options)
        {
        }

        public DbSet<Employee> Employee { get; set; } = default!;
    }
}
