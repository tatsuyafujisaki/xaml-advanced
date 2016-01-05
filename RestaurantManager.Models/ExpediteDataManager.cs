using System.Collections.Generic;

namespace RestaurantManager.Models
{
    public class ExpediteDataManager : DataManager
    {
        private List<Order> _orderItems;

        public List<Order> OrderItems
        {
            get { return _orderItems; }
            set { SetProperty(ref _orderItems, value); }
        }

        protected override void OnDataLoaded()
        {
            OrderItems = Repository.Orders;
        }
    }
}