using System.Diagnostics;
using System.IO.IsolatedStorage;
using System.Windows;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Newtonsoft.Json;

namespace DMPN_prototype
{
    public partial class App : Application
    {
        // Singleton pattern
        private static QueueViewModel _queueViewModel = null;
        private static DebugViewModel _debugViewModel = null;

        /// <summary>
        /// A static ViewModel used by the views to bind against.
        /// </summary>
        /// <returns>The MainViewModel object.</returns>
        public static QueueViewModel queueViewModel
        {
            get
            {
                // Delay creation of the view model until necessary
                if(_queueViewModel == null)
                    _queueViewModel = new QueueViewModel();

                return _queueViewModel;
            }

            private set
            {
                _queueViewModel = value;
            }
        }

        /// <summary>
        /// A static ViewModel used by the views to bind against.
        /// </summary>
        /// <returns>The DebugViewModel object.</returns>
        public static DebugViewModel debugViewModel
        {
            get
            {
                if(_debugViewModel == null)
                    _debugViewModel = new DebugViewModel();
                return _debugViewModel;
            }
        }

        /// <summary>
        /// Provides easy access to the root frame of the Phone Application.
        /// </summary>
        /// <returns>The root frame of the Phone Application.</returns>
        public PhoneApplicationFrame RootFrame { get; private set; }

        /// <summary>
        /// Constructor for the Application object.
        /// </summary>
        public App()
        {
            // Global handler for uncaught exceptions. 
            // Note that exceptions thrown by ApplicationBarItem.Click will not get caught here.
            UnhandledException += Application_UnhandledException;

            // Show graphics profiling information while debugging.
            if (System.Diagnostics.Debugger.IsAttached)
            {
                // Display the current frame rate counters.
                Application.Current.Host.Settings.EnableFrameRateCounter = true;

                // Show the areas of the app that are being redrawn in each frame.
                //Application.Current.Host.Settings.EnableRedrawRegions = true;

                // Enable non-production analysis visualization mode, 
                // which shows areas of a page that are being GPU accelerated with a colored overlay.
                //Application.Current.Host.Settings.EnableCacheVisualization = true;
            }

            // Standard Silverlight initialization
            InitializeComponent();

            // Phone-specific initialization
            InitializePhoneApplication();
        }

        // Code to execute when the application is launching (eg, from Start)
        // This code will not execute when the application is reactivated
        private void Application_Launching(object sender, LaunchingEventArgs e)
        {
            Debug.WriteLine("App Launching...");
            this.unpersist();

            if(App.queueViewModel.Items.Count == 0)
            {
                App.debugViewModel.AddEntry("Version", "0.6.4-prototype");
                App.debugViewModel.AddEntry("Credits", "Lead Developers: Bernard Dickens, Shawn Wilkinson\nJunior Developers: Stephen Stafford, Aaron Owens\nMentor: Dr. Kenneth R. Perry\nFaculty: Prof. Sonya Dennis, Prof. Henry Cook, Dr. Kinnis Gosha\nJames Newton-King's Json.NET lib");

                App.queueViewModel.AddEntry("sam@mail.microsoft.com", "anna@microsoft.com", "Hello! Network features are not operational, currently, since this is only a prototype.", QueueViewModel.DUMPED);
                App.queueViewModel.AddEntry("b.dickens@darkgray.org", "super3@gmail.com", "Is it possible to test wifi in a spacial capacity with an emulator?! ~Shawn", QueueViewModel.EXPIRED);
            }
        }

        // Code to execute when the application is activated (brought to foreground)
        // This code will not execute when the application is first launched
        private void Application_Activated(object sender, ActivatedEventArgs e)
        {
            Debug.WriteLine("Application Activated.");
            this.unpersist();
        }

        // Code to execute when the application is deactivated (sent to background)
        // This code will not execute when the application is closing
        private void Application_Deactivated(object sender, DeactivatedEventArgs e)
        {
            Debug.WriteLine("Application Deactivated.");
            this.persist();
        }

        // Code to execute when the application is closing (eg, user hit Back)
        // This code will not execute when the application is deactivated
        private void Application_Closing(object sender, ClosingEventArgs e)
        {
            Debug.WriteLine("Application Closing...");
            this.persist();
        }

        /// <summary>
        /// Stores the QueueViewModel
        /// </summary>
        private void persist()
        {
            if(IsolatedStorageSettings.ApplicationSettings.Contains("QueueViewModel"))
                IsolatedStorageSettings.ApplicationSettings["QueueViewModel"] = JsonConvert.SerializeObject(queueViewModel);
            else
                IsolatedStorageSettings.ApplicationSettings.Add("QueueViewModel", JsonConvert.SerializeObject(queueViewModel));
            IsolatedStorageSettings.ApplicationSettings.Save();
            Debug.WriteLine("[Application State Serialized]");
        }

        /// <summary>
        /// Restores the QueueViewModel
        /// </summary>
        private void unpersist()
        {
            if(IsolatedStorageSettings.ApplicationSettings.Contains("QueueViewModel"))
            {
                string str = IsolatedStorageSettings.ApplicationSettings["QueueViewModel"].ToString();
                queueViewModel = JsonConvert.DeserializeObject<QueueViewModel>(str);
                App.debugViewModel.AddEntry("unpersist() data", str);
                Debug.WriteLine("[Application State Deserialized]");
            }
        }

        // Code to execute if a navigation fails
        private void RootFrame_NavigationFailed(object sender, NavigationFailedEventArgs e)
        {
            if (System.Diagnostics.Debugger.IsAttached)
            {
                // A navigation has failed; break into the debugger
                System.Diagnostics.Debugger.Break();
            }
        }

        // Code to execute on Unhandled Exceptions
        private void Application_UnhandledException(object sender, ApplicationUnhandledExceptionEventArgs e)
        {
            if (System.Diagnostics.Debugger.IsAttached)
            {
                // An unhandled exception has occurred; break into the debugger
                System.Diagnostics.Debugger.Break();
            }
        }

        #region Phone application initialization

        // Avoid double-initialization
        private bool phoneApplicationInitialized = false;

        // Do not add any additional code to this method
        private void InitializePhoneApplication()
        {
            if (phoneApplicationInitialized)
                return;

            // Create the frame but don't set it as RootVisual yet; this allows the splash
            // screen to remain active until the application is ready to render.
            RootFrame = new PhoneApplicationFrame();
            RootFrame.Navigated += CompleteInitializePhoneApplication;

            // Handle navigation failures
            RootFrame.NavigationFailed += RootFrame_NavigationFailed;

            // Ensure we don't initialize again
            phoneApplicationInitialized = true;
        }

        // Do not add any additional code to this method
        private void CompleteInitializePhoneApplication(object sender, NavigationEventArgs e)
        {
            // Set the root visual to allow the application to render
            if (RootVisual != RootFrame)
                RootVisual = RootFrame;

            // Remove this handler since it is no longer needed
            RootFrame.Navigated -= CompleteInitializePhoneApplication;
        }

        #endregion
    }
}