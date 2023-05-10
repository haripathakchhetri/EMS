using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EMS.Models;

namespace EMS.Controllers
{
    public class employeeDashboardController : Controller
    {
        private readonly EmployeedbContext _context;

        public employeeDashboardController(EmployeedbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

       public async Task<IActionResult> departmentDetails()
        {
            return _context.DepartmentTables != null ?
                View(await _context.DepartmentTables.ToListAsync()):
                Problem("Entity set 'EmployeeDbContext.DepartmentTables' is null.");
        }

        public async Task<IActionResult> designationDetails()
        {
            return _context.DesignationTables != null ?
                View(await _context.DesignationTables.ToListAsync()):
                Problem("Entity set 'EmployeeDbContext.DesignationTables' is null.");
        }

        public async Task<IActionResult> leaveDetails()
        {
            return _context.LeaveTables != null ?
                View(await _context.LeaveTables.ToListAsync()) :
                Problem("Entity set 'EmployeeDbContext.LeaveTables' is null.");
        }

        public async Task<IActionResult> vacancyDetails()
        {
            return _context.VacancyTables != null ?
                View(await _context.VacancyTables.ToListAsync()) :
                Problem("Entity set 'EmployeeDbContext.VacancyTables' is null.");
        }


    }
}
