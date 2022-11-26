using PassCryptor.Domain.Models.Abstract;

namespace PassCryptor.Encoder.Controllers.Abstract
{
    public interface IEncoderController
    {
        public INode EncryptNode(INode node);

        public INode DecryptNode(INode node, string key);

        public bool IsKeyCorrect(INode node, string key);

        public string GetHash(string key);
    }
}