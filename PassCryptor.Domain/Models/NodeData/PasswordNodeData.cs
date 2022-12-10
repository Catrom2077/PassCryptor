using PassCryptor.Domain.Models.Abstract;

namespace PassCryptor.Domain.Models.NodeData
{
    public class PasswordNodeData : INodeData
    {
        public PasswordNodeData(string password, string login, string email)
        {
            _password = password;
            _login = login;
            _email = email;
        }

        public string Password => _password;
        private readonly string _password = string.Empty;

        public string Login => _login;
        private readonly string _login = string.Empty;

        public string Email => _email;
        private readonly string _email = string.Empty;
    }
}