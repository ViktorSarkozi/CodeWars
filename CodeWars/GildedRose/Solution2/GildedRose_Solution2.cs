using System.Collections.Generic;
using System.Linq;

namespace CodeWars.GildedRose.Solution2
{
    public static class GildedRose_Solution2
    {
        private static readonly List<IItemUpdateService> _itemUpdateServices;

        static GildedRose_Solution2()
        {
            _itemUpdateServices = new List<IItemUpdateService>
            {
                new AgedItemUpdateService(),
                new BackstageItemUpdateService(),
                new LegendaryItemUpdateService(),
                new ConjuredItemUpdateService(),
                new DefaultItemUpdateService(),
            };
        }

        public static void UpdateQuality(IEnumerable<ItemExtension> items)
        {

            foreach (var item in items)
            {
                var itemUpdateService = 
                    _itemUpdateServices.FirstOrDefault(svc => svc.CanUpdate(item));

                itemUpdateService?.Update(item);
            }
        }
    }
}