namespace CodeWars.GildedRose.Solution2
{
    public class ItemExtension : Item
    {
        public ItemExtension(string name, int sellIn, int quality, ItemType type)
        {
            Name = name;
            SellIn = sellIn;
            Quality = quality;
            Type = type;
        }

        public ItemType Type { get; }
    }
}