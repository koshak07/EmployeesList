using EmployeesList.Interfaces;
using EmployeesList.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EmployeesList.Data;
using EmployeesList.Models;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace EmployeesList.Servises
{
    public class EmployeeService : IEmployeeService

    {
        private EmployeesListContext _context;

        public EmployeeService(EmployeesListContext context)
        {
            _context = context;
        }

        public async Task<List<Employee>> GetEmployees()
        {
            return await _context.Employee.ToListAsync();
        }

        public async Task<Employee> GetEmployee(int? id)
        {


            var employee = await _context.Employee
                .FindAsync(id);
            if (employee == null)
            {
                return null;
            }

            return employee;
        }
        public async Task CreateEmployee(Employee employee)
        {

            _context.Add(employee);
            await _context.SaveChangesAsync();

        }
        public async Task UpdateEmployee(Employee employee)
        {
                try
                {
                    _context.Update(employee);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmployeeExists(employee.Id))
                    {
                        return;
                    }
                    else
                    {
                        throw;
                    }
                }
        }
        private bool EmployeeExists(int id)
        {
            return (_context.Employee?.Any(e => e.Id == id)).GetValueOrDefault();
        }
        public async Task RemoveEmployee(int? id)
        {


            var employee = await _context.Employee.FindAsync(id);
            if (employee != null)
            {
                _context.Employee.Remove(employee);
            }

            await _context.SaveChangesAsync();
        }

    }
    }



