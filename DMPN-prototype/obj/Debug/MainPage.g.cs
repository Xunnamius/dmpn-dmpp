﻿#pragma checksum "F:\Blend\Projects\DMPN-prototype\DMPN-prototype\MainPage.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "F703E26E2CDB8354237A2B1485CE649F"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.239
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using DMPN_prototype;
using Microsoft.Phone.Controls;
using System;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Automation.Peers;
using System.Windows.Automation.Provider;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Resources;
using System.Windows.Shapes;
using System.Windows.Threading;


namespace DMPN_prototype {
    
    
    public partial class MainPage : Microsoft.Phone.Controls.PhoneApplicationPage {
        
        internal System.Windows.Controls.Grid LayoutRoot;
        
        internal DMPN_prototype.OverTextBox txtDestination;
        
        internal DMPN_prototype.OverTextBox txtSource;
        
        internal DMPN_prototype.OverTextBox txtMessage;
        
        internal System.Windows.Controls.Button btnSend;
        
        internal System.Windows.Controls.ListBox FirstListBox;
        
        internal System.Windows.Controls.ListBox SecondListBox;
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Windows.Application.LoadComponent(this, new System.Uri("/DMPN_prototype;component/MainPage.xaml", System.UriKind.Relative));
            this.LayoutRoot = ((System.Windows.Controls.Grid)(this.FindName("LayoutRoot")));
            this.txtDestination = ((DMPN_prototype.OverTextBox)(this.FindName("txtDestination")));
            this.txtSource = ((DMPN_prototype.OverTextBox)(this.FindName("txtSource")));
            this.txtMessage = ((DMPN_prototype.OverTextBox)(this.FindName("txtMessage")));
            this.btnSend = ((System.Windows.Controls.Button)(this.FindName("btnSend")));
            this.FirstListBox = ((System.Windows.Controls.ListBox)(this.FindName("FirstListBox")));
            this.SecondListBox = ((System.Windows.Controls.ListBox)(this.FindName("SecondListBox")));
        }
    }
}

