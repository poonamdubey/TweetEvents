// ***********************************************************************
// Assembly         : EventManagement
// Author           : PDUBEY
// Created          : 12-11-2015
//
// Last Modified By : PDUBEY
// Last Modified On : 12-13-2015
// ***********************************************************************
// <copyright file="UserProfileWindow.xaml.cs" company="">
//     Copyright ©  2015
// </copyright>
// <summary></summary>
// ***********************************************************************
using BusinessLogic;
using BusinessObject;
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
using System.Windows.Threading;



namespace EventManagement
{
    /// <summary>
    /// Interaction logic for UserProfileWindow.xaml
    /// </summary>
    /// <seealso cref="System.Windows.Window" />
    public partial class UserProfileWindow : Window
    {
        /// <summary>
        /// The user profile manager object
        /// </summary>
        UserProfileManager userProfileManagerObj = new UserProfileManager();
        List<Roles> roleList = null;
        bool isEdit = false;

        #region 'Public Function'
        /// <summary>
        /// Initializes a new instance of the <see cref="UserProfileWindow" /> class.
        /// </summary>
        public UserProfileWindow()
        {
            InitializeComponent();
            DisplayUserData();
        }

        #endregion


        #region 'private functions'

        /// <summary>
        /// Method to display User data into grid
        /// </summary>
        private void DisplayUserData()
        {
            try
            {
                List<UserProfile> usersList = userProfileManagerObj.GetUserProfileList();

                roleList = userProfileManagerObj.GetRoleList();
                cmbRoleName.ItemsSource = roleList;
                cmbRoleName.Text = string.Empty;
                grdUserList.ItemsSource = usersList;
                ((MainWindow)System.Windows.Application.Current.Windows[1]).grdUserList.ItemsSource = usersList;
            }
            catch (Exception ex)
            {
                lblMessage.Content = ex.Message;
            }

        }

        /// <summary>
        /// Method to enable disable form entry fields
        /// </summary>
        /// <param name="isEnable">bool</param>
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

                if (grdUserList != null && grdUserList.SelectedItems != null && grdUserList.SelectedItems.Count == 1)
                {
                    (grdUserList.ItemContainerGenerator.ContainerFromItem(grdUserList.SelectedItem) as DataGridRow).IsSelected = false;
                }
            }
        }


        /// <summary>
        /// Method to fill entry form fields
        /// </summary>
        /// <param name="profile">UserProfile class object</param>
        private void FillEntryForm(UserProfile profile)
        {
            txtFirstName.Text = profile.FirstName;
            txtLastName.Text = profile.LastName;
            txtMiddleName.Text = profile.MiddleName;
            txtUserName.Text = profile.UserName;
            txtEmailAddress.Text = profile.EmailAddress;
            chkIsActive.IsChecked = profile.IsActive;
            txtPhoneNum.Text = profile.Phone;
            txtAddress1.Text = profile.Address;
            txtCity.Text = profile.City;
            txtState.Text = profile.State;
            txtZIP.Text = profile.Zip;
            cmbRoleName.Text = profile.RoleName;

        }


        #region 'Window Events'

        /// <summary>
        /// Close button - click event
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="System.Windows.RoutedEventArgs" /> instance containing the event data.</param>
        private void btnClose_Click(object sender, RoutedEventArgs e)
        {

            this.Close();
            this.Cursor = Cursors.Arrow;
        }


        /// <summary>
        /// Handles the Click event of the btnCancel control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                EnableDisableForm(false);
                CleanEntryForm();

            }
            catch (Exception ex)
            {
                throw;
            }
        }

        #endregion

        /// <summary>
        /// User List Grid - Grid item selection change event
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="System.Windows.Controls.SelectionChangedEventArgs"/> instance containing the event data.</param>
        private void grdUserList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (grdUserList.SelectedItem != null)
            {
                try
                {
                    UserProfile selectedUsersProfile = (UserProfile)grdUserList.SelectedItem;
                    FillEntryForm(selectedUsersProfile);
                    EnableDisableForm(true);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("You must select a line with event in it.");
                }
            }
        }


        #endregion

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (grdUserList.SelectedItem != null)
            {
                try
                {
                    var selectedUser = (UserProfile)grdUserList.SelectedItem;

                    MessageBoxResult _result = MessageBox.Show("Are you sure you want to delete this User record, User Id - " + Convert.ToString(selectedUser.UserID), "Delete Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question);

                    if (_result == MessageBoxResult.Yes)
                    {
                        if (userProfileManagerObj.DeleteUser(selectedUser.UserID))
                        {
                            MessageBox.Show("Selected user has been deleted.");
                            DisplayUserData();
                            CleanEntryForm();
                        }
                    }
                }
                catch
                {
                    MessageBox.Show("You must select a line with user in it.");
                }
            }
        }

        /// <summary>
        /// Cleans the entry form.
        /// </summary>
        private void CleanEntryForm()
        {
            txtFirstName.Text = string.Empty;
            txtLastName.Text = string.Empty;
            txtMiddleName.Text = string.Empty;
            txtUserName.Text = string.Empty;
            txtEmailAddress.Text = string.Empty;
            chkIsActive.IsChecked = false;
            txtPhoneNum.Text = string.Empty;
            txtAddress1.Text = string.Empty;
            txtCity.Text = string.Empty;
            txtState.Text = string.Empty;
            txtZIP.Text = string.Empty;
            cmbRoleName.Text = string.Empty;
            isEdit = false;

        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            isEdit = true;
            grdCustEntryForm.IsEnabled = true;
            btnDelete.IsEnabled = false;
            btnSave.IsEnabled = true;
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string firstName = txtFirstName.Text;
                string lastName = txtLastName.Text;
                string middleName = txtMiddleName.Text;
                string emailID = txtEmailAddress.Text;
                string phone = txtPhoneNum.Text;
                string userName = txtUserName.Text;
                string address = txtAddress1.Text;
                string city = txtCity.Text;
                string state = txtState.Text;
                string postalcode = txtZIP.Text;
                bool isActive = chkIsActive.IsChecked.Value;
                string roleName = cmbRoleName.Text;

                if (!isEdit)
                {
                    if ((firstName != string.Empty) && (lastName != string.Empty) && (phone != string.Empty) && (!String.IsNullOrEmpty(emailID)) && (!String.IsNullOrEmpty(userName))
                        && (!String.IsNullOrEmpty(address)) && (!String.IsNullOrEmpty(city)) && (!String.IsNullOrEmpty(state)) && (!String.IsNullOrEmpty(postalcode)) && (!String.IsNullOrEmpty(roleName)))
                    {
                        if (userProfileManagerObj.InsertNewUser(firstName, lastName, middleName, userName, emailID, phone, address, postalcode, city, state, roleName, isActive, ""))
                        {

                            MessageBox.Show("New User has been added.", "New Record", MessageBoxButton.OK, MessageBoxImage.Information);
                            CleanEntryForm();
                            DisplayUserData();
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
                if (isEdit)
                {

                    if (grdUserList.SelectedItem != null)
                    {
                        try
                        {
                            var selectedUser = (UserProfile)grdUserList.SelectedItem;

                            MessageBoxResult _result = MessageBox.Show("Are you sure you want to update this users record, user Id - " + selectedUser.UserID.ToString(), "Edit Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question);

                            if (_result == MessageBoxResult.Yes)
                            {

                                if ((firstName != string.Empty) && (lastName != string.Empty) && (phone != string.Empty) && (!String.IsNullOrEmpty(emailID)) && (!String.IsNullOrEmpty(userName))
                         && (!String.IsNullOrEmpty(address)) && (!String.IsNullOrEmpty(city)) && (!String.IsNullOrEmpty(state)) && (!String.IsNullOrEmpty(postalcode)) && (!String.IsNullOrEmpty(roleName)))
                                {

                                    UserProfile _editUser = new UserProfile();
                                    _editUser.UserID = selectedUser.UserID;
                                    _editUser.FirstName = firstName;
                                    _editUser.LastName = lastName;
                                    _editUser.EmailAddress = emailID;
                                    _editUser.Phone = phone;
                                    _editUser.Address = address;
                                    _editUser.City = city;
                                    _editUser.State = state;
                                    _editUser.Zip = postalcode;
                                    _editUser.MiddleName = middleName;
                                    _editUser.UserName = userName;
                                    _editUser.IsActive = isActive;
                                    _editUser.RoleName = roleName;

                                    if (userProfileManagerObj.UpdateUser(_editUser))
                                    {
                                        MessageBox.Show("Selected user has been updated.");
                                        DisplayUserData();
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
                            MessageBox.Show("You must select a line in grid with user in it.");
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
