using MauiCodeChallenge.Core.ViewModel;
using NSubstitute;

namespace MauiCodeChallenge.Tests.ViewModel
{
    public class CoffeeViewModelTests
    {
        private CoffeeViewModel _sut;
        private readonly ICoffeeService _coffeeService;

        public CoffeeViewModelTests()
        {
            _coffeeService = Substitute.For<CoffeeService>();

            _sut = new CoffeeViewModel(_coffeeService);
        }

        [Fact]
        public void Should_Coffees_Collection_Is_Not_Null_Upon_Initialization()
        {
            // Arrange

            // Act & Assert
            Assert.NotNull(_sut.Coffees);
        }

        [Fact]
        public void Should_Constructor_Initialize_The_Title_And_Calls_LoadCoffee_When_Called()
        {
            // Arrange

            // Act & Assert
            Assert.Equal("Coffee bar", _sut.Title);
            _coffeeService.Received(1).GetCoffeeProducts();
        }

        [Fact]
        public void Should_LoadCoffee_Add_Coffee_Products_To_Coffees_Collection_When_Called()
        {
            // Arrange
            var coffeeService = Substitute.For<ICoffeeService>();

            // Arrange
            var coffeeProducts = new List<Coffee>
            {
                new() { Name = "Coffee1", Description = "Description1" },
                new() { Name = "Coffee2", Description = "Description2" }
            };
            // Use Returns method directly on the call to GetCoffeeProducts
            coffeeService.GetCoffeeProducts().Returns(coffeeProducts);

            // Act
            _sut = new CoffeeViewModel(coffeeService);


            // Assert
            Assert.Equal(coffeeProducts, _sut.Coffees.ToList());
        }

        [Fact]
        public void Should_CoffeeProduct_PropertyChanged_RaisesPropertyChangedEvent_When_CoffeeProduct_Changed()
        {
            // Arrange
            var eventRaised = false;
            _sut.PropertyChanged += (sender, args) =>
            {
                if (args.PropertyName == nameof(_sut.CoffeeProduct))
                    eventRaised = true;
            };

            // Act
            _sut.CoffeeProduct = new Coffee() { Name = "Coffee product", Description = "Description" };

            // Assert
            Assert.True(eventRaised);
        }
    }
}
