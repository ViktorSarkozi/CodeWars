namespace CodeWars.GildedRose.Solution1
{
    public class DefaultItemUpdateService : IItemUpdateService
    {
        public void Update(Item item)
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