using Newtonsoft.Json;
using OrderFood.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace OrderFood.Components
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Register : ContentPage
    {
        //static List<User> ListUsers = new List<User>();
        public Register()
        {
            InitializeComponent();
        }
        public async void CheckRegister(User user)
        {
            popupLoadingView.IsVisible = true;
            var httpClient = new HttpClient();
            try
            {
                var response = await httpClient.GetStringAsync("http://www.orderfood213.somee.com/api/ServiceController/checkTenDNTonTai?TenDN=" + user.MaKH);
                if (response == "true")
                {
                    await DisplayAlert("Thông báo", "Tên đăng nhập đã tồn tại!", "OK");
                }
                else
                {
                
                    await httpClient.GetStringAsync("http://www.orderfood213.somee.com/api/ServiceController/createKhachHang?MaKH="
                                                + user.MaKH + "&MatKhau=" + user.MatKhau + "&HoTen=" + user.HoTen +
                                                "&Email=" + user.Email + "&DiaChi=" + user.DiaChi +
                                                "&Sdt=" + user.Sdt);
                    await Navigation.PushAsync(new Login(user));
                    await DisplayAlert("Thông báo", "Đăng ký thành công!!!", "OK");
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Thông báo", "Bạn cần kết nối Internet để thực hiện thao tác", "OK");
                throw ex;
            }
            popupLoadingView.IsVisible = false;
        }

        private void btnRegister_Clicked(object sender, EventArgs e)
        {
            var current = Connectivity.NetworkAccess;
            
            //if (username.Text == null || password.Text == null || address.Text == null || email.Text == null || phone.Text == null || age.Text == null)
            if (username.Text == null || password.Text == null || address.Text == null || email.Text == null || phone.Text == null)
            {
                DisplayAlert("Thông báo", "Bạn chưa điền đủ thông tin", "OK");
            }
            else
            {
                User user = new User
                {
                    MaKH = username.Text,
                    MatKhau = password.Text,
                    HoTen = fullname.Text,
                    Email = email.Text,
                    DiaChi = address.Text,
                    Sdt = phone.Text,
                    SoDu = 0
                };
                CheckRegister(user);
            }
        }

        private void btnLogin_Clicked(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }
    }
}