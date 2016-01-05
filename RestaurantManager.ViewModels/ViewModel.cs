using RestaurantManager.Models;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace RestaurantManager.ViewModels
{
    public abstract class ViewModel : INotifyPropertyChanged
    {
        protected RestaurantContext Repository { get; private set; }

        protected ViewModel()
        {
            LoadData();
        }

        private async void LoadData()
        {
            this.Repository = await RestaurantContextFactory.GetRestaurantContextAsync();
            OnDataLoaded();
        }

        protected abstract void OnDataLoaded();

        public event PropertyChangedEventHandler PropertyChanged;

        public void NotifyPropertyChanged([CallerMemberName]string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
