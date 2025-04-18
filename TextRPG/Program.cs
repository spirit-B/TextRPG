namespace TextRPG
{

	internal class Program
	{
        static void Main(string[] args)
		{
			Charactor charactor = new Charactor();
			Shop shop = new Shop(charactor);
			Rest rest = new Rest(charactor);

			while (true)
			{
				// 게임 시작 화면
				Console.Clear();
				Console.WriteLine("스파르타 마을에 오신 여러분 환영합니다.");
				Console.WriteLine("이곳에서 던전으로 들어가기전 활동을 할 수 있습니다.");
				Console.WriteLine();
				Console.WriteLine("1. 상태 보기\n2. 인벤토리\n3. 상점\n5. 휴식하기");
				Console.WriteLine();
				Console.WriteLine("원하시는 행동을 입력해주세요.");

				string selectNumber = Console.ReadLine();

				switch (selectNumber)
				{
					case "1":
						charactor.ShowStatus();
						break;
					case "2":
						charactor.ShowInventory();
						break;
					case "3":
						shop.ShowSellingItem();
						break;
					case "5":
						rest.InAnn();
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
