// (C) 2020 FOTEC Forschungs- und Technologietransfer GmbH
// Das Forschungsunternehmen der Fachhochschule Wiener Neustadt
// 
// Kontakt biss@fotec.at / www.fotec.at
// 
// Erstversion vom 24.09.2020 15:19
// Entwickler      Michael Kollegger
// Projekt         swd2020

using System;
using System.ComponentModel;
using sharedcode;

namespace ConsoleDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            var dd = new DomoData();
            dd.PropertyChanged += Dd_PropertyChanged;

            Console.WriteLine("Demo is running ... ENTER to end!");
            Console.ReadLine();
        }

        private static void Dd_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            var t = (DomoData) sender;

            if (e.PropertyName == nameof(t.Data)) Console.WriteLine(t.Data);
        }
    }
}