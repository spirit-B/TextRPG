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
    }
}
