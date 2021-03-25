using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BegginerLevelTask.Context;

namespace BegginerLevelTask.Controllers
{
    public class EmployeeController : Controller
    {
        BegginerLevelTaskEntities dbobj = new BegginerLevelTaskEntities();
        // GET: Employee
        public ActionResult Employee(Employee obj)
        {
            try
            {
                var user = (int)Session["UserID"];
                var OrgID = dbobj.tbl_Organisation.Single(x => x.UserID == user);
                ViewBag.Welcome = "Welcome, ";
                ViewBag.DisplayName = OrgID.Name;

                return View(obj);
            }
            catch
            {
                ModelState.AddModelError(" ", "Invalid Operation");
                return View();
            }
        }

        [HttpGet]
        public ActionResult EditEmployee(Employee edit)
        {
            try
            {
                var user = (int)Session["UserID"];
                var OrgID = dbobj.tbl_Organisation.Single(x => x.UserID == user);
                ViewBag.Welcome = "Welcome, ";
                ViewBag.DisplayName = OrgID.Name;

                edit.UserID = (int)user;

                return View(edit);
            }
            catch
            {
                ModelState.AddModelError(" ", "Invalid Operation");
                return View();
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddEmployee(Employee model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    model.UserID = (int)Session["UserID"];
                    model.CreatedBy = (int)Session["UserID"];
                    model.CreatedOn = DateTime.Now;
                    if (model.EmployeeID == 0)
                    {
                        dbobj.Employees.Add(model);
                        dbobj.SaveChanges();
                        ModelState.Clear();
                    }
                    else
                    {
                        dbobj.Entry(model).State = EntityState.Modified;
                        dbobj.SaveChanges();
                    }
                }
                //ViewBag.SuccessMessage = "Registration Successful.";
                return View("Employee");
            }
            catch
            {
                ModelState.AddModelError(" ", "Invalid Operation");
                return View();
            }
        }



        public JsonResult CheckUsernameAvailability(string UserNameEmp)
        {
            return Json(!dbobj.Employees.Any(x => x.UserNameEmp == UserNameEmp), JsonRequestBehavior.AllowGet);
        }


        public ActionResult EmployeeList()
        {
            try
            {
                var user = (int)Session["UserID"];
                var OrgID = dbobj.tbl_Organisation.Single(x => x.UserID == user);
                ViewBag.Welcome = "Welcome, ";
                ViewBag.DisplayName = OrgID.Name;

                var OrganisationID = (int)Session["UserID"];

                IEnumerable<Employee> res = dbobj.Employees.Where(x => x.UserID == OrganisationID);
                return View(res);
            }
            catch
            {
                ModelState.AddModelError(" ", "Invalid Operation");
                return View();
            }
        }


        public ActionResult Delete(int id)
        {
            try
            {
                var check = dbobj.Employees.Single(x => x.EmployeeID == id);
                if (check.Status == "Active")
                {
                    check.Status = "In-active";                //If active then make In-active

                }
                //else
                //{
                //    var res = dbobj.Employees.Where(x => x.EmployeeID == id).First();
                //    dbobj.Employees.Remove(res);
                //}
                dbobj.SaveChanges();

                var OrganisationID = (int)Session["UserID"];
                IEnumerable<Employee> list = dbobj.Employees.Where(x => x.UserID == OrganisationID && x.Status == "Active");

                return View("EmployeeList", list);
            }
            catch
            {
                ModelState.AddModelError(" ", "Invalid Operation");
                return View();
            }

        }
    }
}