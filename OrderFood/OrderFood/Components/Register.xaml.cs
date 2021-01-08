using OrderFood.Modals;
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
        static List<User> ListUsers = new List<User>();
        private void Button_Clicked(object sender, EventArgs e)
        {
            if(username.Text==null|| password.Text==null || address.Text==null || email.Text==null || phone.Text==null || age.Text==null)
            {
                DisplayAlert("Notify", "Please fill in full!", "OK");
                
            }
            else
            {
                User user = new User { UserName=username.Text,Password=password.Text,Address=address.Text,Email=email.Text,Phone=phone.Text,Age=age.Text};
                if (ListUsers.Any(item => item.UserName == user.UserName) == true)
                {

                    DisplayAlert("Notify", "Account already exists!", "OK");
                }
                else
                {
                    ListUsers.Add(user);
                    Navigation.PushAsync(new Login(ListUsers,user));
                    DisplayAlert("Notify", "Register success!!!", "OK");
                }
            }
        }
    }
}