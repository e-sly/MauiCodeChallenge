using MauiCodeChallenge.View;

namespace MauiCodeChallenge
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute(nameof(CoffeeDetailPage), typeof(CoffeeDetailPage));
        }
    }
}
