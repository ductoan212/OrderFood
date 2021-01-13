using OrderFood.Models;
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
    public partial class DaThanhToan : ContentPage
    {
        static List<MonAn> listMonAn=new List<MonAn>();
        public DaThanhToan()
        {
            InitializeComponent();
            InitList(listMonAn);
        }
        public DaThanhToan( List<MonAn> list )
        {
            InitializeComponent();
            assignListMonAn(list);
            InitList(listMonAn);
        }
        public void assignListMonAn(List<MonAn> list)
        {
            list.ForEach((MonAn item) =>
            {
                listMonAn.Add(item);
            });
        }
        public void InitList(List<MonAn> list)
        {
            lstcheckout.ItemsSource = list;
        }
    }
}