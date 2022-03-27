namespace CodeWars.GildedRose
{
    public interface IItemUpdateFactory
    {
        IItemUpdateService Create(Item item);
    }
}