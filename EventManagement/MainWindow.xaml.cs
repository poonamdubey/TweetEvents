// ***********************************************************************
// Assembly         : EventManagement
// Author           : PDUBEY
// Created          : 11-05-2015
//
// Last Modified By : PDUBEY
// Last Modified On : 12-12-2015
// ***********************************************************************
// <copyright file="MainWindow.xaml.cs" company="">
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

namespace EventManagement
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        /// <summary>
        /// The _access token
        /// </summary>
        AccessToken _accessToken = new AccessToken();
        /// <summary>
        /// The _login
        /// </summary>
        LoginWindow _login;


        //CustomerManager myCustomerManager = new CustomerManager();
        /// <summary>
        /// Initializes a new instance of the <see cref="MainWindow"/> class.
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
            _accessToken = null;

            UserAuthorization();
        }



        /// <summary>
        /// Handles the Click event of the btnLogin control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {

            if (_accessToken == null)
            {
                _login = new LoginWindow();

                _login.AccessTokenCreatedEvent += setAccessToken;  // subscribe a listener to the login event
                if (_login.ShowDialog() == true && _accessToken != null)  // login succeeded
                {
                    // initialize the form
                    // MessageBox.Show(_accessToken.FirstName + " has logged in.");
                    this.lblLoginMessage.Content = _accessToken.FirstName + " " + _accessToken.LastName + " is logged in.";

                    ShowHideTabs(_accessToken.RoleName);



                    this.btnLogin.Content = "Log Out";
                }
                else
                {
                    // clear the access token reference to null and updata status bar
                    _accessToken = null;
                    MessageBox.Show("Login failed.");
                }
            }
            else // someone is already logged in
            {
                _accessToken = null;
                ShowHideTabs(string.Empty);


                this.lblLoginMessage.Content = "You are not logged in.";
                this.btnLogin.Content = "Log In";
            }
           
        }
        /// <summary>
        /// Sets the access token.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="at">At.</param>
        private void setAccessToken(object sender, AccessToken at)  // this is a listener for a login event
        {
            if (sender == _login)
            {
                this._accessToken = at;
            }
        }


        /// <summary>
        /// Users the authorization.
        /// </summary>
        private void UserAuthorization()
        {
            if (_accessToken != null)
            {
             
                    // initialize the form
                    //MessageBox.Show(_accessToken.FirstName + " has logged in.");

                    this.lblLoginMessage.Content = _accessToken.FirstName + " " + _accessToken.LastName + " is logged in.";

                    ShowHideTabs(_accessToken.RoleName);

                    this.btnLogin.Content = "Log Out";
            }
            else // someone is already logged in
            {
                _accessToken = null;
                ShowHideTabs(string.Empty);


                this.lblLoginMessage.Content = "You are not logged in.";
                this.btnLogin.Content = "Log In";
            }
        }

        /// <summary>
        /// Shows the hide tabs.
        /// </summary>
        /// <param name="roleName">Name of the role.</param>
        private void ShowHideTabs(string roleName)
        {

            //Customer Tab
            this.tabCustomer.Visibility = Visibility.Visible;
            this.grdCustomer.Visibility = Visibility.Visible;
            this.tabCustomer.Focus();
            DisplayCustomerData();


            //Event Booking Tab
            this.tabEventBooking.Visibility = Visibility.Visible;
            this.grdEventBooking.Visibility = Visibility.Visible;
            DisplayEventBookingsData();


            if (roleName == "Staff")
            {
                this.tabUser.Visibility = Visibility.Collapsed;
                this.grdUser.Visibility = Visibility.Hidden;

            }
            else if (roleName == "Admin")
            {
                this.tabUser.Visibility = Visibility.Visible;
                this.grdUser.Visibility = Visibility.Visible;
                DisplayUserData();
                
            }
            else if (roleName == string.Empty)
            {
                this.tabCustomer.Visibility = Visibility.Collapsed;
                this.grdCustomer.Visibility = Visibility.Hidden;

                this.tabEventBooking.Visibility = Visibility.Collapsed;
                this.grdEventBooking.Visibility = Visibility.Hidden;

                this.tabUser.Visibility = Visibility.Collapsed;
                this.grdUser.Visibility = Visibility.Hidden;
            }

        }


        /// <summary>
        /// To bind customer data grid
        /// </summary>
        private void DisplayCustomerData()
        {
            try
            {
                CustomerManager myCustomerManager = new CustomerManager();

                var customers = myCustomerManager.GetCustomerList();

                grdCustomerList.ItemsSource = customers;

            }
            catch (Exception ex)
            {
                lblMessage.Content = ex.Message;
            }

        }

        /// <summary>
        /// Handles the Click event of the btnAddCustomer control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void btnAddCustomer_Click(object sender, RoutedEventArgs e)
        {
            CustomerWindow objCustomerWindow = new CustomerWindow();

            objCustomerWindow.ShowDialog();
            objCustomerWindow = null;

        }

        /// <summary>
        /// Handles the SelectionChanged event of the grdCustomerList control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="SelectionChangedEventArgs"/> instance containing the event data.</param>
        private void grdCustomerList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        /// <summary>
        /// To Bind Event Booking Grid
        /// </summary>
        private void DisplayEventBookingsData()
        {
            try
            {
                EventBookingManager eventBookingManager = new EventBookingManager();

                List<EventBookings> eventBookingList = eventBookingManager.GetEventBookingList();
                grdEventBookingList.ItemsSource = eventBookingList;

            }
            catch (Exception ex)
            {
                lblMessage.Content = ex.Message;
            }

        }

        /// <summary>
        /// To Bind Event Booking Grid
        /// </summary>
        private void DisplayUserData()
        {
            try
            {
                UserProfileManager userProfileManager = new UserProfileManager();


                List<UserProfile> userProfileList = userProfileManager.GetUserProfileList();
                var reducedList = userProfileList.Select(e => new { e.UserID, e.UserName, e.FirstName, e.LastName, e.MiddleName, e.EmailAddress, e.RoleName, e.Phone, e.Address, e.City, e.State, e.Zip, e.IsActive }).ToList();
                grdUserList.ItemsSource = reducedList;
                

            }
            catch (Exception ex)
            {
                lblMessage.Content = ex.Message;
            }

        }

        /// <summary>
        /// Handles the Click event of the btnAddEventBooking control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void btnAddEventBooking_Click(object sender, RoutedEventArgs e)
        {
            EventBooking objEventBooking = new EventBooking();

            objEventBooking.ShowDialog();
            objEventBooking = null;
        }

        /// <summary>
        /// Handles the Click event of the btnUserProfile control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void btnUserProfile_Click(object sender, RoutedEventArgs e)
        {
            UserProfileWindow userProfile = new UserProfileWindow();

            userProfile.ShowDialog();
            userProfile = null;
        }

        /// <summary>
        /// Handles the SelectionChanged event of the grdEventBookingList control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="SelectionChangedEventArgs"/> instance containing the event data.</param>
        private void grdEventBookingList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }



    }
}
