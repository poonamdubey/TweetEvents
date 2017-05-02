using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessObject;
using BusinessLogic;
using EventManagementWebApp.Models;

namespace EventManagementWebApp.Controllers
{
    public class EventBookingController : Controller
    {
        EventBookingManager eventBookingMnger = new EventBookingManager();
        CustomerManager customerManager = new CustomerManager();
        //
        // GET: /EventBooking/

        public ActionResult Index()
        {
            return View(eventBookingMnger.GetEventBookingList());
        }

        //
        // GET: /EventBooking/Details/5

        public ActionResult Details(int id)
        {
            EventBookingsO eventBookingO = eventBookingMnger.GetEventBookingOnBookingId(id);
            EventBookingViewModel modelObj = new EventBookingViewModel();
            modelObj.BookingID = id;
            modelObj.EventType = eventBookingMnger.GetEventTypeList();
            modelObj.EventID = eventBookingO.EventTypeID;


            modelObj.StartTime = eventBookingO.StartTime;
            modelObj.EndTime = eventBookingO.EndTime;
            modelObj.EventDate = eventBookingO.EventDate;
            modelObj.Venue = eventBookingMnger.GetVenueList();
            modelObj.VenueID = eventBookingO.VenueID;

            modelObj.Caterer = eventBookingMnger.GetCaterersList();
            modelObj.CatererID = eventBookingO.CaterersID;
            modelObj.Customer = customerManager.GetCustomerList();
            modelObj.CustomerID = eventBookingO.CustomerID;
            return View(modelObj);
        }

        //
        // GET: /EventBooking/Create

        public ActionResult Create()
        {
            EventBookingViewModel modelObj = new EventBookingViewModel();
            EventType typ = new EventType(0,"Please Select","");
            modelObj.EventType = eventBookingMnger.GetEventTypeList();
            modelObj.EventType.Insert(0, typ);
            modelObj.EventID = 0;

            Venue ven = new Venue(0, "Please Select");
            modelObj.Venue = eventBookingMnger.GetVenueList();
            modelObj.Venue.Insert(0, ven);
            modelObj.VenueID = 0;

            Caterers cat = new Caterers(0, "Please Select");
            modelObj.Caterer = eventBookingMnger.GetCaterersList();
            modelObj.Caterer.Insert(0,cat);
            modelObj.CatererID = 0;
            Customer cust = new Customer();
            cust.CustomerID = 0;
            cust.FirstName = "Please Select";
            modelObj.Customer = customerManager.GetCustomerList();
            modelObj.Customer.Insert(0, cust);
            modelObj.CustomerID = 0;
            return View(modelObj);
        }

        //
        // POST: /EventBooking/Create

        [HttpPost]
        public ActionResult Create(EventBookingViewModel eventBookings)
        {
            if (ModelState.IsValid)
            {
                if (eventBookings.EventID != 0 && eventBookings.VenueID != 0 && eventBookings.CatererID != 0 && eventBookings.CustomerID != 0)
                {
                    if (eventBookings.StartTime < eventBookings.EndTime)
                    {
                        if (eventBookingMnger.InsertNewEventBooking(eventBookings.EventID, eventBookings.StartTime, eventBookings.EndTime, eventBookings.EventDate, eventBookings.VenueID, eventBookings.CustomerID, eventBookings.CatererID, 1000))
                        {
                            return RedirectToAction("Index");
                        }
                        else
                        {
                            return RedirectToAction("Error");
                        }
                    }
                    else
                    {
                        ModelState.AddModelError("", "Event start time should be less than event end time.");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Please enter values for required fields.");
                }
            }
            else
            {
                ModelState.AddModelError("", "Error Occured.");
            }
            EventBookingViewModel modelObj = new EventBookingViewModel();
            EventType typ = new EventType(0, "Please Select", "");
            modelObj.EventType = eventBookingMnger.GetEventTypeList();
            modelObj.EventType.Insert(0, typ);
            modelObj.EventID = 0;

            Venue ven = new Venue(0, "Please Select");
            modelObj.Venue = eventBookingMnger.GetVenueList();
            modelObj.Venue.Insert(0, ven);
            modelObj.VenueID = 0;

            Caterers cat = new Caterers(0, "Please Select");
            modelObj.Caterer = eventBookingMnger.GetCaterersList();
            modelObj.Caterer.Insert(0, cat);
            modelObj.CatererID = 0;
            Customer cust = new Customer();
            cust.CustomerID = 0;
            cust.FirstName = "Please Select";
            modelObj.Customer = customerManager.GetCustomerList();
            modelObj.Customer.Insert(0, cust);
            modelObj.CustomerID = 0;
            return View(modelObj);
        }

        //
        // GET: /EventBooking/Edit/5

        public ActionResult Edit(int id = 0)
        {

            EventBookingsO eventBookingO = eventBookingMnger.GetEventBookingOnBookingId(id);
            EventBookingViewModel modelObj = new EventBookingViewModel();
            modelObj.BookingID = id;
            modelObj.EventType = eventBookingMnger.GetEventTypeList();
            modelObj.EventID = eventBookingO.EventTypeID;


            modelObj.StartTime = eventBookingO.StartTime;
            modelObj.EndTime = eventBookingO.EndTime;
            modelObj.EventDate = eventBookingO.EventDate;
            modelObj.Venue = eventBookingMnger.GetVenueList();
            modelObj.VenueID = eventBookingO.VenueID;

            modelObj.Caterer = eventBookingMnger.GetCaterersList();
            modelObj.CatererID = eventBookingO.CaterersID;
            modelObj.Customer = customerManager.GetCustomerList();
            modelObj.CustomerID = eventBookingO.CustomerID;
            return View(modelObj);
        }

        //
        // POST: /EventBooking/Edit/5

        [HttpPost]
        public ActionResult Edit(EventBookingViewModel eventBookingViewModelObj)
        {
            try
            {
                EventBookingsO eventBookingObj = new EventBookingsO();
                // TODO: Add update logic here

                eventBookingObj.BookingID = eventBookingViewModelObj.BookingID;
                eventBookingObj.CaterersID = eventBookingViewModelObj.CatererID;
                eventBookingObj.CustomerID = eventBookingViewModelObj.CustomerID;
                eventBookingObj.EventTypeID = eventBookingViewModelObj.EventID;
                eventBookingObj.VenueID = eventBookingViewModelObj.VenueID;
                eventBookingObj.StartTime = eventBookingViewModelObj.StartTime;
                eventBookingObj.EndTime = eventBookingViewModelObj.EndTime;
                eventBookingObj.EventDate = eventBookingViewModelObj.EventDate;
                eventBookingObj.UserProfileID = 1000;


                eventBookingMnger.UpdateEventBooking(eventBookingObj);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /EventBooking/Delete/5

        //public ActionResult Delete(int id)
        //{
        //    EventBookingsO eventBookingO = eventBookingMnger.GetEventBookingOnBookingId(id);
        //    EventBookingViewModel modelObj = new EventBookingViewModel();

        //    modelObj.EventType = eventBookingMnger.GetEventTypeList();
        //    modelObj.EventID = eventBookingO.EventTypeID;


        //    modelObj.StartTime = eventBookingO.StartTime;
        //    modelObj.EndTime = eventBookingO.EndTime;
        //    modelObj.EventDate = eventBookingO.EventDate;
        //    modelObj.Venue = eventBookingMnger.GetVenueList();
        //    modelObj.VenueID = eventBookingO.VenueID;

        //    modelObj.Caterer = eventBookingMnger.GetCaterersList();
        //    modelObj.CatererID = eventBookingO.CaterersID;
        //    modelObj.Customer = customerManager.GetCustomerList();
        //    modelObj.CustomerID = eventBookingO.CustomerID;
        //    return View(modelObj);
        //}

        ////
        //// POST: /EventBooking/Delete/5

        //[HttpPost]
        //public ActionResult Delete(int id, FormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add delete logic here

        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
    }
}
