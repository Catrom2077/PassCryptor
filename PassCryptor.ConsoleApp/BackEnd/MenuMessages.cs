namespace PassCryptor.ConsoleApp.BackEnd
{
    internal class MenuMessages
    {
        public void WriteError(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"[err] {message}");
            Console.ForegroundColor = ConsoleColor.White;
        }

        public void WriteWarrning(string message)
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine($"[wrn] {message}");
            Console.ForegroundColor = ConsoleColor.White;
        }

        public void WriteSuccess(string message)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"[ok] {message}");
            Console.ForegroundColor = ConsoleColor.White;
        }

        public void WriteMessage(string message)
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine($"[msg] {message}");
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}