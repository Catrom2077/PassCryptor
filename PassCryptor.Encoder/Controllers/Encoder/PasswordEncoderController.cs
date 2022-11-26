using System.Text;
using System.Security.Cryptography;
using PassCryptor.Domain.Models.Node;
using PassCryptor.Domain.Models.NodeData;
using PassCryptor.Domain.Models.Abstract;
using PassCryptor.Encoder.Models.Abstract;
using PassCryptor.Encoder.Controllers.Abstract;

namespace PassCryptor.Encoder.Controllers.Encoder
{
    public class PasswordEncoderController : IEncoderController
    {
        public PasswordEncoderController(IEncoder<IEncoderConfig> encoder)
        {
            _encoder = encoder;
        }

        private readonly IEncoder<IEncoderConfig> _encoder;

        public INode EncryptNode(INode node) =>
            XORChiper(node);

        public INode DecryptNode(INode node, string key)
        {
            if (IsKeyCorrect(node, key))
                return XORChiper(node);
            else
                throw new InvalidDataException("Key is incorrect!");
        }

        public bool IsKeyCorrect(INode node, string key) =>
            node.HashKey == GetHash(key);

        public string GetHash(string key)
        {
            byte[] hash = MD5.Create().ComputeHash(Encoding.UTF8.GetBytes(key));

            return Convert.ToBase64String(hash);
        }

        #region Reusable Methods

        private PasswordNode XORChiper(INode node)
        {
            string[] dataset = { node.Data.Login, node.Data.Email, node.Data.Password };
            string[] cryptedDataset = new string[dataset.Length];
            string key = _encoder.Config.XORKey;

            for(int i = 0; i < dataset.Length; ++i)
            {
                cryptedDataset[i] = GetXOR(dataset[i], key);
            }

            PasswordNodeData nodeData = new(cryptedDataset[0], cryptedDataset[1], cryptedDataset[2]);
            return new(node.Name, nodeData, node.HashKey);
        }

        public static string GetXOR(string data, string xorKey)
        {
            int dataLenght = data.Length;
            int keyLenght = xorKey.Length;
            char[] result = new char[dataLenght];

            for (int i = 0; i < dataLenght; ++i)
            {
                result[i] = (char)(data[i] ^ xorKey[i % keyLenght]);
            }

            return new string(result);
        }

        #endregion
    }
}