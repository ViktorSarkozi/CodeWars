using System.Collections.Generic;
using CodeWars.GildedRose;
using FluentAssertions;
using Xunit;

namespace CodeWars.UnitTest
{
    public class GildedRoseTests
    {
        private const string NormalItemName = "+5 Dexterity Vest";
        private readonly ItemUpdateFactory _itemUpdateFactory;

        public GildedRoseTests()
        {
            var itemUpdateService = new List<IItemUpdateService>
            {
                new AgedItemUpdateService(),
                new BackstageItemUpdateService(),
                new LegendaryItemUpdateService(),
                new ConjuredItemUpdateService(),
                new DefaultItemUpdateService(),
            };
            _itemUpdateFactory = new ItemUpdateFactory(itemUpdateService);
        }

        [Fact]
        public void WhenAgedBrieGetsUpdated_QualityIncrease()
        {
            // Arrange
            var inputItems = new List<Item>
            {
                new() { Name = ItemName.AgedBrie, SellIn = 2, Quality = 0 },
            };
            var gildedRoseApp = new GildedRose_Solution(inputItems, _itemUpdateFactory);
            
            // Act
            gildedRoseApp.UpdateQuality();

            // Assert
            var expected = new Item { Name = ItemName.AgedBrie, SellIn = 1, Quality = 1 };
            inputItems[0].Should().BeEquivalentTo(expected);
        }
        
        [Fact]
        public void WhenAgedBrieWithQuality50GetsUpdated_QualityDoesNotIncreaseAnymore()
        {
            // Arrange
            var inputItems = new List<Item>
            {
                new() { Name = ItemName.AgedBrie, SellIn = 2, Quality = 50 },
            };
            var gildedRoseApp = new GildedRose_Solution(inputItems, _itemUpdateFactory);
            
            // Act
            gildedRoseApp.UpdateQuality();

            // Assert
            var expected = new Item { Name = ItemName.AgedBrie, SellIn = 1, Quality = 50 };
            inputItems[0].Should().BeEquivalentTo(expected);
        }

        [Fact]
        public void WhenAgedBrieSellInLessThan0GetsUpdated_QualityIncreaseTwiceAsFast()
        {
            // Arrange
            var inputItems = new List<Item>
            {
                new() { Name = ItemName.AgedBrie, SellIn = 0, Quality = 10 },
            };
            var gildedRoseApp = new GildedRose_Solution(inputItems, _itemUpdateFactory);
            
            // Act
            gildedRoseApp.UpdateQuality();

            // Assert
            var expected = new Item { Name = ItemName.AgedBrie, SellIn = -1, Quality = 12 };
            inputItems[0].Should().BeEquivalentTo(expected);

        }
        
        
        [Fact]
        public void WhenANormalItemWith0SellInGetsUpdated_QualityDecreaseTwiceAsFast()
        {
            // Arrange
            var inputItems = new List<Item>
            {
                new() { Name = NormalItemName, SellIn = 0, Quality = 6 },
            };
            var gildedRoseApp = new GildedRose_Solution(inputItems, _itemUpdateFactory);
            
            // Act
            gildedRoseApp.UpdateQuality();

            // Assert
            var expected = new Item { Name = NormalItemName, SellIn = -1, Quality = 4 };
            inputItems[0].Should().BeEquivalentTo(expected);
        }
        
        [Fact]
        public void WhenANormalItemWith0QualityGetsUpdated_QualityDoesNotDecreaseAnymore()
        {
            // Arrange
            var inputItems = new List<Item>
            {
                new() { Name = NormalItemName, SellIn = 5, Quality = 0 },
            };
            var gildedRoseApp = new GildedRose_Solution(inputItems, _itemUpdateFactory);
            
            // Act
            gildedRoseApp.UpdateQuality();

            // Assert
            var expected = new Item { Name = NormalItemName, SellIn = 4, Quality = 0 };
            inputItems[0].Should().BeEquivalentTo(expected);
        }
        
        [Fact]
        public void WhenANormalItemGetsUpdated_BothSellInAndQualityDecrease()
        {
            // Arrange
            var inputItems = new List<Item>
            {
                new() { Name = NormalItemName, SellIn = 5, Quality = 6 },
            };
            var gildedRoseApp = new GildedRose_Solution(inputItems, _itemUpdateFactory);
            
            // Act
            gildedRoseApp.UpdateQuality();

            // Assert
            var expected = new Item { Name = NormalItemName, SellIn = 4, Quality = 5 };
            inputItems[0].Should().BeEquivalentTo(expected);
        }

        [Fact]
        public void WhenSulfurasGetUpdated_SellInAndQualityDoNotChange()
        {
            // Arrange
            var inputItems = new List<Item>
            {
                new() { Name = ItemName.Sulfuras, SellIn = 10, Quality = 10 },
            };
            var gildedRoseApp = new GildedRose_Solution(inputItems, _itemUpdateFactory);
            
            // Act
            gildedRoseApp.UpdateQuality();

            // Assert
            var expected = new Item { Name = ItemName.Sulfuras, SellIn = 10, Quality = 10 };
            inputItems[0].Should().BeEquivalentTo(expected);
        }
        
        [Fact]
        public void WhenBackstageWith10PlusSellInGetsUpdated_SellIndDecreaseAndQualityDecreaseNormally()
        {
            // Arrange
            var inputItems = new List<Item>
            {
                new() { Name = ItemName.Backstage, SellIn = 14, Quality = 10 },
            };
            var gildedRoseApp = new GildedRose_Solution(inputItems, _itemUpdateFactory);
            
            // Act
            gildedRoseApp.UpdateQuality();

            // Assert
            var expected = new Item { Name = ItemName.Backstage, SellIn = 13, Quality = 11 };
            inputItems[0].Should().BeEquivalentTo(expected);
        }
        
        [Fact]
        public void WhenBackstageWithBetween5and10SellInGetsUpdated_SellIndDecreaseAndQualityDecreaseTwiceAsFast()
        {
            // Arrange
            var inputItems = new List<Item>
            {
                new() { Name = ItemName.Backstage, SellIn = 7, Quality = 10 },
            };
            var gildedRoseApp = new GildedRose_Solution(inputItems, _itemUpdateFactory);
            
            // Act
            gildedRoseApp.UpdateQuality();

            // Assert
            var expected = new Item { Name = ItemName.Backstage, SellIn = 6, Quality = 12 };
            inputItems[0].Should().BeEquivalentTo(expected);
        }
        
        [Fact]
        public void WhenBackstageWithLessThan5SellInGetsUpdated_SellIndDecreaseAndQualityDecreaseThreeTimesAsFast()
        {
            // Arrange
            var inputItems = new List<Item>
            {
                new() { Name = ItemName.Backstage, SellIn = 4, Quality = 10 },
            };
            var gildedRoseApp = new GildedRose_Solution(inputItems, _itemUpdateFactory);
            
            // Act
            gildedRoseApp.UpdateQuality();

            // Assert
            var expected = new Item { Name = ItemName.Backstage, SellIn = 3, Quality = 13 };
            inputItems[0].Should().BeEquivalentTo(expected);
        }
        
        [Fact]
        public void WhenBackstageWithLessThan0SellInGetsUpdated_SellIndDecreaseAndQualityDropsTo0()
        {
            // Arrange
            var inputItems = new List<Item>
            {
                new() { Name = ItemName.Backstage, SellIn = 0, Quality = 10 },
            };
            var gildedRoseApp = new GildedRose_Solution(inputItems, _itemUpdateFactory);
            
            // Act
            gildedRoseApp.UpdateQuality();

            // Assert
            var expected = new Item { Name = ItemName.Backstage, SellIn = -1, Quality = 0 };
            inputItems[0].Should().BeEquivalentTo(expected);
        }

        [Fact]
        public void WhenConjuredGetsUpdated_QualityDecreaseTwiceAsFast()
        {
            // Arrange
            var inputItems = new List<Item>
            {
                new() { Name = ItemName.Conjured, SellIn = 4, Quality = 10 },
            };
            var gildedRoseApp = new GildedRose_Solution(inputItems, _itemUpdateFactory);
            
            // Act
            gildedRoseApp.UpdateQuality();

            // Assert
            var expected = new Item { Name = ItemName.Conjured, SellIn = 3, Quality = 8 };
            inputItems[0].Should().BeEquivalentTo(expected);
        }
    }
}