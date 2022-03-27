﻿namespace CodeWars.GildedRose.Solution2
{
    public class AgedItemUpdateService : IItemUpdateService
    {
        public bool CanUpdate(ItemExtension item)
        {
            return item.Type == ItemType.Aged;
        }

        public void Update(ItemExtension item)
        {
            item.SellIn -= 1;
            if (item.Quality == 50)
            {
                return;
            }

            if (item.SellIn < 0)
            {
                item.Quality += 1;
            }

            item.Quality += 1;
        }
    }
}