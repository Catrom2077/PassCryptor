using PassCryptor.Domain.Models.Abstract;

namespace PassCryptor.Domain.Models.Node
{
    public class PasswordNode : INode
    {
        public PasswordNode(string nodeName, INodeData nodeData, string key)
        {
            _nodeName = nodeName;
            _nodeData = nodeData;
            _key = key;
        }

        public string Name => _nodeName;
        private readonly string _nodeName = string.Empty;

        public INodeData Data => _nodeData;
        private readonly INodeData _nodeData;

        public string HashKey => _key;
        private readonly string _key = string.Empty;

        public override string ToString() => _nodeName;
    }
}