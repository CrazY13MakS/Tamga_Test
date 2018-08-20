using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Tamga_Test_WebApp.Data;
using Tamga_Test_WebApp.Models;

namespace Tamga_Test_WebApp.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EmployeesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Employees
        public async Task<IActionResult> Index()
        {
            ViewBag.Applicants = new SelectList(_context.Applicants, "ApplicantId", "Name");
            // var applicationDbContext = _context.Employees.Include(e => e.Applicant).Include(e => e.Company);
            // return View(await applicationDbContext.ToListAsync());
            var applicants = await _context.Applicants.ToListAsync();
            return View(applicants);
        }

        public async Task<IActionResult> Employeed()
        {
            return View(await _context.Employees.Include(x => x.Applicant).Include(x => x.Position).ToListAsync());
        }


        [HttpPost]
        public async Task<IActionResult> Employ(int applicantId, int positionId)
        {
            if (!ApplicantExists(applicantId))
            {
                return NotFound("Applicant not found");
            }
            if (!PositionExists(positionId))
            {
                return NotFound("Position not found");
            }
            var applicant = await _context.Applicants.FirstOrDefaultAsync(x => x.ApplicantId == applicantId);
            var position = await _context.Positions.FirstOrDefaultAsync(x => x.PositionId == positionId);
            if (applicant.PretendedSalary > position.SalaryForkMax || applicant.PretendedSalary < position.SalaryForkMin)
            {
                return BadRequest("Applicant pretended salary not allowed");
            }
            if (_context.Employees.Any(x => x.PositionId == positionId && x.ApplicantId == applicantId))
            {
                return BadRequest("Applicant already emloyeed");
            }
            _context.Employees.Add(new Employee() { ApplicantId = applicantId, PositionId = positionId });
            await _context.SaveChangesAsync();
            return Json("Трудоустроен");
        }

        private bool PositionExists(int id)
        {
            return _context.Positions.Any(e => e.PositionId == id);
        }
        private bool ApplicantExists(int id)
        {
            return _context.Applicants.Any(e => e.ApplicantId == id);
        }



        //// GET: Employees/Details/5
        //public async Task<IActionResult> Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var employee = await _context.Employees
        //        .Include(e => e.Applicant)
        //        .Include(e => e.Company)
        //        .FirstOrDefaultAsync(m => m.ApplicantId == id);
        //    if (employee == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(employee);
        //}




        //// GET: Employees/Create
        //public IActionResult Create()
        //{
        //    ViewData["ApplicantId"] = new SelectList(_context.Applicants, "ApplicantId", "LastName");
        //    ViewData["CompanyId"] = new SelectList(_context.Companies, "CompanyId", "Address");
        //    return View();
        //}

        //// POST: Employees/Create
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("CompanyId,ApplicantId")] Employee employee)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _context.Add(employee);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    ViewData["ApplicantId"] = new SelectList(_context.Applicants, "ApplicantId", "LastName", employee.ApplicantId);
        //    ViewData["CompanyId"] = new SelectList(_context.Companies, "CompanyId", "Address", employee.CompanyId);
        //    return View(employee);
        //}

        //// GET: Employees/Edit/5
        //public async Task<IActionResult> Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var employee = await _context.Employees.FindAsync(id);
        //    if (employee == null)
        //    {
        //        return NotFound();
        //    }
        //    ViewData["ApplicantId"] = new SelectList(_context.Applicants, "ApplicantId", "LastName", employee.ApplicantId);
        //    ViewData["CompanyId"] = new SelectList(_context.Companies, "CompanyId", "Address", employee.CompanyId);
        //    return View(employee);
        //}

        //// POST: Employees/Edit/5
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id, [Bind("CompanyId,ApplicantId")] Employee employee)
        //{
        //    if (id != employee.ApplicantId)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(employee);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!EmployeeExists(employee.ApplicantId))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }
        //        return RedirectToAction(nameof(Index));
        //    }
        //    ViewData["ApplicantId"] = new SelectList(_context.Applicants, "ApplicantId", "LastName", employee.ApplicantId);
        //    ViewData["CompanyId"] = new SelectList(_context.Companies, "CompanyId", "Address", employee.CompanyId);
        //    return View(employee);
        //}

        //// GET: Employees/Delete/5
        //public async Task<IActionResult> Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var employee = await _context.Employees
        //        .Include(e => e.Applicant)
        //        .Include(e => e.Company)
        //        .FirstOrDefaultAsync(m => m.ApplicantId == id);
        //    if (employee == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(employee);
        //}

        //// POST: Employees/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    var employee = await _context.Employees.FindAsync(id);
        //    _context.Employees.Remove(employee);
        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        private bool EmployeeExists(int id)
        {
            return _context.Employees.Any(e => e.ApplicantId == id);
        }
    }
}
