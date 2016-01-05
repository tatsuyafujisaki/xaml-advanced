using System.Collections.Generic;

namespace RestaurantManager.Models
{
    public class OrderDataManager : DataManager
    {
        private List<MenuItem> _menuItems;
        private List<MenuItem> _currentlySelectedMenuItems;

        public List<MenuItem> MenuItems
        {
            get
            {
                return _menuItems;
            }
            set
            {
                _menuItems = value;
                OnPropertyChanged();
            }
        }

        public List<MenuItem> CurrentlySelectedMenuItems
        {
            get
            {
                return _currentlySelectedMenuItems;
            }
            set
            {
                _currentlySelectedMenuItems = value;
                OnPropertyChanged();
            }
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