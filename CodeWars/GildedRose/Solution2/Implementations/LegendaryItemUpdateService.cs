namespace CodeWars.GildedRose.Solution2
{
    public class LegendaryItemUpdateService :  IItemUpdateService
    {
        public bool CanUpdate(ItemExtension item)
        {
            return item.Type == ItemType.Legendary;
        }

        public void Update(ItemExtension item)
        {
        }
    }
}