﻿using BLAPI;
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

namespace PL.WPF
{
    /// <summary>
    /// Interaction logic for UpdateDistanceAndTime.xaml
    /// </summary>
    public partial class UpdateDistanceAndTime : Window
    {
        IBL bl;
        BO.StationInLine station;
        //BO.StationInLine nextStat;
        public UpdateDistanceAndTime(IBL _bl, BO.StationInLine _station/*, BO.StationInLine Nstation*/)
        {
            InitializeComponent();
            bl = _bl;
            station = _station;
            

        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {

        }
    }
    }


