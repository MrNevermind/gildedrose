using NUnit.Framework;
using System.Collections.Generic;

namespace csharp
{
    [TestFixture]
    public class GildedRoseTest
    {
        [Test]
        public void foo()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "foo", SellIn = 0, Quality = 0 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.AreEqual("foo", Items[0].Name);
        }
        [Test]
        public void TestUsualItem()
        {
            IList<Item> items = new List<Item> { new Item { Name = "Something simple", SellIn = 3, Quality = 6 } };
            GildedRose app = new GildedRose(items);

            app.UpdateQuality();
            Assert.AreEqual(2, items[0].SellIn);
            Assert.AreEqual(5, items[0].Quality);

            app.UpdateQuality();
            Assert.AreEqual(1, items[0].SellIn);
            Assert.AreEqual(4, items[0].Quality);

            app.UpdateQuality();
            Assert.AreEqual(0, items[0].SellIn);
            Assert.AreEqual(3, items[0].Quality);

            app.UpdateQuality();
            Assert.AreEqual(-1, items[0].SellIn);
            Assert.AreEqual(1, items[0].Quality);

            app.UpdateQuality();
            Assert.AreEqual(-2, items[0].SellIn);
            Assert.AreEqual(0, items[0].Quality);
        }
        [Test]
        public void TestAgedBrie()
        {
            IList<Item> items = new List<Item> { new Item { Name = "Aged Brie", SellIn = 3, Quality = 47 } };
            GildedRose app = new GildedRose(items);

            app.UpdateQuality();
            Assert.AreEqual(2, items[0].SellIn);
            Assert.AreEqual(48, items[0].Quality);

            app.UpdateQuality();
            Assert.AreEqual(1, items[0].SellIn);
            Assert.AreEqual(49, items[0].Quality);

            app.UpdateQuality();
            Assert.AreEqual(0, items[0].SellIn);
            Assert.AreEqual(50, items[0].Quality);

            app.UpdateQuality();
            Assert.AreEqual(-1, items[0].SellIn);
            Assert.AreEqual(50, items[0].Quality);
        }
        [Test]
        public void TestBackstagePass()
        {
            IList<Item> items = new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 11, Quality = 10 } };
            GildedRose app = new GildedRose(items);

            app.UpdateQuality();
            Assert.AreEqual(10, items[0].SellIn);
            Assert.AreEqual(11, items[0].Quality);

            app.UpdateQuality();
            Assert.AreEqual(9, items[0].SellIn);
            Assert.AreEqual(13, items[0].Quality);

            app.UpdateQuality();
            app.UpdateQuality();
            app.UpdateQuality();
            app.UpdateQuality();

            Assert.AreEqual(5, items[0].SellIn);
            Assert.AreEqual(21, items[0].Quality);

            app.UpdateQuality();
            Assert.AreEqual(4, items[0].SellIn);
            Assert.AreEqual(24, items[0].Quality);

            app.UpdateQuality();
            app.UpdateQuality();
            app.UpdateQuality();
            app.UpdateQuality();
            app.UpdateQuality();

            Assert.AreEqual(-1, items[0].SellIn);
            Assert.AreEqual(0, items[0].Quality);

            app.UpdateQuality();
            Assert.AreEqual(-2, items[0].SellIn);
            Assert.AreEqual(0, items[0].Quality);
        }

        [Test]
        public void TestSulfuras()
        {
            IList<Item> items = new List<Item> { new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = 3, Quality = 80 } };
            GildedRose app = new GildedRose(items);

            app.UpdateQuality();
            Assert.AreEqual(3, items[0].SellIn);
            Assert.AreEqual(80, items[0].Quality);

            app.UpdateQuality();
            Assert.AreEqual(3, items[0].SellIn);
            Assert.AreEqual(80, items[0].Quality);
        }

        [Test]
        public void TestConjured()
        {
            IList<Item> items = new List<Item> { new Item { Name = "Conjured Mana Cake", SellIn = 3, Quality = 10 } };
            GildedRose app = new GildedRose(items);

            app.UpdateQuality();
            Assert.AreEqual(2, items[0].SellIn);
            Assert.AreEqual(8, items[0].Quality);

            app.UpdateQuality();
            Assert.AreEqual(1, items[0].SellIn);
            Assert.AreEqual(6, items[0].Quality);

            app.UpdateQuality();
            Assert.AreEqual(0, items[0].SellIn);
            Assert.AreEqual(4, items[0].Quality);

            app.UpdateQuality();
            Assert.AreEqual(-1, items[0].SellIn);
            Assert.AreEqual(0, items[0].Quality);

            app.UpdateQuality();
            Assert.AreEqual(-2, items[0].SellIn);
            Assert.AreEqual(0, items[0].Quality);
        }
    }
}
