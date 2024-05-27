using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Keeps.Data;
using Keeps.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Keeps.Controllers
{

    public class EmployeeController : Controller
    {
        private readonly KeepsDB _context;
        public EmployeeController(KeepsDB context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            try
            {
                //var employee = _context.ToList();
                var empList = from a in _context.tbl_employees
                              join b in _context.tbl_departments
                              on a.DeptId equals b.Id
                              into Dep
                              from b in Dep.DefaultIfEmpty()

                              select new Employee
                              {
                                  ID = a.ID,
                                  EmpCode = a.EmpCode,
                                  Name = a.Name,
                                  Email = a.Email,
                                  DeptId = a.DeptId,
                                  DeptName = b == null ? "" : b.DeptName
                              };
                return View(empList);
            }
            catch (Exception e)
            {
                return View(e);
            }

        }
        [HttpGet]
        public IActionResult AddEmp(Employee obj)
        {
            LoadDDL();
            return View(obj);
        }
        [HttpPost]
        public async Task<IActionResult> AddEmployee(Employee obj)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (obj.ID == 0)
                    {
                        _context.Add(obj);
                        await _context.SaveChangesAsync();
                    }
                    else
                    {
                        _context.Entry(obj).State = EntityState.Modified;
                        _context.SaveChanges();
                    }
                  
                }
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index");
            }
        }
        public IActionResult Deleteemp(int id)
        {
            try
            {
                var emp = _context.tbl_employees.Find(id);
                if(emp != null)
                {
                    _context.tbl_employees.Remove(emp);
                     _context.SaveChanges();
                }
                return RedirectToAction("Index");

            }
            catch (Exception e)
            {
                return RedirectToAction("Index");
            }
        }
        private void LoadDDL()
        {
            try
            {
                List<Department> deptList = new List<Department>();
                deptList = _context.tbl_departments.ToList();
                deptList.Insert(0, new Department { Id = 0, DeptName = "Please Select" });

                ViewBag.DeptList = deptList;


            }
            catch (Exception ex)
            {

            }
        }
    }
}