using PropertyChanged;
using System;
using System.ComponentModel;
using System.Diagnostics.Tracing;
using System.Threading;
using System.Threading.Tasks;

namespace sharedcode
{
    public class DomoData : INotifyPropertyChanged, IDisposable
    {
        public int Counter {get;set;}
        private object _readLock = new object();
        private Task _worker;
        private CancellationTokenSource _workerToker = new CancellationTokenSource();

        public DomoData()
        {
            _worker = new Task(async()=> 
            {
                do
                {
                    await Task.Delay(1000, _workerToker.Token).ConfigureAwait(false);
                    Counter++;
                } while (!_workerToker.IsCancellationRequested);
            });
            _worker.Start();
        }

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

        public event PropertyChangedEventHandler PropertyChanged;

        public void Dispose()
        {
            _workerToker.Cancel();
        }
    }
}
