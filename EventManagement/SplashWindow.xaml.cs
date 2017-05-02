// ***********************************************************************
// Assembly         : EventManagement
// Author           : PDUBEY
// Created          : 11-12-2015
//
// Last Modified By : PDUBEY
// Last Modified On : 11-26-2015
// ***********************************************************************
// <copyright file="SplashWindow.xaml.cs" company="">
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

namespace EventManagement
{
    /// <summary>
    /// Interaction logic for SplashWindow.xaml
    /// </summary>
    public partial class SplashWindow : Window
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SplashWindow"/> class.
        /// </summary>
        public SplashWindow()
        {
            
            this.Cursor = Cursors.Wait;
            InitializeComponent();
            this.Cursor = Cursors.Arrow;

            //double height = SystemParameters.WorkArea.Height;
            //double width = SystemParameters.WorkArea.Width;
            //this.Top = (height - this.Height) / 2;
            //this.Left = (width - this.Width) / 2;



        }


        /// <summary>
        /// Handles the Completed event of the Storyboard control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void Storyboard_Completed(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Wait;
            
            //LoginWindow objLoginWindow = new LoginWindow();
            //objLoginWindow.ShowDialog();
            //objLoginWindow = null;

            MainWindow objMainWindow = new MainWindow();
            objMainWindow.ShowDialog();
            objMainWindow = null;
            
            this.Close();
            this.Dispatcher.InvokeShutdown();
            this.Cursor = Cursors.Arrow;

        }

    }
}
