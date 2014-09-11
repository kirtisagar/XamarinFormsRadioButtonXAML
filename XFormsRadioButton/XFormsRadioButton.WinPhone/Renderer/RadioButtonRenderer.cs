using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using Xamarin.Forms;
using Xamarin.Forms.Platform.WinPhone;
using XFormsRadioButton.CustomControls;
using XFormsRadioButton.WinPhone.Controls;

[assembly: ExportRenderer(typeof(CustomRadioButton), typeof(RadioButtonRenderer))]

namespace XFormsRadioButton.WinPhone.Controls
{
  
    using NativeCheckBox = System.Windows.Controls.RadioButton;
    public class RadioButtonRenderer : ViewRenderer<CustomRadioButton, System.Windows.Controls.RadioButton>
    {
        protected override void OnElementChanged(ElementChangedEventArgs<CustomRadioButton> e)
        {
            base.OnElementChanged(e);

            if (e.OldElement != null)
            {
                e.OldElement.CheckedChanged -= CheckedChanged;
            }

            if (this.Control == null)
            {
                var checkBox = new NativeCheckBox();
                checkBox.Checked += (s, args) => this.Element.Checked = true;
                checkBox.Unchecked += (s, args) => this.Element.Checked = false;

                this.SetNativeControl(checkBox);
            }

            this.Control.Content = e.NewElement.Text;
            this.Control.IsChecked = e.NewElement.Checked;
           

            this.Element.CheckedChanged += CheckedChanged;
            this.Element.PropertyChanged += ElementOnPropertyChanged;
        }

        private void ElementOnPropertyChanged(object sender, PropertyChangedEventArgs propertyChangedEventArgs)
        {
            switch (propertyChangedEventArgs.PropertyName)
            {
                case "Checked":
                    this.Control.IsChecked = this.Element.Checked;
                    break;
                case "TextColor":
                    //this.Control.Foreground = this.Element.TextColor ToBrush();
                    break;
                case "Text":
                    this.Control.Content = Element.Text;
                    break;
                default:
                    System.Diagnostics.Debug.WriteLine("Property change for {0} has not been implemented.", propertyChangedEventArgs.PropertyName);
                    break;
            }
        }

        private void CheckedChanged(object sender, EventArgs<bool> eventArgs)
        {
            Device.BeginInvokeOnMainThread(() =>
            {
                this.Control.Content = this.Element.Text;
                this.Control.IsChecked = eventArgs.Value;
            });
        }

       
    }
}
