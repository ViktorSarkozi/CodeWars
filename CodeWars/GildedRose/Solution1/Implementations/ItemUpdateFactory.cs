using System.Collections.Generic;
using System.Linq;
using Dawn;

namespace CodeWars.GildedRose.Solution1
{
    public class ItemUpdateFactory : IItemUpdateFactory
    {
        private readonly IEnumerable<IItemUpdateService> _itemUpdateServices;

        public ItemUpdateFactory()
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

        public IItemUpdateService Create(Item item)
        {
            Guard.Argument(item, nameof(item)).NotNull();
            
            switch (item.Name)
            {
                case ItemName.AgedBrie:
                    return _itemUpdateServices.OfType<AgedItemUpdateService>().FirstOrDefault();
                case ItemName.Backstage:
                    return _itemUpdateServices.OfType<BackstageItemUpdateService>().FirstOrDefault();
                case ItemName.Sulfuras:
                    return _itemUpdateServices.OfType<LegendaryItemUpdateService>().FirstOrDefault();
                case ItemName.Conjured:
                    return _itemUpdateServices.OfType<ConjuredItemUpdateService>().FirstOrDefault();
                default:
                    return _itemUpdateServices.OfType<DefaultItemUpdateService>().FirstOrDefault();
            }
        }
    }
}