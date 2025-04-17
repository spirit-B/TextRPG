namespace TextRPG
{
    internal class Inventory
    {
        public List<Item>? ItemList { get; set; }
        public bool isArmed = false;

        public Inventory()
        {
            ItemList = new List<Item>();
        }
    }
}
