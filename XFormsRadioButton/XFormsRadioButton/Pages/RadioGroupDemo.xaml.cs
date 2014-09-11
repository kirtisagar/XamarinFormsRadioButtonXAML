using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XFormsRadioButton.ViewModel;
using XFormsRadioButton;
using XFormsRadioButton.CustomControls;

namespace XFormsRadioButton.Pages
{
    public partial class RadioGroupDemo
    {
        public RadioGroupDemo()
        {
            InitializeComponent();
            this.BindingContext = new RadioGroupDemoViewModel();

            MyRadiouGroup.CheckedChanged += MyRadiouGroup_CheckedChanged;	
        }

        void MyRadiouGroup_CheckedChanged(object sender, int e)
        {
            var radio = sender as CustomRadioButton;

            if (radio == null || radio.Id == -1) return;

            txtSelected.Text = radio.Text;

           
        }

    }
}
