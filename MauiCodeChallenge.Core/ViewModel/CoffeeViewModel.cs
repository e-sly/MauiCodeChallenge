using CommunityToolkit.Mvvm.ComponentModel;
using MauiCodeChallenge.Core.Model;
using MauiCodeChallenge.Core.Services;
using System.Collections.ObjectModel;

namespace MauiCodeChallenge.Core.ViewModel
{
    public partial class CoffeeViewModel : ObservableObject
    {
        readonly ICoffeeService _coffeeService;

        [ObservableProperty]
        private string title;

        [ObservableProperty]
        private Coffee? coffeeProduct;

        public ObservableCollection<Coffee> Coffees { get; } = [];

        public CoffeeViewModel(ICoffeeService coffeeService)
        {
            Title = "Coffee bar";
            _coffeeService = coffeeService;
            LoadCoffee();
        }

        private void LoadCoffee()
        {
            var products = _coffeeService.GetCoffeeProducts();
            foreach (var product in products) { Coffees.Add (product); }
        }
     }
}
