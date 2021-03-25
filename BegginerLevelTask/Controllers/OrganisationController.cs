using BegginerLevelTask.Context;
using BegginerLevelTask.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BegginerLevelTask.Controllers
{
    public class OrganisationController : Controller
    {
        // GET: Organisation
        BegginerLevelTaskEntities dbobj = new BegginerLevelTaskEntities();
        public ActionResult Organisation(tbl_Organisation obj)
        {
            try
            {
                var superID = (long)Session["SuperID"];
                var SuperID = dbobj.SuperUsers.Single(x => x.SuperID == superID);

                ViewBag.Welcome = "Welcome, ";
                ViewBag.DisplayName = SuperID.SuperFirstName + " " + SuperID.SuperLastName;

               
                return View(obj);
            }
            catch
            {
                ModelState.AddModelError(" ", "Invalid Operation");
                return View();
            }
        }

        public ActionResult EditOrganisation(tbl_Organisation edit)
        {
            try
            {
                var superID = (long)Session["SuperID"];
                var SuperID = dbobj.SuperUsers.Single(x => x.SuperID == superID);

                ViewBag.Welcome = "Welcome, ";
                ViewBag.DisplayName = SuperID.SuperFirstName + " " + SuperID.SuperLastName;
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
        public ActionResult AddOrganisation(tbl_Organisation model)
        {
            try
            {
                var superID = (long)Session["SuperID"];
                if (ModelState.IsValid)
                {
                    model.SuperID = superID;
                    model.CreatedBy = superID;
                    model.CreatedOn = DateTime.Now;

                    dbobj.tbl_Organisation.Add(model);
                    dbobj.SaveChanges();
                    ModelState.Clear();
                }
                //ViewBag.SuccessMessage = "Registration Successful.";
                return View("Organisation");
            }
            catch
            {
                ModelState.AddModelError(" ", "Invalid Operation");
                return View();
            }
        }

        [HttpPost]
        public ActionResult EditAddOrganisation(tbl_Organisation organisation)
        { 
            try
            {
                var superID = (long)Session["SuperID"];
                organisation.SuperID = superID;
                organisation.CreatedBy = superID;
                organisation.CreatedOn = DateTime.Now;
                dbobj.Entry(organisation).State = EntityState.Modified;
                dbobj.SaveChanges();
                return View("EditOrganisation");
            }
            catch
            {
                ModelState.AddModelError(" ", "Invalid Operation");
                return View();
            }
        }

        public JsonResult CheckUsernameAvailability(string UserName)
        {
            return Json(!dbobj.tbl_Organisation.Any(x => x.UserName == UserName), JsonRequestBehavior.AllowGet);
        }


        public ActionResult OrganisationList()
        {
            try
            {
                var superID = (long)Session["SuperID"];
                var SuperID = dbobj.SuperUsers.Single(x => x.SuperID == superID);

                ViewBag.Welcome = "Welcome, ";
                ViewBag.DisplayName = SuperID.SuperFirstName + " " + SuperID.SuperLastName;

                var superId = (long)Session["SuperID"];
                var res = dbobj.tbl_Organisation.Where(x => x.SuperID == superId).ToList();
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
                var superUser = (long)Session["SuperID"];
                var check = dbobj.tbl_Organisation.Single(x => x.UserID == id);
                if (check.MaritalStatus == "Active")
                {
                    check.MaritalStatus = "In-active";                //If active then make In-active
                }
                //else
                //{
                //    var res = dbobj.tbl_Organisation.Where(x => x.UserID == id).First();
                //    dbobj.tbl_Organisation.Remove(res);
                //}
                dbobj.SaveChanges();

                var list = dbobj.tbl_Organisation.Where(x => x.SuperID == superUser && x.MaritalStatus == "Active").ToList();

                return View("OrganisationList", list);
            }
            catch
            {
                ModelState.AddModelError(" ", "Invalid Operation");
                return View();
            }

        }


        //public ActionResult GetCountryList()
        //{
        //    List<Country> countries = dbobj.Countries.ToList();
        //    ViewBag.CountryList = new SelectList(countries, "CountryID", "CountryName");
        //    return PartialView("DisplayCountry");
        //}

        //public ActionResult GetStateList(int countryID)
        //{
        //    List<State> stateList = dbobj.States.Where(x => x.CountryID == countryID).ToList();
        //    ViewBag.StateList = new SelectList(stateList, "StateID", "StateName");
        //    return PartialView("DisplayState");
        //}

        //public ActionResult GetCityList(int stateID)
        //{
        //    List<City> cityList = dbobj.Cities.Where(x => x.StateID == stateID).ToList();
        //    ViewBag.CityList = new SelectList(cityList, "CityID", "CityName");
        //    return PartialView("DisplayCity");
        //}
    }
}