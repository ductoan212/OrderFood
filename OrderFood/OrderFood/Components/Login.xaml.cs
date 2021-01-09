using Newtonsoft.Json;
using OrderFood.Modals;
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
    public partial class Login : ContentPage
    {
        //List<User> ListUsersLogin = new List<User>();
        public Login()
        {
            InitializeComponent();
           
        }
        public Login(User user)
        {
            InitializeComponent();
            InitAccount(user);
        }
        public void InitAccount(User user)
        {
            usernameLogin.Text = user.TenDN;
            passwordLogin.Text = user.MatKhau;
        }
        public async void CheckLogin(string TenDN, string MatKhau)
        {
            popupLoadingView.IsVisible = true;
            var httpClient = new HttpClient();
            var response = await httpClient.GetStringAsync("http://www.orderfood212.somee.com/api/ServiceController/checkDangNhap?TenDN=" + TenDN + "&MatKhau=" + MatKhau);
            if(response == "true")
            {
                var response2 = await httpClient.GetStringAsync("http://www.orderfood212.somee.com/api/ServiceController/getKhachHangTheoTenDN?TenDN=" + TenDN);
                List<User> user = JsonConvert.DeserializeObject<List<User>>(response2);
                Navigation.PushAsync(new BottomNavBarXf.Home(user[0]));
            }
            else
            {
                await DisplayAlert("Thông báo", "Tên đăng nhập hoặc mật khẩu sai!", "OK");
            }
            popupLoadingView.IsVisible = false;
        }

        private void btnLogin_Clicked(object sender, EventArgs e)
        {
            var username = usernameLogin.Text;
            var password = passwordLogin.Text;
            var current = Connectivity.NetworkAccess;
            if (username == null || password == null ||
                username == "" || password == "")
            {
                DisplayAlert("Thông báo", "Bạn chưa điền đủ thông tin", "OK");
            }
            else if (current == NetworkAccess.Internet)
            {
                CheckLogin(username, password);
            }
            else
            {
                DisplayAlert("Thông báo", "Bạn cần kết nối Internet để thực hiện thao tác", "OK");
            }
            
        }

        private void btnRegister_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Register());
        }
    }
}