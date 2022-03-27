namespace CodeWars.GildedRose.Solution1
{
    public class AgedItemUpdateService : IItemUpdateService
    {
        public void Update(Item item)
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