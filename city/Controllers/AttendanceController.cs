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
    public class AttendanceController : Controller
    {

        private IUniteOfWork _un;
        public AttendanceController(ApplicationDbContext db)
        {
            _un = new UniteOfWork(db);
        }
        // GET: EmployeeController

        public ActionResult Index(int id)
        {
            ViewBag.Id = id;    
            var listofEmployee = _un.AttendanceRepository.FindAll().Where(e=>e.EmployeeId==id);
            return View(listofEmployee);
        }
        public ActionResult GetAttendance(int id)
        {
            ViewBag.Id = id;
            var listofEmployee = _un.AttendanceRepository.FindAll().Where(e => e.EmployeeId == id);
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
           Attendance Attendance = new Attendance();
            Attendance.EmployeeId = Id;
            return View(Attendance);
        }
      
        // POST: EmployeeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Attendance Attendance)
        {
            Attendance.Id = 0;
            
            _un.AttendanceRepository.Add(Attendance);
            _un.Save();
             return View(Attendance);
        }
        [HttpPost]
        public ActionResult AddJson(int emp, string date, double days, string type)
        {
            Attendance Attendance1 = new Attendance() { 
            EmployeeId = emp ,
          Start_day=date,
          Days = days,
          Type = type
            };

           _un.AttendanceRepository.Add(Attendance1);
            _un.Save();
            return new JsonResult("تم الاضافة بنجاح");
            
        }

        public ActionResult refresh(int id)
        {
          
            return RedirectToAction("Index", "Attendance", new { id = id });
        }
        // GET: EmployeeController/Edit/5
        public ActionResult Edit(int id)
        {
            
            var obj = _un.AttendanceRepository.GetFristOrDefault(b => b.Id == id);
            return View(obj);
        }
        // POST: EmployeeController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Attendance Attendance)
        {
            if (Attendance != null) { 
            _un.AttendanceRepository.Update(Attendance);
                _un.Save();
            }
            return View();
        }

        // GET: EmployeeController/Delete/5
        public ActionResult Delete(int Id)

        {
            
            var obj = _un.AttendanceRepository.GetFristOrDefault(b=>b.Id==Id);
            _un.AttendanceRepository.Delete(obj);
            _un.Save();
            int id = obj.EmployeeId;
            return RedirectToAction("Index", "Attendance", new {id=id });
           
        }
    }
}
