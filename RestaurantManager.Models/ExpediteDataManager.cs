using System.Collections.Generic;

namespace RestaurantManager.Models
{
    public class ExpediteDataManager : DataManager
    {
        protected override void OnDataLoaded()
        {

        }

        public List<Order> OrderItems
        {
            get { return base.Repository.Orders; }
        }
    }
}
