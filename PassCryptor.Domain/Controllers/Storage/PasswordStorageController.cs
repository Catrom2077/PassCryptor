using PassCryptor.Domain.Models.Abstract;
using PassCryptor.Domain.Controllers.Abstract;

namespace PassCryptor.Domain.Controllers.Storage
{
    public class PasswordStorageController : IStorageController<IStorage<INode>>
    {
        public PasswordStorageController(IStorage<INode> storage)
        {
            _storage = storage;
        }

        public IStorage<INode> Storage => _storage;
        private readonly IStorage<INode> _storage;

        public void CreateNode(INode node) =>
            _storage.Nodes.Add(node);

        public INode ReadNode(string nodeName) =>
            _storage.Nodes[FindNodeIndex(nodeName)];

        public void UpdateNode(INode node, string nodeName) =>
            _storage.Nodes[FindNodeIndex(nodeName)] = node;

        public void DeleteNode(string nodeName) =>
            _storage.Nodes.RemoveAt(FindNodeIndex(nodeName));

        public List<INode> GetNodes() =>
            _storage.Nodes;
        
        #region Reusable Methods

        private int FindNodeIndex(string nodeName)
        {
            int passwordNodeIndex = _storage.Nodes.FindIndex(node => node.Name == nodeName);

            if (passwordNodeIndex == -1)
                throw new ArgumentNullException($"Node with name: {nodeName}, not be founded!");

            return passwordNodeIndex;
        }

        #endregion
    }
}