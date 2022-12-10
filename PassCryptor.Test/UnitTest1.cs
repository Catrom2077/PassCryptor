using Xunit;
using PassCryptor.Domain.Models.Node;
using PassCryptor.Domain.Models.Storage;
using PassCryptor.Domain.Models.NodeData;
using PassCryptor.Domain.Models.Abstract;
using PassCryptor.Encoder.Models.Encoder;
using PassCryptor.Domain.Controllers.Storage;
using PassCryptor.Encoder.Controllers.Encoder;

namespace PassCryptor.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void CreateNodeEncryptAndMoveToStorage()
        {
            int expectedNodeCount = 1;
            int expectedNodeKeyLength = 24;

            //========= init storage ==============

            PasswordStorage storage = new();
            PasswordStorageController storageController = new(storage);

            PasswordEncoderConfig encoderConfig = new("123");
            PasswordEncoder encoder = new(encoderConfig);

            PasswordEncoderController encoderController = new(encoder);

            //========== create node =================

            PasswordNodeData nodeData = new("password123", "login123", "email@mail.com");
            string hashKey = encoderController.GetHash("secretKey");
            PasswordNode passwordNode = new("Github", nodeData, hashKey);

            //== encoding and add to storage node ==

            INode encryptedNode = encoderController.EncryptNode(passwordNode);
            storageController.CreateNode(encryptedNode);

            int actualNodeKeyLength = encryptedNode.HashKey.Length;
            int actualNodeCount = storageController.GetNodes().Count;
            bool isNodeExisting = storageController.ReadNode("Github") != null;

            //============ test ================

            Assert.True(isNodeExisting);
            Assert.Equal(expectedNodeKeyLength, actualNodeKeyLength);
            Assert.Equal(expectedNodeCount, actualNodeCount);
        }

        [Fact]
        public void EncyptAndDecryptNode()
        {
            string expectedNodePassword = "password123";

            //========= init storage ==============

            PasswordStorage storage = new();
            PasswordStorageController storageController = new(storage);

            PasswordEncoderConfig encoderConfig = new("123");
            PasswordEncoder encoder = new(encoderConfig);

            PasswordEncoderController encoderController = new(encoder);

            //========== create node =================

            PasswordNodeData nodeData = new("password123", "login123", "email@mail.com");
            string hashKey = encoderController.GetHash("secretKey");
            PasswordNode passwordNode = new("Github", nodeData, hashKey);


            INode encryptedNode = encoderController.EncryptNode(passwordNode);
            storageController.CreateNode(encryptedNode);

            bool actualFormatCoincidence = expectedNodePassword == encryptedNode.Data.Password;
            string actualNodePassword = encoderController.DecryptNode(encryptedNode, "secretKey").Data.Password;

            Assert.False(actualFormatCoincidence);
            Assert.Equal(expectedNodePassword, actualNodePassword);
        }
    }
}