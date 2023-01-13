using city.Data;
using city.Models;
using city.Models.ViewModel;
using city.Repository;
using city.Repository.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace city.Controllers
{
    public class AdvanceController : Controller
    {

        private IUniteOfWork _un;
        public AdvanceController(ApplicationDbContext db)
        {
            _un = new UniteOfWork(db);
        }
        // GET: EmployeeController

        public ActionResult Index()
        {

            //var listofEmployee = _un.AdvanceRepository.FindAll(IncludeProperties: "Employee");
            return View();
        }
        public ActionResult GetAdvance()
        {
            var listofEmployee = _un.AdvanceRepository.FindAll(IncludeProperties: "Employee");
            return new JsonResult(listofEmployee);
        }

        // GET: EmployeeController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: EmployeeController/Create
        public ActionResult Create(int Id)
        {
           Advance Advance = new Advance();
            Advance.EmployeeId = Id;
            return View(Advance);
        }
      
        // POST: EmployeeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Advance Advance)
        {
            Advance.Id = 0;
            
            _un.AdvanceRepository.Add(Advance);
            _un.Save();
             return View(Advance);
        }
        [HttpPost]
        public ActionResult AddJson(int emp, double need, double accept)
        {
            int id = _un.EmployeeRepository.GetFristOrDefault(e => e.Emp_code == emp).Id;
            Advance Advance1 = new Advance() { 
            EmployeeId = id ,
            Need = need ,
            Accept = accept
            };

           _un.AdvanceRepository.Add(Advance1);
            _un.Save();
            return new JsonResult("تم الاضافة بنجاح");
            
        }

        public ActionResult refresh(int id)
        {
          
            return RedirectToAction("Index", "Advance", new { id = id });
        }
        // GET: EmployeeController/Edit/5
        public ActionResult Edit(int id)
        {
            
            var obj = _un.AdvanceRepository.GetFristOrDefault(b => b.Id == id);
            return View(obj);
        }
        // POST: EmployeeController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Advance Advance)
        {
            if (Advance != null) { 
            _un.AdvanceRepository.Update(Advance);
                _un.Save();
            }
            return View();
        }

        // GET: EmployeeController/Delete/5
        public ActionResult Delete(int Id)

        {
            
            var obj = _un.AdvanceRepository.GetFristOrDefault(b=>b.Id==Id);
            _un.AdvanceRepository.Delete(obj);
            _un.Save();
            int id = obj.EmployeeId;
            return RedirectToAction("Index", "Advance", new {id=id });
           
        }

        public ActionResult FindName(int code) {
            string ? name =_un.EmployeeRepository.GetFristOrDefault(e=>e.Emp_code==code).Name;
            return new JsonResult(name);
        }
    }
}
