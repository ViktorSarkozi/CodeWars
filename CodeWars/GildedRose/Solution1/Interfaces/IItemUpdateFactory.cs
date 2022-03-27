namespace CodeWars.GildedRose.Solution1
{
    public interface IItemUpdateFactory
    {
        IItemUpdateService Create(Item item);
    }
}