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
    public class CustomerController : Controller
    {
        CustomerManager custManagerObj = new CustomerManager();

        //
        // GET: /Customer/

        public ActionResult Index()
        {
            return View(custManagerObj.GetCustomerList());
        }

        //
        // GET: /Customer/Details/5

        public ActionResult Details(int id = 0)
        {
            Customer customer = custManagerObj.GetCustomerById(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        //
        // GET: /Customer/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Customer/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Customer customer)
        {
            if (ModelState.IsValid)
            {
                if (custManagerObj.InsertNewCustomer(customer.FirstName, customer.LastName, customer.EmailID, customer.PhoneNo1, customer.PhoneNo2, customer.Address1, customer.Address2, customer.PostalCode, customer.City, customer.State))
                    return RedirectToAction("Index");
                else
                    return RedirectToAction("Error");
            }

            return View(customer);
        }

        //
        // GET: /Customer/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Customer customer = custManagerObj.GetCustomerById(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        //
        // POST: /Customer/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Customer customer)
        {
            if (ModelState.IsValid)
            {
                if (String.IsNullOrEmpty(customer.PhoneNo2))
                    customer.PhoneNo2 = string.Empty;

                if (String.IsNullOrEmpty(customer.Address2))
                    customer.Address2 = string.Empty;


                if (custManagerObj.UpdateCustomer(customer))
                    return RedirectToAction("Index");
                else
                    return RedirectToAction("Error");
            }
            return View(customer);
        }

        //
        // GET: /Customer/Delete/5

        public ActionResult Delete(int id = 0)
        {
            
            Customer customer = custManagerObj.GetCustomerById(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        //
        // POST: /Customer/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Customer cust = new Customer();
            cust.CustomerID = id;
            if (custManagerObj.DeleteCustomer(cust))
                return RedirectToAction("Index");
            else
                return RedirectToAction("Error");
        }
    }
}