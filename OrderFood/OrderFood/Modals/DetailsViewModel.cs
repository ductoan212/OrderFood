using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace OrderFood.Modals
{
    public class DetailsViewModel : BaseViewModel
    {
        ObservableCollection<Burger> burgers;
        public ObservableCollection<Burger> Burgers
        {
            get { return burgers; }
            set
            {
                burgers = value;
                OnPropertyChanged();
            }
        }

        private Burger selectedBurger;
        public Burger SelectedBurger
        {
            get { return selectedBurger; }
            set
            {
                
                selectedBurger = value;
                OnPropertyChanged();
            }
        }

        private int position;
        public int Position
        {
            get
            {
                if (position != burgers.IndexOf(selectedBurger))
                    return burgers.IndexOf(selectedBurger);

                return position;
            }
            set
            {
                position = value;
                selectedBurger = burgers[position];

                OnPropertyChanged();
                OnPropertyChanged(nameof(SelectedBurger));
            }
        }

        

    }
}
