namespace PassCryptor.Domain.Models.Abstract
{
    public interface INodeData
    {
        public string? Password { get; }

        public string? Login { get; }

        public string? Email { get; }
    }
}