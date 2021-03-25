using BegginerLevelTask.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BegginerLevelTask.Controllers
{
    public class ReviewAssignmentController : Controller
    {
        BegginerLevelTaskEntities dbobj = new BegginerLevelTaskEntities();
        // GET: ReviewAssignment
        [HttpGet]
        public ActionResult ReviewAssignment(int id)
        {
            try
            {
                Session["ReviewID"] = id;
                var user = Session["UserID"];
                var UserId = (int)user;

                var OrgID = dbobj.tbl_Organisation.Single(x => x.UserID == UserId);
                ViewBag.Welcome = "Welcome, ";
                ViewBag.DisplayName = OrgID.Name;

                var review = Session["ReviewID"];
                var ReviewId = (int)review;

                var agenda = dbobj.ReviewCreations.Single(x => x.ReviewID == ReviewId);
                ViewBag.Agenda = agenda.ReviewAgenda;

                ViewBag.ID = Session["UserID"];
                ViewBag.ReviewID = Session["ReviewID"];
                ViewBag.OrganizationList = dbobj.tbl_Organisation;
                ViewBag.Reviews = dbobj.ReviewCreations.Where(x => x.ReviewID == ReviewId).Select(x => x.ReviewID);
                ViewBag.EmployeeList = dbobj.Employees.Where(x => x.UserID == UserId);
                ViewBag.ReviewList = dbobj.Employees.Where(x => x.UserID == UserId);
                ReviewAssignment emp = dbobj.ReviewAssignments.Find(id);
                return View("ReviewAssignment", emp);
            }
            catch
            {
                ModelState.AddModelError(" ", "Invalid Operation");
                return View();
            }
            
        }

        [HttpPost]
        public ActionResult ReviewAssignment(ReviewAssignment model)
        {
            try
            {
                ViewBag.ID = Session["UserID"];
                model.UserID = ViewBag.ID;
                ViewBag.ReviewID = Session["ReviewID"];
                model.ReviewID = ViewBag.ReviewID;
                if (ModelState.IsValid || model.ReviewAssignmentID == 0)
                {
                    model.CreatedBy = (int)Session["UserID"];
                    model.CreatedOn = DateTime.Now;
                    model.AssignmentStatus = true;

                    dbobj.ReviewAssignments.Add(model);
                    dbobj.SaveChanges();
                    return RedirectToAction("ReviewAssignment");
                }
                else
                {
                    ModelState.AddModelError(" ", "Invalid Data");
                    return View();
                }
            }
            catch
            {
                ModelState.AddModelError(" ", "Invalid Operation");
                return View();
            }
            
        }

        public ActionResult ReviewAssignmentList()
        {
            try
            {
                var user = Session["UserID"];
                var UserId = (int)user;

                var OrgID = dbobj.tbl_Organisation.Single(x => x.UserID == UserId);
                ViewBag.Welcome = "Welcome, ";
                ViewBag.DisplayName = OrgID.Name;

                var result = dbobj.ReviewAssignments.ToList();
                return View(result);
            }
            catch
            {
                ModelState.AddModelError(" ", "Invalid Operation");
                return View();
            }
            
        }
    }
}