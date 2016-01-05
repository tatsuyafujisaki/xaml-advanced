using Microsoft.Xaml.Interactivity;
using System;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;

namespace RestaurantManager.Extensions
{
    public class RightClickMessageDialogBehavior : DependencyObject, IBehavior
    {
        public string Title { get; set; }
        public string Message { get; set; }
        public DependencyObject AssociatedObject { get; private set; }

        public void Attach(DependencyObject associatedObject)
        {
            if (associatedObject is Page)
            {
                AssociatedObject = associatedObject;
                ((Page)AssociatedObject).RightTapped += Page_RightTapped;
            }
        }

        public void Detach()
        {
            (AssociatedObject as Page).RightTapped -= Page_RightTapped;
        }

        private async void Page_RightTapped(object sender, RightTappedRoutedEventArgs e)
        {
            await new MessageDialog(Message, Title).ShowAsync();
        }
    }
}
