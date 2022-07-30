using Artsofte.Dal;
using Artsofte.Dtos;
using Artsofte.Models;
using AutoMapper;
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
        private readonly IMapper _mapper;

        public EmployeeController(ArtsofteDbContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _context.EmployeeDatasFromDb.FromSqlRaw("exec GetEmployees").ToListAsync());
        }

        [HttpGet, Route("employee/add")]
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

            if (!ModelState.IsValid) return View();

            var results=  _context.Database.ExecuteSqlRaw("AddEmployee {0}, {1}, {2}, {3}, {4}, {5}",postDto.Name,postDto.Surname,postDto.Age,postDto.Gender,postDto.DepartmentId,postDto.ProgrammingLanguageId);
          
            return RedirectToAction(nameof(Index));
        }

        public IActionResult RedirectToProfile(int? id)
        {
            if (id == null || id == 0) return NotFound();

            TempData["Id"] = id;
            return RedirectToAction(nameof(Edit));
        }

        [HttpGet, Route("employee/edit")]
        public  IActionResult Edit()
        {
            int id= (int)TempData["Id"];

            TempData["Id"] = id;

            ViewBag.Departments = _context.Departments.FromSqlRaw("exec GetDepartments");

            ViewBag.PrograminLanguage = _context.Departments.FromSqlRaw("exec GetDepartments");

            EmployeeDataFromDb employee = GetEmployeeById(id);

            if (employee==null) return NotFound();

            EmployeeEditDto dto = _mapper.Map<EmployeeEditDto>(employee);
            return View(dto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit( EmployeeEditDto editDto)
        {
            int id = (int)TempData["Id"];

            var results = _context.Database.ExecuteSqlRaw("UpdateEmployeeById {0}, {1}, {2}, {3}, {4}, {5}, {6}", id, editDto.EmployeeName, editDto.EmployeeSurname, editDto.EmployeeAge, editDto.EmployeeGender, editDto.DepartmentId, editDto.ProgrammingLanguageId);
            return RedirectToAction(nameof(Index));
        }

       
        public IActionResult Delete(int? id)
        {
            if (id==null&&id == 0) return NotFound();

          EmployeeDataFromDb employee=  GetEmployeeById(id);

            if(employee==null) return NotFound();

               var result=  _context.Database.ExecuteSqlRaw($"exec DeleteEmployee {id}");
            return RedirectToAction(nameof(Index));
        }
        public IActionResult GetProgammingLanguage(int id)
        {
            return Json(_context.ProgramingLanguages.FromSqlRaw($"exec ProgramLanguage {id}"));
        }


       public EmployeeDataFromDb GetEmployeeById(int? id)
        {
    
            var result = _context.EmployeeDatasFromDb.FromSqlRaw("exec GetEmployees").ToList();
            EmployeeDataFromDb employee = result.FirstOrDefault(x => x.EmployeeId == id);
            return employee;
        }
    }
}
