using System;
using System.Collections.Generic;

namespace csharp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            /*
             Well done on simplifying the existing logic. Even though some of it broke - it still is a sizeable decrease of code lines.​
While having specific item types for identification is a good idea, it's not a great sign when there is a single method that resolves all of item types.​
Would recommend checking through the project and remove any leftover comments, like "// this conjured item does not work properly yet".​
The idea to switch items according to their names is a good one, but it isn't used to it's full potential when it collapses back to a single method. Would recommend splitting the item update logic across methods or classes. That would make it easier to update concrete item's update logic without the thought of breaking it somewhere else.​
There shouldn't be leftover tests like "foo()". They don't test anything and give no value.​
Test names should be more concrete and explain what is tested and why. Right now, these are just generic tests by item type that, when broken, won't give a clue what case has broken. Additionally, tests should be smaller to better isolate tested cases, which would help with naming and explaining what is being tested.
             */
            Console.WriteLine("OMGHAI!");

            IList<Item> Items = new List<Item>{
                new Item {Name = "+5 Dexterity Vest", SellIn = 10, Quality = 20},
                new Item {Name = "Aged Brie", SellIn = 2, Quality = 0},
                new Item {Name = "Elixir of the Mongoose", SellIn = 5, Quality = 7},
                new Item {Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80},
                new Item {Name = "Sulfuras, Hand of Ragnaros", SellIn = -1, Quality = 80},
                new Item
                {
                    Name = "Backstage passes to a TAFKAL80ETC concert",
                    SellIn = 15,
                    Quality = 20
                },
                new Item
                {
                    Name = "Backstage passes to a TAFKAL80ETC concert",
                    SellIn = 10,
                    Quality = 49
                },
                new Item
                {
                    Name = "Backstage passes to a TAFKAL80ETC concert",
                    SellIn = 5,
                    Quality = 49
                },
				new Item {Name = "Conjured Mana Cake", SellIn = 3, Quality = 6}
            };

            var app = new GildedRose(Items);


            for (var i = 0; i < 31; i++)
            {
                Console.WriteLine("-------- day " + i + " --------");
                Console.WriteLine("name, sellIn, quality");
                for (var j = 0; j < Items.Count; j++)
                {
                    System.Console.WriteLine(Items[j]);
                }
                Console.WriteLine("");
                app.UpdateQuality();
            }
        }
    }
}
