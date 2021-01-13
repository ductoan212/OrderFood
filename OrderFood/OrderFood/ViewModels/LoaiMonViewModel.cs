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

        public ICommand SelectionCommand => new Command(DisplayBurger);

        private async void DisplayBurger()
        {
            if (_selectedBurger != null)
            {
                var httpClient = new HttpClient();
                var response = await httpClient.GetStringAsync("http://www.orderfood212.somee.com/api/ServiceController/getMonAnTheoLoai?MaLM=" + _selectedBurger.MaLM.ToString());
                monans = JsonConvert.DeserializeObject<ObservableCollection<MonAn>>(response);
                //Console.ReadLine();
                //Console.WriteLine("Here Result Print!!!!!!!!!!!!!!!!");
                //Console.WriteLine(monans[0]);
                //Console.WriteLine(monans[0].Hinh);
                for (int i = 0; i < monans.Count; i++)
                {

                    monans[i].Gia = Convert.ToInt32(monans[i].Gia);
                }
                var viewModel = new DetailsViewModel { _selectedMonAn = monans[0], monans = monans, position = 0 , tenloaimon = _selectedBurger.TenLM};
                var detailsPage = new DetailsPage { BindingContext = viewModel };

                var navigation = Application.Current.MainPage as NavigationPage;
                await navigation.PushAsync(detailsPage, true);
                SelectedBurger = null;
            }
        }

        private async void GetBurgers()
        {
            var httpClient = new HttpClient();
            var response = await httpClient.GetStringAsync("http://www.orderfood212.somee.com/api/ServiceController/getLoaiMon");
            loaimons = JsonConvert.DeserializeObject<ObservableCollection<LoaiMon>>(response);
        }

        private async void GetMonAnTheoLoai(int MaLM)
        {
            var httpClient = new HttpClient();
            var response2 = await httpClient.GetStringAsync("http://www.orderfood212.somee.com/api/ServiceController/getMonAnTheoLoai?MaLM=2");
            monans = JsonConvert.DeserializeObject<ObservableCollection<MonAn>>(response2);
            //var response = await httpClient.GetStringAsync("http://www.orderfood212.somee.com/api/ServiceController/getLoaiMon");
            //loaimons = JsonConvert.DeserializeObject<ObservableCollection<LoaiMon>>(response);
        }

        private ObservableCollection<MonAn> GetBreakFast()
        {
            return new ObservableCollection<MonAn>
            {
                //new MonAn { Name = "Break",LoaiMon = "breakfast",  Price = 12.99f, Image = "breakfast.jpg", Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Bibendum est ultricies"},
                //new MonAn { Name = "Noodle",LoaiMon = "breakfast",  Price = 19.99f, Image = "noodle.jpg", Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Bibendum est ultricies"},

                new MonAn { MaLM = 1, TenMA = "Bánh mì", MaMA = 1, DanhGia = 8, Gia = 50000, Hinh = "https://aseasyasapplepie.com/wp-content/uploads/2018/01/healthy-breakfast-bowl-500x500.jpg", MoTa = "Đây là mô tả món ăn" },
                new MonAn { MaLM = 1, TenMA = "Bánh mì", MaMA = 1, DanhGia = 8, Gia = 50000, Hinh = "https://aseasyasapplepie.com/wp-content/uploads/2018/01/healthy-breakfast-bowl-500x500.jpg", MoTa = "Đây là mô tả món ăn" },
            };
        }
        private ObservableCollection<MonAn> GetLunch()
        {
            return new ObservableCollection<MonAn>
            {

                //new MonAn { Name = "Pizza",LoaiMon = "lunch", Price = 17.29f, Image = "pizza.jpg", Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Bibendum est ultricies"},

                //new MonAn { Name = "Pizza",LoaiMon = "lunch", Price = 17.29f, Image = "pizza.jpg", Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Bibendum est ultricies"},
                new MonAn { MaLM = 1, TenMA = "Bánh mì", MaMA = 1, DanhGia = 8, Gia = 50000, Hinh = "abc", MoTa = "Đây là mô tả món ăn" },
                new MonAn { MaLM = 1, TenMA = "Bánh mì", MaMA = 1, DanhGia = 8, Gia = 50000, Hinh = "abc", MoTa = "Đây là mô tả món ăn" },
            };
        }
        private ObservableCollection<MonAn> GetSupper()
        {
            return new ObservableCollection<MonAn>
            {

                //new MonAn { Name = "Pizza",LoaiMon = "supper", Price = 17.29f, Image = "pizza.jpg", Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Bibendum est ultricies"},

                //new MonAn { Name = "Pizza",LoaiMon = "supper", Price = 17.29f, Image = "pizza.jpg", Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Bibendum est ultricies"},
                new MonAn { MaLM = 1, TenMA = "Bánh mì", MaMA = 1, DanhGia = 8, Gia = 50000, Hinh = "abc", MoTa = "Đây là mô tả món ăn" },
                new MonAn { MaLM = 1, TenMA = "Bánh mì", MaMA = 1, DanhGia = 8, Gia = 50000, Hinh = "abc", MoTa = "Đây là mô tả món ăn" },
            };
        }
        private ObservableCollection<MonAn> GetDinner()
        {
            return new ObservableCollection<MonAn>
            {
                //new MonAn { Name = "Apple",LoaiMon = "dinner", Price = 15.99f, Image = "vegetable.jpg", Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Bibendum est ultricies"},
                //new MonAn { Name = "Apple",LoaiMon = "dinner", Price = 15.99f, Image = "vegetable.jpg", Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Bibendum est ultricies"},
                new MonAn { MaLM = 1, TenMA = "Bánh mì", MaMA = 1, DanhGia = 8, Gia = 50000, Hinh = "abc", MoTa = "Đây là mô tả món ăn" },
                new MonAn { MaLM = 1, TenMA = "Bánh mì", MaMA = 1, DanhGia = 8, Gia = 50000, Hinh = "abc", MoTa = "Đây là mô tả món ăn" },
            };
        }
        private ObservableCollection<MonAn> GetSnack()
        {
            return new ObservableCollection<MonAn>
            {
                //new MonAn { Name = "Rice",LoaiMon = "snack", Price = 11.99f, Image = "breakfast.jpg", Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Bibendum est ultricies"},
                //new MonAn { Name = "Rice",LoaiMon = "snack", Price = 11.99f, Image = "breakfast.jpg", Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Bibendum est ultricies"},
                new MonAn { MaLM = 1, TenMA = "Bánh mì", MaMA = 1, DanhGia = 8, Gia = 50000, Hinh = "abc", MoTa = "Đây là mô tả món ăn" },
                new MonAn { MaLM = 1, TenMA = "Bánh mì", MaMA = 1, DanhGia = 8, Gia = 50000, Hinh = "abc", MoTa = "Đây là mô tả món ăn" },
            };
        }
        private ObservableCollection<MonAn> GetDesserts()
        {
            return new ObservableCollection<MonAn>
            {
                new MonAn { MaLM = 1, TenMA = "Bánh mì", MaMA = 1, DanhGia = 8, Gia = 50000, Hinh = "abc", MoTa = "Đây là mô tả món ăn" },
                new MonAn { MaLM = 1, TenMA = "Bánh mì", MaMA = 1, DanhGia = 8, Gia = 50000, Hinh = "abc", MoTa = "Đây là mô tả món ăn" },

                //new MonAn { Name = "cow", LoaiMon = "desserts",Price = 13.99f, Image = "noodle.jpg", Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Bibendum est ultricies"},

                //new MonAn { Name = "cow", LoaiMon = "desserts",Price = 13.99f, Image = "noodle.jpg", Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Bibendum est ultricies"},
            };
        }
        private ObservableCollection<MonAn> GetTemp()
        {
            ObservableCollection<MonAn> ListBurger = new ObservableCollection<MonAn>();
            ListBurger.Add(new MonAn { MaLM = 1, TenMA = "Bánh mì", MaMA = 1, DanhGia = 8, Gia = 50000, Hinh = "abc", MoTa = "Đây là mô tả món ăn" });
            return ListBurger;
        }
    }
}
