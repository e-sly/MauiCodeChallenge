using MauiCodeChallenge.Core.Model;

namespace MauiCodeChallenge.Core.Services
{
    public class CoffeeService : ICoffeeService
    {
        public List<Coffee> GetCoffeeProducts()
        {
            return new List<Coffee>
            {
                new Coffee { Name = "Espresso", Description = "A strong and concentrated coffee made by forcing hot water through finely-ground coffee beans." },
                new Coffee { Name = "Cappuccino", Description = "Equal parts espresso, steamed milk, and milk foam, creating a creamy and frothy drink." },
                new Coffee { Name = "Latte", Description = "Similar to a cappuccino but with more steamed milk and less foam, resulting in a milder flavor." }
            };
        }
    }
}
