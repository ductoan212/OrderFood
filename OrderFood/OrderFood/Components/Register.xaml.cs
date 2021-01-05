using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace OrderFood.Components
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Register : ContentPage
    {
        public Register()
        {
            InitializeComponent();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            
            if(username.Text==null|| password.Text==null || address.Text==null || email.Text==null || phone.Text==null || age.Text==null)
            {
                DisplayAlert("Notify", "Please fill in full!", "OK");
                
            }
            else
            {
                string user=username.Text, pass=password.Text;

            Navigation.PushAsync(new Login(user,pass));
            DisplayAlert("Notify", "Register success!!!", "OK");
            }
        }
    }
}