using Newtonsoft.Json;
using OrderFood.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace OrderFood.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DaThanhToan : ContentPage
    {
        static List<HoaDon> listHoaDon = new List<HoaDon>();
        public DaThanhToan()
        {
            InitializeComponent();
            //InitList();
        }
        public DaThanhToan(User user)
        {
            InitializeComponent();
            InitList(user);
            Title = "Đã thanh toán";
        }
        public async void InitList(User user)
        {
            var httpClient = new HttpClient();

            try
            {
                var response = await httpClient.GetStringAsync("http://www.orderfood212.somee.com/api/ServiceController/getHoaDonDaTTTheoKH?MaKH=" + user.MaKH.ToString());
                var list = JsonConvert.DeserializeObject<List<HoaDon>>(response);

                if (list != null && list.Count() >= 0)
                {
                    lstcheckout.ItemsSource = list;
                }
                else
                {
                    lstcheckout.ItemsSource = new List<HoaDon>();
                }
                //popupLoadingView.IsVisible = false;
            }
            catch (Exception ex)
            {
                await DisplayAlert("Thông báo", "Bạn cần kết nối Internet để thực hiện thao tác", "OK");
            }
            //lstcheckout.ItemsSource = list;
        }

        private void lstcheckout_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            HoaDon hd = (HoaDon)lstcheckout.SelectedItem;
            Navigation.PushAsync(new DaThanhToanDetail(hd));
        }
    }
}