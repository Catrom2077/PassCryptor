using PassCryptor.Encoder.Models.Abstract;

namespace PassCryptor.Encoder.Models.Encoder
{
    public class PasswordEncoder : IEncoder<IEncoderConfig>
    {
        public PasswordEncoder(IEncoderConfig config)
        {
            _config = config;
        }

        public IEncoderConfig Config => _config;
        private readonly IEncoderConfig _config;
    }
}