XamarinFormsRadioButtonXAML
===========================

Radio button and Radio Group for Xamarin.Forms just works like [Picker](http://iosapi.xamarin.com/?link=T%3aXamarin.Forms.Picker)  and it is bindable in XAML. 

This Sample demostrated using MVVM design pattern. 

it is an extension to (https://github.com/XForms/Xamarin-Forms-Labs)

###Radio Group in Android
![Demo] (https://raw.githubusercontent.com/kirtisagar/XamarinFormsRadioButtonXAML/master/2014-09-09-17-10-52.png)

###Radio Group in iOS
![Demo] (https://github.com/kirtisagar/XamarinFormsRadioButtonXAML/blob/master/RadioButtoniOS.jpg)

###Radio Group in Windows Phone (Coming soon..)



#### Super easy to use. 

Xaml :

Reference the assembly namespace

           xmlns:custom="clr-namespace:XFormsRadioButton.CustomControls;assembly=XFormsRadioButton"
           
Render your control:

           <custom:BindableRadioGroup x:Name="MyRadiouGroup" 
             ItemsSource="{Binding Path=MyList.Values}" 
             SelectedIndex="{Binding SelectedIndex}" VerticalOptions="Start" />

To suscribe for Radio Button Checked event, follow this code.              
Code behing of Xaml: 

             MyRadiouGroup.CheckedChanged += MyRadiouGroup_CheckedChanged;	
             
             void MyRadiouGroup_CheckedChanged(object sender, int e)
             {
               var radio = sender as CustomRadioButton;

               if (radio == null || radio.Id == -1) return;
               
               // Display selected value in Label   
                txtSelected.Text = radio.Text;

             }
 
 In The ViewModel, you need to provide the ItemSource as Dictionary of type <int, string>, Ex. Dictionary<int, string>();
 
            private Dictionary<int, string> myList;
            public Dictionary<int, string> MyList
            {
              get { return myList; }
              set
              {
                myList = value;
                NotifyPropertyChanged("MyList");
              }
             }
             
             private void LoadData()
             {
               for (int i = 0; i < 3; i++)
                {
                  MyList.Add(i, "Item " + i); 
                }
              }

              
If you are stuck, let me know - [@kirtisagar](http://twitter.com/Kirtisagar)
