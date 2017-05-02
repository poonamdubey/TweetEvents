// ***********************************************************************
// Assembly         : EventManagement
// Author           : PDUBEY
// Created          : 11-18-2015
//
// Last Modified By : PDUBEY
// Last Modified On : 12-11-2015
// ***********************************************************************
// <copyright file="EventBooking.xaml.cs" company="">
//     Copyright ©  2015
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using BusinessLogic;
using BusinessObject;
using System.Windows.Navigation;


namespace EventManagement
{
    /// <summary>
    /// Interaction logic for EventBooking.xaml
    /// </summary>
    public partial class EventBooking : Window
    {
        /// <summary>
        /// The _access token
        /// </summary>
        AccessToken _accessToken = new AccessToken();
        /// <summary>
        /// The event booking manager
        /// </summary>
        EventBookingManager eventBookingManager = new EventBookingManager();
        /// <summary>
        /// The customer manager
        /// </summary>
        CustomerManager customerManager = new CustomerManager();
        /// <summary>
        /// The is edit
        /// </summary>
        private bool isEdit = false;
        //private bool isAdd = false;

        /// <summary>
        /// Initializes a new instance of the <see cref="EventBooking"/> class.
        /// </summary>
        public EventBooking()
        {
            InitializeComponent();
            DisplayEventBookingsData();


        }

        /// <summary>
        /// Handles the SelectionChanged event of the grdEventBookingList control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="SelectionChangedEventArgs"/> instance containing the event data.</param>
        private void grdEventBookingList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (grdEventBookingList.SelectedItem != null)
            {
                try
                {
                    var selectedEventBookings = (EventBookings)grdEventBookingList.SelectedItem;

                    dpEventDate.SelectedDate = selectedEventBookings.EventDate;
                    txtStartTime.Text = selectedEventBookings.StartTime.ToString();
                    txtEndTime.Text = selectedEventBookings.EndTime.ToString();

                    cmbEventName.SelectedValue = selectedEventBookings.EventType.EventTypeID;

                    cmbVenue.SelectedValue = selectedEventBookings.Venue.VenueID;

                    cmbCaterers.SelectedValue = selectedEventBookings.Caterer.CatererID;
                    cmbCustomer.SelectedValue = selectedEventBookings.Customer.CustomerID;


                    EnableDisableForm(true);
                }
                catch
                {
                    MessageBox.Show("You must select a line with event in it.");
                }
            }
        }

        /// <summary>
        /// Displays the event bookings data.
        /// </summary>
        private void DisplayEventBookingsData()
        {
            try
            {
                List<EventBookings> eventBookingList = eventBookingManager.GetEventBookingList();
                grdEventBookingList.ItemsSource = eventBookingList;

                List<EventType> eventTypeList = eventBookingManager.GetEventTypeList();
                cmbEventName.ItemsSource = eventTypeList;


                List<Venue> venueList = eventBookingManager.GetVenueList();
                cmbVenue.ItemsSource = venueList;

                List<Caterers> caterersList = eventBookingManager.GetCaterersList();
                cmbCaterers.ItemsSource = caterersList;

                List<Customer> customerList = customerManager.GetCustomerList();
                cmbCustomer.ItemsSource = customerList;

                ((MainWindow)System.Windows.Application.Current.Windows[1]).grdEventBookingList.ItemsSource = eventBookingList;
            }
            catch (Exception ex)
            {
                lblMessage.Content = ex.Message;
            }

        }

        /// <summary>
        /// Cleans the entry form.
        /// </summary>
        private void CleanEntryForm()
        {
            isEdit = false;

            dpEventDate.Text = string.Empty;

            txtStartTime.Text = string.Empty;

            txtEndTime.Text = string.Empty;

            cmbEventName.SelectedIndex = -1;

            cmbVenue.SelectedIndex = -1;

            cmbCustomer.SelectedIndex = -1;

            cmbCaterers.SelectedIndex = -1;


        }

        /// <summary>
        /// Fills the entry form.
        /// </summary>
        /// <param name="eventBook">The event book.</param>
        private void FillEntryForm(EventBookingsO eventBook)
        {
            dpEventDate.Text = eventBook.EventDate.ToString();
            txtStartTime.Text = eventBook.StartTime.ToString();
            txtEndTime.Text = eventBook.EndTime.ToString();
            cmbEventName.SelectedIndex = eventBook.EventTypeID;
            cmbVenue.SelectedIndex = eventBook.VenueID;
            cmbCustomer.SelectedIndex = eventBook.CustomerID;
            cmbCaterers.SelectedIndex = eventBook.CaterersID;
        }

        //private void btnAdd_Click(object sender, RoutedEventArgs e)
        //{


        //    try
        //    {
        //        btnSave.IsEnabled = true;
        //        btnCancel.IsEnabled = true;
        //        isEdit = false;
        //        isAdd = true;

        //        btnEdit.IsEnabled = false;
        //        btnDelete.IsEnabled = false;
        //        btnAdd.IsEnabled = false;
        //        grdEventEntryForm.IsEnabled = true;


        //        CleanEntryForm();


        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }




        /*
            DateTime eventDate      = DateTime.Parse(dpEventDate.SelectedDate.ToString());
            TimeSpan startTime      = TimeSpan.Parse(txtStartTime.Text);
            TimeSpan endTime        = TimeSpan.Parse(txtEndTime.Text);
            int eventTypeId         = int.Parse(cmbEventName.SelectedValue.ToString());
            int venueId             = int.Parse(cmbVenue.SelectedValue.ToString());
            int customerId          = int.Parse(cmbCustomer.SelectedValue.ToString());
            int catererId           = int.Parse(cmbCaterers.SelectedValue.ToString());

            int uID = 1001;

            if ((eventDate.ToString() != string.Empty))
            {
                if (eventBookingManager.InsertNewEventBooking(eventTypeId, startTime, endTime, eventDate, venueId, customerId, catererId, uID))
                {

                    MessageBox.Show("New event has been booked.", "New Record", MessageBoxButton.OK, MessageBoxImage.Information);
                    
                    DisplayEventBookingsData();
                    CleanEntryForm();


                }
            }
            else
            {
                MessageBox.Show("Please enter all required fields", "New Record", MessageBoxButton.OK, MessageBoxImage.Information);
            }*/
        //}

        /// <summary>
        /// Handles the Click event of the btnCancel control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            EnableDisableForm(false);
            CleanEntryForm();

        }

        /// <summary>
        /// Handles the Click event of the btnClose control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void btnClose_Click(object sender, RoutedEventArgs e)
        {

            this.Close();
            //  this.Dispatcher.InvokeShutdown();
            this.Cursor = Cursors.Arrow;
        }

        /// <summary>
        /// Enables the disable form.
        /// </summary>
        /// <param name="isEnable">if set to <c>true</c> [is enable].</param>
        private void EnableDisableForm(bool isEnable)
        {
            if (isEnable)
            {
                grdEventEntryForm.IsEnabled = false;
                //btnDelete.IsEnabled = true;
                btnEdit.IsEnabled = true;
                btnSave.IsEnabled = false;
                btnCancel.IsEnabled = true;
                btnClose.IsEnabled = true;
            }
            else
            {
                grdEventEntryForm.IsEnabled = true;
                //btnDelete.IsEnabled = false;
                btnEdit.IsEnabled = false;
                btnSave.IsEnabled = true;
                btnCancel.IsEnabled = true;
                btnClose.IsEnabled = true;

                if (grdEventBookingList != null && grdEventBookingList.SelectedItems != null && grdEventBookingList.SelectedItems.Count == 1)
                {
                    (grdEventBookingList.ItemContainerGenerator.ContainerFromItem(grdEventBookingList.SelectedItem) as DataGridRow).IsSelected = false;
                }
            }
        }

        /*/// <summary>
        /// Handles the Click event of the btnDelete control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {

        }*/

        /// <summary>
        /// Handles the Click event of the btnEdit control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                grdEventEntryForm.IsEnabled = true;
               // btnDelete.IsEnabled = false;
                btnSave.IsEnabled = true;
                isEdit = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// Handles the Click event of the btnSave control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                DateTime eventDate = DateTime.Parse(dpEventDate.SelectedDate.ToString());
                TimeSpan startTime = TimeSpan.Parse(txtStartTime.Text);
                TimeSpan endTime = TimeSpan.Parse(txtEndTime.Text);
                int eventTypeId = int.Parse(cmbEventName.SelectedValue.ToString());
                int venueId = int.Parse(cmbVenue.SelectedValue.ToString());
                int customerId = int.Parse(cmbCustomer.SelectedValue.ToString());
                int catererId = int.Parse(cmbCaterers.SelectedValue.ToString());

                int uID = 1001;

                if (!isEdit)
                {

                    if ((eventDate.ToString() != string.Empty) && (startTime.ToString() != string.Empty) &&
                        (endTime.ToString() != string.Empty) && (eventTypeId.ToString() != string.Empty &&
                         venueId.ToString() != string.Empty && customerId.ToString() != string.Empty))
                    {
                        if (eventBookingManager.InsertNewEventBooking(eventTypeId, startTime, endTime, eventDate, venueId, customerId, catererId, uID))
                        {
                            MessageBox.Show("New event has been booked.", "New Record", MessageBoxButton.OK, MessageBoxImage.Information);

                            DisplayEventBookingsData();
                            CleanEntryForm();
                            isEdit = false;
                            btnSave.IsEnabled = false;
                            btnCancel.IsEnabled = false;
                            btnEdit.IsEnabled = true;
                           // btnDelete.IsEnabled = true;
                            grdEventEntryForm.IsEnabled = false;
                        }

                    }
                    else
                    {
                        MessageBox.Show("Please enter all required fields", "New Record", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                }

                if (isEdit)
                {
                    if (grdEventBookingList.SelectedItem != null)
                    {
                        try
                        {
                            var selectedBooking = (EventBookings)grdEventBookingList.SelectedItem;

                            MessageBoxResult _result = MessageBox.Show("Are you sure you want to update this booking record, Booking Id - " + selectedBooking.BookingID, "Edit Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question);

                            if (_result == MessageBoxResult.Yes)
                            {

                                if ((eventDate.ToString() != string.Empty) && (startTime.ToString() != string.Empty) &&
                                     (endTime.ToString() != string.Empty) && (eventTypeId.ToString() != string.Empty &&
                                      venueId.ToString() != string.Empty && customerId.ToString() != string.Empty))
                                {

                                    EventBookingsO _editEvent = new EventBookingsO();

                                    _editEvent.EventDate = eventDate;
                                    _editEvent.StartTime = startTime;
                                    _editEvent.EndTime = endTime;
                                    _editEvent.EventTypeID = eventTypeId;
                                    _editEvent.VenueID = venueId;
                                    _editEvent.CustomerID = customerId;
                                    _editEvent.CaterersID = catererId;
                                    _editEvent.BookingID = selectedBooking.BookingID;
                                    _editEvent.UserProfileID = uID;




                                    if (eventBookingManager.UpdateEventBooking(_editEvent))
                                    {
                                        MessageBox.Show("Selected booking has been updated.");
                                        DisplayEventBookingsData();
                                        CleanEntryForm();
                                        isEdit = false;
                                        btnSave.IsEnabled = false;
                                        btnCancel.IsEnabled = false;
                                        btnEdit.IsEnabled = true;
                                        //btnDelete.IsEnabled = true;

                                    }
                                }
                            }
                        }
                        catch
                        {
                            MessageBox.Show("You must select a line in grid with customer in it.");
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}