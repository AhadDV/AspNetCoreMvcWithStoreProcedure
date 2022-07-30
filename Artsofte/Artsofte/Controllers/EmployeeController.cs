using Artsofte.Dal;
using Artsofte.Dtos;
using Artsofte.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Artsofte.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly ArtsofteDbContext _context;

        public EmployeeController(ArtsofteDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _context.EmployeeDatasFromDb.FromSqlRaw("exec GetEmployees").ToListAsync());
        }

        public IActionResult Add()
        {
            ViewBag.Departments = _context.Departments.FromSqlRaw("exec GetDepartments");
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Add(EmployeePostDto postDto)
        {
            ViewBag.Departments = _context.Departments.FromSqlRaw("exec GetDepartments");
            if (!ModelState.IsValid)
                return View();
            var results=  _context.Database.ExecuteSqlRaw("AddEmployee {0}, {1}, {2}, {3}, {4}, {5}",postDto.Name,postDto.Surname,postDto.Age,postDto.Gender,postDto.DepartmentId,postDto.ProgrammingLanguageId);
          
            return RedirectToAction(nameof(Index));
        }


        public IActionResult Edit(int id)
        {
            ViewBag.Departments = _context.Departments.FromSqlRaw("exec GetDepartments");
            ViewBag.PrograminLanguage = _context.Departments.FromSqlRaw("exec GetDepartments");
            var result = _context.EmployeeDatasFromDb.FromSqlRaw($"exec GetEmployeById {id}").AsEnumerable().Last();
            EmployeeEditDto dto = Map(result);
            return View(dto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit( int id,EmployeeEditDto editDto)
        {
            ViewBag.Departments = _context.Departments.FromSqlRaw("exec GetDepartments");
            ViewBag.PrograminLanguage = _context.Departments.FromSqlRaw("exec GetDepartments");
            var result = _context.EmployeeDatasFromDb.FromSqlRaw($"exec GetEmployeById {id}").AsEnumerable().Last();
            EmployeeEditDto dto = Map(result);
            if (!ModelState.IsValid)
                return View(dto);
            var results = _context.Database.ExecuteSqlRaw("UpdateEmployeeById {0}, {1}, {2}, {3}, {4}, {5}, {6}", id, editDto.EmployeeName, editDto.EmployeeSurname, editDto.EmployeeAge, editDto.EmployeeGender, editDto.DepartmentId, editDto.ProgrammingLanguageId);
            return RedirectToAction(nameof(Index));
        }

       
        public IActionResult Delete(int id)
        {
            var employee = _context.EmployeeDatasFromDb.FromSqlRaw($"exec GetEmployeById {id}").AsEnumerable().Last();

            if (employee == null)
                return NotFound();

            var result=  _context.Database.ExecuteSqlRaw($"exec DeleteEmployee {id}");
            return RedirectToAction(nameof(Index));
        }
        public IActionResult GetProgammingLanguage(int id)
        {
            return Json(_context.ProgramingLanguages.FromSqlRaw($"exec ProgramLanguage {id}"));
        }


        public EmployeeEditDto Map(EmployeeDataFromDb data)
        {
             EmployeeEditDto employeeEditDto = new EmployeeEditDto
                {
                    EmployeeName = data.EmployeeName,
                    EmployeeSurname = data.EmployeeSurname,
                    EmployeeAge = data.EmployeeAge,
                    EmployeeGender = data.EmployeeGender,
                    DepartmentId = data.DepartmentId,
                    DepartmentName = data.DepartmentName,
                    ProgrammingLanguageId = data.ProgrammingLanguageId,
                    ProgrammingLanguageName = data.ProgrammingLanguageName
                };

            return employeeEditDto;
        }
    }
}
