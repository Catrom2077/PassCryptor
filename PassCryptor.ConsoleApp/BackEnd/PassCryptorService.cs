using PassCryptor.Domain.Models.Storage;
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

        private readonly PasswordStorage _storage;
        private readonly PasswordStorageController _storageController;

        private readonly PasswordEncoderConfig _encoderConfig;
        private readonly PasswordEncoder _encoder;
        private readonly PasswordEncoderController _encoderController;

        public void CreateAndSavePassNode()
        {
            Console.WriteLine();
        }
    }
}