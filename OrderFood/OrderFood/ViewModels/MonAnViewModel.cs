using BottomNavBarXf;
using OrderFood.Models;
using OrderFood.Views;
using System;
using System.Collections.Generic;
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
