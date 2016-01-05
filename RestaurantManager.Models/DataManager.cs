using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace RestaurantManager.Models
{
    public abstract class DataManager : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected abstract void OnDataLoaded();
        protected RestaurantContext Repository { get; private set; }

        protected DataManager()
        {
            LoadData();
        }

        private async void LoadData()
        {
            Repository = new RestaurantContext();
            await Repository.InitializeContextAsync();
            OnDataLoaded();
        }

        protected void SetProperty<T>(ref T property, T value, [CallerMemberName] string propertyName = null)
        {
            if (Equals(property, value)) { return; }
            property = value;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}