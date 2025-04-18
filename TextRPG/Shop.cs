//using System.Reflection;
namespace TextRPG
{
	internal class Shop
	{
		private List<Item> sellingItems;
		private Charactor charactor;
		private bool intoBuyItem = false;
		private bool intoSellItem = false;
		private bool isShowing = false;

		public Shop(Charactor charactor)
		{
            sellingItems = new List<Item>();
			this.charactor = charactor;
			InitSellingItems();
		}

		// 아이템 구매
		private void InitSellingItems()
		{
			Console.WriteLine("판매 아이템 초기화중..");
			sellingItems.Add(new Item("수련자 갑옷", ItemType.Armor, 5, "수련에 도움을 주는 갑옷입니다.", 1000));
			sellingItems.Add(new Item("무쇠갑옷", ItemType.Armor, 9, "무쇠로 만들어져 튼튼한 갑옷입니다.", 1800));
			sellingItems.Add(new Item("스파르타 갑옷", ItemType.Armor, 15, "스파르타의 전사들이 사용했다는 전설의 갑옷입니다.", 3500));
			sellingItems.Add(new Item("낡은 검", ItemType.Weapon, 2, "쉽게 볼 수 있는 낡은 검입니다.", 600));
			sellingItems.Add(new Item("청동 도끼", ItemType.Weapon, 5, "어디선가 사용됐던 것 같은 도끼입니다.", 1500));
			sellingItems.Add(new Item("스파르타의 창", ItemType.Weapon, 7, "스파르타의 전사들이 사용했다는 전설의 창입니다.", 2700));
		}

		public void ShowSellingItem()
		{
			isShowing = true;

			while (isShowing)
			{
				Console.Clear();
				Console.WriteLine("상점\n 필요한 아이템을 얻을 수 있는 상점입니다.\n");
				Console.WriteLine($"[보유 골드]\n{charactor.gold}G\n");
				Console.WriteLine("[아이템 목록]");

				// 판매 혹은 구매에 따라 보여지는 화면을 다르게 구성
				if (!intoSellItem)
				{
					CanBuyItemList();
				}
				else
				{
					SellItemList();
                }
				
				// 공통 출력 부분
				Console.WriteLine($"{(intoBuyItem || intoSellItem ? "" : "\n1. 아이템 구매")}{(intoSellItem || intoBuyItem ? "" : "\n2. 아이템 판매")}\n0. 나가기\n");
				Console.WriteLine("원하시는 행동을 입력해주세요.");
				string selectNum = Console.ReadLine();

				// 아이템 구매 로직
				if (intoBuyItem && selectNum == "0")
				{
					intoBuyItem = false;
				}
				else if (intoBuyItem && int.TryParse(selectNum, out int buyIndex))
				{
                    buyIndex--;
					if (buyIndex >= 0 && buyIndex < sellingItems.Count)
					{
						Item selectedItem = sellingItems[buyIndex];
						if (charactor.gold >= selectedItem.price)
						{
							charactor.gold -= selectedItem.price;
							charactor.inventory.ItemList.Add(selectedItem);
							sellingItems[buyIndex].isSelled = true;
							Console.Clear();
							Console.WriteLine("구매를 완료했습니다.");
						}
						else
						{
							Console.Clear();
							Console.WriteLine("Gold가 부족합니다.");
						}
					}
					else
					{
						Console.Clear();
						Console.WriteLine("잘못된 입력입니다.");
					}
					Thread.Sleep(1000);
				}
				// 아이템 판매 로직
				else if (intoSellItem && selectNum == "0")
				{
					intoSellItem = false;
				}
				else if (intoSellItem && int.TryParse(selectNum, out int sellIndex))
				{
					sellIndex--;
					Item selectedItem = charactor.inventory.ItemList[sellIndex];
					if (selectedItem == null)
					{
						Console.Clear();
						Console.WriteLine("판매할 아이템이 없습니다.");
					}
					else
					{
						double sellingPrice = selectedItem.price * 0.85;
						charactor.gold += (int)sellingPrice;
						charactor.inventory.ItemList[sellIndex].isArmed = false;
						charactor.inventory.ItemList.Remove(selectedItem);
                    }
				}
				else
				{
					InputHandler.HandleInputHandlerInShop(selectNum, ref intoBuyItem, ref intoSellItem, ref isShowing);
				}
            }
		}

		private void CanBuyItemList()
		{
            foreach (Item item in sellingItems)
            {
                string itemIndexTxt = intoBuyItem ? $"{sellingItems.IndexOf(item) + 1}" : "";
                string itemTypeTxt = item.type == ItemType.Weapon ? "공격력" : "방어력";
                string checkSelledTxt = item.isSelled ? "구매완료" : $"{item.price} G";

                Console.WriteLine($"- {itemIndexTxt} {item.name}	| {itemTypeTxt} +{item.stat}	| {item.description} | {checkSelledTxt}");
            }
        }

		// 아이템 판매
		public void SellItemList()
		{
            if (charactor.inventory.ItemList.Count == 0)
            {
                Console.WriteLine("");
            }
            else
            {
                foreach (Item item in charactor.inventory.ItemList)
                {
                    string checkIsArmedTxt = item.isArmed ? "[E]" : "";
                    string indexTxt = $"{charactor.inventory.ItemList.IndexOf(item) + 1}";
                    string typeTxt = item.type == ItemType.Weapon ? "공격력" : "방어력";

                    Console.WriteLine($"- {indexTxt} {checkIsArmedTxt}{item.name} | {typeTxt} +{item.stat} | {item.description} | 판매금액 : {item.price * 0.85} G");
                }
            }
        }
	}
}

