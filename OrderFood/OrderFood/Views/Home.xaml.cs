using BottomBar.XamarinForms;
using Newtonsoft.Json;
using OrderFood.Components;
using OrderFood.Models;
using OrderFood.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
namespace BottomNavBarXf
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Home 
    {
        static User currentUser = new User();
        static List<MonAn> ListBurgers = new List<MonAn>();
        static List<MonAn> ListFav = new List<MonAn>();

        public Home()
        {
            InitializeComponent();
            ListFav = null;
            try
            {
                InitUser();
                InitFavorite();
            }
            catch
            {
                DisplayAlert("Lỗi", "Cần kết nối mạng để sử dụng app!!!", "OK");
            }
        }
        public Home(User user)
        {
            InitializeComponent();
            currentUser = user;
            ListFav = null;
            InitUser();
            InitFavorite();
        }
      
        public Home(MonAn burger, string str)
        {
            InitializeComponent();
            KhoiTaoCart(burger,str);
            InitUser();
        }
        public void InitUser()
        {
            usernameProfile.Text = currentUser.TenDN;
            ageProfile.Text = "Age : " + currentUser.Tuoi.ToString();
            addressProfile.Text = currentUser.DiaChi;
            emailProfile.Text = currentUser.Email;
            phoneProfile.Text = currentUser.Sdt;
            userName.Text = "Xin chào " + currentUser.HoTen;

            //usernameProfile.Text = "ductoan212";
            //ageProfile.Text = "20";
            //addressProfile.Text = "Hồ Chí Minh";
            //emailProfile.Text = "ductoan20102000@gmail.com";
            //phoneProfile.Text = "0123456789";
            //userName.Text = "Xin chào Toàn";
            //currentUser.MaKH = 1;
        }
        public async void InitFavorite()
        {
            var httpClient = new HttpClient();
            var response = await httpClient.GetStringAsync("http://www.orderfood212.somee.com/api/ServiceController/getYeuThichTheoKH?MaKH=" + currentUser.MaKH.ToString());
            ListFav =  JsonConvert.DeserializeObject<List<MonAn>>(response);
            lstfavorities.ItemsSource = ListFav;
        }
        public void KhoiTaoCart(MonAn burger,string str)
        {
            if (str == "cart")
            {
                bool check = ListBurgers.Any(item=>item.TenMA==burger.TenMA);
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
                bool check = ListFav.Any(item => item.TenMA == burger.TenMA);
                if (check ==true)
                {
                    DisplayAlert("Notify", "Food existed in favorities!", "OK");
                }
                else
                {
                    ListFav.Add(burger);
                    var httpClient = new HttpClient();
                    var response = httpClient.GetStringAsync("http://www.orderfood212.somee.com/api/ServiceController/createYeuThich?MaKH=" + currentUser.MaKH.ToString() +
                        "&MaMA=" + burger.MaMA.ToString() + "&GhiChu=abc");
                }
                lstfavorities.ItemsSource = ListFav;
                lstfoods.ItemsSource = ListBurgers;
            }
        }

        private void btnLogout_Clicked(object sender, EventArgs e)
        {
            Application.Current.MainPage = new NavigationPage(new Login());
        }

        private void checkouted_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new DaThanhToan());
        }

        private void checkout_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new DaThanhToan(ListBurgers));
            ListBurgers.Clear();
        }
    }
    
}