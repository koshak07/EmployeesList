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
        private ApplicationContext _context;

        public EmployeeService(ApplicationContext context)
        {
            _context = context;
        }

        //get employee list
        public async Task<List<Employee>> GetEmployees()
        {
            return await _context.Employee.Include(c => c.Childrens).ToListAsync();
        }

        //get child list
        public async Task<List<Children>> GetChildren(int id)
        {
            return await _context.Children.Where(p => p.EmployeeId == id).ToListAsync();
        }

        //get employee by id
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

        //get employee by id
        public async Task<Children> GetChild(Guid? id)
        {
            var child = await _context.Children
                .FindAsync(id);
            if (child == null)
            {
                return null;
            }

            return child;
        }

        //create employee
        public async Task CreateEmployee(Employee employee)
        {
            _context.Add(employee);
            await _context.SaveChangesAsync();
        }

        //create child

        public async Task CreateChildren(Children children)
        {
            _context.Add(children);
            await _context.SaveChangesAsync();
        }

        //edit emloyee
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

        //edit child
        public async Task UpdateChild(Children children)
        {
            try
            {
                _context.Update(children);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ChildExists(children.Id))
                {
                    return;
                }
                else
                {
                    throw;
                }
            }
        }

        private bool ChildExists(Guid id)
        {
            return (_context.Children?.Any(e => e.Id == id)).GetValueOrDefault();
        }

        // delete employee
        public async Task RemoveEmployee(int? id)
        {
            var employee = await _context.Employee.FindAsync(id);
            if (employee != null)
            {
                _context.Employee.Remove(employee);
            }

            await _context.SaveChangesAsync();
        }

        // delete child
        public async Task RemoveChild(Guid? id)
        {
            var child = await _context.Children.FindAsync(id);
            if (child != null)
            {
                _context.Children.Remove(child);
            }

            await _context.SaveChangesAsync();
        }
    }
}