using Newtonsoft.Json;
using OrderFood.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace OrderFood.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DaThanhToanDetail : ContentPage
    {
        static List<CTHD> listItem = new List<CTHD>();
        public DaThanhToanDetail()
        {
            InitializeComponent();
        }
        public DaThanhToanDetail(HoaDon hd)
        {
            InitializeComponent();
            InitListItem(hd);
            Title = "Chi tiết hóa đơn";
        }

        public async void InitListItem(HoaDon hd)
        {
            var httpClient = new HttpClient();

            try
            {
                var response = await httpClient.GetStringAsync("http://www.orderfood212.somee.com/api/ServiceController/getCTHDTheoHD?MaHD=" + hd.MaHD.ToString());
                var list = JsonConvert.DeserializeObject<List<CTHD>>(response);

                if (list != null && list.Count() >= 0)
                {
                    lstItem.ItemsSource = list;
                }
                else
                {
                    lstItem.ItemsSource = new List<CTHD>();
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Thông báo", "Bạn cần kết nối Internet để thực hiện thao tác", "OK");
            }
        }
    }
}