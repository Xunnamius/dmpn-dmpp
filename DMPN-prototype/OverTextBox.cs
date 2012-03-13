using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace DMPN_prototype
{
	public class OverTextBox : TextBox
	{
		public static readonly DependencyProperty DefaultTextProperty =
			DependencyProperty.Register("DefaultText", typeof(string), typeof(OverTextBox), new PropertyMetadata(""));

        public string DefaultText
        {
            get { return GetValue(DefaultTextProperty).ToString(); }
            set
            {
                SetValue(DefaultTextProperty, value.Trim());
                SetDefaultText();
            }
        }
		
		public void SetDefaultText(bool forced = false)
		{
			if(this.Text.Length == 0 || forced)
				this.Text = DefaultText;
            else this.Text = this.Text.Trim();
		}
		
		public OverTextBox()
		{
			this.GotFocus += (sender, e) =>
            {
                if(this.Text.Equals(DefaultText))
                    this.Text = string.Empty;
                else this.Text = this.Text.Trim();
            };

        	this.LostFocus += (sender, e) => { SetDefaultText(); };
			this.Loaded += (sender, e) => { SetDefaultText(); };
		}

        public bool InDefaultState()
        {
            return this.Text.Equals(DefaultText);
        }
	}
}