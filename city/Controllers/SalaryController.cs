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
    public class SalaryController : Controller
    {

        private IUniteOfWork _un;
        public SalaryController(ApplicationDbContext db)
        {
            _un = new UniteOfWork(db);
        }
        // GET: EmployeeController

        public ActionResult Index(int id)
        {
            ViewBag.Id = id;    
            var listofEmployee = _un.SalaryRepository.FindAll().Where(e=>e.EmployeeId==id);
            return View(listofEmployee);
        }
        public ActionResult GetSalary(int id)
        {
            ViewBag.Id = id;
            var listofEmployee = _un.SalaryRepository.FindAll().Where(e => e.EmployeeId == id);
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
           Salary salary = new Salary();
            salary.EmployeeId = Id;
            return View(salary);
        }
      
        // POST: EmployeeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Salary salary)
        {
            salary.Id = 0;
            
            _un.SalaryRepository.Add(salary);
            _un.Save();
             return View(salary);
        }
        [HttpPost]
        public ActionResult AddJson(int id , double salary , double p)
        {
            Salary salary1 = new Salary() { 
            EmployeeId = id ,
            Total = salary ,
            punishment=p
            };

           _un.SalaryRepository.Add(salary1);
            _un.Save();
            return new JsonResult("تم الاضافة بنجاح");
            
        }

        public ActionResult refresh(int id)
        {
          
            return RedirectToAction("Index", "Salary", new { id = id });
        }
        // GET: EmployeeController/Edit/5
        public ActionResult Edit(int id)
        {
            
            var obj = _un.SalaryRepository.GetFristOrDefault(b => b.Id == id);
            return View(obj);
        }
        // POST: EmployeeController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Salary Salary)
        {
            if (Salary != null) { 
            _un.SalaryRepository.Update(Salary);
                _un.Save();
            }
            return View();
        }

        // GET: EmployeeController/Delete/5
        public ActionResult Delete(int Id)

        {
            
            var obj = _un.SalaryRepository.GetFristOrDefault(b=>b.Id==Id);
            _un.SalaryRepository.Delete(obj);
            _un.Save();
            int id = obj.EmployeeId;
            return RedirectToAction("Index", "Salary", new {id=id });
           
        }
    }
}
