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
        static List<CTHD> ListBurgers = new List<CTHD>();
        static List<MonAn> ListFav = new List<MonAn>();
        static HoaDon currentHD = new HoaDon();

        public Home()
        {
            InitializeComponent();
            ListFav = null;
            try
            {
                InitUser();
                InitFavorite();
                InitCartItem();
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
            InitCartItem();
        }
      
        public Home(MonAn burger, string str)
        {
            InitializeComponent();
            KhoiTaoCart(burger,str);
            InitUser();
        }
        public void InitUser()
        {
            //usernameProfile.Text = currentUser.TenDN;
            //ageProfile.Text = "Age : " + currentUser.Tuoi.ToString();
            //addressProfile.Text = currentUser.DiaChi;
            //emailProfile.Text = currentUser.Email;
            //phoneProfile.Text = currentUser.Sdt;
            //userName.Text = "Xin chào " + currentUser.HoTen;

            usernameProfile.Text = "ductoan212";
            ageProfile.Text = "20";
            addressProfile.Text = "Hồ Chí Minh";
            emailProfile.Text = "ductoan20102000@gmail.com";
            phoneProfile.Text = "0123456789";
            userName.Text = "Xin chào Toàn";
            currentUser.MaKH = 1;
        }
        public async void InitFavorite()
        {
            var httpClient = new HttpClient();
            var response = await httpClient.GetStringAsync("http://www.orderfood212.somee.com/api/ServiceController/getYeuThichTheoKH?MaKH=" + currentUser.MaKH.ToString());
            ListFav =  JsonConvert.DeserializeObject<List<MonAn>>(response);
            lstfavorities.ItemsSource = ListFav;
        }
        public async void InitCartItem()
        {
            var httpClient = new HttpClient();
            var response = await httpClient.GetStringAsync("http://www.orderfood212.somee.com/api/ServiceController/getHoaDonChuaTTTheoKH?MaKH=" + currentUser.MaKH.ToString());
            List<HoaDon> temp = JsonConvert.DeserializeObject<List<HoaDon>>(response);
            if(temp.Count() == 0)
            {
                response = await httpClient.GetStringAsync("http://www.orderfood212.somee.com/api/ServiceController/createHoaDon?MaKH=" + currentUser.MaKH.ToString());
                ListBurgers = new List<CTHD>();
            }
            else
            {
                currentHD = temp[0];
                var _lstCartItem = await httpClient.GetStringAsync("http://www.orderfood212.somee.com/api/ServiceController/getCTHDTheoHD?MaHD=" + currentHD.MaHD.ToString());
                ListBurgers = JsonConvert.DeserializeObject<List<CTHD>>(_lstCartItem);
            }
            lstfoods.ItemsSource = ListBurgers;
        }
        public void KhoiTaoCart(MonAn burger,string str)
        {
            if (str == "cart")
            {
                bool check = ListBurgers.Any(item=>item.TenMA==burger.TenMA);
                if (check==true)
                {
                    DisplayAlert("Thông báo", "Món này đã có trong giỏ hàng!", "OK");
                }
                else
                {
                    CTHD temp = new CTHD()
                    {
                        MaMA = burger.MaMA,
                        TenMA = burger.TenMA,
                        MoTa  = burger.MoTa,
                        Hinh = burger.Hinh,
                        Gia = burger.Gia,
                        DanhGia = burger.DanhGia,
                        MaLM = burger.MaLM,
                        SoLuong = 1,
                        ThanhTien = burger.Gia*1
                    };
                    ListBurgers.Add(temp);
                    var httpClient = new HttpClient();
                    var response = httpClient.GetStringAsync("http://www.orderfood212.somee.com/api/ServiceController/createCTHD?MaHD=" + currentHD.MaHD.ToString() +
                        "&MaMA=" + burger.MaMA + "&SoLuong=1");
                }
                
            }
            else if (str == "fav")
            {
                bool check = ListFav.Any(item => item.TenMA == burger.TenMA);
                if (check ==true)
                {
                    DisplayAlert("Thông báo", "Món này đã có trong yêu thích!", "OK");
                }
                else
                {
                    ListFav.Add(burger);
                    var httpClient = new HttpClient();
                    var response = httpClient.GetStringAsync("http://www.orderfood212.somee.com/api/ServiceController/createYeuThich?MaKH=" + currentUser.MaKH.ToString() +
                        "&MaMA=" + burger.MaMA.ToString() + "&GhiChu=abc");
                }
            }
            lstfoods.ItemsSource = ListBurgers;
            lstfavorities.ItemsSource = ListFav;
        }

        private void btnLogout_Clicked(object sender, EventArgs e)
        {
            Application.Current.MainPage = new NavigationPage(new Login());
        }

        private void checkouted_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new DaThanhToan(currentUser));
        }

        private void checkout_Clicked(object sender, EventArgs e)
        {
            if(ListBurgers.Count() == 0)
            {
                DisplayAlert("Thông báo", "Chưa có món trong giỏ! Hãy thêm ngay nào...", "OK");
                return;
            }    
            var httpClient = new HttpClient();
            var response = httpClient.GetStringAsync("http://www.orderfood212.somee.com/api/ServiceController/updateTrangThaiHD?MaHD=" + currentHD.MaHD.ToString());
            ListBurgers.Clear();
            lstfoods.ItemsSource = ListBurgers;
            DisplayAlert("Thông báo", "Đã thanh toán thành công", "OK");
            Application.Current.MainPage = new NavigationPage(new BottomNavBarXf.Home());
        }
    }
    
}