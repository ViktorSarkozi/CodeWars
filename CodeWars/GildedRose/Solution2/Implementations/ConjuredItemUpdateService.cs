namespace CodeWars.GildedRose.Solution2
{
    public class ConjuredItemUpdateService : IItemUpdateService
    {
        public bool CanUpdate(ItemExtension item)
        {
            return item.Type == ItemType.Conjured;
        }

        public void Update(ItemExtension item)
        {
            item.SellIn -= 1;
            item.Quality -= 2;
        }
    }
}