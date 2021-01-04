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
    public partial class Login : ContentPage
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {

            var username = usernameLogin.Text;
            var password = passwordLogin.Text;
            if (username == "ad" && password == "ad")
            {
                //Navigation.PushAsync(new BottomNavBarXf.Home());
                Application.Current.MainPage = new BottomNavBarXf.Home();

            }
            else
            {
                DisplayAlert("Notification", "User name or Password incorrect!", "OK");
            }
        }
    }
}