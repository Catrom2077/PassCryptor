namespace PassCryptor.ConsoleApp.BackEnd
{
    internal class MenuController
    {
        public bool IsExit => _isExit;
        private bool _isExit = false;

        private readonly MenuMessages _menuMessages = new();
        private readonly PassCryptorService _service = new();

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
            _menuMessages.WriteMessage("Enter option: ");

            key = Console.ReadKey(true).Key;

            switch(key)
            {
                case ConsoleKey.D1:
                    _menuMessages.WriteMessage("Creating node...");
                    _service.CreateAndSavePassNode();
                    break;

                case ConsoleKey.D2:
                    _menuMessages.WriteMessage("Reading node...");
                    break;

                case ConsoleKey.D3:
                    _menuMessages.WriteMessage("Updating node...");
                    break;

                case ConsoleKey.D4:
                    _menuMessages.WriteMessage("Deleting node...");
                    break;

                case ConsoleKey.D5:
                    _menuMessages.WriteMessage("Geting node list...");
                    break;

                case ConsoleKey.D0:
                    _menuMessages.WriteWarrning("Exit the PassCryptor...");
                    _isExit = true;
                    break;

                default:
                    _menuMessages.WriteError("Options is incorrect!");
                    break;
            }
        }
    }
}