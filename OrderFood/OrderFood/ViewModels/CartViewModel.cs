using Newtonsoft.Json;
using OrderFood.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace OrderFood.ViewModels
{
    public class CartViewModel : BaseViewModel
    {
        private List<CTHD> _lstCartItem;
        public List<CTHD> lstCartItem
        {
            get { return _lstCartItem; }
            set
            {
                _lstCartItem = value;
                OnPropertyChanged();
            }
        }


        CartViewModel()
        {
            GetItemCart();
        }

        public async void GetItemCart()
        {
            try
            {
                var httpClient = new HttpClient();
                var response = await httpClient.GetStringAsync("http://www.orderfood212.somee.com/api/ServiceController/getHoaDonChuaTTTheoKH?MaKH={MaKH}");
                lstCartItem = JsonConvert.DeserializeObject<List<CTHD>>(response);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
