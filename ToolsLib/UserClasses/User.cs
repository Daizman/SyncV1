using System;

namespace ToolsLib.UserClasses
{
    public class User
    {

        private string _name;
        private string _publicKey;
        private UDirectory _userDirectory;

        public User()
        {
            _userDirectory = new UDirectory();
        }

        public User(string name)
        {
            _name = name;
            _userDirectory = new UDirectory();
        }

        public User(string name, string publicKey)
        {
            _name = name;
            _publicKey = publicKey;
            _userDirectory = new UDirectory();
        }

        public User(string name, string publicKey, UDirectory dir)
        {
            _name = name;
            _publicKey = publicKey;
            _userDirectory = dir;
        }

        public string PublicKey
        {
            get
            {
                return _publicKey;
            }
            set
            {
                if (_publicKey == "")
                {
                    _publicKey = value.Trim();
                }
                else
                {
                    throw new InvalidOperationException("Нельзя менять публичный ключ");
                }
            }
        }

        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                if (_name == "")
                {
                    _name = value.Trim();
                }
                else
                {
                    throw new InvalidOperationException("Нельзя менять имя");
                }
            }
        }

        public UDirectory UserDirectory
        {
            get 
            {
                return _userDirectory;
            }
        }
    }
}
