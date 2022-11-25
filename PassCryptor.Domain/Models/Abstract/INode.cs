namespace PassCryptor.Domain.Models.Abstract
{
    public interface INode
    {
        public string Name { get; }

        public INodeData Data { get; }

        public string Key { get; }
    }
}