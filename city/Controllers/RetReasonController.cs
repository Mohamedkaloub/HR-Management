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
    public class RetReasonController : Controller
    {

        private IUniteOfWork _un;
        public RetReasonController(ApplicationDbContext db)
        {
            _un = new UniteOfWork(db);
        }
        // GET: EmployeeController

        public ActionResult Index()
        {
            var listofEmployee = _un.RetReasonRepository.FindAll();
            return View(listofEmployee);
        }

        // GET: EmployeeController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: EmployeeController/Create
        public ActionResult Create(int code)
        {
            RetReasonView retReasonView = new RetReasonView();
            retReasonView.RetReason = new RetReason();
            RetReason re = _un.RetReasonRepository.FindAll().Where(a => a.Emp_Code == code).FirstOrDefault();

            if (code != 0 || code !=null ) {
             String name= _un.EmployeeRepository.FindAll().Where(e => e.Emp_code == code).Select(e=>e.Name).FirstOrDefault();
                retReasonView.Name = name;
                if (re != null)
                {
                    retReasonView.RetReason = re;
                }
                retReasonView.RetReason.Emp_Code = code;
            }
            return View(retReasonView);
        }

        // POST: EmployeeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(RetReasonView retReasonView)
        {
            
            _un.RetReasonRepository.Add(retReasonView.RetReason);
            _un.Save();
             return View();
        }

        // GET: EmployeeController/Edit/5
        public ActionResult Edit(int id)
        {
            
            var obj = _un.RetReasonRepository.GetFristOrDefault(b => b.id == id);
            return View(obj);
        }
        // POST: EmployeeController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(RetReason RetReason)
        {
            if (RetReason != null) { 
            _un.RetReasonRepository.Update(RetReason);
                _un.Save();
            }
            return View();
        }

        // GET: EmployeeController/Delete/5
        public ActionResult Delete(int id)
        {
            var obj = _un.RetReasonRepository.GetFristOrDefault(b=>b.id==id);
            _un.RetReasonRepository.Delete(obj);
            _un.Save();
            return RedirectToAction(nameof(Index));
           
        }
    }
}
