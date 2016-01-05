using RestaurantManager.Models;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace RestaurantManager.ViewModels
{
    public abstract class ViewModel : INotifyPropertyChanged
    {
        private bool _isLoading;

        protected ViewModel()
        {
            LoadData();
        }

        protected RestaurantContext Repository { get; private set; }

        public bool IsLoading
        {
            get { return _isLoading; }

            private set
            {
                _isLoading = value;
                NotifyPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private async void LoadData()
        {
            IsLoading = true;
            Repository = await RestaurantContextFactory.GetRestaurantContextAsync();
            OnDataLoaded();
            IsLoading = false;
        }

        protected abstract void OnDataLoaded();

        protected void NotifyPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}