namespace PassCryptor.ConsoleApp.BackEnd
{
    internal class MenuController
    {
        public bool IsExit => _isExit;
        private bool _isExit = false;

        public void DrawBanner()
        {
            string banner = File.ReadAllText($"{Directory.GetCurrentDirectory()}\\Resources\\Banner.txt");
            Console.WriteLine(banner + "\n");
        }

        public void DrawMenu()
        {
            Console.WriteLine("[1] Create node");
            Console.WriteLine("[2] Read node");
            Console.WriteLine("[3] Update node");
            Console.WriteLine("[4] Delete node");
            Console.WriteLine("[5] Get node list");
            Console.WriteLine("[0] Exit");
        }

        public void HandleInput()
        {
            ConsoleKey key;
            WriteMessage("Enter option: ");

            key = Console.ReadKey(true).Key;

            switch(key)
            {
                case ConsoleKey.D1:
                    WriteMessage("Creating node...");
                    break;

                case ConsoleKey.D2:
                    WriteMessage("Reading node...");
                    break;

                case ConsoleKey.D3:
                    WriteMessage("Updating node...");
                    break;

                case ConsoleKey.D4:
                    WriteMessage("Deleting node...");
                    break;

                case ConsoleKey.D5:
                    WriteMessage("Geting node list...");
                    break;

                case ConsoleKey.D0:
                    WriteWarrning("Exit the PassCryptor...");
                    _isExit = true;
                    break;

                default:
                    WriteError("Options is incorrect!");
                    break;
            }
        }

        #region Reusable Methods

        private void WriteError(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"[err] {message}");
            Console.ForegroundColor = ConsoleColor.White;
        }

        private void WriteWarrning(string message)
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine($"[wrn] {message}");
            Console.ForegroundColor = ConsoleColor.White;
        }

        private void WriteSuccess(string message)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"[ok] {message}");
            Console.ForegroundColor = ConsoleColor.White;
        }

        private void WriteMessage(string message)
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine($"[msg] {message}");
            Console.ForegroundColor = ConsoleColor.White;
        }

        #endregion
    }
}