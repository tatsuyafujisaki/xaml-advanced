using System.Collections.Generic;

namespace RestaurantManager.Models
{
    public class ExpediteDataManager : DataManager
    {
        private List<Order> _orderItems;

        public List<Order> OrderItems
        {
            get { return _orderItems; }
            set
            {
                _orderItems = value;
                OnPropertyChanged();
            }
        }

        protected override void OnDataLoaded()
        {
            OrderItems = Repository.Orders;
        }
    }
}