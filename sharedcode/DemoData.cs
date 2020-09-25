// (C) 2020 FOTEC Forschungs- und Technologietransfer GmbH
// Das Forschungsunternehmen der Fachhochschule Wiener Neustadt
// 
// Kontakt biss@fotec.at / www.fotec.at
// 
// Erstversion vom 24.09.2020 14:38
// Entwickler      Michael Kollegger
// Projekt         swd2020

using System;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using PropertyChanged;

namespace sharedcode
{
    public class DomoData : INotifyPropertyChanged, IDisposable
    {
        private readonly object _readLock = new object();
        private readonly Task _worker;
        private readonly CancellationTokenSource _workerToker = new CancellationTokenSource();

        public DomoData()
        {
            _worker = new Task(async () =>
            {
                do
                {
                    await Task.Delay(1000, _workerToker.Token).ConfigureAwait(false);
                    Counter++;
                } while (!_workerToker.IsCancellationRequested);
            });
            _worker.Start();
        }

        #region Properties

        public int Counter { get; set; }

        [DependsOn(nameof(Counter))]
        public string Data
        {
            get
            {
                lock (_readLock)
                {
                    return $"Counter Value: {Counter}";
                }
            }
        }

        #endregion

        #region Interface Implementations

        public void Dispose()
        {
            _workerToker.Cancel();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion
    }
}