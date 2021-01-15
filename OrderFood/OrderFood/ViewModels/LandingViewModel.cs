//using OrderFood.Components;
//using OrderFood.Models;
//using System;
//using System.Collections.Generic;
//using System.Collections.ObjectModel;
//using System.Diagnostics;
//using System.Text;
//using System.Windows.Input;
//using Xamarin.Forms;

//namespace OrderFood.ViewModels
//{
//    public class LandingViewModel : BaseViewModel
//    {
//        public LandingViewModel()
//        {
//            burgers = GetBurgers();
//        }

//        ObservableCollection<Category> burgers;
//        ObservableCollection<Burger> foods;
//        public ObservableCollection<Category> Burgers
//        {
//            get { return burgers; }
//            set
//            {
//                burgers = value;
//                OnPropertyChanged();
//            }
//        }
//        private Category selectedBurger;
//        public Category SelectedBurger
//        {
//            get { return selectedBurger; }
//            set
//            {
//                selectedBurger = value;
//                OnPropertyChanged();
//            }
//        }
//        public ICommand SelectionCommand => new Command(DisplayBurger);
       
//        private void DisplayBurger()
//        {
//            if (selectedBurger != null)
//            {
//                if (selectedBurger.CategoryName == "breakfast")
//                {
//                    foods = GetBreakFast();
//                }else if(selectedBurger.CategoryName == "lunch")
//                {
//                    foods = GetLunch();
//                }
//                else if (selectedBurger.CategoryName == "dinner")
//                {
//                    foods = GetDinner();
//                }
//                else if (selectedBurger.CategoryName == "snack")
//                {
//                    foods = GetSnack();
//                }
//                else if (selectedBurger.CategoryName == "desserts")
//                {
//                    foods = GetDesserts();
//                }
//                else if (selectedBurger.CategoryName == "supper")
//                {
//                    foods = GetSupper();
//                }
//                var viewModel = new DetailsViewModel { selectedBurger = foods[0], Burgers = foods, position = 0 };
//                var detailsPage = new DetailsPage { BindingContext = viewModel };

//                var navigation = Application.Current.MainPage as NavigationPage;
//                navigation.PushAsync(detailsPage, true);
//            }
//        }
//        private ObservableCollection<Category> GetBurgers()
//        {
//            return new ObservableCollection<Category>
//            {
//                new Category { Name = "BREAKFAST",CategoryName = "breakfast",  Image = "breakfast.jpg", Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Bibendum est ultricies"},
//                new Category { Name = "LUNCH",CategoryName = "lunch", Image = "noodle.jpg", Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Bibendum est ultricies"},
//                new Category { Name = "DINNER", CategoryName = "dinner", Image = "pizza.jpg", Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Bibendum est ultricies"},
//                new Category { Name = "SNACK",CategoryName = "snack",  Image = "vegetable.jpg", Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Bibendum est ultricies"},
//                new Category { Name = "SUPPER", CategoryName = "supper",Image = "breakfast.jpg", Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Bibendum est ultricies"},
//                new Category { Name = "DESSERTS",CategoryName = "desserts",  Image = "noodle.jpg", Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Bibendum est ultricies"}
//            };
//        }
//        private ObservableCollection<Burger> GetBreakFast()
//        {
//            return new ObservableCollection<Burger>
//            {
             
//                new Burger { Name = "Break",Category = "breakfast",  Price = 12.99f, Image = "breakfast.jpg", Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Bibendum est ultricies"},
//                new Burger { Name = "Noodle",Category = "breakfast",  Price = 19.99f, Image = "noodle.jpg", Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Bibendum est ultricies"},

            
                
//            };
//        }
//        private ObservableCollection<Burger> GetLunch()
//        {
//            return new ObservableCollection<Burger>
//            {
                
//                new Burger { Name = "Pizza",Category = "lunch", Price = 17.29f, Image = "pizza.jpg", Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Bibendum est ultricies"},
                
//                new Burger { Name = "Pizza",Category = "lunch", Price = 17.29f, Image = "pizza.jpg", Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Bibendum est ultricies"},
                
//            };
//        }
//        private ObservableCollection<Burger> GetSupper()
//        {
//            return new ObservableCollection<Burger>
//            {

//                new Burger { Name = "Pizza",Category = "supper", Price = 17.29f, Image = "pizza.jpg", Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Bibendum est ultricies"},

//                new Burger { Name = "Pizza",Category = "supper", Price = 17.29f, Image = "pizza.jpg", Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Bibendum est ultricies"},

//            };
//        }
//        private ObservableCollection<Burger> GetDinner()
//        {
//            return new ObservableCollection<Burger>
//            {

               
//                new Burger { Name = "Apple",Category = "dinner", Price = 15.99f, Image = "vegetable.jpg", Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Bibendum est ultricies"},
              
//                new Burger { Name = "Apple",Category = "dinner", Price = 15.99f, Image = "vegetable.jpg", Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Bibendum est ultricies"},
                
//            };
//        }
//        private ObservableCollection<Burger> GetSnack()
//        {
//            return new ObservableCollection<Burger>
//            {

               
//                new Burger { Name = "Rice",Category = "snack", Price = 11.99f, Image = "breakfast.jpg", Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Bibendum est ultricies"},
               
//                new Burger { Name = "Rice",Category = "snack", Price = 11.99f, Image = "breakfast.jpg", Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Bibendum est ultricies"},
               
//            };
//        }
//        private ObservableCollection<Burger> GetDesserts()
//        {
//            return new ObservableCollection<Burger>
//            {

               
//                new Burger { Name = "cow", Category = "desserts",Price = 13.99f, Image = "noodle.jpg", Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Bibendum est ultricies"},
                
//                new Burger { Name = "cow", Category = "desserts",Price = 13.99f, Image = "noodle.jpg", Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Bibendum est ultricies"},
//            };
//        }
//        private ObservableCollection<Burger> GetTemp()
//        {
//            ObservableCollection<Burger> ListBurger = new ObservableCollection<Burger>();
//            ListBurger.Add(new Burger { Name = "cow", Category = "desserts", Price = 13.99f, Image = "noodle.jpg", Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Bibendum est ultricies" });
//            return ListBurger;
//        }
//    }
//}
