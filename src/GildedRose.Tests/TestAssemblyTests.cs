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
}