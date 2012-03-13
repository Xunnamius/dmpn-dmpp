using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;
using System.Windows.Navigation;

namespace DMPN_prototype
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();
            
            FirstListBox.DataContext  = App.queueViewModel;
            SecondListBox.DataContext = App.debugViewModel;

            this.Loaded +=new RoutedEventHandler(MainPage_Loaded);
        }

        private void MainPage_Loaded(object sender, RoutedEventArgs e)
        {
            App.queueViewModel.AddEntry(("65920"+((new Random(99999)).Next()).ToString())+"@tmobile", "spysrs2@gmail.com", "Lol.", QueueViewModel.DUMPED);
        }

        private void btnSend_Click(object sender, RoutedEventArgs e)
        {
            if(txtDestination.Text.Length == 0 || txtDestination.InDefaultState())
                MessageBox.Show("You forgot to enter a Destination.");
            else if(txtSource.Text.Length == 0 || txtSource.InDefaultState())
                MessageBox.Show("You forgot to enter a Source.");
            else if(txtMessage.Text.Length == 0 || txtMessage.InDefaultState())
                MessageBox.Show("You forgot to enter a Messsage.");
            else
            {
                App.queueViewModel.AddEntry(txtDestination.Text, txtSource.Text, txtMessage.Text);

                txtDestination.SetDefaultText(true);
                txtSource.SetDefaultText(true);
                txtMessage.SetDefaultText(true);

                MessageBox.Show("Your message has been added to your Queue!");
            }
        }
    }
}