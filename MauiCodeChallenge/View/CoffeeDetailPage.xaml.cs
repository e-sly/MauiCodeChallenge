using MauiCodeChallenge.Core.Model;
using MauiCodeChallenge.Core.ViewModel;

namespace MauiCodeChallenge.View
{
    [QueryProperty("CoffeeProduct", "CoffeeProduct")]
    public partial class CoffeeDetailPage : ContentPage
    {
        private readonly CoffeeViewModel _viewModel;
        private Coffee? _coffeeProduct;

        public CoffeeDetailPage(CoffeeViewModel coffeeViewModel)
        {
            InitializeComponent();
            _viewModel = coffeeViewModel;
            BindingContext = _viewModel;
        }

        public Coffee CoffeeProduct
        {
            set
            {
                _coffeeProduct = value;
                _viewModel.CoffeeProduct = _coffeeProduct;
            }
        }
    }
}
