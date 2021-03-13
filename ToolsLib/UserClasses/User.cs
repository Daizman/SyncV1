using Newtonsoft.Json;
using System;
using System.Linq;

namespace ToolsLib.UserClasses
{
    public class User
    {
        [JsonProperty("publicKey")]
        private readonly string _publicKey;
        [JsonProperty("userDirectory")]
        private UDirectory _userDirectory;
        [JsonProperty("friends")]
        public Friends Friends { get; set; }

        public User()
        {
            _publicKey = GeneratePublicKey();
            Friends = new Friends();
            _userDirectory = new UDirectory();
        }

        public User(UDirectory dir)
        {
            _publicKey = GeneratePublicKey();
            Friends = new Friends();
            _userDirectory = dir;
        }
        public User(string publicKey)
        {
            _publicKey = publicKey;
            Friends = new Friends();
            _userDirectory = new UDirectory();
        }

        public User(string publicKey, UDirectory dir)
        {
            _publicKey = publicKey;
            Friends = new Friends();
            _userDirectory = dir;
        }

        public User(Friends friends)
        {
            _publicKey = GeneratePublicKey();
            Friends = friends;
            _userDirectory = new UDirectory();
        }
        public User(string publicKey, Friends friends)
        {
            _publicKey = publicKey;
            Friends = friends;
            _userDirectory = new UDirectory();
        }

        public User(Friends friends, UDirectory dir)
        {
            _publicKey = GeneratePublicKey();
            Friends = friends;
            _userDirectory = dir;
        }

        public User(string publicKey, Friends friends, UDirectory dir)
        {
            _publicKey = publicKey;
            Friends = friends;
            _userDirectory = dir;
        }

        private string GeneratePublicKey()
        {
            var publicKey = Cryptor.Cryptographer.GetRSA().ExportParameters(false);
            return JsonConvert.SerializeObject(new Cryptor.RSAPublicKeyParameters(publicKey));
        }

        public string PublicKey
        {
            get
            {
                return _publicKey;
            }
        }

        public UDirectory UserDirectory
        {
            get 
            {
                return _userDirectory;
            }
            set
            {
                _userDirectory = value;
            }
        }
    }
}
