using PassCryptor.Domain.Models.Abstract;

namespace PassCryptor.Domain.Controllers.Abstract
{
    public interface IStorageController<T> where T : IStorage<INode>
    {
        public T Storage { get; }

        public void CreateNode(INode node);

        public INode ReadNode(string nodeName);

        public void UpdateNode(INode node, string nodeName);

        public void DeleteNode(string nodeName);

        public List<INode> GetNodes();
    }
}