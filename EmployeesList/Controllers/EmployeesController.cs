using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EmployeesList.Data;
using EmployeesList.Models;
using EmployeesList.Servises;
using EmployeesList.Interfaces;
using Microsoft.AspNetCore.Authorization;

namespace EmployeesList.Controllers

{
    [Authorize]
    public class EmployeesController : Controller
    {
        private readonly IEmployeeService employeeService;

        public EmployeesController(IEmployeeService employeeService)
        {
            this.employeeService = employeeService;
        }

        public async Task<IActionResult> Index()
        {
            var result = await employeeService.GetEmployees();

            return View(result);
        }

        public async Task<IActionResult> IndexChild(int id)
        {
            var result = await employeeService.GetChildren(id);

            return View(result);
        }

        // GET: Employees/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            var employee = await employeeService.GetEmployee(id);
            ViewData["Emploee"] = employee;
            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        // GET: Employees/Create
        public IActionResult Create()
        {
            return View();
        }

        public IActionResult CreateChild(int id)
        {
            return View(new Children { EmployeeId = id, Id = Guid.NewGuid() });
        }

        // POST: Employees/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Patronymic,Surname,DateОfBirth,Position,Childrens")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                await employeeService.CreateEmployee(employee);
                return RedirectToAction(nameof(Index));
            }
            //добавить проверку на одинаковых пользователей
            return View(employee);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateChild([Bind("Id,Name,Patronymic,Surname,DateОfBirth,EmployeeId")] Children children)
        {
            if (ModelState.IsValid)
            {
                await employeeService.CreateChildren(children);
                return RedirectToAction(nameof(IndexChild));
            }
            //добавить проверку на одинаковых пользователей
            return View(children);
        }

        // GET: Employees/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = await employeeService.GetEmployee(id);
            if (employee == null)
            {
                return NotFound();
            }
            return View(employee);
        }

        // POST: Employees/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Patronymic,Surname,DateОfBirth,Position")] Employee employee)
        {
            if (id != employee.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                await employeeService.UpdateEmployee(employee);

                return RedirectToAction(nameof(Index));
            }
            return View(employee);
        }

        // GET: Employees/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = await employeeService.GetEmployee(id);
            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        // POST: Employees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            if (Models.Employee.Equals == null)
            {
                return Problem("Entity set 'EmployeesListContext.Employee'  is null.");
            }
            await employeeService.RemoveEmployee(id);

            return RedirectToAction(nameof(Index));
        }
    }
}