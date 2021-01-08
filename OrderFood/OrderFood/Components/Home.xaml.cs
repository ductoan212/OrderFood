using BottomBar.XamarinForms;
using OrderFood.Components;
using OrderFood.Modals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
namespace BottomNavBarXf
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Home 
    {
        public Home()
        {
            InitializeComponent();
            InitUser();
        }
        static User currentUser = new User();
        public Home(User user)
        {
            InitializeComponent();
            currentUser = user;
            InitUser();
        }

        static List<Burger> ListBurgers = new List<Burger>();
        static List<Burger> ListFav = new List<Burger>();
        public Home(Burger burger, string str)
            {

                InitializeComponent();
            KhoiTaoCart(burger,str);
            InitUser();
            }
        public void InitUser()
        {
            usernameProfile.Text = currentUser.TenDN;
            ageProfile.Text = "Age : "+currentUser.Tuoi.ToString();
            addressProfile.Text = currentUser.DiaChi;
            emailProfile.Text = currentUser.Email;
            phoneProfile.Text = currentUser.Sdt;
        }
        public void KhoiTaoCart(Burger burger,string str)
        {
            if (str == "cart")
            {
                bool check = ListBurgers.Any(item=>item.Name==burger.Name);
                if (check==true)
                {
                    DisplayAlert("Notify", "Food existed in order list!", "OK");
                }
                else
                {

                ListBurgers.Add(burger);
                }
            lstfoods.ItemsSource = ListBurgers;
                lstfavorities.ItemsSource = ListFav;
            }
            else if (str == "fav")
            {
                bool check = ListFav.Any(item => item.Name == burger.Name);
                if (check ==true)
                {
                    DisplayAlert("Notify", "Food existed in favorities!", "OK");
                }
                else
                {

                    ListFav.Add(burger);
                }
                lstfavorities.ItemsSource = ListFav;
                lstfoods.ItemsSource = ListBurgers;
            }
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            Application.Current.MainPage = new NavigationPage(new Login());
        }
    }
    
}