using BottomBar.XamarinForms;
using OrderFood.Modals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
namespace BottomNavBarXf
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Home 
    {
        public Home()
        {
            InitializeComponent();
        }

       
         static List<Burger> ListBurgers = new List<Burger>();
        public Home(Burger burger)
            {

                InitializeComponent();
            KhoiTaoCart(burger);
            }
        public void KhoiTaoCart(Burger burger)
        {

            ListBurgers.Add(burger);
            lstfoods.ItemsSource = ListBurgers;
        }
    }
    
}