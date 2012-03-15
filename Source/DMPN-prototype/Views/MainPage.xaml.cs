using System;
using System.Windows;
using Microsoft.Phone.Controls;
using System.Diagnostics;
using DMPN_prototype.ViewModels;

// TODO: We need (deep) settings of some kind and long-press functionality in the queue!

namespace DMPN_prototype.Views
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
            App.queueViewModel.AddEntry(("8826" + ((new Random(999)).Next()).ToString()) + "@tmobile", "spysrs2@gmail.com", "test2.", QueueViewModel.PROPAGATING);
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

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult m = MessageBox.Show("This will clear sent and expired packets. Are you sure?", "Clear Packets?", MessageBoxButton.OKCancel);
            if (m == MessageBoxResult.OK)
            {
                App.queueViewModel.cleanEntries();
            }
        }

        private void btnClearAll_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult m = MessageBox.Show("This will clear all packets. Are you sure?", "Clear Packets?", MessageBoxButton.OKCancel);
            if (m == MessageBoxResult.OK)
            {
                App.queueViewModel.clearAllEntries();
            }
        }
    }
}