using OrderFood.Components;
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

            //MainPage = new NavigationPage(new Login());
            MainPage =new Login();

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
