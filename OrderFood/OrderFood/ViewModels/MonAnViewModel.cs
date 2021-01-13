using OrderFood.Models;
using System;
using System.Collections.Generic;
using System.Text;

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
    }
}
