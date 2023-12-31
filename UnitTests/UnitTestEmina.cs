﻿using Microsoft.EntityFrameworkCore;
using Moq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SmartCafe.Controllers;
using SmartCafe.Data;
using SmartCafe.Models;
using System.Collections.Generic;
using System.Linq;
using VVSProject.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System.Xml.Linq;
using Microsoft.EntityFrameworkCore.Update;
using static SmartCafe.Controllers.AdminPanelController;

namespace UnitTestEmina
{
    [TestClass]
    public class UnitTestEmina
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
        public void InsertionSort_SortsIngredientsAscending()
        {
            // Arrange
            var ingredients = new List<Ingredient>
            {
                new Ingredient(1, "Berry", 40),
                new Ingredient(3, "Kiwi", 66),
                new Ingredient(2, "Watermelon", 30),
                new Ingredient(4, "Lemon", 37),
                new Ingredient(5, "Lime", 90)
            };

            var expectedSortedIngredients = new List<Ingredient>
            {
                new Ingredient(2, "Watermelon", 30),
                new Ingredient(4, "Lemon", 37),
                new Ingredient(1, "Berry", 40),
                new Ingredient(3, "Kiwi", 66),
                new Ingredient(5, "Lime", 90)
            };

            var sortedIngredients = controller.insertionSort(ingredients);

            Assert.IsNotNull(sortedIngredients);
            Assert.AreEqual(2, sortedIngredients[0].id);
            Assert.AreEqual(4, sortedIngredients[1].id);
            Assert.AreEqual(1, sortedIngredients[2].id);
            Assert.AreEqual(3, sortedIngredients[3].id);
            Assert.AreEqual(5, sortedIngredients[4].id);
        }

        public static IEnumerable<object[]> IngredientListXmlData()
        {
            var xmlTestData = @"
        <TestData>
            <TestEntry>
                <IngredientList>
                    <Ingredient id='1' name='Watermelon' quantity='50' />
                    <Ingredient id='2' name='Lime' quantity='20' />
                    <Ingredient id='3' name='Ice' quantity='79' />
                </IngredientList>
                <ExpectedSortedIngredients>
                    <Ingredient id='2' name='Lime' quantity='20' />
                    <Ingredient id='1' name='Watermelon' quantity='50' />
                    <Ingredient id='3' name='Ice' quantity='79' />
                </ExpectedSortedIngredients>
            </TestEntry>
        </TestData>";

            var xmlDoc = XDocument.Parse(xmlTestData);
            var testEntries = xmlDoc.Descendants("TestEntry");

            foreach (var entry in testEntries)
            {
                var expectedIngredientsElement = entry.Element("ExpectedSortedIngredients");
                var expectedIngredients = expectedIngredientsElement.Elements("Ingredient")
                    .Select(e => new Ingredient { quantity = int.Parse(e.Attribute("quantity").Value) })
                    .ToList();

                var ingredientsElement = entry.Element("IngredientList");
                var ingredients = ingredientsElement.Elements("Ingredient")
                    .Select(e => new Ingredient { quantity = int.Parse(e.Attribute("quantity").Value) })
                    .ToList();

                yield return new object[] { expectedIngredients, ingredients };
            }
        }
        [TestMethod]
        [DynamicData(nameof(IngredientListXmlData), DynamicDataSourceType.Method)]
        public void InsertionSort_XmlData_ReturnsSortedIngredientsList(List<Ingredient> expectedIngredients, List<Ingredient> ingredients)
        {
            // Act
            var sortedIngredients = controller.insertionSort(ingredients);

            // Assert
            Assert.IsNotNull(sortedIngredients);
            for (int i = 0; i < expectedIngredients.Count; i++)
            {
                Assert.AreEqual(expectedIngredients[i].quantity, sortedIngredients[i].quantity);
            }
        }


        [TestMethod]
        public void OptimalProfitMessage_RealProfitBelowOptimal_ReturnsBelowOptimalMessage()
        {
            // Arrange
            var drinks = new List<Drink>
            {
                new Drink(1, "Berrylicious", 7.9),
                new Drink(2, "Cherry Bomb", 4.9),
                new Drink(3, "Watermelon Wave", 3.6),
            };

            mockDbContext.Setup(c => c.Drinks).Returns(MockDbSet(drinks));

            controller = new AdminPanelController(mockDbContext.Object);

            // Act
            var result = controller.optimalProfitMessage(15.0); // Postavite stvarni profit manji od optimalnog

            // Assert
            Assert.AreEqual("You are below optimal profit", result);
        }

        [TestMethod]
        public void OptimalProfitMessage_RealProfitEqualsOptimal_ReturnsOptimalMessage()
        {
            // Arrange
            var drinks = new List<Drink>
            {
                new Drink(1, "Berrylicious", 5.99),
                new Drink(2, "Cherry Bomb", 7.99),
                new Drink(3, "Watermelon Wave", 3.99),
            };

            var mockDbContext = new Mock<IApplicationDbContext>();
            mockDbContext.Setup(c => c.Drinks).Returns(MockDbSet(drinks));

            controller = new AdminPanelController(mockDbContext.Object);

            // Act
            var result = controller.optimalProfitMessage(17.97); // Postavite stvarni profit jednak optimalnom

            // Assert
            Assert.AreEqual("Your profit is optimal", result);
        }

        [TestMethod]
        public void OptimalProfitMessage_RealProfitAboveOptimal_ReturnsAboveOptimalMessage()
        {
            // Arrange
            var drinks = new List<Drink>
            {
                new Drink(1, "Berrylicious", 5.99),
                new Drink(2, "Cherry Bomb", 7.99),
                new Drink(3, "Watermelon Wave", 3.99),
            };

            var mockDbContext = new Mock<IApplicationDbContext>();
            mockDbContext.Setup(c => c.Drinks).Returns(MockDbSet(drinks));

            controller = new AdminPanelController(mockDbContext.Object);

            // Act
            var result = controller.optimalProfitMessage(31.7); // Postavite stvarni profit iznad optimalnog

            // Assert
            Assert.AreEqual("Your profit is above average", result);
        }


        [TestMethod]
        public async Task Edit_IdMismatch_ReturnsNotFound()
        {
            // Arrange
            var drinks = new List<Drink>
            {
                new Drink { id = 1, name = "Berrylicious", price = 5.99 }
            };

            var mockDbContext = new Mock<IApplicationDbContext>();
            mockDbContext.Setup(c => c.Drinks).Returns(MockDbSet(drinks));

            controller = new AdminPanelController(mockDbContext.Object);

            // Act
            var result = await controller.Edit(2, new Drink { id = 1, name = "Berrylicious", price = 7.99 });

            // Assert
            Assert.IsInstanceOfType(result, typeof(NotFoundResult));
        }

        [TestMethod]
        public async Task Edit_ValidModelState_ReturnsRedirectToAction()
        {
            // Arrange
            var existingDrink = new Drink
            {
                id = 1,
                name = "ExistingDrink",
                price = 15.0
            };

            var updatedDrink = new Drink
            {
                id = 1,
                name = "UpdatedDrink",
                price = 20.0
            };

            mockDbContext.Setup(c => c.Drinks.FindAsync(1)).ReturnsAsync(existingDrink);

            var controller = new AdminPanelController(mockDbContext.Object);

            // Act
            var result = await controller.Edit(1, updatedDrink);

            // Assert
            Assert.IsInstanceOfType(result, typeof(RedirectToActionResult));

            var redirectToActionResult = result as RedirectToActionResult;
            Assert.IsNotNull(redirectToActionResult);
            Assert.AreEqual("Index", redirectToActionResult.ActionName);

            // Ensure that SaveChangesAsync was called
            mockDbContext.Verify(x => x.SaveChangesAsync(It.IsAny<CancellationToken>()), Times.Once);

            // Ensure that the existingDrink properties were updated
            Assert.AreEqual(updatedDrink.name, existingDrink.name);
            Assert.AreEqual(updatedDrink.price, existingDrink.price);
        }
        [TestMethod]
        public async Task Edit_InvalidModelState_ReturnsViewWithModel()
        {
            // Arrange
            var existingDrink = new Drink
            {
                id = 1,
                name = "ExistingDrink",
                price = 15.0
            };

            mockDbContext.Setup(c => c.Drinks.FindAsync(1)).ReturnsAsync(existingDrink);

            var controller = new AdminPanelController(mockDbContext.Object);
            controller.ModelState.AddModelError("price", "Price isn't correct.");

            // Act
            var result = await controller.Edit(1, new Drink { id = 1, name = "Berrylicious", price = 7.99 });

            // Assert
            Assert.IsInstanceOfType(result, typeof(ViewResult));
            var viewResult = (ViewResult)result;
            Assert.AreEqual("Berrylicious", ((Drink)viewResult.Model).name);

            // Ensure that FindAsync was called to get the existing drink
            mockDbContext.Verify(x => x.Drinks.FindAsync(1), Times.Once);
        }
        [TestMethod]
        public async Task Edit_ValidModelStateBelowPriceRange_ReturnsRedirectToAction()
        {
            // Arrange
            var existingDrink = new Drink
            {
                id = 1,
                name = "ExistingDrink",
                price = 15.0
            };

            mockDbContext.Setup(c => c.Drinks.FindAsync(1)).ReturnsAsync(existingDrink);

            var controller = new AdminPanelController(mockDbContext.Object);

            // Act
            var result = await controller.Edit(1, new Drink { id = 1, name = "UpdatedDrink", price = 1.99 });

            // Assert
            Assert.IsInstanceOfType(result, typeof(RedirectToActionResult));
            var redirectToActionResult = result as RedirectToActionResult;
            Assert.IsNotNull(redirectToActionResult);
            Assert.AreEqual("Index", redirectToActionResult.ActionName);

        }
        [TestMethod]
        public async Task Edit_DrinkNotFound_ReturnsNotFound()
        {
            // Arrange
            var drinks = new List<Drink>();

            mockDbContext.Setup(c => c.Drinks).Returns(MockDbSet(drinks));

            controller = new AdminPanelController(mockDbContext.Object);

            // Act
            var result = await controller.Edit(1, new Drink { id = 1, name = "Berrylicious", price = 7.99 });

            // Assert
            Assert.IsInstanceOfType(result, typeof(NotFoundResult));
        }
        [TestMethod]
        public async Task Edit_DbUpdateException_DrinkDoesNotExist_ReturnsNotFound()
        {
            // Arrange
            var existingDrink = new Drink
            {
                id = 1,
                name = "Berrylicious",
                price = 5.99
            };

            var updatedDrink = new Drink
            {
                id = 1,
                name = "UpdatedDrink",
                price = 20
            };

            var drinks = new List<Drink>
            {
                new Drink(1, "Berrylicious", 5.99),
                new Drink(2, "Cherry Bomb", 7.99),
                new Drink(3, "Watermelon Wave", 3.99),
            };

            mockDbContext.Setup(c => c.Drinks).Returns(MockDbSet(drinks));
            mockDbContext.Setup(c => c.Drinks.FindAsync(1)).ReturnsAsync(existingDrink);
            mockDbContext.Setup(c => c.SaveChangesAsync(It.IsAny<CancellationToken>())).ThrowsAsync(new DbUpdateConcurrencyException());

            controller = new AdminPanelController(mockDbContext.Object);

            // Act
            var result = await controller.Edit(1, new Drink { id = 1, name = "Berrylicious", price = 7.99 });

            // Assert
            Assert.IsInstanceOfType(result, typeof(RedirectToActionResult));

        }
        [TestMethod]
        public void AreAllDrinksAlcoholic_AllDrinksAlcoholic_ReturnsTrue()
        {
            var drinks = new List<Drink>
            {
                new Drink(2, "Boody Mary", 6.49),
                new Drink(3, "Blue Lagoon", 7.99),
                new Drink(4, "Blue Lemonade", 7.88)
            };

            var mockDbContext = new Mock<IApplicationDbContext>();

            controller = new AdminPanelController(mockDbContext.Object);

            var drinkIngredientsData = new List<DrinkIngredient>
            {
                new DrinkIngredient { id = 1, idDrink = 2, idIngredient = 21 },
                new DrinkIngredient { id = 2, idDrink = 3, idIngredient = 27 },
                new DrinkIngredient { id = 3, idDrink = 4, idIngredient = 29 }
            };

            mockDbContext.Setup(c => c.DrinkIngredients).Returns(MockDbSet(drinkIngredientsData));
            var result = controller.AreAllDrinksAlcoholic(drinks);

            Assert.IsTrue(result);
        }

        [TestMethod]
        [DynamicData(nameof(GetOptimalProfitMessageCsvTestData), DynamicDataSourceType.Method)]
        public void OptimalProfitMessage_CsvData_ReturnsCorrectResult(double realProfit, string expectedMessage)
        {
            // Arrange
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
            var result = controller.optimalProfitMessage(realProfit);
            // Assert
            Assert.AreEqual(expectedMessage, result);
        }

        public static List<object[]> GetOptimalProfitMessageCsvTestData()
        {
            var csvTestData = @"33,Your profit is optimal,35,Your profit is above average,25,You are below optimal profit";

            var lines = csvTestData.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
            var testDataList = new List<object[]>();
            Console.WriteLine($"{lines[0]}: {csvTestData}");
            foreach (var line in lines)
            {
                try
                {
                    var values = line.Split(',');

                    double realProfit = double.Parse(values[0]);
                    string expectedMessage = values[1];
                    testDataList.Add(new object[] { realProfit, expectedMessage });

                    realProfit = double.Parse(values[2]);
                    expectedMessage = values[3];
                    testDataList.Add(new object[] { realProfit, expectedMessage });

                    realProfit = double.Parse(values[4]);
                    expectedMessage = values[5];
                    testDataList.Add(new object[] { realProfit, expectedMessage });
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
        public void OptimalProfitMessage_EmptyList_ReturnsAverageMessage()
        {
            var mockDrinks = new List<Drink> { };
            mockDbContext.Setup(c => c.Drinks).Returns(MockDbSet(mockDrinks));
            controller = new AdminPanelController(mockDbContext.Object);
            var result = controller.optimalProfitMessage(0);
            Assert.AreEqual("Your profit is optimal", result);
        }

        [TestMethod]
        public void OptimalProfitMessage_SingleDrink_ReturnsBelowOptimalMessage()
        {
            var mockDrinks = new List<Drink>
            {
                new Drink { id = 1, name = "Drink1", price = 10 }
            };
            mockDbContext.Setup(c => c.Drinks).Returns(MockDbSet(mockDrinks));
            controller = new AdminPanelController(mockDbContext.Object);
            var result = controller.optimalProfitMessage(0);
            Assert.AreEqual("You are below optimal profit", result);
        }

        [TestMethod]
        public void OptimalProfitMessage_TwoDrinks_ReturnsBelowOptimalMessage()
        {
            var mockDrinks = new List<Drink>
            {
                new Drink { id = 1, name = "Drink1", price = 10 },
                new Drink { id = 2, name = "Drink2", price = 15 }
            };
            mockDbContext.Setup(c => c.Drinks).Returns(MockDbSet(mockDrinks));
            controller = new AdminPanelController(mockDbContext.Object);
            var result = controller.optimalProfitMessage(0);
            Assert.AreEqual("You are below optimal profit", result);
        }


        [TestMethod]
        public void OptimalProfitMessage_FiveDrinks_ReturnsBelowOptimalMessage()
        {
            var mockDrinks = new List<Drink>
            {
                new Drink { id = 1, name = "Drink1", price = 10 },
                new Drink { id = 2, name = "Drink2", price = 15 },
                new Drink { id = 3, name = "Drink1", price = 10 },
                new Drink { id = 4, name = "Drink2", price = 15 },
                new Drink { id = 5, name = "Drink2", price = 15 }
            };
            mockDbContext.Setup(c => c.Drinks).Returns(MockDbSet(mockDrinks));
            controller = new AdminPanelController(mockDbContext.Object);
            var result = controller.optimalProfitMessage(0);
            Assert.AreEqual("You are below optimal profit", result);
        }

        [TestMethod]
        public void OptimalProfitMessage_SevenDrinks_ReturnsBelowOptimalMessage()
        {
            var mockDrinks = new List<Drink>
            {
                new Drink { id = 1, name = "Drink1", price = 10 },
                new Drink { id = 2, name = "Drink2", price = 15 },
                new Drink { id = 3, name = "Drink1", price = 10 },
                new Drink { id = 4, name = "Drink2", price = 15 },
                new Drink { id = 5, name = "Drink2", price = 15 },
                new Drink { id = 6, name = "Drink1", price = 10 },
                new Drink { id = 7, name = "Drink2", price = 15 }
            };
            mockDbContext.Setup(c => c.Drinks).Returns(MockDbSet(mockDrinks));
            controller = new AdminPanelController(mockDbContext.Object);
            var result = controller.optimalProfitMessage(0);
            Assert.AreEqual("You are below optimal profit", result);
        }

        [TestMethod]
        public void OptimalProfitMessage_EightDrinks_ReturnsBelowOptimalMessage()
        {
            var mockDrinks = new List<Drink>
            {
                new Drink { id = 1, name = "Drink1", price = 10 },
                new Drink { id = 2, name = "Drink2", price = 15 },
                new Drink { id = 3, name = "Drink1", price = 10 },
                new Drink { id = 4, name = "Drink2", price = 15 },
                new Drink { id = 5, name = "Drink2", price = 15 },
                new Drink { id = 6, name = "Drink1", price = 10 },
                new Drink { id = 7, name = "Drink2", price = 15 },
                new Drink { id = 8, name = "Drink2", price = 15 }
            };
            mockDbContext.Setup(c => c.Drinks).Returns(MockDbSet(mockDrinks));
            controller = new AdminPanelController(mockDbContext.Object);
            var result = controller.optimalProfitMessage(0);
            Assert.AreEqual("You are below optimal profit", result);
        }


        [TestMethod]
        public void OptimalProfitMessage_EmptyList_ReturnsBelowAverageMessage()
        {
            var mockDrinks = new List<Drink> { };
            mockDbContext.Setup(c => c.Drinks).Returns(MockDbSet(mockDrinks));
            controller = new AdminPanelController(mockDbContext.Object);
            var result = controller.optimalProfitMessage(-10.1);
            Assert.AreEqual("You are below optimal profit", result);
        }

        [TestMethod]
        public void OptimalProfitMessage_EmptyList_ReturnsAboveAverageMessage()
        {
            var mockDrinks = new List<Drink> { };
            mockDbContext.Setup(c => c.Drinks).Returns(MockDbSet(mockDrinks));
            controller = new AdminPanelController(mockDbContext.Object);
            var result = controller.optimalProfitMessage(10.1);
            Assert.AreEqual("Your profit is above average", result);
        }

    }

}