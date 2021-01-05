using BottomBar.XamarinForms;
using OrderFood.Modals;
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
        }

    private void Button_Clicked(object sender, EventArgs e)
        {
        Burger item = (Burger)caroulitem.CurrentItem;
            Navigation.PushAsync(new BottomNavBarXf.Home(item));
            
        }
    }
        
}