using PassCryptor.Encoder.Models.Abstract;

namespace PassCryptor.Encoder.Models.Encoder
{
    public class PasswordEncoderConfig : IEncoderConfig
    {
        public PasswordEncoderConfig(string key)
        {
            _key = key;
        }

        public string XORKey => _key;
        private readonly string _key = string.Empty;
    }
}