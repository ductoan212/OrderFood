using OrderFood.Models;
﻿using BottomNavBarXf;
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
        private MonAn _monan;
        public MonAn monan
        {
            get { return _monan; }
            set
            {
                _monan = value;
                if (_monan.KhuyenMai == 0)
                    isKhuyenMai = false;
                else
                    isKhuyenMai = true;
                tamTinh = Convert.ToInt32(Convert.ToSingle(_monan.Gia) * (1.0 - Convert.ToSingle(_monan.KhuyenMai) / 100));
                OnPropertyChanged();
            }
        }

        public bool _isKhuyenMai;
        public bool isKhuyenMai
        {
            get { return _isKhuyenMai; }
            set
            {
                _isKhuyenMai = value;
                OnPropertyChanged();
            }
        }

        public int _tamTinh;
        public int tamTinh
        {
            get { return _tamTinh; }
            set
            {
                _tamTinh = value;
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
            }
        }
        public ICommand OrderMonAnCommand => new Command<MonAn>(AddToOrder);

        private async void AddToOrder(MonAn monAn)
        {
            if (monAn != null)
            {
                monAn.Gia = Convert.ToInt32(Convert.ToSingle(monan.Gia) * (1.0 - Convert.ToSingle(monan.KhuyenMai) / 100));
                var detailsPage = new BottomNavBarXf.Home(monAn,"cart");
                
                var navigation = Application.Current.MainPage as NavigationPage;
                await navigation.PushAsync(detailsPage, true);
            }
        }
    }
}
