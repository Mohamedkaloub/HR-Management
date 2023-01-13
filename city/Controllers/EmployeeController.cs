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
    public class EmployeeController : Controller
    {

        private IUniteOfWork _un;
        public EmployeeController(ApplicationDbContext db)
        {
            _un = new UniteOfWork(db);
        }
        // GET: EmployeeController

        public ActionResult Index()
        {
          
         //  var listofEmployee = _un.EmployeeRepository.FindAll();
            return View();
        }
        public ActionResult GetAll()
        {
            var data = _un.EmployeeRepository.FindAll(IncludeProperties: "job,Management,department").ToList();
            return new JsonResult(data);

        }


        // GET: EmployeeController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: EmployeeController/Create
        public ActionResult Create()
        {
            IEnumerable<SelectListItem> JobList = _un.JobRepository.FindAll().Select(i => new SelectListItem
            {
                Text = i.Name,
                Value = i.Id.ToString()
            });
            IEnumerable<SelectListItem> DerpartmentList = _un.DepartmentRepository.FindAll().Select(i => new SelectListItem
            {
                Text = i.Name,
                Value = i.Id.ToString()
            });
            IEnumerable<SelectListItem> ManagementList = _un.ManagementRepository.FindAll().Select(i => new SelectListItem
            {
                Text = i.Name,
                Value = i.Id.ToString()
            });
            IEnumerable<SelectListItem> SectionList = _un.SectionRepository.FindAll().Select(i => new SelectListItem
            {
                Text = i.Name,
                Value = i.Id.ToString()
            });
            ViewBag.JobList = JobList;
            ViewBag.DerpartmentList = DerpartmentList;
            ViewBag.ManagementList = ManagementList;
            ViewBag.SectionList = SectionList;

            return View();
        }

        // POST: EmployeeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Employee emp)
        {
            IEnumerable<SelectListItem> JobList = _un.JobRepository.FindAll().Select(i => new SelectListItem
            {
                Text = i.Name,
                Value = i.Id.ToString()
            });
            IEnumerable<SelectListItem> DerpartmentList = _un.DepartmentRepository.FindAll().Select(i => new SelectListItem
            {
                Text = i.Name,
                Value = i.Id.ToString()
            });
            IEnumerable<SelectListItem> ManagementList = _un.ManagementRepository.FindAll().Select(i => new SelectListItem
            {
                Text = i.Name,
                Value = i.Id.ToString()
            });
            IEnumerable<SelectListItem> SectionList = _un.SectionRepository.FindAll().Select(i => new SelectListItem
            {
                Text = i.Name,
                Value = i.Id.ToString()
            });
            ViewBag.JobList = JobList;
            ViewBag.DerpartmentList = DerpartmentList;
            ViewBag.ManagementList = ManagementList;
            ViewBag.SectionList = SectionList;
            if (!ModelState.IsValid) {
                
                return View(emp);
            }

            _un.EmployeeRepository.Add(emp);
            _un.Save();
            return RedirectToAction(nameof(Index));
        }

        // GET: EmployeeController/Edit/5
        public ActionResult Edit(int id)
        {
            IEnumerable<SelectListItem> JobList = _un.JobRepository.FindAll().Select(i => new SelectListItem
            {
                Text = i.Name,
                Value = i.Id.ToString()
            });
            IEnumerable<SelectListItem> DerpartmentList = _un.DepartmentRepository.FindAll().Select(i => new SelectListItem
            {
                Text = i.Name,
                Value = i.Id.ToString()
            });
            IEnumerable<SelectListItem> ManagementList = _un.ManagementRepository.FindAll().Select(i => new SelectListItem
            {
                Text = i.Name,
                Value = i.Id.ToString()
            });
            IEnumerable<SelectListItem> SectionList = _un.SectionRepository.FindAll().Select(i => new SelectListItem
            {
                Text = i.Name,
                Value = i.Id.ToString()
            });
            ViewBag.JobList = JobList;
            ViewBag.DerpartmentList = DerpartmentList;
            ViewBag.ManagementList = ManagementList;
            ViewBag.SectionList = SectionList;
            var obj = _un.EmployeeRepository.GetFristOrDefault(b => b.Id == id);
            return View(obj);
        }
        // POST: EmployeeController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Employee emp)
        {
            IEnumerable<SelectListItem> JobList = _un.JobRepository.FindAll().Select(i => new SelectListItem
            {
                Text = i.Name,
                Value = i.Id.ToString()
            });
            IEnumerable<SelectListItem> DerpartmentList = _un.DepartmentRepository.FindAll().Select(i => new SelectListItem
            {
                Text = i.Name,
                Value = i.Id.ToString()
            });
            IEnumerable<SelectListItem> ManagementList = _un.ManagementRepository.FindAll().Select(i => new SelectListItem
            {
                Text = i.Name,
                Value = i.Id.ToString()
            });
            IEnumerable<SelectListItem> SectionList = _un.SectionRepository.FindAll().Select(i => new SelectListItem
            {
                Text = i.Name,
                Value = i.Id.ToString()
            });
            ViewBag.JobList = JobList;
            ViewBag.DerpartmentList = DerpartmentList;
            ViewBag.ManagementList = ManagementList;
            ViewBag.SectionList = SectionList;
            if (emp != null) {
                _un.EmployeeRepository.Update(emp);
                _un.Save();
            }
            return View(emp);
        }
        public ActionResult ViewOne(int id)
        {
            IEnumerable<SelectListItem> JobList = _un.JobRepository.FindAll().Select(i => new SelectListItem
            {
                Text = i.Name,
                Value = i.Id.ToString()
            });
            IEnumerable<SelectListItem> DerpartmentList = _un.DepartmentRepository.FindAll().Select(i => new SelectListItem
            {
                Text = i.Name,
                Value = i.Id.ToString()
            });
            IEnumerable<SelectListItem> ManagementList = _un.ManagementRepository.FindAll().Select(i => new SelectListItem
            {
                Text = i.Name,
                Value = i.Id.ToString()
            });
            IEnumerable<SelectListItem> SectionList = _un.SectionRepository.FindAll().Select(i => new SelectListItem
            {
                Text = i.Name,
                Value = i.Id.ToString()
            });
            ViewBag.JobList = JobList;
            ViewBag.DerpartmentList = DerpartmentList;
            ViewBag.ManagementList = ManagementList;
            ViewBag.SectionList = SectionList;
            var obj = _un.EmployeeRepository.GetFristOrDefault(b => b.Id == id);
            return View(obj);
        }
        // POST: EmployeeController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ViewOne(Employee emp)
        {
            IEnumerable<SelectListItem> JobList = _un.JobRepository.FindAll().Select(i => new SelectListItem
            {
                Text = i.Name,
                Value = i.Id.ToString()
            });
            IEnumerable<SelectListItem> DerpartmentList = _un.DepartmentRepository.FindAll().Select(i => new SelectListItem
            {
                Text = i.Name,
                Value = i.Id.ToString()
            });
            IEnumerable<SelectListItem> ManagementList = _un.ManagementRepository.FindAll().Select(i => new SelectListItem
            {
                Text = i.Name,
                Value = i.Id.ToString()
            });
            IEnumerable<SelectListItem> SectionList = _un.SectionRepository.FindAll().Select(i => new SelectListItem
            {
                Text = i.Name,
                Value = i.Id.ToString()
            });
            ViewBag.JobList = JobList;
            ViewBag.DerpartmentList = DerpartmentList;
            ViewBag.ManagementList = ManagementList;
            ViewBag.SectionList = SectionList;
            if (emp != null)
            {
                _un.EmployeeRepository.Update(emp);
                _un.Save();
            }
            return View(emp);
        }
        // GET: EmployeeController/Delete/5
        public ActionResult Delete(int id)
        {
            var obj = _un.EmployeeRepository.GetFristOrDefault(b => b.Id == id);
            _un.EmployeeRepository.Delete(obj);
            _un.Save();
            return RedirectToAction(nameof(Index));

        }

      

    }

}
