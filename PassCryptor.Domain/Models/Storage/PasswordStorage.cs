using PassCryptor.Domain.Models.Abstract;

namespace PassCryptor.Domain.Models.Storage
{
    public class PasswordStorage : IStorage<INode>
    {
        public PasswordStorage()
        {
            _nodes = new();
        }

        public List<INode> Nodes => _nodes;
        private readonly List<INode> _nodes;
    }
}