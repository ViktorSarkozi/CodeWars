namespace CodeWars.GildedRose.Solution2
{
    public class DefaultItemUpdateService : IItemUpdateService
    {
        public bool CanUpdate(ItemExtension item)
        {
            return item.Type == ItemType.Default;
        }

        public void Update(ItemExtension item)
        {
            item.SellIn -= 1;
            if (item.Quality <= 0)
            {
                return;
            }

            item.Quality -= 1;
            if (item.SellIn < 0)
            {
                item.Quality -= 1;
            }
        }
    }
}