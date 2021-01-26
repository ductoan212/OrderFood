using Newtonsoft.Json;
using OrderFood.Models;
using OrderFood.ViewModels;
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
                var response = await httpClient.GetStringAsync("http://www.orderfood213.somee.com/api/ServiceController/getCTHDTheoHD?MaHD=" + hd.MaHD.ToString());
                var list = JsonConvert.DeserializeObject<List<CTHD>>(response);

                if (list != null && list.Count() >= 0)
                {
                    for (int i = 0; i < list.Count; i++)
                    {
                        list[i].Gia = Convert.ToInt32(list[i].Gia);
                        list[i].ThanhTien = Convert.ToInt32(list[i].ThanhTien);
                    }
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
                throw ex;
            }
        }

        private void lstItem_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (lstItem.SelectedItem != null)
            {
                CTHD cthd = (CTHD)lstItem.SelectedItem;
                MonAn monAn = new MonAn 
                {
                    MaMA = cthd.MaMA,
                    TenMA = cthd.TenMA,
                    DanhGia = cthd.DanhGia,
                    MoTa = cthd.MoTa,
                    Hinh = cthd.Hinh,
                    Gia = cthd.Gia,
                    MaLM = cthd.MaMA
                };
                var viewModel = new MonAnViewModel { monan = monAn };
                var detailsPage = new DetailMonAn { BindingContext = viewModel };

                Navigation.PushAsync(detailsPage, true);
                lstItem.SelectedItem = null;
            }
        }
    }
}