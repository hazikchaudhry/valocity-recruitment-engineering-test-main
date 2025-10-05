using Xunit;
using GildedRose.Console;

namespace GildedRose.Tests;

public class TestAssemblyTests
{
    [Fact]
    public void TestTheTruth()
    {
        Assert.True(true);
    }
    
    [Fact]
    public void RegularItem_NormalDay_DecreasesQualityAndSellInByOne()
    {
        // Arrange
        var program = new Program();
        var item = new Item 
        { 
            Name = "+5 Dexterity Vest", 
            SellIn = 10, 
            Quality = 20 
        };
        program.Items.Add(item);
        
        // Act
        program.UpdateQuality();
        
        // Assert
        Assert.Equal(9, item.SellIn);
        Assert.Equal(19, item.Quality);
    }

    [Fact]
    public void RegularItem_AfterSellDate_QualityDegradesTwiceAsFast()
    {
        // Arrange
        var program = new Program();
        var item = new Item 
        { 
            Name = "Elixir of the Mongoose", 
            SellIn = 0, 
            Quality = 7 
        };
        program.Items.Add(item);
        
        // Act
        program.UpdateQuality();
        
        // Assert
        Assert.Equal(-1, item.SellIn);
        Assert.Equal(5, item.Quality);
    }

    [Fact]
    public void RegularItem_QualityAtZero_NeverGoesNegative()
    {
        // Arrange
        var program = new Program();
        var item = new Item 
        { 
            Name = "Low Quality Item", 
            SellIn = 5, 
            Quality = 0 
        };
        program.Items.Add(item);
        
        // Act
        program.UpdateQuality();
        
        // Assert
        Assert.Equal(4, item.SellIn);
        Assert.Equal(0, item.Quality);
    }

    [Fact]
    public void AgedBrie_NormalDay_IncreasesQuality()
    {
        // Arrange
        var program = new Program();
        var item = new Item 
        { 
            Name = "Aged Brie", 
            SellIn = 2, 
            Quality = 0 
        };
        program.Items.Add(item);
        
        // Act
        program.UpdateQuality();
        
        // Assert
        Assert.Equal(1, item.SellIn);
        Assert.Equal(1, item.Quality);
    }

    [Fact]
    public void AgedBrie_QualityAtMaximum_NeverExceedsFifty()
    {
        // Arrange
        var program = new Program();
        var item = new Item 
        { 
            Name = "Aged Brie", 
            SellIn = 5, 
            Quality = 50 
        };
        program.Items.Add(item);
        
        // Act
        program.UpdateQuality();
        
        // Assert
        Assert.Equal(4, item.SellIn);
        Assert.Equal(50, item.Quality);
    }

    [Fact]
    public void Sulfuras_LegendaryItem_NeverChanges()
    {
        // Arrange
        var program = new Program();
        var item = new Item 
        { 
            Name = "Sulfuras, Hand of Ragnaros", 
            SellIn = 0, 
            Quality = 80 
        };
        program.Items.Add(item);
        
        // Act
        program.UpdateQuality();
        
        // Assert
        Assert.Equal(0, item.SellIn);
        Assert.Equal(80, item.Quality);
    }

    [Fact]
    public void BackstagePasses_MoreThanTenDays_IncreasesQualityByOne()
    {
        // Arrange
        var program = new Program();
        var item = new Item 
        { 
            Name = "Backstage passes to a TAFKAL80ETC concert", 
            SellIn = 15, 
            Quality = 20 
        };
        program.Items.Add(item);
        
        // Act
        program.UpdateQuality();
        
        // Assert
        Assert.Equal(14, item.SellIn);
        Assert.Equal(21, item.Quality);
    }
}