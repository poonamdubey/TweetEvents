// ***********************************************************************
// Assembly         : EventManagement
// Author           : PDUBEY
// Created          : 11-12-2015
//
// Last Modified By : PDUBEY
// Last Modified On : 11-20-2015
// ***********************************************************************
// <copyright file="LoginWindow.xaml.cs" company="">
//     Copyright ©  2015
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
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
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        /// <summary>
        /// The _access token
        /// </summary>
        static AccessToken _accessToken;

        /// <summary>
        /// Initializes a new instance of the <see cref="LoginWindow"/> class.
        /// </summary>
        public LoginWindow()
        {
            this.Cursor = Cursors.Wait;
            InitializeComponent();
            txtUsername.Focus();
            this.Cursor = Cursors.Arrow;
        }

        /// <summary>
        /// Handles the Executed event of the CloseCommand control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="ExecutedRoutedEventArgs"/> instance containing the event data.</param>
        private void CloseCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Handles the MouseDown event of the Window control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="MouseButtonEventArgs"/> instance containing the event data.</param>
        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        /// <summary>
        /// Handles the Click event of the btnLogin control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        /// <exception cref="System.ApplicationException">Please enter valid username and password !</exception>
        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            // first, grab the values of the text boxes
            string username = this.txtUsername.Text;
            string password = this.txtPassword.Password;

            try
            {
                // decide whether to check for new user or existing user

                if ((password != string.Empty) && (username != string.Empty))
                {
                    _accessToken = SecurityManager.ValidateExistingUser(username, password);
                    this.DialogResult = true;
                }
                else
                {
                    throw new ApplicationException("Please enter valid username and password !");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }



        /// <summary>
        /// Handles the Click event of the btnCancel control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void btnCancel_Click(object sender, RoutedEventArgs e) // login canceled
        {
            _accessToken = null;
            this.DialogResult = false;
        }

        // Declare the delegate that will be the prototype of event subscribers
        /// <summary>
        /// Delegate AccessTokenCreatedEventHandler
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="a">a.</param>
        public delegate void AccessTokenCreatedEventHandler(object sender, AccessToken a);

        // Declare the event from a delegate, so it knows what sort of subscribers to accept
        public event AccessTokenCreatedEventHandler AccessTokenCreatedEvent;
        /// <summary>
        /// Raises the access token created event.
        /// </summary>
        protected virtual void RaiseAccessTokenCreatedEvent()  // we need a method to raise the event
        {
            // Raise the event
            if (AccessTokenCreatedEvent != null)  // if there are subscribers/listeners/handlers
                AccessTokenCreatedEvent(this, _accessToken); // go ahead and raise the event
        }

        /// <summary>
        /// Handles the Closing event of the Window control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.ComponentModel.CancelEventArgs"/> instance containing the event data.</param>
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (_accessToken != null)  // don't raise the event if no one logged in
            {
                RaiseAccessTokenCreatedEvent();
            }
        }

        /// <summary>
        /// Handles the Loaded event of the Window control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.txtUsername.Focus();
        }

    }

     
}
