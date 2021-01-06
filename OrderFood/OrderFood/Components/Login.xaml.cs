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
    public partial class Login : ContentPage
    {
        public Login()
        {
            InitializeComponent();
           
        }
        List<User> ListUsersLogin = new List<User>();
        public Login(List<User> list,User user)
        {
            InitializeComponent();
            InitAccount(user);
            ListUsersLogin = list;

        }
        public void InitAccount(User user)
        {
            usernameLogin.Text = user.UserName;
            passwordLogin.Text = user.Password;
        }
        private void Button_Clicked(object sender, EventArgs e)
        {

            var username = usernameLogin.Text;
            var password = passwordLogin.Text;
            User user = ListUsersLogin.Find(item => item.UserName == username);
            if (username == "ad" && password == "ad")
            {
                User admin = new User {UserName="ADMIN", Password="ad",Phone="123456789",Email="VietNam@gmail.vn",Address="Thu Duc district,HCM city,Viet Nam",Age="18"};
                Navigation.PushAsync(new BottomNavBarXf.Home(admin));
            }
            else if (user!=null)
            {

            if (username == user.UserName && password == user.Password||username =="ad"&&password=="ad")
            {
                Navigation.PushAsync(new BottomNavBarXf.Home(user));
                //Application.Current.MainPage = new BottomNavBarXf.Home();

            }
            else
            {
                DisplayAlert("Notification", "User name or Password incorrect!", "OK");
            }
            }
        }

        

        private void Button_Clicked_2(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Register());
        }
    }
}