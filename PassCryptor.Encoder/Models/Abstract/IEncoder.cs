namespace PassCryptor.Encoder.Models.Abstract
{
    public interface IEncoder<T> where T : IEncoderConfig
    {
        public T Config { get; }
    }
}