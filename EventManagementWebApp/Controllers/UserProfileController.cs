using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessObject;
using BusinessLogic;

namespace EventManagementWebApp.Controllers
{
    public class UserProfileController : Controller
    {
        UserProfileManager profileObj = new UserProfileManager();
        //
        // GET: /UserProfile/

        public ActionResult Index()
        {
            return View(profileObj.GetUserProfileList());
        }

        //
        // GET: /UserProfile/Details/5

        public ActionResult Details(int id = 0)
        {
            UserProfile userprofile = profileObj.GetUserProfileByUserID(id);
            if (userprofile == null)
            {
                return HttpNotFound();
            }
            return View(userprofile);
        }

        //
        // GET: /UserProfile/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /UserProfile/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(UserProfile userprofile)
        {
            if (ModelState.IsValid)
            {
                if (profileObj.InsertNewUser(userprofile.FirstName, userprofile.LastName, userprofile.MiddleName, userprofile.UserName, userprofile.EmailAddress, userprofile.Phone, userprofile.Address, userprofile.Zip, userprofile.City, userprofile.State, userprofile.RoleName, userprofile.IsActive, userprofile.Password))
                    return RedirectToAction("Index");
                else
                    return RedirectToAction("Error");
            }

            return View(userprofile);
        }

        //
        // GET: /UserProfile/Edit/5

        public ActionResult Edit(int id = 0)
        {
            UserProfile userprofile = profileObj.GetUserProfileByUserID(id);
            if (userprofile == null)
            {
                return HttpNotFound();
            }
            return View(userprofile);
        }

        //
        // POST: /UserProfile/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(UserProfile userprofile)
        {
            if (ModelState.IsValid)
            {
                if (profileObj.UpdateUser(userprofile))
                    return RedirectToAction("Index");
                else

                    return RedirectToAction("Error");
            }
            return View(userprofile);
        }

        //
        // GET: /UserProfile/Delete/5

        public ActionResult Delete(int id = 0)
        {
            UserProfile userprofile = profileObj.GetUserProfileByUserID(id);
            if (userprofile == null)
            {
                return HttpNotFound();
            }
            return View(userprofile);
        }

        //
        // POST: /UserProfile/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            if (profileObj.DeleteUser(id))
                return RedirectToAction("Index");
            else
                return RedirectToAction("Error");
        }
    }
}