using Newtonsoft.Json;
using OrderFood.Components;
using OrderFood.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace OrderFood.ViewModels
{
    public class LoaiMonViewModel : BaseViewModel
    {
        public LoaiMonViewModel()
        {
            GetBurgers();
            GetCartItem();
        }

        public LoaiMonViewModel(User user)
        {
            currentUser = user;
            GetBurgers();
            GetCartItem();
        }

        ObservableCollection<LoaiMon> _loaimons;
        ObservableCollection<MonAn> monans;
        public ObservableCollection<LoaiMon> loaimons
        {
            get { return _loaimons; }
            set
            {
                _loaimons = value;
                OnPropertyChanged();
            }
        }

        private LoaiMon _selectedBurger;
        public LoaiMon SelectedBurger
        {
            get { return _selectedBurger; }
            set
            {
                _selectedBurger = value;
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

        private HoaDon _currentHD;
        public HoaDon currentHD
        {
            get { return _currentHD; }
            set
            {
                _currentHD = value;
                OnPropertyChanged();
            }
        }

        ObservableCollection<CTHD> _cartItems;
        public ObservableCollection<CTHD> cartItems
        {
            get { return _cartItems; }
            set
            {
                _cartItems = value;
                OnPropertyChanged("cartItems");
            }
        }
        //================================= Function =================================//
        public ICommand SelectionCommand => new Command(DisplayBurger);

        private async void DisplayBurger()
        {
            if (_selectedBurger != null)
            {
                try
                {
                    var httpClient = new HttpClient();
                    var response = await httpClient.GetStringAsync("http://www.orderfood212.somee.com/api/ServiceController/getMonAnTheoLoai?MaLM=" + _selectedBurger.MaLM.ToString());
                    monans = JsonConvert.DeserializeObject<ObservableCollection<MonAn>>(response);

                    for (int i = 0; i < monans.Count; i++)
                    {
                        monans[i].Gia = Convert.ToInt32(monans[i].Gia);
                    }
                    var viewModel = new DetailsViewModel { _selectedMonAn = monans[0], monans = monans, position = 0, loaimon = _selectedBurger };
                    var detailsPage = new DetailsPage { BindingContext = viewModel };

                    var navigation = Application.Current.MainPage as NavigationPage;
                    await navigation.PushAsync(detailsPage, true);
                    SelectedBurger = null;
                }
                catch(Exception ex)
                {
                    throw ex;
                }
            }
        }

        private async void GetBurgers()
        {
            try
            {
                var httpClient = new HttpClient();
                var response = await httpClient.GetStringAsync("http://www.orderfood212.somee.com/api/ServiceController/getLoaiMon");
                loaimons = JsonConvert.DeserializeObject<ObservableCollection<LoaiMon>>(response);
            }
            catch(Exception ex)
            {
                loaimons = new ObservableCollection<LoaiMon>();
                throw ex;
            }
        }

        private async void GetCartItem()
        {
            var httpClient = new HttpClient();
            var response = await httpClient.GetStringAsync("http://www.orderfood212.somee.com/api/ServiceController/getHoaDonChuaTTTheoKH?MaKH=" + currentUser.MaKH.ToString());
            List<HoaDon> temp = JsonConvert.DeserializeObject<List<HoaDon>>(response);
            if (temp.Count == 0)
            {
                response = await httpClient.GetStringAsync("http://www.orderfood212.somee.com/api/ServiceController/createHoaDon?MaKH=" + currentUser.MaKH.ToString());
                temp = JsonConvert.DeserializeObject<List<HoaDon>>(response);
                currentHD = temp[0];
                cartItems = new ObservableCollection<CTHD>();
            }
            else
            {
                currentHD = temp[0];
                var _lstCartItem = await httpClient.GetStringAsync("http://www.orderfood212.somee.com/api/ServiceController/getCTHDTheoHD?MaHD=" + currentHD.MaHD.ToString());
                cartItems = JsonConvert.DeserializeObject<ObservableCollection<CTHD>>(_lstCartItem);
            }
        }

        public ICommand SubQuantityCommand => new Command<int>(SubQuantity);

        private async void SubQuantity(int MaMA)
        {
            ObservableCollection<CTHD> temp = cartItems;
            for (int i = 0; i < temp.Count; i++)
            {
                if (temp[i].MaMA == MaMA)
                    temp[i].SoLuong = 8;
            }
            cartItems = temp;
            //cartItems.Add(new CTHD { MaMA = 50, SoLuong = 1});
        }
    }
}
