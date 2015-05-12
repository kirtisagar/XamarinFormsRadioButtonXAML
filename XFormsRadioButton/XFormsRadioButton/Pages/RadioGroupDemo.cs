using System;

using Xamarin.Forms;
using XFormsRadioButton.ViewModel;
using XFormsRadioButton.CustomControls;

namespace XFormsRadioButton.Pages
{
    public class RadioGroupDemo : ContentPage
    {
        private Label txtSelected;
        private BindableRadioGroup radioGroup;

        public RadioGroupDemo()
        {
            BindingContext = new RadioGroupDemoViewModel();
            txtSelected = GetLabel("Selected Item is");
            radioGroup = GetRadioGroup();

            Content = new StackLayout
                {
                    VerticalOptions = LayoutOptions.Start,
                    Children =
                        {
                            GetLabel("Hello"),
                            radioGroup,
                            txtSelected,
                            new StackLayout
                            {
                                Children =
                                    {
                                        GetLabel("Selected The Index"),
                                        GetEntry()
                                    }
                                }
                        }
                    };
            radioGroup.CheckedChanged += SelectionChangedEventHandler;
        }

        //event handler
        void SelectionChangedEventHandler(object sender, int e)
        {
            var radio = sender as CustomRadioButton;
            if(radio == null || radio.Id == -1)
            {
                return;
            }
            txtSelected.Text = radio.Text;
        }


        private Entry GetEntry()
        {
            Entry returnValue = new Entry
                {
                    HorizontalOptions = LayoutOptions.Center,
                    VerticalOptions = LayoutOptions.Center,
                };
            var selectedIndexBinding = new Binding("SelectedIndex");
            returnValue.SetBinding(Entry.TextProperty, "SelectedIndex");
            return returnValue;
        }

        private Label GetLabel (String text){
            return new Label
            {
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,
                Text = text,
            };
        }

        private BindableRadioGroup GetRadioGroup()
        {
            var rads = new BindableRadioGroup();
            var selectedIndexBinding = new Binding("SelectedIndex");
            rads.SetBinding(BindableRadioGroup.ItemsSourceProperty, "MyList.Values");
            rads.SetBinding(BindableRadioGroup.SelectedIndexProperty, "SelectedIndex");
            return rads;
        }
    }

}
