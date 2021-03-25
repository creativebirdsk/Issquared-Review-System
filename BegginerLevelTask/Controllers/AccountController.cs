using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BegginerLevelTask.Context;
//using System.Web.Security;

namespace BegginerLevelTask.Controllers
{

    public class AccountController : Controller
    {
        // GET: Account
        //public ActionResult Login()
        //{
        //    return View();
        //}

        //[HttpPost]
        //public ActionResult Login(tbl_Organisation data)
        //{
        //    BegginerLevelTaskEntities dbobj = new BegginerLevelTaskEntities();

        //    if (dbobj.tbl_Organisation.SingleOrDefault(m => m.UserName == data.UserName && m.Password == data.Password) != null)
        //    {
        //        var Login = dbobj.tbl_Organisation.Where(m => m.UserName == data.UserName && m.Password == data.Password).Select(x => x.UserID).FirstOrDefault();
        //        Session["UserID"] = Login;
        //        //ViewBag.UserName = data.UserName;
        //        return RedirectToAction("EmployeeList", "Employee");
        //    }
        //    else if (dbobj.Employees.SingleOrDefault(x => x.UserNameEmp == data.UserName && x.PasswordEmp == data.Password) != null)
        //    {
        //        var user = dbobj.Employees.Where(x => x.UserNameEmp == data.UserName && x.PasswordEmp == data.Password).Select(x => x.EmployeeID).FirstOrDefault();
        //        Session["EmployeeID"] = user;
        //        return RedirectToAction("ReviewSubmissionList", "ReviewSubmission", new { user });
        //    }
        //    else if (data.UserName == "bala" && data.Password == "Welcome@123")
        //    {
        //        return RedirectToAction("OrganisationList", "Organisation");
        //    }
        //    else
        //    {
        //        return RedirectToAction("Login", "Account");
        //    }

        //}

        public ActionResult MagicLogin()
        {
            return View();
        }


        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult MagicLogin(tbl_Organisation data)
        {
            BegginerLevelTaskEntities dbobj = new BegginerLevelTaskEntities();
            try
            {
                if (dbobj.tbl_Organisation.SingleOrDefault(m => m.UserName == data.UserName && m.Password == data.Password) != null)
                {
                    var Login = dbobj.tbl_Organisation.Where(m => m.UserName == data.UserName && m.Password == data.Password).Select(x => x.UserID).FirstOrDefault();
                    Session["UserID"] = Login;
                    //ViewBag.UserName = data.UserName;
                    return RedirectToAction("EmployeeList", "Employee");
                }
                else if (dbobj.Employees.SingleOrDefault(x => x.UserNameEmp == data.UserName && x.PasswordEmp == data.Password) != null)
                {
                    var user = dbobj.Employees.Where(x => x.UserNameEmp == data.UserName && x.PasswordEmp == data.Password).Select(x => x.EmployeeID).FirstOrDefault();
                    Session["EmployeeID"] = user;
                    return RedirectToAction("ReviewSubmissionList", "ReviewSubmission", new { user });
                }
                else if (dbobj.SuperUsers.SingleOrDefault(x => x.SuperUserName == data.UserName && x.SuperPassword == data.Password) != null)
                {
                    var SuperUser = dbobj.SuperUsers.Where(x => x.SuperUserName == data.UserName && x.SuperPassword == data.Password).Select(x => x.SuperID).FirstOrDefault();
                    Session["SuperID"] = SuperUser;
                    return RedirectToAction("OrganisationList", "Organisation");
                }
                else
                {
                    return RedirectToAction("MagicLogin", "Account");
                }
            }
            catch
            {
                ModelState.AddModelError(" ", "Invalid Operation");
                return View();
            }
        }
        //var Login = dbobj.tbl_Organisation.Where(m => m.UserName == data.UserName && m.Password == data.Password).Select(x => x.UserID).FirstOrDefault();
        //Session["UserID"] = Login;
        //if (Login != 0)
        //{
        //    ViewBag.UserName = data.UserName;
        //    return RedirectToAction("EmployeeList", "Employee");
        //}
        //else
        //{
        //    return RedirectToAction("Login", "Account");
        //}



        //using(var context = new BegginerLevelTaskEntities())
        //{
        //    bool isvalid = context.tbl_Organisation.Any(x => x.UserName == data.UserName && x.Password == data.Password);
        //    if(isvalid)
        //    {
        //        FormsAuthentication.SetAuthCookie(data.UserName, false);
        //        return View("~/Views/Employee/EmployeeList.cshtml");
        //    }

        //    ModelState.AddModelError("", "Invalid username or password !");
        //    return View();
        //}

        //public ActionResult EmployeeLogin()
        //{
        //    return View();
        //}

        //[HttpPost]
        //public ActionResult EmployeeLogin(Employee data)
        //{
        //    var user = dbobj.Employees.Where(x => x.UserNameEmp == data.UserNameEmp && x.PasswordEmp == data.PasswordEmp).Select(x => x.EmployeeID).FirstOrDefault();
        //    Session["EmployeeID"] = user;
        //    if (user != 0)
        //    {
        //        return RedirectToAction("ReviewSubmissionList", "ReviewSubmission", new { user });
        //    }
        //    else
        //    {
        //        return View();
        //    }

        //}
        public ActionResult Logout()
        {
            return RedirectToAction("Login", "Account");
        }
    }
}
   