using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using EmployeesList.Models;

namespace EmployeesList.Data
{
    public interface IApplicationContext 
    {
         DbSet<Employee> Employee { get; set; }
        DbSet<Children> Children { get; set; }

    }
}
