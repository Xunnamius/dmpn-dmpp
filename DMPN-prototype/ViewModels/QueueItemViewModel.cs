using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace DMPN_prototype
{
    public class QueueItemViewModel : INotifyPropertyChanged 
    {
        private static int SubtitleLength = 50;
        private string _Destination, _Source, _Message, _MessageExcerpt, _Status;

        /// <summary>
        /// The message's destination
        /// </summary>
        /// <returns>Destination email of the message</returns>
        public string Destination
        {
            get 
            {
                return _Destination;
            }

            set 
            {
                _Destination = value;
                NotifyPropertyChanged("Destination");
            }
        }
        
        /// <summary>
        /// The message's sender
        /// </summary>
        /// <returns>Source email of the message</returns>
        public string Source
        {
            get
            {
                return _Source;
            }

            set
            {
                _Source = value;
                NotifyPropertyChanged("Source");
            }
        }

        /// <summary>
        /// A small excerpt of the message field
        /// </summary>
        /// <returns>25-character string</returns>
        public string MessageExcerpt
        {
            get
            {
                return _MessageExcerpt;
            }
            
			private set
			{
                _MessageExcerpt = value;
                NotifyPropertyChanged("MessageExcerpt");
            }
        }
		
		/// <summary>
        /// The message body
        /// </summary>
        /// <returns>Full message contents</returns>
        public string Message
        {
            get
            {
                return _Message;
            }

            set
            {
                _Message = value;
                MessageExcerpt = _Message.Substring(0, _Message.Length < SubtitleLength ? _Message.Length : SubtitleLength);
                if(_Message.Length >= SubtitleLength) MessageExcerpt += "...";
                NotifyPropertyChanged("Message");
            }
        }
		
		/// <summary>
        /// The entry's status (was it sent/pruned/dumped)
        /// </summary>
        /// <returns>Status of the message</returns>
        public string Status
        {
            get
            {
                return _Status;
            }

            set
            {
                _Status = value;
                NotifyPropertyChanged("Status");
            }
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