using DemoRepository.DAL;
using DemoRepository.GenericRepository;
using DemoRepository.Repository;
using DemoRepository.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DemoRepository.Controllers
{
    public class EmployeeController : Controller
    {
        private UnitOfWork<EmployeeDBContext> unitOfWork = new UnitOfWork<EmployeeDBContext>();
        private GenericRepository<Employee> genericRepository;
        private IEmployeeRepository employeeRepository;
        public EmployeeController()
        {
            employeeRepository = new EmployeeRepository(unitOfWork);
            genericRepository = new GenericRepository<Employee>(unitOfWork);
        }
        
        [HttpGet]
        public ActionResult Index()
        {
            var model = genericRepository.GetAll();
            return View(model);
        }
        [HttpGet]
        public ActionResult AddEmployee()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddEmployee(Employee model)
        {
            try
            {
                unitOfWork.CreateTransaction();
                if (ModelState.IsValid)
                {
                    genericRepository.Insert(model);
                    unitOfWork.Save();
                    unitOfWork.Commit();
                    return RedirectToAction("Index", "Employee");
                }
            }
            catch (Exception ex)
            {
                unitOfWork.Rollback();
            }
            return View();
        }
        [HttpGet]
        public ActionResult EditEmployee(int EmployeeId)
        {
            Employee model = genericRepository.GetById(EmployeeId);
            return View(model);
        }
        [HttpPost]
        public ActionResult EditEmployee(Employee model)
        {
            if (ModelState.IsValid)
            {
                genericRepository.Update(model);
                unitOfWork.Save();
                return RedirectToAction("Index", "Employee");
            }
            else
            {
                return View(model);
            }
        }
        [HttpGet]
        public ActionResult DeleteEmployee(int EmployeeId)
        {
            Employee model = genericRepository.GetById(EmployeeId);
            return View(model);
        }
        [HttpPost]
        public ActionResult Delete(int EmployeeID)
        {
            Employee model = genericRepository.GetById(EmployeeID);
            genericRepository.Delete(model);
            unitOfWork.Save();
            return RedirectToAction("Index", "Employee");
        }
    }
}