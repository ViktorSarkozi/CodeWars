namespace CodeWars.GildedRose.Solution1
{
    public class ConjuredItemUpdateService : IItemUpdateService
    {
        public void Update(Item item)
        {
            item.SellIn -= 1;
            item.Quality -= 2;
        }
    }
}