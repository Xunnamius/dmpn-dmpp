using System;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace DMPN_prototype.ViewModels
{
	public class DebugViewModel : INotifyPropertyChanged
    {
        public DebugViewModel()
        {
            this.Items = new ObservableCollection<DebugItemViewModel>();
        }

        /// <summary>
        /// Adds an item to the observablecollection
        /// </summary>
        /// <param name="title">Debug entry title</param>
        /// <param name="data">Debug entry data</param>
        /// <returns>A reference to the entry item.</returns>
        public DebugItemViewModel AddEntry(string title, string data)
        {
            this.Items.Add(new DebugItemViewModel() { Title = title, Data = data });
            return this.Items[this.Items.Count-1];
        }

        public DebugItemViewModel AddEntry(DebugItemViewModel obj)
        {
            this.Items.Add(obj);
            return this.Items[this.Items.Count - 1];
        }

        /// <summary>
        /// A collection for DebugItemViewModel objects.
        /// </summary>
        public ObservableCollection<DebugItemViewModel> Items { get; private set; }
        
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