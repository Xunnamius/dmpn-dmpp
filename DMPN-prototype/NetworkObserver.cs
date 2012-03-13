using System;
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
    /// <summary>
    /// This class holistically observers the phone's current
    /// network situation, exposing events for other classes
    /// to hook in to. Acts as a simple wrapper for a few of
    /// WP7's network detection functions.
    /// </summary>
    public class NetworkObserver
    {
        // TODO: Flesh this class out when we leave the prototype stage

        public delegate void PropertyChangeHandler(object sender, EventArgs data);
        public event PropertyChangeHandler PropertyChange;

        protected void OnPropertyChange(object sender, EventArgs data)
        {
            // Check if there are any Subscribers
            if(PropertyChange != null)
            {
                // Call the Event
                PropertyChange(this, data);
            }
        }  
    }
}
