//using System.Reflection;
namespace TextRPG
{
	internal class Shop
	{
		private List<Item> sellingItems;
		private Charactor charactor;
		private bool intoBuyItem = false;
		private bool isShowing = false;

		public Shop(Charactor charactor)
		{
            sellingItems = new List<Item>();
			this.charactor = charactor;
			InitSellingItems();
		}

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

				foreach (Item item in sellingItems)
				{
					Console.Write($"- {(intoBuyItem ? sellingItems.IndexOf(item) + 1 : "")} {item.name}	| {(item.type == ItemType.Weapon ? "공격력" : "방어력")} +{item.stat}	| ");
					Console.WriteLine($"{item.description} | {(item.isSelled ? "구매완료" : $"{item.price} G")}");
				}

				Console.WriteLine($"{ (intoBuyItem ? "" : "\n1. 아이템 구매") }\n0. 나가기\n");
				Console.WriteLine("원하시는 행동을 입력해주세요.");
				string selectNum = Console.ReadLine();
				
				if (intoBuyItem && selectNum == "0")
				{
					intoBuyItem = false;
				}
				else if (intoBuyItem && int.TryParse(selectNum, out int index))
				{
					index--;
					if (index >= 0 && index < sellingItems.Count)
					{
						Item selectedItem = sellingItems[index];
						if (charactor.gold >= selectedItem.price)
						{
							charactor.gold -= selectedItem.price;
							charactor.inventory.ItemList.Add(selectedItem);
							sellingItems[index].isSelled = true;
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
				else
				{
					InputHandler.HandleInputHandler(selectNum, ref intoBuyItem, ref isShowing);
				}
			}
		}
	}
}

