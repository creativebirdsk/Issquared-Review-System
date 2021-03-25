using BegginerLevelTask.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BegginerLevelTask.Controllers
{
    public class ReviewSubmissionController : Controller
    {
        BegginerLevelTaskEntities dbobj = new BegginerLevelTaskEntities();
        // GET: ReviewSubmission
      

        [HttpGet]
        public ActionResult ReviewSubmissionList()
        {
            try
            {
                var EmpID = (long)Session["EmployeeID"];

                var check = dbobj.Employees.Single(x => x.EmployeeID == EmpID);
                ViewBag.Welcome = "Welcome, ";
                ViewBag.DisplayName = check.FirstName + " " + check.LastName;

                var AssignedReviews = dbobj.ReviewAssignments.Where(x => x.Reviewer == EmpID && x.AssignmentStatus == true).ToList();
                return View(AssignedReviews);
            }
            catch 
            {
                ModelState.AddModelError(" ", "Invalid Operation");
                return View();
            }            
        }

        [HttpGet]
        public ActionResult ReviewSubmission(int id)
        {
            try
            {
                var EmpID = (long)Session["EmployeeID"];
                var check = dbobj.Employees.Single(x => x.EmployeeID == EmpID);
                ViewBag.Welcome = "Welcome, ";
                ViewBag.DisplayName = check.FirstName + " " + check.LastName;

                Session["id1"] = id;
                int num = (int)Session["id1"];
                TempData["AssignmentID"] = num;
                Session["ReviewID"] = dbobj.ReviewAssignments.Where(x => x.ReviewAssignmentID == num).Select(x => x.ReviewID).FirstOrDefault();

                var RevID = (long)Session["ReviewID"];
                var agenda = dbobj.ReviewCreations.Single(x => x.ReviewID == RevID);
                ViewBag.Agenda = agenda.ReviewAgenda;
                return View();
            }
            catch
            {
                ModelState.AddModelError(" ", "Invalid Operation");
                return View();
            }
        }

        [HttpPost]
        public ActionResult ReviewSubmission(ReviewSubmission reviewSubmission)
        {
            try
            {
                reviewSubmission.EmployeeID = (long)Session["EmployeeID"];
                reviewSubmission.ReviewID = (long)Session["ReviewID"];
                reviewSubmission.CreatedBy = (long)Session["EmployeeID"];
                reviewSubmission.CreatedOn = DateTime.Now;

                var AssignmentID = (int)TempData["AssignmentID"];

                var EmployeeToBeReviewedID = dbobj.ReviewAssignments.Where(x => x.ReviewAssignmentID == AssignmentID).Select(x => x.EmployeeID).FirstOrDefault();

                var check = dbobj.ReviewAssignments.Single(x => x.ReviewAssignmentID == AssignmentID);
                if (ModelState.IsValid)
                {
                    dbobj.ReviewSubmissions.Add(reviewSubmission);
                    reviewSubmission.EmployeeToBeReviewed = (long)EmployeeToBeReviewedID;  /*here "reviewer" is Employee to be reviewed*/
                    reviewSubmission.SubmissionStatus = false;
                    check.AssignmentStatus = false;
                    dbobj.SaveChanges();
                    return RedirectToAction("ReviewSubmissionList", new { user = reviewSubmission.EmployeeID });
                }
                return View();
            }
            catch
            {
                ModelState.AddModelError(" ", "Invalid Operation");
                return View();
            }
        }

        public ActionResult SubmittedList()
        {
            try
            {
                var user = (long)Session["EmployeeID"];
                var EmpID = dbobj.Employees.Single(x => x.EmployeeID == user);
                ViewBag.Welcome = "Welcome, ";
                ViewBag.DisplayName = EmpID.FirstName + " " + EmpID.LastName;

                var AssignedReviews = dbobj.ReviewSubmissions.Where(x => x.EmployeeID == user && x.SubmissionStatus == false).ToList();
                return View(AssignedReviews);
            }
            catch
            {
                ModelState.AddModelError(" ", "Invalid Operation");
                return View();
            }
        }

    }
}