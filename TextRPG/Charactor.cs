namespace TextRPG
{
    internal class Charactor
    {

        public int level { get; }
        public string name { get; }
        public string role { get; }
        public int atk { get; set; }
        public int def { get; set; }
        public int hp { get; set; }
        public int gold { get; set; }

        public Inventory inventory;

        private bool armedMod = false;

        public Charactor()
        {
            level = 1;
            name = "포켓몬마스터";
            role = "전사";
            atk = 10;
            def = 5;
            hp = 100;
            gold = 5000;

            inventory = new Inventory();
        }

        // 상태 보기
        public void ShowStatus()
        {
            while (true)
            {
                int plusAtk = 0;
                int plusDef = 0;
                foreach (Item item in inventory.ItemList)
                {
                    if (item.isArmed)
                    {
                        if (item.type == ItemType.Weapon)
                        {
                            plusAtk += item.stat;
                        }
                        else
                        {
                            plusDef += item.stat;
                        }
                    }
                }
                Console.Clear();
                Console.WriteLine($"상태 보기\n캐릭터의 정보가 표시됩니다.\n\n"
                    + $"Lv. {level}\n"
                    + $"{name} ({role})\n"
                    + $"공격력 : {atk} {(plusAtk > 0 ? $"(+{plusAtk})" : "")}\n"
                    + $"방어력 : {def} {(plusDef > 0 ? $"(+{plusDef})" : "")}\n"
                    + $"체  력 : {hp}\n"
                    + $"Gold : {gold}\n\n"
                    + "0. 나가기\n\n원하시는 행동을 입력해주세요.");
                string number = Console.ReadLine();
                if (number != "0")
                {
                    Console.Clear();
                    Console.WriteLine("잘못된 입력입니다.");
                    Thread.Sleep(1000);
                }
                else break;
            }
        }
        public void ShowInventory()
        {
            bool isShowing = true;
            while (isShowing)
            {
                Console.Clear();
                Console.WriteLine("인벤토리\n보유 중인 아이템을 관리할 수 있습니다.\n\n"
                    + "[아이템 목록]\n");

                if (inventory.ItemList == null)
                {
                    Console.WriteLine("");
                }
                else
                {
                    foreach (Item item in inventory.ItemList)
                    {
                        string indexTxt = armedMod ? (inventory.ItemList.IndexOf(item) + 1).ToString() : "";
                        string typeTxt = item.type == ItemType.Weapon ? "공격력" : "방어력";
                        Console.WriteLine($"- {indexTxt} {(item.isArmed ? "[E]" : "")}{item.name}  | {typeTxt} +{item.stat}    | {item.description}");
                    }
                }

                Console.WriteLine("\n1. 장착 관리\n0. 나가기\n\n");
                Console.WriteLine("원하시는 행동을 입력해주세요.");
                string selectNumber = Console.ReadLine();

                if (armedMod && selectNumber == "0")
                {
                    armedMod = false;
                }
                else if (armedMod && int.TryParse(selectNumber, out int index))
                {
                    index--;
                    if (index >= 0 && index < inventory.ItemList.Count)
                    {
                        Item selectedItem = inventory.ItemList[index];
                        selectedItem.isArmed = true;
                        if (selectedItem.type == ItemType.Weapon)
                        {
                            this.atk += selectedItem.stat;
                        }
                        else
                        {
                            this.def += selectedItem.stat;
                        }
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("잘못된 입력입니다.");
                        Thread.Sleep(1000);
                    }
                }
                else
                {
                    switch (selectNumber)
                    {
                        case "1":
                            armedMod = true;
                            break;
                        case "0":
                            isShowing = false;
                            break;
                        default:
                            Console.Clear();
                            Console.WriteLine("잘못된 입력입니다.");
                            Thread.Sleep(1000);
                            break;
                    }
                }

            }
        }
    }
}
