using NUnit.Framework;
using System.Collections.Generic;

namespace csharp
{
    [TestFixture]
    public class GildedRoseTest
    {
        [Test]
        public void TestUsualItemDecreaseByOne()
        {
            IList<Item> items = new List<Item> { new Item { Name = "Something simple", SellIn = 3, Quality = 6 } };
            GildedRose app = new GildedRose(items);

            app.UpdateQuality();
            Assert.AreEqual(2, items[0].SellIn);
            Assert.AreEqual(5, items[0].Quality);
        }
        [Test]
        public void TestQualityBellowZero()
        {
            IList<Item> items = new List<Item> { new Item { Name = "Something simple", SellIn = 0, Quality = 1 } };
            GildedRose app = new GildedRose(items);

            app.UpdateQuality();
            Assert.AreEqual(0, items[0].Quality);
            app.UpdateQuality();
            Assert.AreEqual(0, items[0].Quality);
        }
        [Test]
        public void TestAgedBrieIncreaseByOne()
        {
            IList<Item> items = new List<Item> { new Item { Name = "Aged Brie", SellIn = 3, Quality = 10 } };
            GildedRose app = new GildedRose(items);

            app.UpdateQuality();
            Assert.AreEqual(11, items[0].Quality);
        }
        [Test]
        public void TestQualityCapNonLegendary()
        {
            IList<Item> items = new List<Item> { new Item { Name = "Aged Brie", SellIn = 3, Quality = 50 } };
            GildedRose app = new GildedRose(items);

            app.UpdateQuality();
            Assert.AreEqual(50, items[0].Quality);
        }
        [Test]
        public void TestQualityCapLegendary()
        {
            IList<Item> items = new List<Item> { new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = 3, Quality = 50 } };
            GildedRose app = new GildedRose(items);

            app.UpdateQuality();
            Assert.AreEqual(80, items[0].Quality);
        }
        [Test]
        public void TestSellInLegendary()
        {
            IList<Item> items = new List<Item> { new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = 3, Quality = 80 } };
            GildedRose app = new GildedRose(items);

            app.UpdateQuality();
            Assert.AreEqual(3, items[0].SellIn);
        }
        [Test]
        public void TestSellInNonLegendary()
        {
            IList<Item> items = new List<Item> { new Item { Name = "Leather Jacket", SellIn = 3, Quality = 45 } };
            GildedRose app = new GildedRose(items);

            app.UpdateQuality();
            Assert.AreEqual(2, items[0].SellIn);
        }
        [Test]
        public void TestBackstagePassMoreThan10Days()
        {
            IList<Item> items = new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 20, Quality = 10 } };
            GildedRose app = new GildedRose(items);

            app.UpdateQuality();
            Assert.AreEqual(19, items[0].SellIn);
            Assert.AreEqual(11, items[0].Quality);
        }
        [Test]
        public void TestBackstagePassMoreThan5Days()
        {
            IList<Item> items = new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 7, Quality = 10 } };
            GildedRose app = new GildedRose(items);

            app.UpdateQuality();
            Assert.AreEqual(6, items[0].SellIn);
            Assert.AreEqual(12, items[0].Quality);
        }
        [Test]
        public void TestBackstagePassLessThan5Days()
        {
            IList<Item> items = new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 4, Quality = 10 } };
            GildedRose app = new GildedRose(items);

            app.UpdateQuality();
            Assert.AreEqual(3, items[0].SellIn);
            Assert.AreEqual(13, items[0].Quality);
        }

        [Test]
        public void TestConjuredSellInAbove0()
        {
            IList<Item> items = new List<Item> { new Item { Name = "Conjured Mana Cake", SellIn = 3, Quality = 10 } };
            GildedRose app = new GildedRose(items);

            app.UpdateQuality();
            Assert.AreEqual(2, items[0].SellIn);
            Assert.AreEqual(8, items[0].Quality);
        }
        [Test]
        public void TestConjuredSellInBelow0()
        {
            IList<Item> items = new List<Item> { new Item { Name = "Conjured Mana Cake", SellIn = 0, Quality = 10 } };
            GildedRose app = new GildedRose(items);

            app.UpdateQuality();
            Assert.AreEqual(-1, items[0].SellIn);
            Assert.AreEqual(6, items[0].Quality);
        }
    }
}
