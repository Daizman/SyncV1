using System;
using System.Linq;

namespace ToolsLib.UserClass
{
    public class UserPublicKey
    {
        private readonly string _key;
        private Random _random;

        public string Key {
            get 
            {
                return _key;
            }
        }

        public UserPublicKey()
        {
            _random = new Random();
            _key = GenerateKey();
        }

        private string GenerateKey() 
        {
            
            const string chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, 35)
              .Select(s => s[_random.Next(s.Length)]).ToArray());
        }
    }
}
