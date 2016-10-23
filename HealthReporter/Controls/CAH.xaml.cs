﻿using System;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using HealthReporter.Models;

namespace HealthReporter.Controls
{
    /// <summary>
    /// Interaction logic for ClientAppraisalHistoryControl.xaml
    /// </summary>
    public partial class CAH : UserControl
    {
        private Client client;
        private MainWindow _parent;


        public CAH(MainWindow _parent)
        {

            this._parent = _parent;
        }

        public CAH(MainWindow _parent, Client client) : this(_parent)
        {
            InitializeComponent();
            this._parent = _parent;
            this.client = client;
            ClientInfo.DataContext = client;
        }

        private void btn_Back(object sender, RoutedEventArgs e)
        {
            this._parent.stkTest.Children.Clear();
            ClientUserControl obj = new ClientUserControl(this._parent);
            this._parent.stkTest.Children.Add(obj);
        }
        
        private void btn_NewAppraisal(object sender, RoutedEventArgs e)
        {
            this._parent.stkTest.Children.Clear();
            CAH_SelectTestControl obj = new CAH_SelectTestControl(this._parent,client);
            this._parent.stkTest.Children.Add(obj);
        }

        private void btn_AddTest(object sender, RoutedEventArgs e)
        {

        }

        private void btn_Report(object sender, RoutedEventArgs e)
        {

        }
    }
}