using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace RestaurantManager.Models
{
    public abstract class DataManager : INotifyPropertyChanged
    {
        protected DataManager()
        {
            LoadData();
        }

        protected RestaurantContext Repository { get; private set; }
        public event PropertyChangedEventHandler PropertyChanged;

        private async void LoadData()
        {
            Repository = new RestaurantContext();
            await Repository.InitializeContextAsync();
            OnDataLoaded();
            OnPropertyChanged();
        }

        protected abstract void OnDataLoaded();

        public void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}