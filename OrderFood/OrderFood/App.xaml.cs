using OrderFood.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace OrderFood
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            MainPage = new NavigationPage(new BottomNavBarXf.Home());
            //MainPage = new NavigationPage(new DetailMonAn());
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
