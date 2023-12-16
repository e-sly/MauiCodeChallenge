namespace MauiCodeChallenge.Tests
{
    public class CoffeeServiceTests
    {
        private readonly CoffeeService _sut;

        public CoffeeServiceTests()
        {
            _sut = new CoffeeService();
        }

        [Fact]
        public void Should_GetCoffeeProducts_Return_Coffee_List_When_Called()
        {
            // Arrange

            // Act
            List<Coffee> coffeeProducts = _sut.GetCoffeeProducts();

            // Assert
            Assert.NotNull(coffeeProducts);
            Assert.IsType<List<Coffee>>(coffeeProducts);
        }

        [Fact]
        public void Should_GetCoffeeProducts_Return_Three_Coffee_Products_When_Called()
        {
            // Arrange
            const int expectedCount = 3;

            // Act
            List<Coffee> coffeeProducts = _sut.GetCoffeeProducts();

            // Assert
            Assert.Equal(expectedCount, coffeeProducts.Count);
        }

        [Fact]
        public void GetCoffeeProducts_ContainsExpectedCoffeeItems()
        {
            // Arrange
            var expectedCoffees = new List<Coffee>
            {
                new() {Name = "Espresso", Description = "A strong and concentrated coffee made by forcing hot water through finely-ground coffee beans."},
                new() {Name = "Cappuccino", Description = "Equal parts espresso, steamed milk, and milk foam, creating a creamy and frothy drink."},
                new() {Name = "Latte", Description = "Similar to a cappuccino but with more steamed milk and less foam, resulting in a milder flavor."}
            };

            // Act
            List<Coffee> coffeeProducts = _sut.GetCoffeeProducts();

            // Assert
            Assert.Equal(expectedCoffees, coffeeProducts, CoffeeEqualityComparer.Instance);
        }
    }

    public class CoffeeEqualityComparer : IEqualityComparer<Coffee>
    {
        public static CoffeeEqualityComparer Instance { get; } = new CoffeeEqualityComparer();

        public bool Equals(Coffee x, Coffee y)
        {
            return x.Name == y.Name && x.Description == y.Description;
        }

        public int GetHashCode(Coffee obj)
        {
            return obj.Name.GetHashCode() ^ obj.Description.GetHashCode();
        }
    }
}