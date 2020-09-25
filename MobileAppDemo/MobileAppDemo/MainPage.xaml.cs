// (C) 2020 FOTEC Forschungs- und Technologietransfer GmbH
// Das Forschungsunternehmen der Fachhochschule Wiener Neustadt
// 
// Kontakt biss@fotec.at / www.fotec.at
// 
// Erstversion vom 25.09.2020 08:13
// Entwickler      Michael Kollegger
// Projekt         swd2020

using System;
using sharedcode;
using Xamarin.Forms;

namespace MobileAppDemo
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            BindingContext = this;
        }

        #region Properties

        public DomoData Data { get; set; } = new DomoData();

        #endregion
    }
}