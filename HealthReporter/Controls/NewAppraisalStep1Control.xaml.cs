﻿using HealthReporter.Models;
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

namespace HealthReporter.Controls
{
    /// <summary>
    /// Interaction logic for NewAppraisalStep1Control.xaml
    /// </summary>
    public partial class NewAppraisalStep1Control : UserControl
    {
        public MainWindow _parent;
        private Client client;
        private Group group;

        public NewAppraisalStep1Control(MainWindow parentWindow, Client client, Group group)
        {
            InitializeComponent();
            this._parent = parentWindow;
            this.client = client;
            this.group = group;
        }

        private void btn_Back(object sender, RoutedEventArgs e)
        {
            int childNumber = this._parent.stkTest.Children.Count;
            this._parent.stkTest.Children.RemoveAt(childNumber - 1);
        }

        private void btn_Next(object sender, RoutedEventArgs e)
        {

            try {
                // New appraiser object
                Appraiser appraiser = new Appraiser();
                appraiser.id = System.Guid.NewGuid().ToByteArray();
                appraiser.name = appraisersName.Text.ToString();

                // New appraisal object
                Appraisal appraisal = new Appraisal();
                appraisal.id = System.Guid.NewGuid().ToByteArray();
                appraisal.appraiserId = appraiser.id;
                appraisal.clientId = client.id;
                DateTime enteredDate = Convert.ToDateTime(date.SelectedDate.ToString());
                appraisal.date = String.Format("{0:yyyy-MM-dd}", enteredDate);

                NewAppraisalStep2Control obj = new NewAppraisalStep2Control(this._parent, client, group, appraiser, appraisal);
                this._parent.stkTest.Children.Add(obj);

            } catch
            {
                MessageBox.Show("Please enter appraiser's name and/or appraisal's date.");
            }
            
        }
    }
}