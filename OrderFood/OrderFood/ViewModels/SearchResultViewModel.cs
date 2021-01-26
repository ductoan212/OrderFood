using OrderFood.Models;
using OrderFood.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace OrderFood.ViewModels
{
    public class SearchResultViewModel : BaseViewModel
    {
        ObservableCollection<MonAn> _monans;
        public ObservableCollection<MonAn> monans
        {
            get { return _monans; }
            set
            {
                _monans = value;
                OnPropertyChanged();
            }
        }

        public MonAn _selectedMonAn;
        public MonAn SelectedBurger
        {
            get { return _selectedMonAn; }
            set
            {
                _selectedMonAn = value;
                OnPropertyChanged();
            }
        }

        private int _position;
        public int position
        {
            get
            {
                if (_position != _monans.IndexOf(_selectedMonAn))
                    return _monans.IndexOf(_selectedMonAn);

                return _position;
            }
            set
            {
                _position = value;
                _selectedMonAn = _monans[_position];

                OnPropertyChanged();
                OnPropertyChanged(nameof(SelectedBurger));
            }
        }

        private bool _isEmpty;
        public bool isEmpty
        {
            get
            {
                return _isEmpty;
            }
            set
            {
                _isEmpty = value;
                OnPropertyChanged();
            }
        }

        private LoaiMon _loaimon;
        public LoaiMon loaimon
        {
            get { return _loaimon; }
            set
            {
                _loaimon = value;
                OnPropertyChanged();
            }
        }


        public void listItem__ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (SelectedBurger != null)
            {
                var viewModel = new MonAnViewModel { monan = SelectedBurger };
                var detailsPage = new DetailMonAn { BindingContext = viewModel };

                var navigation = Application.Current.MainPage as NavigationPage;
                navigation.PushAsync(detailsPage, true);
                SelectedBurger = null;
            }
        }

        public ICommand DisplayDetailMonAnCommand => new Command<MonAn>(DisplayDetailMonAn);

        private async void DisplayDetailMonAn(MonAn monAn)
        {
            if (monAn != null)
            {
                var viewModel = new MonAnViewModel { monan = monAn };
                var detailsPage = new DetailMonAn { BindingContext = viewModel };

                var navigation = Application.Current.MainPage as NavigationPage;
                await navigation.PushAsync(detailsPage, true);
                SelectedBurger = null;
            }
        }
    }
}
