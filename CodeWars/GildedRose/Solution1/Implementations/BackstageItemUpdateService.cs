namespace CodeWars.GildedRose.Solution1
{
    public class BackstageItemUpdateService : IItemUpdateService
    {
        public void Update(Item item)
        {
            item.SellIn -= 1;
            switch (item.SellIn)
            {
                case < 0:
                    item.Quality = 0;
                    break;
                case >= 10:
                    item.Quality += 1;
                    break;
                case > 5 and < 10:
                    item.Quality += 2;
                    break;
                default:
                    item.Quality += 3;
                    break;
            }
        }
    }
}