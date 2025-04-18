namespace TextRPG
{
    internal class Rest
    {
        private Charactor charactor;

        private bool isInAnn = true;

        public Rest(Charactor charactor)
        {
            this.charactor = charactor;
        }
        public void InAnn()
        {
            isInAnn = true;

            while (isInAnn)
            {
                Console.Clear();
                Console.WriteLine("휴식하기");
                Console.WriteLine($"500 G 를 내면 체력을 회복할 수 있습니다. (보유 골드 : {charactor.gold})\n");
                Console.WriteLine("1. 휴식하기\n0. 나가기\n\n");
                Console.WriteLine("원하는 행동을 입력해주세요.");

                string selectNumber = Console.ReadLine();

                InputHandler.HandleInputHandler(selectNumber, TakeARest, ref isInAnn);
            }
        }

        private void TakeARest()
        {
            if (charactor.gold >= 500)
            {
                charactor.gold -= 500;
                charactor.hp = 100;
                Console.Clear();
                Console.WriteLine("체력이 전부 회복되었습니다!");
                Thread.Sleep(1000);
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Gold가 부족합니다.");
                Thread.Sleep(1000);
            }
        }
    }
}
