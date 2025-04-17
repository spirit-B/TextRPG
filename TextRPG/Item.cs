namespace TextRPG
{
    public enum ItemType
    {
        Weapon,
        Armor
    }

    internal class Item
    {
        public string name { get; set; }
        public ItemType type { get; set; }
        public int stat { get; set; }
        public string description { get; set; }
        public int price { get; set; }
        public bool isSelled = false;
        public bool isArmed = false;

        public Item(string CName, ItemType CType, int CStat, string CDescription, int CPrice)
        {
            name = CName;
            type = CType;
            stat = CStat;
            description = CDescription;
            price = CPrice;
            isSelled = false;
            isArmed = false;
        }
    }
}
