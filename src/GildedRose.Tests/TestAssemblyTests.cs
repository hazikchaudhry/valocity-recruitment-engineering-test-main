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

    [Fact]
    public void BackstagePasses_TenDaysOrLess_IncreasesQualityByTwo()
    {
        // Arrange
        var program = new Program();
        var item = new Item 
        { 
            Name = "Backstage passes to a TAFKAL80ETC concert", 
            SellIn = 10, 
            Quality = 20 
        };
        program.Items.Add(item);
        
        // Act
        program.UpdateQuality();
        
        // Assert
        Assert.Equal(9, item.SellIn);
        Assert.Equal(22, item.Quality);
    }

    [Fact]
    public void BackstagePasses_FiveDaysOrLess_IncreasesQualityByThree()
    {
        // Arrange
        var program = new Program();
        var item = new Item 
        { 
            Name = "Backstage passes to a TAFKAL80ETC concert", 
            SellIn = 5, 
            Quality = 20 
        };
        program.Items.Add(item);
        
        // Act
        program.UpdateQuality();
        
        // Assert
        Assert.Equal(4, item.SellIn);
        Assert.Equal(23, item.Quality);
    }

    [Fact]
    public void BackstagePasses_AfterConcert_BecomesWorthless()
    {
        // Arrange
        var program = new Program();
        var item = new Item 
        { 
            Name = "Backstage passes to a TAFKAL80ETC concert", 
            SellIn = 0, 
            Quality = 20 
        };
        program.Items.Add(item);
        
        // Act
        program.UpdateQuality();
        
        // Assert
        Assert.Equal(-1, item.SellIn);
        Assert.Equal(0, item.Quality);
    }

    [Fact]
    public void GoldenMaster_ThirtyDaySystemTest_VerifiesCompleteSystemBehavior()
    {
        // Arrange
        var program = new Program();
        program.Items = new List<Item>
        {
            new Item { Name = "+5 Dexterity Vest", SellIn = 10, Quality = 20 },
            new Item { Name = "Aged Brie", SellIn = 2, Quality = 0 },
            new Item { Name = "Elixir of the Mongoose", SellIn = 5, Quality = 7 },
            new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80 },
            new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 15, Quality = 20 },
            new Item { Name = "Conjured Mana Cake", SellIn = 3, Quality = 6 }
        };

        // Act - Run for 30 days
        for (int day = 0; day < 30; day++)
        {
            program.UpdateQuality();
        }

        // Assert - Key system invariants after 30 days
        var dexterityVest = program.Items[0];
        var agedBrie = program.Items[1];
        var elixir = program.Items[2];
        var sulfuras = program.Items[3];
        var backstagePasses = program.Items[4];
        var conjuredCake = program.Items[5];

        // Sulfuras never changes (legendary item)
        Assert.Equal("Sulfuras, Hand of Ragnaros", sulfuras.Name);
        Assert.Equal(0, sulfuras.SellIn);
        Assert.Equal(80, sulfuras.Quality);

        // Regular items should have degraded quality and SellIn
        Assert.Equal("+5 Dexterity Vest", dexterityVest.Name);
        Assert.Equal(-20, dexterityVest.SellIn); // 10 - 30 = -20
        Assert.Equal(0, dexterityVest.Quality); // Should be 0 (can't go negative)

        // Aged Brie should have increased in quality but capped at 50
        Assert.Equal("Aged Brie", agedBrie.Name);
        Assert.Equal(-28, agedBrie.SellIn); // 2 - 30 = -28
        Assert.Equal(50, agedBrie.Quality); // Should be capped at 50

        // Elixir should have degraded to 0
        Assert.Equal("Elixir of the Mongoose", elixir.Name);
        Assert.Equal(-25, elixir.SellIn); // 5 - 30 = -25
        Assert.Equal(0, elixir.Quality); // Should be 0 (can't go negative)

        // Backstage passes should be worthless after concert (SellIn went negative)
        Assert.Equal("Backstage passes to a TAFKAL80ETC concert", backstagePasses.Name);
        Assert.Equal(-15, backstagePasses.SellIn); // 15 - 30 = -15
        Assert.Equal(0, backstagePasses.Quality); // Worthless after concert

        // Conjured item (treated as regular item in current implementation)
        Assert.Equal("Conjured Mana Cake", conjuredCake.Name);
        Assert.Equal(-27, conjuredCake.SellIn); // 3 - 30 = -27
        Assert.Equal(0, conjuredCake.Quality); // Should be 0 (can't go negative)
    }
}