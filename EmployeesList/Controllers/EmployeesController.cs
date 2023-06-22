using EmployeesList.Interfaces;
using EmployeesList.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

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

        //get employee list
        public async Task<IActionResult> Index()
        {
            var result = await employeeService.GetEmployees();

            return View(result);
        }

        //get child list
        public async Task<IActionResult> IndexChild(int id)
        {
            var result = await employeeService.GetChildren(id);
            ViewData["id"] = id;
            ViewData["count"] = result.Count;

            return View(result);
        }

        // GET: Employees/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            var employee = await employeeService.GetEmployee(id);
            ViewData["Employee"] = employee;
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

        // GET: Child/Create
        public IActionResult CreateChild(int id)
        {
            return View(new Children { EmployeeId = id, Id = Guid.NewGuid() });
        }

        // POST: Employees/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Patronymic,Surname,DateОfBirth,Position,Childrens")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                await employeeService.CreateEmployee(employee);
                return RedirectToAction(nameof(Index));
            }
            return View(employee);
        }

        // POST: Child/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateChild([Bind(
            "Id,Name,Patronymic,Surname,DateОfBirth,EmployeeId")] Children children)
        {
            if (ModelState.IsValid)
            {
                await employeeService.CreateChildren(children);
                return RedirectToAction(nameof(IndexChild), new { id = children.EmployeeId });
            }

            return View(children);
        }

        // GET: Employees/Edit
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

        // GET: Children/Edit
        public async Task<IActionResult> EditChild(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var child = await employeeService.GetChild(id);
            if (child == null)
            {
                return NotFound();
            }
            return View(child);
        }

        // POST: Employees/Edit

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

        // POST: Child/Edit

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditChild(Guid id, [Bind("Id,Name,Patronymic,Surname,DateОfBirth,EmployeeId")] Children children)
        {
            if (id != children.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                await employeeService.UpdateChild(children);

                return RedirectToAction(nameof(IndexChild), new { id = children.EmployeeId });
            }
            return View(children);
        }

        // GET: Employees/Delete
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

        // GET: Child/Delete
        public async Task<IActionResult> DeleteChild(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var child = await employeeService.GetChild(id);
            if (child == null)
            {
                return NotFound();
            }

            return View(child);
        }

        // POST: Employees/Delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            if (Employee.Equals == null)
            {
                return Problem("Entity set 'ApplicationContext.Employee'  is null.");
            }
            await employeeService.RemoveEmployee(id);

            return RedirectToAction(nameof(Index));
        }

        // POST: Child/Delete
        [HttpPost, ActionName("DeleteChild")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid? id)
        {
            if (Children.Equals == null)
            {
                return Problem("Entity set 'ApplicationContext.Children'  is null.");
            }
            var child = await employeeService.GetChild(id);
            await employeeService.RemoveChild(id);

            return RedirectToAction(nameof(IndexChild), new { id = child.EmployeeId });
        }
    }
}