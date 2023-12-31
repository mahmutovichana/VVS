﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using SmartCafe.Controllers;
using SmartCafe.Data;
using SmartCafe.Models;
using VVSProject.Interfaces;
using Moq;

using Microsoft.EntityFrameworkCore;

using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using static SmartCafe.Controllers.AdminPanelController;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Web.Helpers;
using System.Xml.Linq;

namespace UnitTestHana
{
    [TestClass]
    public class UnitTestHana
    {
        private AdminPanelController controller;
        private Mock<IApplicationDbContext> mockDbContext;
        private ApplicationDbContext mockContext;

        // method for creating a mock DbSet
        private static DbSet<T> MockDbSet<T>(List<T> data) where T : class
        {
            var queryable = data.AsQueryable();
            var mockSet = new Mock<DbSet<T>>();
            mockSet.As<IQueryable<T>>().Setup(m => m.Provider).Returns(queryable.Provider);
            mockSet.As<IQueryable<T>>().Setup(m => m.Expression).Returns(queryable.Expression);
            mockSet.As<IQueryable<T>>().Setup(m => m.ElementType).Returns(queryable.ElementType);
            mockSet.As<IQueryable<T>>().Setup(m => m.GetEnumerator()).Returns(queryable.GetEnumerator());
            return mockSet.Object;
        }

        [TestInitialize]
        public void SetUp()
        {
            controller = new AdminPanelController(null);
            mockDbContext = new Mock<IApplicationDbContext>();
        }

        [TestMethod]
        public void SearchDrinksByName_ReturnsCorrectResults()
        {
            // Arrange
            var searchTerm = "Kiwi";
            // setting up mock behavior for Drinks property
            var drinksMocked = new List<Drink>
            {
                new Drink(1, "Grapefruit Spritz", 4.99),
                new Drink(2, "Cucumber Cooler", 2.99),
                new Drink(3, "Orange Blossom", 2.99),
                new Drink(4, "Kiwi Kiss", 6.99)
            };
            mockDbContext.Setup(m => m.Drinks).Returns(MockDbSet(drinksMocked));

            // injecting the mockDbContext into the controller
            var controller = new AdminPanelController(mockDbContext.Object);

            // Act
            var result = controller.searchDrinksByName(searchTerm) as ActionResult<IEnumerable<Drink>>;

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result.Value, typeof(List<Drink>));

            var drinks = (List<Drink>)result.Value;
            Assert.IsTrue(drinks.Count > 0);
        }

        [TestMethod]
        public void SearchDrinksByIngredient_ReturnsCorrectResults()
        {
            // Arrange
            var searchTerm = "Vodka";
            var drinksMocked = new List<Drink>
            {
                new Drink { id = 1, name = "Grapefruit Spritz", price = 4.99 },
                new Drink { id = 2, name = "Cucumber Cooler", price = 2.99 },
                new Drink { id = 3, name = "Orange Blossom", price = 2.99 },
                new Drink { id = 4, name = "Kiwi Kiss", price = 6.99 }
            };

            var ingredientsMocked = new List<Ingredient>
            {
                new Ingredient { id = 1, name = "Vodka", quantity = 100 },
                new Ingredient { id = 2, name = "Lime", quantity = 5 },
                new Ingredient { id = 3, name = "Soda", quantity = 200 }
            };

            var drinkIngredientsMocked = new List<DrinkIngredient>
            {
                new DrinkIngredient { id = 1, idDrink = 1, idIngredient = 1, Ingredient = ingredientsMocked[0], Drink = drinksMocked[0] },
                new DrinkIngredient { id = 2, idDrink = 2, idIngredient = 1, Ingredient = ingredientsMocked[0], Drink = drinksMocked[1] },
                new DrinkIngredient { id = 3, idDrink = 3, idIngredient = 2, Ingredient = ingredientsMocked[1], Drink = drinksMocked[2] },
                new DrinkIngredient { id = 4, idDrink = 4, idIngredient = 3, Ingredient = ingredientsMocked[2], Drink = drinksMocked[3] }
            };

            // Konfiguracija MockDbContext-a
            mockDbContext.Setup(m => m.Drinks).Returns(MockDbSet(drinksMocked));
            mockDbContext.Setup(m => m.Ingredients).Returns(MockDbSet(ingredientsMocked));
            mockDbContext.Setup(m => m.DrinkIngredients).Returns(MockDbSet(drinkIngredientsMocked));

            // injecting the mockDbContext into the controller
            var controller = new AdminPanelController(mockDbContext.Object);

            // Act
            var result = controller.searchDrinksByIngredient(searchTerm) as ActionResult<IEnumerable<Drink>>;

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result.Value, typeof(List<Drink>));

            var drinks = (List<Drink>)result.Value;
            Assert.IsTrue(drinks.Count > 0);

        }

        [TestMethod]
        public void CalculateDailyProfit_ReturnsCorrectResult()
        {
            // Arrange
            var selectedDrinks = new List<DrinkQuantityPair>
            {
                new DrinkQuantityPair { DrinkId = 1, Quantity = 2 },
                new DrinkQuantityPair { DrinkId = 2, Quantity = 3 },
                new DrinkQuantityPair { DrinkId = 3, Quantity = 1 }
            };

            var mockDrinks = new List<Drink>
            {
                new Drink { id = 1, name = "Drink1", price = 10 },
                new Drink { id = 2, name = "Drink2", price = 15 },
                new Drink { id = 3, name = "Drink3", price = 8 }
            };

            mockDbContext.Setup(c => c.Drinks).Returns(MockDbSet(mockDrinks));

            // injecting the mockDbContext into the controller
            var controller = new AdminPanelController(mockDbContext.Object);

            // Act
            var result = controller.CalculateDailyProfit(selectedDrinks);

            // Assert
            Assert.IsInstanceOfType(result, typeof(Tuple<double, string>));
            Assert.IsNotNull(result);

            double dailyProfit = result.Item1;
            string message = result.Item2;

            Assert.AreEqual(73.0, dailyProfit, 0.01);
            Assert.AreEqual("Your profit is above average", message);
        }


        [TestMethod]
        public void CalculateDailyProfit_DrinkNotFound_ReturnsResultWithZeroProfit()
        {
            // Arrange
            var selectedDrinks = new List<DrinkQuantityPair>
            {
                new DrinkQuantityPair { DrinkId = 1, Quantity = 2 }
            };

            var mockDrinks = new List<Drink>
            {
                new Drink { id = 150, name = "Drink1", price = 10 }
            };

            mockDbContext.Setup(c => c.Drinks).Returns(MockDbSet(mockDrinks));

            // injecting the mockDbContext into the controller
            var controller = new AdminPanelController(mockDbContext.Object);

            // Act
            var result = controller.CalculateDailyProfit(selectedDrinks);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(0.0, result.Item1);
        }


        [TestMethod]
        public void CalculateDailyProfit_NegativeQuantity_ReturnsResultWithZeroProfit()
        {
            // Arrange
            var selectedDrinks = new List<DrinkQuantityPair>
            {
                new DrinkQuantityPair { DrinkId = 1, Quantity = -2 }
            };

            var mockDrinks = new List<Drink>
            {
                new Drink { id = 150, name = "Drink1", price = 10 }
            };

            mockDbContext.Setup(c => c.Drinks).Returns(MockDbSet(mockDrinks));

            // injecting the mockDbContext into the controller
            var controller = new AdminPanelController(mockDbContext.Object);

            // Act
            var result = controller.CalculateDailyProfit(selectedDrinks);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(0.0, result.Item1);
        }

        [TestMethod]
        public void CalculateDailyProfit_EmptyList_ReturnsResultWithZeroProfit()
        {
            // Arrange
            var selectedDrinks = new List<DrinkQuantityPair>();

            var mockDrinks = new List<Drink>
            {
                new Drink { id = 1, name = "Drink1", price = 10 }
            };

            mockDbContext.Setup(c => c.Drinks).Returns(MockDbSet(mockDrinks));

            // injecting the mockDbContext into the controller
            var controller = new AdminPanelController(mockDbContext.Object);

            // Act
            var result = controller.CalculateDailyProfit(selectedDrinks);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(0.0, result.Item1);
            Assert.AreEqual("No drinks selected.", result.Item2);
        }

        [TestMethod]
        public void CalculateDailyProfit_NullList_ReturnsZeroProfitWithMessage()
        {
            // Arrange
            List<DrinkQuantityPair> selectedDrinks = null;

            var mockDrinks = new List<Drink>
            {
                new Drink { id = 1, name = "Drink1", price = 10 }
            };

            mockDbContext.Setup(c => c.Drinks).Returns(MockDbSet(mockDrinks));

            // injecting the mockDbContext into the controller
            var controller = new AdminPanelController(mockDbContext.Object);

            // Act
            var result = controller.CalculateDailyProfit(selectedDrinks);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(0.0, result.Item1);
            Assert.AreEqual("No drinks selected.", result.Item2);
        }


        [TestMethod]
        [DynamicData(nameof(GetCalculateProfitXmlTestData), DynamicDataSourceType.Method)]
        public void CalculateDailyProfit_ReturnsCorrectResultFromXml(int drink1Quantity, int drink2Quantity, int drink3Quantity, double expectedProfit, string expectedMessage)
        {
            // Arrange
            var selectedDrinks = new List<DrinkQuantityPair>
            {
                new DrinkQuantityPair { DrinkId = 1, Quantity = drink1Quantity },
                new DrinkQuantityPair { DrinkId = 2, Quantity = drink2Quantity },
                new DrinkQuantityPair { DrinkId = 3, Quantity = drink3Quantity }
            };

            var mockDrinks = new List<Drink>
            {
                new Drink { id = 1, name = "Drink1", price = 10 },
                new Drink { id = 2, name = "Drink2", price = 15 },
                new Drink { id = 3, name = "Drink3", price = 8 }
            };

            mockDbContext.Setup(c => c.Drinks).Returns(MockDbSet(mockDrinks));

            // injecting the mockDbContext into the controller
            var controller = new AdminPanelController(mockDbContext.Object);

            // Act
            var result = controller.CalculateDailyProfit(selectedDrinks);

            // Assert
            Assert.IsInstanceOfType(result, typeof(Tuple<double, string>));
            Assert.IsNotNull(result);

            double dailyProfit = result.Item1;
            string message = result.Item2;

            Assert.AreEqual(expectedProfit, dailyProfit, 0.01);
            Assert.AreEqual(expectedMessage, message);
        }

        public static IEnumerable<object[]> GetCalculateProfitXmlTestData()
        {
            var xmlTestData = @"
            <TestData>
                <TestEntry>
                    <Drink1Quantity>2</Drink1Quantity>
                    <Drink2Quantity>3</Drink2Quantity>
                    <Drink3Quantity>1</Drink3Quantity>
                    <ExpectedProfit>73</ExpectedProfit>
                    <ExpectedMessage>Your profit is above average</ExpectedMessage>
                </TestEntry>
            </TestData>";

            var xmlDoc = XDocument.Parse(xmlTestData);
            var testData = xmlDoc.Descendants("TestEntry")
                .Select(entry => new
                {
                    Drink1Quantity = int.Parse(entry.Element("Drink1Quantity").Value),
                    Drink2Quantity = int.Parse(entry.Element("Drink2Quantity").Value),
                    Drink3Quantity = int.Parse(entry.Element("Drink3Quantity").Value),
                    ExpectedProfit = double.Parse(entry.Element("ExpectedProfit").Value),
                    ExpectedMessage = entry.Element("ExpectedMessage").Value
                });

            return testData.Select(data => new object[] { data.Drink1Quantity, data.Drink2Quantity, data.Drink3Quantity, data.ExpectedProfit, data.ExpectedMessage });
        }

        [TestMethod]
        [DynamicData(nameof(GetCalculateProfitCsvTestData), DynamicDataSourceType.Method)]
        public void CalculateDailyProfit_ReturnsCorrectResultFromCsv(int drink1Quantity, int drink2Quantity, int drink3Quantity, double expectedProfit, string expectedMessage)
        {
            // Arrange
            var selectedDrinks = new List<DrinkQuantityPair>
            {
                new DrinkQuantityPair { DrinkId = 1, Quantity = drink1Quantity },
                new DrinkQuantityPair { DrinkId = 2, Quantity = drink2Quantity },
                new DrinkQuantityPair { DrinkId = 3, Quantity = drink3Quantity }
            };

            var mockDrinks = new List<Drink>
            {
                new Drink { id = 1, name = "Drink1", price = 10 },
                new Drink { id = 2, name = "Drink2", price = 15 },
                new Drink { id = 3, name = "Drink3", price = 8 }
            };

            mockDbContext.Setup(c => c.Drinks).Returns(MockDbSet(mockDrinks));

            // injecting the mockDbContext into the controller
            var controller = new AdminPanelController(mockDbContext.Object);

            // Act
            var result = controller.CalculateDailyProfit(selectedDrinks);

            // Assert
            Assert.IsInstanceOfType(result, typeof(Tuple<double, string>));
            Assert.IsNotNull(result);

            double dailyProfit = result.Item1;
            string message = result.Item2;

            Assert.AreEqual(expectedProfit, dailyProfit, 0.01);
            Assert.AreEqual(expectedMessage, message);
        }

        public static List<object[]> GetCalculateProfitCsvTestData()
        {
            var csvTestData = @"2,3,1,73,Your profit is above average,1,-2,3,0,";


            var lines = csvTestData.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
            var testDataList = new List<object[]>();

            foreach (var line in lines)
            {
                try
                {
                    var values = line.Split(',');
                    int drink1Quantity = int.Parse(values[0]);
                    int drink2Quantity = int.Parse(values[1]);
                    int drink3Quantity = int.Parse(values[2]);
                    double expectedProfit = double.Parse(values[3]);
                    string expectedMessage = values.Length > 4 ? values[4] : ""; // Ensure expectedMessage is not null

                    // Print all values in the 'values' array
                    Console.WriteLine("Values in line: " + string.Join(", ", values));

                    Console.WriteLine(drink1Quantity +" "+ drink2Quantity+" "+ drink3Quantity+" "+ expectedProfit+" "+ expectedMessage);

                    testDataList.Add(new object[] { drink1Quantity, drink2Quantity, drink3Quantity, expectedProfit, expectedMessage });
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error parsing line: {line}. Error details: {ex.Message}");
                    throw; // Rethrow the exception for test failure
                }
            }

            return testDataList;
        }

        [TestMethod]
        public void CalculateDailyProfit_NoPassThroughLoop_EmptyList_ReturnsZeroProfitWithMessage()
        {
            // Arrange
            var selectedDrinks = new List<DrinkQuantityPair>();

            var mockDrinks = new List<Drink>
        {
            new Drink { id = 1, name = "Drink1", price = 10 }
            // Dodajte potrebne objekte Drink za pokrivanje svičeva
        };

            mockDbContext.Setup(c => c.Drinks).Returns(MockDbSet(mockDrinks));

            var controller = new AdminPanelController(mockDbContext.Object);

            // Act
            var result = controller.CalculateDailyProfit(selectedDrinks);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(0.0, result.Item1);
            Assert.AreEqual("No drinks selected.", result.Item2);
        }

        [TestMethod]
        public void CalculateDailyProfit_OnePassThroughLoop_ReturnsCorrectResult()
        {
            // Arrange
            var selectedDrinks = new List<DrinkQuantityPair>
        {
            new DrinkQuantityPair { DrinkId = 1, Quantity = 2 }
        };

            var mockDrinks = new List<Drink>
        {
            new Drink { id = 1, name = "Drink1", price = 10 }
        };

            mockDbContext.Setup(c => c.Drinks).Returns(MockDbSet(mockDrinks));

            var controller = new AdminPanelController(mockDbContext.Object);

            // Act
            var result = controller.CalculateDailyProfit(selectedDrinks);

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void CalculateDailyProfit_TwoPassesThroughLoop_ReturnsCorrectResult()
        {
            // Arrange
            var selectedDrinks = new List<DrinkQuantityPair>
        {
            new DrinkQuantityPair { DrinkId = 1, Quantity = 2 },
            new DrinkQuantityPair { DrinkId = 2, Quantity = 3 }
        };

            var mockDrinks = new List<Drink>
        {
            new Drink { id = 1, name = "Drink1", price = 10 },
            new Drink { id = 2, name = "Drink2", price = 15 }
        };

            mockDbContext.Setup(c => c.Drinks).Returns(MockDbSet(mockDrinks));

            var controller = new AdminPanelController(mockDbContext.Object);

            // Act
            var result = controller.CalculateDailyProfit(selectedDrinks);

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void CalculateDailyProfit_FourPassesThroughLoop_ReturnsCorrectResult()
        {
            // Arrange
            var selectedDrinks = new List<DrinkQuantityPair>
        {
            new DrinkQuantityPair { DrinkId = 1, Quantity = 2 },
            new DrinkQuantityPair { DrinkId = 2, Quantity = 3 },
            new DrinkQuantityPair { DrinkId = 3, Quantity = 1 },
            new DrinkQuantityPair { DrinkId = 4, Quantity = 2 }
        };

            var mockDrinks = new List<Drink>
        {
            new Drink { id = 1, name = "Drink1", price = 10 },
            new Drink { id = 2, name = "Drink2", price = 15 },
            new Drink { id = 3, name = "Drink3", price = 8 },
            new Drink { id = 4, name = "Drink4", price = 12 }
        };

            mockDbContext.Setup(c => c.Drinks).Returns(MockDbSet(mockDrinks));

            var controller = new AdminPanelController(mockDbContext.Object);

            // Act
            var result = controller.CalculateDailyProfit(selectedDrinks);

            // Assert
            Assert.IsNotNull(result);
        }

        // ...

        [TestMethod]
        public void CalculateDailyProfit_NMinusOnePassesThroughLoop_ReturnsCorrectResult()
        {
            // Arrange
            var selectedDrinks = new List<DrinkQuantityPair>
    {
        new DrinkQuantityPair { DrinkId = 1, Quantity = 2 },
        new DrinkQuantityPair { DrinkId = 2, Quantity = 3 },
        new DrinkQuantityPair { DrinkId = 3, Quantity = 1 },
        new DrinkQuantityPair { DrinkId = 4, Quantity = 2 },
        new DrinkQuantityPair { DrinkId = 5, Quantity = 4 }
    };

            var mockDrinks = new List<Drink>
    {
        new Drink { id = 1, name = "Drink1", price = 10 },
        new Drink { id = 2, name = "Drink2", price = 15 },
        new Drink { id = 3, name = "Drink3", price = 8 },
        new Drink { id = 4, name = "Drink4", price = 12 },
        new Drink { id = 5, name = "Drink5", price = 20 }
    };

            mockDbContext.Setup(c => c.Drinks).Returns(MockDbSet(mockDrinks));

            var controller = new AdminPanelController(mockDbContext.Object);

            // Act
            var result = controller.CalculateDailyProfit(selectedDrinks);

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void CalculateDailyProfit_NPassesThroughLoop_ReturnsCorrectResult()
        {
            // Arrange
            var selectedDrinks = new List<DrinkQuantityPair>
    {
        new DrinkQuantityPair { DrinkId = 1, Quantity = 2 },
        new DrinkQuantityPair { DrinkId = 2, Quantity = 3 },
        new DrinkQuantityPair { DrinkId = 3, Quantity = 1 },
        new DrinkQuantityPair { DrinkId = 4, Quantity = 2 },
        new DrinkQuantityPair { DrinkId = 5, Quantity = 4 },
        new DrinkQuantityPair { DrinkId = 6, Quantity = 1 }
    };

            var mockDrinks = new List<Drink>
    {
        new Drink { id = 1, name = "Drink1", price = 10 },
        new Drink { id = 2, name = "Drink2", price = 15 },
        new Drink { id = 3, name = "Drink3", price = 8 },
        new Drink { id = 4, name = "Drink4", price = 12 },
        new Drink { id = 5, name = "Drink5", price = 20 },
        new Drink { id = 6, name = "Drink6", price = 18 }
    };

            mockDbContext.Setup(c => c.Drinks).Returns(MockDbSet(mockDrinks));

            var controller = new AdminPanelController(mockDbContext.Object);

            // Act
            var result = controller.CalculateDailyProfit(selectedDrinks);

            // Assert
            Assert.IsNotNull(result);
        }

        // N + 1 prolazaka kroz petlju nećemo testirati, kako imamo kao testni primjer 6 pića, nemoguće je proći 7 puta kroz petlju      

    }
}