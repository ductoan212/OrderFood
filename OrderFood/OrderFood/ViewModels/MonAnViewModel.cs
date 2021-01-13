using OrderFood.Models;
﻿using BottomNavBarXf;
using OrderFood.Models;
using OrderFood.Views;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace OrderFood.ViewModels
{
    public class MonAnViewModel : BaseViewModel
    {
        public MonAn _monan;
        public MonAn monan
        {
            get { return _monan; }
            set
            {
                _monan = value;
                OnPropertyChanged();
            }
        }

        public ICommand AddMonAnFavCommand => new Command<MonAn>(AddMonAnToFav);

        private async void AddMonAnToFav(MonAn monAn)
        {
            if (monAn != null)
            {
                var navigation = Application.Current.MainPage as NavigationPage;
                await navigation.PushAsync(new BottomNavBarXf.Home(monAn, "fav"));

                //var httpClient = new HttpClient();
                //var response = await httpClient.GetStringAsync("http://www.orderfood212.somee.com/api/ServiceController/createHoaDon?MaKH=" + cur);

                //var response2 = await httpClient.GetStringAsync("http://www.orderfood212.somee.com/api/ServiceController/getKhachHangTheoTenDN?TenDN=" + TenDN);
                //List<User> user = JsonConvert.DeserializeObject<List<User>>(response2);
                }
        }
        public ICommand OrderMonAnCommand => new Command<MonAn>(AddToOrder);

        private async void AddToOrder(MonAn monAn)
        {
            if (monAn != null)
            {
              
                var detailsPage = new BottomNavBarXf.Home(monAn,"cart");
                
                var navigation = Application.Current.MainPage as NavigationPage;
                await navigation.PushAsync(detailsPage, true);
            }
        }
    }
}
