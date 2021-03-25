using BegginerLevelTask.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BegginerLevelTask.Controllers
{
    public class ReviewCreationController : Controller
    {
        BegginerLevelTaskEntities dbobj = new BegginerLevelTaskEntities();
        // GET: ReviewCreation
        public ActionResult ReviewCreation(ReviewCreation obj)
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
        public ActionResult EditReviewCreation(ReviewCreation edit)
        {
            try
            {
                var user = (int)Session["UserID"];
                edit.UserID = user;

                var OrgID = dbobj.tbl_Organisation.Single(x => x.UserID == user);
                ViewBag.Welcome = "Welcome, ";
                ViewBag.DisplayName = OrgID.Name;

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
        public ActionResult AddReviewCreation(ReviewCreation model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    model.UserID = (int)Session["UserID"];
                    model.CreatedBy = (int)Session["UserID"];
                    model.CreatedOn = DateTime.Now;

                    if (model.ReviewID == 0)
                    {
                        dbobj.ReviewCreations.Add(model);
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
                return View("ReviewCreation");
            }
            catch
            {
                ModelState.AddModelError(" ", "Invalid Operation");
                return View();
            }
        }
        public ActionResult ReviewCreationList()
        {
            try
            {
                var user = (int)Session["UserID"];
                var OrgID = dbobj.tbl_Organisation.Single(x => x.UserID == user);
                ViewBag.Welcome = "Welcome, ";
                ViewBag.DisplayName = OrgID.Name;

                //var OrganisationID = (int)Session["UserID"];
                IEnumerable<ReviewCreation> res = dbobj.ReviewCreations.Where(x => x.UserID == user);
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
                //var res = dbobj.ReviewCreations.Where(x => x.ReviewID == id).First();
                //dbobj.ReviewCreations.Remove(res);

                var OrganisationID = (int)Session["UserID"];
                var check = dbobj.ReviewCreations.Single(x => x.ReviewID == id);
                if (check.ReviewStatus == true)
                {
                    check.ReviewStatus = false;                //If active then make In-active
                }

                dbobj.SaveChanges();

                var list = dbobj.ReviewCreations.Where(x => x.UserID == OrganisationID && x.ReviewStatus == true).ToList();

                return View("ReviewCreationList", list);
            }
            catch
            {
                ModelState.AddModelError(" ", "Invalid Operation");
                return View();
            }

        }
    }
}