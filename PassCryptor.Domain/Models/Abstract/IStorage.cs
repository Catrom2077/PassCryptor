namespace PassCryptor.Domain.Models.Abstract
{
    public interface IStorage<T> where T : INode<INodeData>
    {
        public List<T> Nodes { get; }
    }
}