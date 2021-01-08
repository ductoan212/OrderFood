using Newtonsoft.Json;
using OrderFood.Modals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

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
            var response = await httpClient.GetStringAsync("http://www.orderfood212.somee.com/api/ServiceController/checkTenDNTonTai?TenDN=" + user.TenDN);
            if (response == "true")
            {
                await DisplayAlert("Thông báo", "Tên đăng nhập đã tồn tại!", "OK");
            }
            else
            {
                await httpClient.GetStringAsync("http://www.orderfood212.somee.com/api/ServiceController/createKhachHang?TenDN=" 
                                                + user.TenDN + "&MatKhau=" + user.MatKhau + "&HoTen=" + user.HoTen +
                                                "&Email=" + user.Email + "&DiaChi=" + user.DiaChi +
                                                "&Tuoi=" + user.Tuoi + "&Sdt=" + user.Sdt +
                                                "&GioiTinh=" + user.GioiTinh);
                await Navigation.PushAsync(new Login(user));
                await DisplayAlert("Thông báo", "Đăng ký thành công!!!", "OK");
            }
            popupLoadingView.IsVisible = false;
        }

        private void btnRegister_Clicked(object sender, EventArgs e)
        {
            //if (username.Text == null || password.Text == null || address.Text == null || email.Text == null || phone.Text == null || age.Text == null)
            if (username.Text == null || password.Text == null || address.Text == null || email.Text == null || phone.Text == null)
            {
                DisplayAlert("Thông báo", "Bạn chưa điền đủ thông tin", "OK");
            }
            else
            {
                User user = new User
                {
                    TenDN = username.Text,
                    MatKhau = password.Text,
                    HoTen = fullname.Text,
                    Email = email.Text,
                    DiaChi = address.Text,
                    //Tuoi = Int32.Parse(age.Text),
                    Tuoi = 20,
                    Sdt = phone.Text,
                    //GioiTinh = sex.SelectedIndex == 1
                    GioiTinh = true
                };
                CheckRegister(user);
            }
        }

        private void btnLogin_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Login());
        }
    }
}