using System.Collections.Generic;
using AutoFixture.Xunit2;
using CodeWars.GildedRose.Solution2;
using FluentAssertions;
using Xunit;

namespace CodeWars.UnitTest
{
    public class GildedRoseSolution2Tests
    {
        [Theory]
        [AutoData]
        public void WhenAgedBrieGetsUpdated_QualityIncrease(string name)
        {
            // Arrange
            var inputItems = new List<ItemExtension>
            {
                new(name, 2, 0, ItemType.Aged),
            };

            // Act
            GildedRose_Solution2.UpdateQuality(inputItems);

            // Assert
            var expected = new ItemExtension(name, 1, 1, ItemType.Aged);
            inputItems[0].Should().BeEquivalentTo(expected);
        }

        [Theory]
        [AutoData]
        public void WhenAgedBrieWithQuality50GetsUpdated_QualityDoesNotIncreaseAnymore(string name)
        {
            // Arrange
            var inputItems = new List<ItemExtension>
            {
                new(name, 2, 50, ItemType.Aged),
            };

            // Act
            GildedRose_Solution2.UpdateQuality(inputItems);

            // Assert
            var expected = new ItemExtension(name, 1, 50, ItemType.Aged);
            inputItems[0].Should().BeEquivalentTo(expected);
        }

        [Theory]
        [AutoData]
        public void WhenAgedBrieSellInLessThan0GetsUpdated_QualityIncreaseTwiceAsFast(string name)
        {
            // Arrange
            var inputItems = new List<ItemExtension>
            {
                new(name, 0, 10, ItemType.Aged),
            };

            // Act
            GildedRose_Solution2.UpdateQuality(inputItems);

            // Assert
            var expected = new ItemExtension(name, -1, 12, ItemType.Aged);
            inputItems[0].Should().BeEquivalentTo(expected);
        }


        [Theory]
        [AutoData]
        public void WhenANormalItemWith0SellInGetsUpdated_QualityDecreaseTwiceAsFast(string name)
        {
            // Arrange
            var inputItems = new List<ItemExtension>
            {
                new(name, 0, 6, ItemType.Default),
            };

            // Act
            GildedRose_Solution2.UpdateQuality(inputItems);

            // Assert
            var expected = new ItemExtension(name, -1, 4, ItemType.Default);
            inputItems[0].Should().BeEquivalentTo(expected);
        }

        [Theory]
        [AutoData]
        public void WhenANormalItemWith0QualityGetsUpdated_QualityDoesNotDecreaseAnymore(
            string name)
        {
            // Arrange
            var inputItems = new List<ItemExtension>
            {
                new(name, 5, 0, ItemType.Default),
            };

            // Act
            GildedRose_Solution2.UpdateQuality(inputItems);

            // Assert
            var expected = new ItemExtension(name, 4, 0, ItemType.Default);
            inputItems[0].Should().BeEquivalentTo(expected);
        }

        [Theory]
        [AutoData]
        public void WhenANormalItemGetsUpdated_BothSellInAndQualityDecrease(string name)
        {
            // Arrange
            var inputItems = new List<ItemExtension>
            {
                new(name, 5, 6, ItemType.Default),
            };

            // Act
            GildedRose_Solution2.UpdateQuality(inputItems);

            // Assert
            var expected = new ItemExtension(name, 4, 5, ItemType.Default);
            inputItems[0].Should().BeEquivalentTo(expected);
        }

        [Theory]
        [AutoData]
        public void WhenLegendaryGetsUpdated_SellInAndQualityDoNotChange(string name)
        {
            // Arrange
            var inputItems = new List<ItemExtension>
            {
                new(name, 10, 10, ItemType.Legendary),
            };

            // Act
            GildedRose_Solution2.UpdateQuality(inputItems);

            // Assert
            var expected = new ItemExtension(name, 10, 10, ItemType.Legendary);
            inputItems[0].Should().BeEquivalentTo(expected);
        }

        [Theory]
        [AutoData]
        public void
            WhenBackstageWith10PlusSellInGetsUpdated_SellIndDecreaseAndQualityDecreaseNormally(
                string name)
        {
            // Arrange
            var inputItems = new List<ItemExtension>
            {
                new(name, 14, 10, ItemType.Backstage),
            };

            // Act
            GildedRose_Solution2.UpdateQuality(inputItems);

            // Assert
            var expected = new ItemExtension(name, 13, 11, ItemType.Backstage);
            inputItems[0].Should().BeEquivalentTo(expected);
        }

        [Theory]
        [AutoData]
        public void
            WhenBackstageWithBetween5and10SellInGetsUpdated_SellIndDecreaseAndQualityDecreaseTwiceAsFast(
                string name)
        {
            // Arrange
            var inputItems = new List<ItemExtension>
            {
                new(name, 7, 10, ItemType.Backstage),
            };

            // Act
            GildedRose_Solution2.UpdateQuality(inputItems);

            // Assert
            var expected = new ItemExtension(name, 6, 12, ItemType.Backstage);
            inputItems[0].Should().BeEquivalentTo(expected);
        }

        [Theory]
        [AutoData]
        public void
            WhenBackstageWithLessThan5SellInGetsUpdated_SellIndDecreaseAndQualityDecreaseThreeTimesAsFast(
                string name)
        {
            // Arrange
            var inputItems = new List<ItemExtension>
            {
                new(name, 4, 10, ItemType.Backstage),
            };

            // Act
            GildedRose_Solution2.UpdateQuality(inputItems);

            // Assert
            var expected = new ItemExtension(name, 3, 13, ItemType.Backstage);
            inputItems[0].Should().BeEquivalentTo(expected);
        }

        [Theory]
        [AutoData]
        public void WhenBackstageWithLessThan0SellInGetsUpdated_SellIndDecreaseAndQualityDropsTo0(
            string name)
        {
            // Arrange
            var inputItems = new List<ItemExtension>
            {
                new(name, 0, 10, ItemType.Backstage),
            };

            // Act
            GildedRose_Solution2.UpdateQuality(inputItems);

            // Assert
            var expected = new ItemExtension(name, -1, 0, ItemType.Backstage);
            inputItems[0].Should().BeEquivalentTo(expected);
        }

        [Theory]
        [AutoData]
        public void WhenConjuredGetsUpdated_QualityDecreaseTwiceAsFast(string name)
        {
            // Arrange
            var inputItems = new List<ItemExtension>
            {
                new(name, 4, 10, ItemType.Conjured),
            };

            // Act
            GildedRose_Solution2.UpdateQuality(inputItems);

            // Assert
            var expected = new ItemExtension(name, 3, 8, ItemType.Conjured);
            inputItems[0].Should().BeEquivalentTo(expected);
        }
    }
}