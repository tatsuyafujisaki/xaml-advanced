using System.Collections.Generic;

namespace RestaurantManager.Models
{
    public class OrderDataManager : DataManager
    {
        private List<MenuItem> _menuItems;
        private List<MenuItem> _currentlySelectedMenuItems;

        public List<MenuItem> MenuItems
        {
            get { return _menuItems; }
            set { SetProperty(ref _menuItems, value); }
        }

        public List<MenuItem> CurrentlySelectedMenuItems
        {
            get { return _currentlySelectedMenuItems; }
            set { SetProperty(ref _currentlySelectedMenuItems, value); }
        }

        protected override void OnDataLoaded()
        {
            MenuItems = Repository.StandardMenuItems;

            CurrentlySelectedMenuItems = new List<MenuItem>
            {
                MenuItems[3],
                MenuItems[5]
            };
        }
    }
}