using city.Data;
using city.Models;
using city.Repository;
using city.Repository.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace city.Controllers
{
    public class DepartmentController : Controller
    {

        private IUniteOfWork _un;
        public DepartmentController(ApplicationDbContext db)
        {
            _un = new UniteOfWork(db);
        }
        // GET: EmployeeController
       
        public ActionResult Index()
        {
            var listofEmployee = _un.DepartmentRepository.FindAll();
            return View(listofEmployee);
        }

        // GET: EmployeeController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: EmployeeController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EmployeeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Department dep)
        {
            
            _un.DepartmentRepository.Add(dep);
            _un.Save();
             return RedirectToAction(nameof(Index));
        }

        // GET: EmployeeController/Edit/5
        public ActionResult Edit(int id)
        {
            
            var obj = _un.DepartmentRepository.GetFristOrDefault(b => b.Id == id);
            return View(obj);
        }
        // POST: EmployeeController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Department dep)
        {
            if (dep != null) { 
            _un.DepartmentRepository.Update(dep);
                _un.Save();
            }
            return View();
        }

        // GET: EmployeeController/Delete/5
        public ActionResult Delete(int id)
        {
            var obj = _un.DepartmentRepository.GetFristOrDefault(b=>b.Id==id);
            _un.DepartmentRepository.Delete(obj);
            _un.Save();
            return RedirectToAction(nameof(Index));
           
        }
    }
}
