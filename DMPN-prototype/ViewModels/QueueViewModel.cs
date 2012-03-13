using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Collections.ObjectModel;

namespace DMPN_prototype
{
    // TODO: Extract QueueViewModel and QueueItemViewModel into abstract classes and inherit
    public class QueueViewModel : INotifyPropertyChanged
    {
        public QueueViewModel()
        {
            this.Items = new ObservableCollection<QueueItemViewModel>();
        }

        /// <summary>
        /// A collection for ItemViewModel objects.
        /// </summary>
        public ObservableCollection<QueueItemViewModel> Items { get; private set; }
		
		public readonly static string PROPAGATING = "PROPAGATING";
		public readonly static string DUMPED = "DUMPED";
		public readonly static string EXPIRED = "EXPIRED";

        /// <summary>
        /// Adds an item to the observablecollection
        /// </summary>
        /// <param name="dest">Message destination email</param>
        /// <param name="source">Message source email</param>
        /// <param name="msg">Message contents (body)</param>
        /// <returns>A reference to the entry item.</returns>
        public QueueItemViewModel AddEntry(string dest, string source, string msg, string status=null)
        {
            this.Items.Add(new QueueItemViewModel() { Destination = dest, Source = source, Message = msg, Status = (status ?? QueueViewModel.PROPAGATING) });
            return this.Items[this.Items.Count-1];
        }

        public QueueItemViewModel AddEntry(QueueItemViewModel obj)
        {
            this.Items.Add(obj);
            return this.Items[this.Items.Count - 1];
        }

        public void SendEntry()
        {
            // Implement this next
        }
        
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(String propertyName)
        {
            if (null != PropertyChanged)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}