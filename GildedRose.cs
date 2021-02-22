using System.Collections.Generic;

namespace csharp
{
    public class GildedRose
    {
        IList<Item> Items;
        public GildedRose(IList<Item> Items)
        {
            this.Items = Items;
        }
        public void UpdateQuality()
        {
            foreach (Item item in Items)
            {
                switch (item.Name)
                {
                    case "Aged Brie":
                        item.UpdateBetterWithAging();
                        break;
                    case "Backstage passes to a TAFKAL80ETC concert":
                        item.UpdateBackstagePass();
                        break;
                    case "Sulfuras, Hand of Ragnaros":
                        item.UpdateLegendary();
                        break;
                    case "Conjured Mana Cake":
                        item.UpdateConjured();
                        break;
                    default:
                        item.UpdateDefaultItem();
                        break;
                }
            }
        }
    }

    public static class GildedRoseExtensions
    {
        private static int fixQuality(int quality, bool isLegendary = false)
        {
            if (quality < 0)
                quality = 0; 
            else if (quality > 50 && !isLegendary)
                quality = 50;
            else if (isLegendary)
                quality = 80;

            return quality;
        }
        public static void UpdateDefaultItem(this Item item)
        {
            item.SellIn--;
            int qualityDecrease = item.SellIn >= 0 ? 1 : 2;
            item.Quality -= qualityDecrease;
            item.Quality = fixQuality(item.Quality);
        }
        public static void UpdateConjured(this Item item)
        {
            item.SellIn--;
            int qualityDecrease = item.SellIn >= 0 ? 2 : 4;
            item.Quality -= qualityDecrease;
            item.Quality = fixQuality(item.Quality);
        }
        public static void UpdateBetterWithAging(this Item item)
        {
            item.SellIn--;
            item.Quality++;
            item.Quality = fixQuality(item.Quality);
        }
        public static void UpdateBackstagePass(this Item item)
        {
            item.SellIn--;

            item.Quality++;
            if (item.SellIn < 10)
                item.Quality++;
            if (item.SellIn < 5)
                item.Quality++;
            if (item.SellIn < 0)
                item.Quality = 0;

            item.Quality = fixQuality(item.Quality);
        }
        public static void UpdateLegendary(this Item item)
        {
            item.Quality = fixQuality(item.Quality, true);
        }
    }
}
