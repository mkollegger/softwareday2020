// (C) 2020 FOTEC Forschungs- und Technologietransfer GmbH
// Das Forschungsunternehmen der Fachhochschule Wiener Neustadt
// 
// Kontakt biss@fotec.at / www.fotec.at
// 
// Erstversion vom 24.09.2020 16:04
// Entwickler      Michael Kollegger
// Projekt         swd2020

using System;
using System.Windows;
using sharedcode;

namespace DesktopApp
{
    /// <summary>
    ///     Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
        }

        #region Properties

        public DomoData Data { get; set; } = new DomoData();

        #endregion
    }
}