namespace PassCryptor.Domain.Models.Abstract
{
    public interface IStorage<T> where T : INode
    {
        public List<T> Nodes { get; }
    }
}