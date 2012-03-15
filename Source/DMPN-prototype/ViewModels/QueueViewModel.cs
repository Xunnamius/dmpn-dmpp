using System;
using System.ComponentModel;
using System.Collections.ObjectModel;
using System.Collections.Generic;

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
        /// <param name="status">Message network status</param>
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

        /// <summary>
        /// Deletes an object from the Queue
        /// </summary>
        /// <param name="obj">Item to delete</param>
        private void DeleteEntry(QueueItemViewModel obj)
        {
            this.Items.Remove(obj);
        }

        /// <summary>
        /// Clears any Dumped or Expired Packs from the Queue
        /// </summary>
        public void cleanEntries()
        { 
            List<QueueItemViewModel> dequeList = new List<QueueItemViewModel>();
            QueueItemViewModel anItem;

            // Loop through the Queue and find DUMPED and EXPIRED packets
            // Add them to a list to be dequed after all of Them are found
            for (int i = 0; i < this.Items.Count; i++)
            {
                anItem = this.Items[i];
                if (anItem.Status == QueueViewModel.DUMPED || anItem.Status == QueueViewModel.EXPIRED)
                    dequeList.Add(anItem);
            }

            // Delete all found packets from the queue
            foreach (QueueItemViewModel toDelete in dequeList)
                DeleteEntry(toDelete);
        }

        public void clearAllEntries()
        {
            this.Items.Clear();
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