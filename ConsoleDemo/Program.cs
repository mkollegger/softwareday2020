using sharedcode;
using System;

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

        private static void Dd_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            var t = (DomoData)sender;

            if (e.PropertyName == nameof(t.Data))
            {
                Console.WriteLine(t.Data);
            }
        }
    }
}
