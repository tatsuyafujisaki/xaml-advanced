using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Windows.UI.Popups;
using RestaurantManager.Models;

namespace RestaurantManager.ViewModels
{
    public class OrderViewModel : ViewModel
    {
        private List<MenuItem> _menuItems;
        private MenuItem _selectedMenuItem;


        public OrderViewModel()
        {
            AddMenuItemCommand = new DelegateCommand(AddMenuItem);
            SubmitOrderCommand = new DelegateCommand(SubmitOrder);
            CurrentlySelectedMenuItems = new ObservableCollection<MenuItem>();
        }

        public ObservableCollection<MenuItem> CurrentlySelectedMenuItems { get; }
        public DelegateCommand AddMenuItemCommand { get; private set; }
        public DelegateCommand SubmitOrderCommand { get; private set; }

        public List<MenuItem> MenuItems
        {
            get { return _menuItems; }
            private set
            {
                _menuItems = value;
                NotifyPropertyChanged();
            }
        }

        public MenuItem SelectedMenuItem
        {
            get { return _selectedMenuItem; }
            set
            {
                _selectedMenuItem = value;
                NotifyPropertyChanged();
            }
        }

        protected override void OnDataLoaded()
        {
            MenuItems = Repository.StandardMenuItems;
        }

        private void AddMenuItem()
        {
            CurrentlySelectedMenuItems.Add(SelectedMenuItem);
        }

        private async void SubmitOrder()
        {
            Repository.Orders.Add(
                new Order
                {
                    Items = CurrentlySelectedMenuItems.ToList(),
                    Table = Repository.Tables.First(),
                    Expedite = false
                });

            CurrentlySelectedMenuItems.Clear();

            await new MessageDialog("Order has been submitted").ShowAsync();
        }
    }
}