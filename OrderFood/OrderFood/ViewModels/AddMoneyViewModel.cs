using Newtonsoft.Json;
using OrderFood.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace OrderFood.ViewModels
{
    public class AddMoneyViewModel : BaseViewModel
    {
        private int _money;
        public int money
        {
            get { return _money; }
            set
            {
                _money = value;
                OnPropertyChanged();
            }
        }

        private User _currentUser;
        public User currentUser
        {
            get { return _currentUser; }
            set
            {
                _currentUser = value;
                OnPropertyChanged();
            }
        }
        public AddMoneyViewModel()
        {

        }

        public AddMoneyViewModel(User u)
        {
            currentUser = u;
        }

        public ICommand addMoneyCommand => new Command(addMoneyToAccount);

        private async void addMoneyToAccount()
        {
            if (money > 0)
            {
                try
                {
                    currentUser.SoDu += money;
                    //int new_money = money + Convert.ToInt32(currentUser.SoDu);
                    var httpClient = new HttpClient();
                    var response = await httpClient.GetStringAsync("http://www.orderfood213.somee.com/api/ServiceController/updateSoDuKH?MaKH=" + currentUser.MaKH + "&SoDuNew=" + currentUser.SoDu.ToString());
                    
                    //var response2 = await httpClient.GetStringAsync("http://www.orderfood213.somee.com/api/ServiceController/getKhachHangTheoTenDN?TenDN=" + currentUser.MaKH);
                    //List<User> user = JsonConvert.DeserializeObject<List<User>>(response2);
                    Application.Current.MainPage = new NavigationPage(new BottomNavBarXf.Home(currentUser));
                    await Application.Current.MainPage.DisplayAlert("Thông báo", "Đã nạp tiền thành công", "OK");
                }
                catch (Exception ex)
                {
                }
            }
            else
            {
                await Application.Current.MainPage.DisplayAlert("Thông báo", "Số tiền không hợp lệ!!! Xin hãy nhập lại", "OK");
            }
        }
    }
}
