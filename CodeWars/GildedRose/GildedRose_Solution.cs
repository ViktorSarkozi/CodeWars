﻿using System.Collections.Generic;

namespace CodeWars.GildedRose
{
    public class GildedRose_Solution
    {
        private readonly IList<Item> _items;
        private readonly IItemUpdateFactory _itemUpdateFactory;

        public GildedRose_Solution(
            IList<Item> items,
            IItemUpdateFactory itemUpdateFactory)
        {
            _items = items;
            _itemUpdateFactory = itemUpdateFactory;
        }

        public void UpdateQuality()
        {
            foreach (var item in _items)
            {
                var itemUpdateService = _itemUpdateFactory.Create(item);
                itemUpdateService.Update(item);
            }
        }
    }
}