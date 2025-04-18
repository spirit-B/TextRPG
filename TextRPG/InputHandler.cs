namespace TextRPG
{
    internal static class InputHandler
    {
        public static void HandleInputHandler(string inputNumber, ref bool mod, ref bool checkLoop)
        {
            switch (inputNumber)
            {
                case "1":
                    mod = true;
                    break;
                case "0":
                    checkLoop = false;
                    break;
                default:
                    Console.Clear();
                    Console.WriteLine("잘못된 입력입니다.");
                    Thread.Sleep(1000);
                    break;
            }
        }
        
        public static void HandleInputHandlerInShop(string inputNumber, ref bool mod1, ref bool mod2, ref bool checkLoop)
        {
            switch (inputNumber)
            {
                case "1":
                    mod1 = true;
                    break;
                case "2":
                    mod2 = true;
                    break;
                case "0":
                    if (mod1)
                    {
                        mod1 = false;
                    }
                    else if (mod2)
                    {
                        mod2 = false;
                    }
                    else if (!mod1 && !mod2)
                    {
                        checkLoop = false;
                    }
                    break;
                default:
                    Console.Clear();
                    Console.WriteLine("잘못된 입력입니다.");
                    Thread.Sleep(1000);
                    break;
            }
        }

        public static void HandleInputHandler(string inputNumber, Action function, ref bool checkLoop)
        {
            switch (inputNumber)
            {
                case "1":
                    function();
                    break;
                case "0":
                    checkLoop = false;
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
