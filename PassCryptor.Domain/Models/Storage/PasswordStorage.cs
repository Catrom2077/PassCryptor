using PassCryptor.Domain.Models.Abstract;

namespace PassCryptor.Domain.Models.Storage
{
    public class PasswordStorage : IStorage<INode<INodeData>>
    {
        public PasswordStorage()
        {
            _nodes = new();
        }

        public List<INode<INodeData>> Nodes => _nodes;
        private readonly List<INode<INodeData>> _nodes;
    }
}