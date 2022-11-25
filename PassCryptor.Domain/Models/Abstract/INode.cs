namespace PassCryptor.Domain.Models.Abstract
{
    public interface INode<T> where T : INodeData
    {
        public string NodeName { get; }

        public T NodeData { get; }

        public string Key { get; }
    }
}