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
    public class ManagementController : Controller
    {

        private IUniteOfWork _un;
        public ManagementController(ApplicationDbContext db)
        {
            _un = new UniteOfWork(db);
        }
        // GET: EmployeeController
       
        public ActionResult Index()
        {
            var listofEmployee = _un.ManagementRepository.FindAll();
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
        public ActionResult Create(Management Management)
        {
            
            _un.ManagementRepository.Add(Management);
            _un.Save();
             return RedirectToAction(nameof(Index));
        }

        // GET: EmployeeController/Edit/5
        public ActionResult Edit(int id)
        {
            
            var obj = _un.ManagementRepository.GetFristOrDefault(b => b.Id == id);
            return View(obj);
        }
        // POST: EmployeeController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Management Management)
        {
            if (Management != null) { 
            _un.ManagementRepository.Update(Management);
                _un.Save();
            }
            return View();
        }

        // GET: EmployeeController/Delete/5
        public ActionResult Delete(int id)
        {
            var obj = _un.ManagementRepository.GetFristOrDefault(b=>b.Id==id);
            _un.ManagementRepository.Delete(obj);
            _un.Save();
            return RedirectToAction(nameof(Index));
           
        }
    }
}
