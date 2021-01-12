using BottomBar.XamarinForms;
using OrderFood.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace OrderFood.Components
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DetailsPage : ContentPage
    {
        public DetailsPage()
        {
            InitializeComponent();
            Title = "DS Món ăn";
        }

    private void Button_Clicked(object sender, EventArgs e)
        {
            MonAn item = (MonAn)caroulitem.CurrentItem;
            Navigation.PushAsync(new BottomNavBarXf.Home(item,"cart"));
            
        }

        private void ImageButton_Clicked(object sender, EventArgs e)
        {
        
            Navigation.PushAsync(new BottomNavBarXf.Home());
        }

        private void ImageButton_Clicked_1(object sender, EventArgs e)
        {
            MonAn item = (MonAn)caroulitem.CurrentItem;
            Navigation.PushAsync(new BottomNavBarXf.Home(item,"fav"));
        }
    }
        
}