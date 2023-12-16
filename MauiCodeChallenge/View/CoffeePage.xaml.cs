using MauiCodeChallenge.Core.Model;
using MauiCodeChallenge.Core.ViewModel;

namespace MauiCodeChallenge.View
{
    public partial class CoffeePage : ContentPage
    {
        public CoffeePage(CoffeeViewModel coffeeViewModel)
        {
            InitializeComponent();
            BindingContext = coffeeViewModel;
        }

        private async void TapGestureRecognizer_Tapped(object sender, TappedEventArgs e)
        {
            if (((VisualElement)sender).BindingContext is not Coffee coffee) return;

            await Shell.Current.GoToAsync(nameof(CoffeeDetailPage), true, new Dictionary<string, object> 
            {
                ["CoffeeProduct"] = coffee
            });
        }
    }
}
