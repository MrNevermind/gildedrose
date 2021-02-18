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
                        item.UpdateItemValues(ItemType.BetterWithAging);
                        break;
                    case "Backstage passes to a TAFKAL80ETC concert":
                        item.UpdateItemValues(ItemType.BackstagePass);
                        break;
                    case "Sulfuras, Hand of Ragnaros":
                        item.UpdateItemValues(ItemType.Legendary);
                        break;
                    case "Conjured Mana Cake":
                        item.UpdateItemValues(ItemType.Conjured);
                        break;
                    default:
                        item.UpdateItemValues(ItemType.Default);
                        break;
                }
            }
        }
    }

    public static class GildedRoseExtensions
    {
        public static void UpdateItemValues(this Item item, ItemType itemType)
        {
            if (itemType != ItemType.Legendary)
                item.SellIn--;

            int qualityDecrease = item.SellIn >= 0 ? 1 : 2;

            if (itemType == ItemType.Default)
                item.Quality -= qualityDecrease;
            else if (itemType == ItemType.Conjured)
                item.Quality -= qualityDecrease * 2;
            else if (itemType == ItemType.BetterWithAging)
                item.Quality++;
            else if (itemType == ItemType.BackstagePass)
            {
                item.Quality++;
                if (item.SellIn < 10)
                    item.Quality++;
                if (item.SellIn < 5)
                    item.Quality++;
                if (item.SellIn < 0)
                    item.Quality = 0;
            }

            if (item.Quality < 0)
                item.Quality = 0;
            else if (item.Quality > 50 && itemType != ItemType.Legendary)
                item.Quality = 50;
        }
    }
    public enum ItemType
    {
        Legendary,
        BackstagePass,
        Conjured,
        BetterWithAging,
        Default
    }
}
