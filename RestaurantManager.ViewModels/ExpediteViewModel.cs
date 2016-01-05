using RestaurantManager.Models;
using System.Collections.Generic;

namespace RestaurantManager.ViewModels
{
    public class ExpediteViewModel : ViewModel
    {
        public List<Order> OrderItems => Repository?.Orders;

        protected override void OnDataLoaded()
        {
            NotifyPropertyChanged("OrderItems");
        }
    }
}
