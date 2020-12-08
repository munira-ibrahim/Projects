using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MuniraJiva_webMobi.Models;
using PagedList;


namespace MuniraJiva_webMobi.Controllers
{
    public class EmployeeController : Controller
    {
        private EmployeeDetailEntities db = new EmployeeDetailEntities();

        // GET: Employee
        public ActionResult Index() {
            var employees = db.Employees.Include(e => e.Department);
            return View(employees.ToList());
            
        }
        
        // GET: Employee/Create
        public ActionResult Create()
        {
            ViewBag.DepartmentId = new SelectList(db.Departments,"DeptId","Department1");
            
            return View();
        }

        // POST: Employee/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EmpId,FirstName,LastName,Gender,DOB,DeptId")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                db.Employees.Add(employee);
                db.SaveChanges();
                
            }
            return RedirectToAction("Index","Home");
            
        }

        // GET: Employee/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            ViewBag.DepartmentId = new SelectList(db.Departments, "DeptId", "Department1", employee.DeptId);
            return View(employee);

            
        }

        // POST: Employee/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EmpId,FirstName,LastName,Gender,DOB,DeptId")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                db.Entry(employee).State = EntityState.Modified;
                db.SaveChanges();
                
            }
            return RedirectToAction("Index", "Home");
            
        }

        // GET: Employee/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // POST: Employee/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Employee employee = db.Employees.Find(id);
            db.Employees.Remove(employee);
            db.SaveChanges();
            return RedirectToAction("Index", "Home");
        }
    }
}
