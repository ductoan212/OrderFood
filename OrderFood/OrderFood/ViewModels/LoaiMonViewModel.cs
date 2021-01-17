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
    }
}
