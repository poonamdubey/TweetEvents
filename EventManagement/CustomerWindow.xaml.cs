// ***********************************************************************
// Assembly         : EventManagement
// Author           : PDUBEY
// Created          : 11-16-2015
//
// Last Modified By : PDUBEY
// Last Modified On : 12-12-2015
// ***********************************************************************
// <copyright file="CustomerWindow.xaml.cs" company="">
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
    /// Interaction logic for CustomerWindow.xaml
    /// </summary>
    public partial class CustomerWindow : Window
    {

        /// <summary>
        /// My customer manager
        /// </summary>
        CustomerManager myCustomerManager = new CustomerManager();
        /// <summary>
        /// The is edit
        /// </summary>
        private bool isEdit = false;
        //private bool isAdd = false;

        /// <summary>
        /// Initializes a new instance of the <see cref="CustomerWindow"/> class.
        /// </summary>
        public CustomerWindow()
        {
            InitializeComponent();

            DisplayCustomerData();
        }

        /// <summary>
        /// Handles the SelectionChanged event of the grdCustomerList control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="SelectionChangedEventArgs"/> instance containing the event data.</param>
        private void grdCustomerList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (grdCustomerList.SelectedItem != null)
            {
                try
                {
                    var selectedCustomer = (Customer)grdCustomerList.SelectedItem;

                    FillEntryForm(selectedCustomer);

                    EnableDisableForm(true);


                }
                catch
                {
                    MessageBox.Show("You must select a line with customer in it.");
                }
            }

        }


        /// <summary>
        /// Handles the Click event of the btnGetCustomerData control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void btnGetCustomerData_Click(object sender, RoutedEventArgs e)
        {
            DisplayCustomerData();

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
        /// Handles the Click event of the btnDeleteCustomer control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void btnDeleteCustomer_Click(object sender, RoutedEventArgs e)
        {


            if (grdCustomerList.SelectedItem != null)
            {
                try
                {
                    var selectedCustomer = (Customer)grdCustomerList.SelectedItem;

                    MessageBoxResult _result = MessageBox.Show("Are you sure you want to delete this customer record, customer Id - " + selectedCustomer.CustomerID.ToString(), "Delete Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question);

                    if (_result == MessageBoxResult.Yes)
                    {
                        if (myCustomerManager.DeleteCustomer(selectedCustomer))
                        {
                            MessageBox.Show("Selected customer has been deleted.");
                            DisplayCustomerData();
                            CleanEntryForm();
                        }
                    }


                }
                catch
                {
                    MessageBox.Show("You must select a line with customer in it.");
                }
            }

        }

        /// <summary>
        /// Displays the customer data.
        /// </summary>
        private void DisplayCustomerData()
        {
            try
            {
                var customers = myCustomerManager.GetCustomerList();
                grdCustomerList.ItemsSource = customers;
                ((MainWindow)System.Windows.Application.Current.Windows[1]).grdCustomerList.ItemsSource = customers;
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
            txtFirstName.Text = string.Empty;
            txtLastName.Text = string.Empty;
            txtEmailid.Text = string.Empty;
            txtPhoneNO1.Text = string.Empty;
            txtPhoneNO2.Text = string.Empty;
            txtAddress1.Text = string.Empty;
            txtAdddress2.Text = string.Empty;
            txtCity.Text = string.Empty;
            txtState.Text = string.Empty;
            txtZIP.Text = string.Empty;
            isEdit = false;

        }

        /// <summary>
        /// Fills the entry form.
        /// </summary>
        /// <param name="cust">The customer.</param>
        private void FillEntryForm(Customer cust)
        {
            txtFirstName.Text = cust.FirstName;
            txtLastName.Text = cust.LastName;
            txtEmailid.Text = cust.EmailID;
            txtPhoneNO1.Text = cust.PhoneNo1;
            txtPhoneNO2.Text = cust.PhoneNo2;
            txtAddress1.Text = cust.Address1;
            txtAdddress2.Text = cust.Address2;
            txtCity.Text = cust.City;
            txtState.Text = cust.State;
            txtZIP.Text = cust.PostalCode;


        }

        /// <summary>
        /// Enables the disable form.
        /// </summary>
        /// <param name="isEnable">if set to <c>true</c> [is enable].</param>
        private void EnableDisableForm(bool isEnable)
        {
            if (isEnable)
            {
                grdCustEntryForm.IsEnabled = false;
                btnEdit.IsEnabled = true;
                btnSave.IsEnabled = false;
                btnCancel.IsEnabled = true;
                btnDelete.IsEnabled = true;
                btnClose.IsEnabled = true;
            }
            else
            {
                grdCustEntryForm.IsEnabled = true;
                btnEdit.IsEnabled = false;
                btnSave.IsEnabled = true;
                btnCancel.IsEnabled = true;
                btnDelete.IsEnabled = false;
                btnClose.IsEnabled = true;

                if (grdCustomerList != null && grdCustomerList.SelectedItems != null && grdCustomerList.SelectedItems.Count == 1)
                {
                    (grdCustomerList.ItemContainerGenerator.ContainerFromItem(grdCustomerList.SelectedItem) as DataGridRow).IsSelected = false;
                }
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
                string firstName = txtFirstName.Text;
                string lastName = txtLastName.Text;
                string emailID = txtEmailid.Text;
                string phoneNO1 = txtPhoneNO1.Text;
                string phoneNO2 = txtPhoneNO2.Text;
                string address1 = txtAddress1.Text;
                string address2 = txtAdddress2.Text;
                string city = txtCity.Text;
                string state = txtState.Text;
                string postalcode = txtZIP.Text;

                if (!isEdit)
                {
                   


                    if ((firstName != string.Empty) && (lastName != string.Empty) && (phoneNO1 != string.Empty))
                    {
                        if (myCustomerManager.InsertNewCustomer(firstName, lastName, emailID, phoneNO1, phoneNO2, address1, address2, postalcode, city, state))
                        {

                            MessageBox.Show("New Customer has been added.", "New Record", MessageBoxButton.OK, MessageBoxImage.Information);
                            CleanEntryForm();
                            DisplayCustomerData();
                            isEdit = false;
                            btnSave.IsEnabled = false;
                            btnCancel.IsEnabled = false;
                            btnEdit.IsEnabled = true;
                            btnDelete.IsEnabled = true;
                            grdCustEntryForm.IsEnabled = false;

                        }
                    }
                    else
                    {
                        MessageBox.Show("Please enter all required fields", "New Record", MessageBoxButton.OK, MessageBoxImage.Information);
                    }

                }

                if(isEdit)
                {

                    if (grdCustomerList.SelectedItem != null)
                    {
                        try
                        {
                            var selectedCustomer = (Customer)grdCustomerList.SelectedItem;

                            MessageBoxResult _result = MessageBox.Show("Are you sure you want to update this customer record, customer Id - " + selectedCustomer.CustomerID.ToString(), "Edit Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question);

                            if (_result == MessageBoxResult.Yes)
                            {

                                if ((firstName != string.Empty) && (lastName != string.Empty) && (phoneNO1 != string.Empty))
                                {

                                    Customer _editCustomer = new Customer();

                                    _editCustomer.CustomerID = selectedCustomer.CustomerID;
                                    _editCustomer.FirstName = firstName;
                                    _editCustomer.LastName = lastName;
                                    _editCustomer.EmailID = emailID;
                                    _editCustomer.PhoneNo1 = phoneNO1;
                                    _editCustomer.PhoneNo2 = phoneNO2;
                                    _editCustomer.Address1 = address1;
                                    _editCustomer.Address2 = address2;
                                    _editCustomer.City = city;
                                    _editCustomer.State = state;
                                    _editCustomer.PostalCode = postalcode;


                                    if (myCustomerManager.UpdateCustomer(_editCustomer))
                                    {
                                        MessageBox.Show("Selected customer has been updated.");
                                        DisplayCustomerData();
                                        CleanEntryForm();
                                        isEdit = false;
                                        btnSave.IsEnabled = false;
                                        btnCancel.IsEnabled = false;
                                        btnEdit.IsEnabled = true;
                                        btnDelete.IsEnabled = true;

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
        /// Handles the Click event of the btnEditCustomer control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void btnEditCustomer_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                grdCustEntryForm.IsEnabled = true;
                btnDelete.IsEnabled = false;
                btnSave.IsEnabled = true;
                isEdit = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

    }
}
