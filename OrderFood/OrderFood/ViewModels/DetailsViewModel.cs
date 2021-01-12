using OrderFood.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace OrderFood.ViewModels
{
    public class DetailsViewModel : BaseViewModel
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

        private MonAn _selectedMonAn;
        public MonAn selectedMonAn
        {
            get { return _selectedMonAn; }
            set
            {
                _selectedMonAn = value;
                OnPropertyChanged();
            }
        }

        //private int _position;
        //public int position
        //{
        //    get
        //    {
        //        if (_position != _monans.IndexOf(_selectedMonAn))
        //            return _monans.IndexOf(_selectedMonAn);

        //        return _position;
        //    }
        //    set
        //    {
        //        _position = value;
        //        _selectedMonAn = _monans[_position];

        //        OnPropertyChanged();
        //        OnPropertyChanged(nameof(selectedMonAn));
        //    }
        //}
    }
}
