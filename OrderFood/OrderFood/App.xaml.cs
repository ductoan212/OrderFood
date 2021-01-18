using OrderFood.Components;
using OrderFood.Models;
using OrderFood.Views;
using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace OrderFood
{
    public partial class App : Application
    {
        public static User currentUser;
        public static HoaDon currentHD;
        public static List<MonAn> listFavs;
        public static List<CTHD> listCartItems;
        public App()
        {
            InitializeComponent();
            //MainPage = new NavigationPage(new BottomNavBarXf.Home());
            MainPage = new NavigationPage(new Login());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
