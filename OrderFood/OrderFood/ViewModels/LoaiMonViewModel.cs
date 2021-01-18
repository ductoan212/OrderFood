using Newtonsoft.Json;
using OrderFood.Components;
using OrderFood.Models;
using OrderFood.Views;
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
            GetFavoriteItem();
        }

        public LoaiMonViewModel(User user, MonAn monAn, string str)
        {
            currentUser = user;
            GetBurgers();
            if (str == "cart")
            {
                GetFavoriteItem();
                GetCartItem(monAn);
            }
            else
            {
                GetFavoriteItem(monAn);
                GetCartItem();
            }
            //GetCartItem();
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

        private MonAn _selectedFav;
        public MonAn selectedFav
        {
            get { return _selectedFav; }
            set
            {
                _selectedFav = value;
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

        private ObservableCollection<MonAn> _listFav;
        public ObservableCollection<MonAn> listFav
        {
            get { return _listFav; }
            set
            {
                _listFav = value;
                OnPropertyChanged();
            }
        }
        
        private ObservableCollection<CTHD> _cartItems;
        public ObservableCollection<CTHD> cartItems
        {
            get { return _cartItems; }
            set
            {
                _cartItems = value;
                OnPropertyChanged();
            }
        }
        private int _total;
        public int total
        {
            get { return _total; }
            set
            {
                _total = value;
                OnPropertyChanged();
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
                    var response = await httpClient.GetStringAsync("http://www.orderfood213.somee.com/api/ServiceController/getMonAnTheoLoai?MaLM=" + _selectedBurger.MaLM.ToString());
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
                var response = await httpClient.GetStringAsync("http://www.orderfood213.somee.com/api/ServiceController/getLoaiMon");
                loaimons = JsonConvert.DeserializeObject<ObservableCollection<LoaiMon>>(response);
            }
            catch(Exception ex)
            {
                loaimons = new ObservableCollection<LoaiMon>();
                throw ex;
            }
        }

        public async void GetCartItem()
        {
            //cartItems = new CartItems();
            var httpClient = new HttpClient();
            var response = await httpClient.GetStringAsync("http://www.orderfood213.somee.com/api/ServiceController/getHoaDonChuaTTTheoKH?MaKH=" + currentUser.MaKH.ToString());
            List<HoaDon> temp = JsonConvert.DeserializeObject<List<HoaDon>>(response);
            if (temp.Count == 0)
            {
                response = await httpClient.GetStringAsync("http://www.orderfood213.somee.com/api/ServiceController/createHoaDon?MaKH=" + currentUser.MaKH.ToString());
                temp = JsonConvert.DeserializeObject<List<HoaDon>>(response);
                currentHD = temp[0];
                cartItems = new ObservableCollection<CTHD>();
            }
            else
            {
                currentHD = temp[0];
                var _lstCartItem = await httpClient.GetStringAsync("http://www.orderfood213.somee.com/api/ServiceController/getCTHDTheoHD?MaHD=" + currentHD.MaHD.ToString());
                cartItems = JsonConvert.DeserializeObject<ObservableCollection<CTHD>>(_lstCartItem);
                for (int i = 0; i < cartItems.Count; i++)
                {
                    cartItems[i].Gia = Convert.ToInt32(cartItems[i].Gia);
                }
            }
            total = Convert.ToInt32(currentHD.TongTien);
        }
        public async void GetCartItem(MonAn monAn)
        {
              
            var httpClient = new HttpClient();
            var response = await httpClient.GetStringAsync("http://www.orderfood213.somee.com/api/ServiceController/getHoaDonChuaTTTheoKH?MaKH=" + currentUser.MaKH.ToString());
            List<HoaDon> temp = JsonConvert.DeserializeObject<List<HoaDon>>(response);
            if (temp.Count == 0)
            {
                response = await httpClient.GetStringAsync("http://www.orderfood213.somee.com/api/ServiceController/createHoaDon?MaKH=" + currentUser.MaKH.ToString());
                temp = JsonConvert.DeserializeObject<List<HoaDon>>(response);
                currentHD = temp[0];
                cartItems = new ObservableCollection<CTHD>();
            }
            else
            {
                currentHD = temp[0];
                var _lstCartItem = await httpClient.GetStringAsync("http://www.orderfood213.somee.com/api/ServiceController/getCTHDTheoHD?MaHD=" + currentHD.MaHD.ToString());
                cartItems = JsonConvert.DeserializeObject<ObservableCollection<CTHD>>(_lstCartItem);
                for (int i = 0; i < cartItems.Count; i++)
                {
                    cartItems[i].Gia = Convert.ToInt32(cartItems[i].Gia);
                }
            }
            // create new item
            for (int i = 0; i < cartItems.Count; i++)
            {
                if (cartItems[i].MaMA == monAn.MaMA)
                {
                    AddQuantity(monAn.MaMA);
                    await Application.Current.MainPage.DisplayAlert("Thông báo", "Đã thêm vào giỏ hàng", "OK");
                    return;
                }
            }
            CTHD new_item = new CTHD()
            {
                MaMA = monAn.MaMA,
                TenMA = monAn.TenMA,
                MoTa = monAn.MoTa,
                Hinh = monAn.Hinh,
                Gia = monAn.Gia,
                DanhGia = monAn.DanhGia,
                MaLM = monAn.MaLM,
                SoLuong = 1,
                ThanhTien = monAn.Gia,
            };
            cartItems.Add(new_item);
            await Application.Current.MainPage.DisplayAlert("Thông báo", "Đã thêm vào giỏ hàng", "OK");
            total = Convert.ToInt32(currentHD.TongTien) + Convert.ToInt32(new_item.ThanhTien);
            _ = httpClient.GetStringAsync("http://www.orderfood213.somee.com/api/ServiceController/createCTHD?MaHD=" + currentHD.MaHD.ToString() +
                "&MaMA=" + new_item.MaMA + "&SoLuong=1");
        }


        public async void GetFavoriteItem()
        {
            var httpClient = new HttpClient();
            var response = await httpClient.GetStringAsync("http://www.orderfood213.somee.com/api/ServiceController/getYeuThichTheoKH?MaKH=" + currentUser.MaKH.ToString());
            listFav = JsonConvert.DeserializeObject<ObservableCollection<MonAn>>(response);
            for (int i = 0; i < listFav.Count; i++)
            {
                listFav[i].Gia = Convert.ToInt32(listFav[i].Gia);
            }
        }
        public async void GetFavoriteItem(MonAn monAn)
        {

            var httpClient = new HttpClient();
            var response = await httpClient.GetStringAsync("http://www.orderfood213.somee.com/api/ServiceController/getYeuThichTheoKH?MaKH=" + currentUser.MaKH.ToString());
            listFav = JsonConvert.DeserializeObject<ObservableCollection<MonAn>>(response);

            for (int i = 0; i < listFav.Count; i++)
                if (listFav[i].MaMA == monAn.MaMA)
                {
                    await Application.Current.MainPage.DisplayAlert("Thông báo", "Đã có trong yêu thích!!!", "OK");
                    return;
                }

            listFav.Add(monAn);
            for (int i = 0; i < listFav.Count; i++)
            {
                listFav[i].Gia = Convert.ToInt32(listFav[i].Gia);
            }
            await Application.Current.MainPage.DisplayAlert("Thông báo", "Đã thêm vào yêu thích", "OK");
            _ = httpClient.GetStringAsync("http://www.orderfood213.somee.com/api/ServiceController/createYeuThich?MaKH=" + currentUser.MaKH.ToString() +
                    "&MaMA=" + monAn.MaMA.ToString() + "&GhiChu=abc");
        }

        private decimal CalTotal()
        {
            decimal s = 0;
            for (int i = 0; i < cartItems.Count; i++)
                s += cartItems[i].ThanhTien;
            return s;
        }
        public ICommand SubQuantityCommand => new Command<int>(SubQuantity);
        private async void SubQuantity(int MaMA)
        {
            var httpClient = new HttpClient();
            CTHD temp = new CTHD();
            int index = 0;
            while(index < cartItems.Count)
            {
                if (cartItems[index].MaMA == MaMA)
                {
                    temp = cartItems[index];
                    break;
                }
                index++;
            }
            
            if (temp.SoLuong == 1)
            {
                cartItems.RemoveAt(index);
                total = Convert.ToInt32(CalTotal());
                _ = httpClient.GetStringAsync("http://www.orderfood213.somee.com/api/ServiceController/deleteCTHD?MaHD=" + currentHD.MaHD.ToString() +
                    "&MaMA=" + temp.MaMA.ToString());
                return;
            }
            temp.SoLuong--;
            temp.ThanhTien = temp.Gia * temp.SoLuong;
            cartItems.RemoveAt(index);
            cartItems.Insert(index, temp);
            total = Convert.ToInt32(CalTotal());
            _ = httpClient.GetStringAsync("http://www.orderfood213.somee.com/api/ServiceController/updateCTHD?MaHD=" + currentHD.MaHD.ToString() + 
                "&MaMA=" + temp.MaMA.ToString() + "&SoLuong=" + temp.SoLuong.ToString());
        }

        public ICommand AddQuantityCommand => new Command<int>(AddQuantity);
        private async void AddQuantity(int MaMA)
        {
            CTHD temp = new CTHD();
            int index = 0;
            while (index < cartItems.Count)
            {
                if (cartItems[index].MaMA == MaMA)
                {
                    temp = cartItems[index];
                    break;
                }
                index++;
            }
            temp.SoLuong++;
            temp.ThanhTien = temp.SoLuong * temp.Gia;
            cartItems.RemoveAt(index);
            cartItems.Insert(index, temp);
            total = Convert.ToInt32(CalTotal());
            var httpClient = new HttpClient();
            _ = httpClient.GetStringAsync("http://www.orderfood213.somee.com/api/ServiceController/updateCTHD?MaHD=" + currentHD.MaHD.ToString() +
                "&MaMA=" + temp.MaMA.ToString() + "&SoLuong=" + temp.SoLuong.ToString());
        }

        public ICommand DeleteCartItemCommand => new Command<int>(DeleteCartItem);
        private async void DeleteCartItem(int MaMA)
        {
            var httpClient = new HttpClient();
            CTHD temp = new CTHD();
            int index = 0;
            while (index < cartItems.Count)
            {
                if (cartItems[index].MaMA == MaMA)
                {
                    temp = cartItems[index];
                    break;
                }
                index++;
            }
            cartItems.RemoveAt(index);
            total = Convert.ToInt32(CalTotal());
            _ = httpClient.GetStringAsync("http://www.orderfood213.somee.com/api/ServiceController/deleteCTHD?MaHD=" + currentHD.MaHD.ToString() +
                "&MaMA=" + temp.MaMA.ToString());
        }
        public ICommand CheckoutCommand => new Command(Checkout);

        private async void Checkout()
        {
            if(cartItems.Count == 0)
            {
                await Application.Current.MainPage.DisplayAlert("Thông báo", "Chưa có món trong giỏ! Hãy thêm ngay nào...", "OK");
                return;
            }
            var httpClient = new HttpClient();
            var response = httpClient.GetStringAsync("http://www.orderfood213.somee.com/api/ServiceController/updateTrangThaiHD?MaHD=" + currentHD.MaHD.ToString());
            cartItems.Clear();
            await Application.Current.MainPage.DisplayAlert("Thông báo", "Đã thanh toán thành công", "OK");
            GetCartItem();
            //Application.Current.MainPage = new NavigationPage(new BottomNavBarXf.Home());
        }

        public ICommand SelectionFavCommand => new Command<MonAn>(DisplayFavDetail);

        private async void DisplayFavDetail(MonAn ma)
        {
            try
            {
                var viewModel = new MonAnViewModel { monan = ma };
                var detailsPage = new DetailMonAn { BindingContext = viewModel };

                var navigation = Application.Current.MainPage as NavigationPage;
                await navigation.PushAsync(detailsPage, true);


                selectedFav = null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
