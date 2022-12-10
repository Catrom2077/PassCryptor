using PassCryptor.Domain.Models.Node;
using PassCryptor.Domain.Models.Storage;
using PassCryptor.Domain.Models.NodeData;
using PassCryptor.Encoder.Models.Encoder;
using PassCryptor.Domain.Controllers.Storage;
using PassCryptor.Encoder.Controllers.Encoder;

namespace PassCryptor.ConsoleApp.BackEnd
{
    internal class PassCryptorService
    {
        public PassCryptorService()
        {
            _storage = new();
            _storageController = new(_storage);

            _encoderConfig = new("1234"); //TODO: add the ability to change the seed of the cipher
            _encoder = new(_encoderConfig);
            _encoderController = new(_encoder);
        }

        private readonly MenuMessages _menuMessages = new();

        private readonly PasswordStorage _storage;
        private readonly PasswordStorageController _storageController;

        private readonly PasswordEncoderConfig _encoderConfig;
        private readonly PasswordEncoder _encoder;
        private readonly PasswordEncoderController _encoderController;

        public void CreateAndSavePassNode()
        {
            _menuMessages.WriteMessage("Enter node name:");
            string? name = Console.ReadLine();

            if(string.IsNullOrWhiteSpace(name))
            {
                _menuMessages.WriteError("Node name is empty!");
                return;
            }

            PasswordNodeData nodeData = InitializePassNodeData();

            _menuMessages.WriteMessage("Enter secret key:");
            string? secretKey = Console.ReadLine();
            _menuMessages.WriteWarrning("Please remember this secrete key for opening your nodes!");

            if (string.IsNullOrWhiteSpace(secretKey))
            {
                _menuMessages.WriteError("Secret key is empty!");
                return;
            }

            string hashKey = _encoderController.GetHash(secretKey);
            PasswordNode passwordNode = new(name, nodeData, hashKey);

            _storageController.CreateNode(passwordNode);
            _menuMessages.WriteSuccess($"Node {name} is created!");
        }

        private PasswordNodeData InitializePassNodeData()
        {
            _menuMessages.WriteMessage("Enter password:");
            string? password = Console.ReadLine();
            _menuMessages.WriteMessage("Enter login:");
            string? login = Console.ReadLine();
            _menuMessages.WriteMessage("Enter email:");
            string? email = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(password) || string.IsNullOrWhiteSpace(login) || string.IsNullOrWhiteSpace(email))
            {
                _menuMessages.WriteWarrning("One or few parameter is empty, continue? [y/n]");
                ConsoleKey key = Console.ReadKey(true).Key;

                if (key == ConsoleKey.Y)
                    return new(password, login, email);
                else
                    InitializePassNodeData();
            }

            return new(string.Empty, string.Empty, string.Empty); 
        }
    }
}