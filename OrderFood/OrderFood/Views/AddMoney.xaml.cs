using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace OrderFood.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddMoney : ContentPage
    {
        public AddMoney()
        {
            InitializeComponent();
            Title = "Nạp thêm tiền";
        }
    }
}