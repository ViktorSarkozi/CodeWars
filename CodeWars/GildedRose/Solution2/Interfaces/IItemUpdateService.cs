namespace CodeWars.GildedRose.Solution2
{
    public interface IItemUpdateService
    {
        bool CanUpdate(ItemExtension item);
        
        void Update(ItemExtension item);
    }
}