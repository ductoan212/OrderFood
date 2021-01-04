using OrderFood.Components;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace OrderFood.Modals
{
    public class LandingViewModel : BaseViewModel
    {
        public LandingViewModel()
        {
            burgers = GetBurgers();
        }

        ObservableCollection<Burger> burgers;
        ObservableCollection<Burger> foods;
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
        public ICommand SelectionCommand => new Command(DisplayBurger);
       
        private void DisplayBurger()
        {
            if (selectedBurger != null)
            {

                if (selectedBurger.Category == "breakfast")
                {
                    foods = GetBreakFast();
                }else if(selectedBurger.Category == "lunch")
                {
                    foods = GetLunch();
                }
                else if (selectedBurger.Category == "dinner")
                {
                    foods = GetDinner();
                }
                else if (selectedBurger.Category == "snack")
                {
                    foods = GetSnack();
                }
                else if (selectedBurger.Category == "desserts")
                {
                    foods = GetDesserts();
                }


                var viewModel = new DetailsViewModel { SelectedBurger = foods[0], Burgers = foods, Position = 0 };
                var detailsPage = new DetailsPage { BindingContext = viewModel };

                var navigation = Application.Current.MainPage as NavigationPage;
                navigation.PushAsync(detailsPage, true);
            }
        }
        private ObservableCollection<Burger> GetBurgers()
        {
            return new ObservableCollection<Burger>
            {
                new Burger { Name = "BREAKFAST",Category = "breakfast", Price = 12.99f, Image = "breakfast.jpg", Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Bibendum est ultricies"},
                new Burger { Name = "LUNCH",Category = "lunch", Price = 19.99f, Image = "noodle.jpg", Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Bibendum est ultricies"},
                new Burger { Name = "DINNER", Category = "dinner",Price = 17.29f, Image = "pizza.jpg", Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Bibendum est ultricies"},
                new Burger { Name = "SNACK",Category = "snack", Price = 15.99f, Image = "vegetable.jpg", Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Bibendum est ultricies"},
                new Burger { Name = "SUPPER", Category = "supper",Price = 11.99f, Image = "breakfast.jpg", Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Bibendum est ultricies"},
                new Burger { Name = "DESSERTS",Category = "desserts", Price = 13.99f, Image = "noodle.jpg", Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Bibendum est ultricies"}
            };
        }
        private ObservableCollection<Burger> GetBreakFast()
        {
            return new ObservableCollection<Burger>
            {
                new Burger { Name = "Break",Category = "breakfast",  Price = 12.99f, Image = "breakfast.jpg", Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Bibendum est ultricies"},
                new Burger { Name = "Noodle",Category = "breakfast",  Price = 19.99f, Image = "noodle.jpg", Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Bibendum est ultricies"},
                
            };
        }
        private ObservableCollection<Burger> GetLunch()
        {
            return new ObservableCollection<Burger>
            {
                
                new Burger { Name = "Pizza",Category = "lunch", Price = 17.29f, Image = "pizza.jpg", Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Bibendum est ultricies"},
                
                new Burger { Name = "Pizza",Category = "lunch", Price = 17.29f, Image = "pizza.jpg", Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Bibendum est ultricies"},
                
            };
        }
        private ObservableCollection<Burger> GetDinner()
        {
            return new ObservableCollection<Burger>
            {

               
                new Burger { Name = "Apple",Category = "dinner", Price = 15.99f, Image = "vegetable.jpg", Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Bibendum est ultricies"},
              
                new Burger { Name = "Apple",Category = "dinner", Price = 15.99f, Image = "vegetable.jpg", Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Bibendum est ultricies"},
                
            };
        }
        private ObservableCollection<Burger> GetSnack()
        {
            return new ObservableCollection<Burger>
            {

               
                new Burger { Name = "Rice",Category = "snack", Price = 11.99f, Image = "breakfast.jpg", Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Bibendum est ultricies"},
               
                new Burger { Name = "Rice",Category = "snack", Price = 11.99f, Image = "breakfast.jpg", Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Bibendum est ultricies"},
               
            };
        }
        private ObservableCollection<Burger> GetDesserts()
        {
            return new ObservableCollection<Burger>
            {

               
                new Burger { Name = "cow", Category = "desserts",Price = 13.99f, Image = "noodle.jpg", Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Bibendum est ultricies"},
                
                new Burger { Name = "cow", Category = "desserts",Price = 13.99f, Image = "noodle.jpg", Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Bibendum est ultricies"},
            };
        }

    }
}
