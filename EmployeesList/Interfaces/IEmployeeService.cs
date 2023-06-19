using EmployeesList.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace EmployeesList.Interfaces
{
    public interface IEmployeeService
    {
        Task<List<Employee>> GetEmployees();
        Task<Employee> GetEmployee(int? id);
        Task CreateEmployee(Employee employee);
        Task UpdateEmployee(Employee employee);
        Task RemoveEmployee(int? id);
        Task<List<Children>> GetChildren();




    }
}




