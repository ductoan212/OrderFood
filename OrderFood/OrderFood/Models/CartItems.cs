using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace OrderFood.Models
{
    public class CartItems
    {
        public ObservableCollection<CTHD> cartItems;
        public decimal total;
        public CartItems()
        {
            cartItems = new ObservableCollection<CTHD>();
        }

        public void UpdateItems(ObservableCollection<CTHD> items)
        {
            cartItems = items;
        }
    }
}
