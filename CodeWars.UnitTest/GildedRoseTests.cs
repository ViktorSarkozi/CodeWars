using System.Collections.Generic;
using CodeWars.GildedRose;
using FluentAssertions;
using Xunit;

namespace CodeWars.UnitTest
{
    public class GildedRoseTests
    {
        private readonly ItemUpdateFactory _itemUpdateFactory;

        public GildedRoseTests()
        {
            var itemUpdateService = new List<IItemUpdateService>
            {
                new AgedItemUpdateService(),
                new BackstageItemUpdateService(),
                new LegendaryItemUpdateService(),
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
        public void WhenAgedBrieSellInLessThan0_QualityIncreaseTwiceAsFast()
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
            const string dexterityVest = "+5 Dexterity Vest";
            var inputItems = new List<Item>
            {
                new() { Name = dexterityVest, SellIn = 0, Quality = 6 },
            };
            var gildedRoseApp = new GildedRose_Solution(inputItems, _itemUpdateFactory);
            
            // Act
            gildedRoseApp.UpdateQuality();

            // Assert
            var expected = new Item { Name = dexterityVest, SellIn = -1, Quality = 4 };
            inputItems[0].Should().BeEquivalentTo(expected);
        }
        
        [Fact]
        public void WhenANormalItemWithGetsUpdated_BothSellInAndQualityDecrease()
        {
            // Arrange
            const string dexterityVest = "+5 Dexterity Vest";
            var inputItems = new List<Item>
            {
                new() { Name = dexterityVest, SellIn = 5, Quality = 6 },
            };
            var gildedRoseApp = new GildedRose_Solution(inputItems, _itemUpdateFactory);
            
            // Act
            gildedRoseApp.UpdateQuality();

            // Assert
            var expected = new Item { Name = dexterityVest, SellIn = 4, Quality = 5 };
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
        public void WhenBackstageWith10PlusSellInGetUpdated_SellIndDecreaseAndQualityDecreaseNormally()
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
        public void WhenBackstageWithBetween5and10SellInGetUpdated_SellIndDecreaseAndQualityDecreaseTwiceAsFast()
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
        public void WhenBackstageWithLessThan5SellInGetUpdated_SellIndDecreaseAndQualityDecreaseThreeTimesAsFast()
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
        public void WhenBackstageWithLessThan0SellInGetUpdated_SellIndDecreaseAndQualityDropsTo0()
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
    }
}