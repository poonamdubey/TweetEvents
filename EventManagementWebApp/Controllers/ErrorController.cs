﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EventManagementWebApp.Controllers
{
    public class ErrorController : Controller
    {
        //
        // GET: /Error/

        public ActionResult AccessDenied()
        {
            return View();
        }

        //
        // GET: /Error/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Error/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Error/Create

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Error/Edit/5

        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Error/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Error/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Error/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
