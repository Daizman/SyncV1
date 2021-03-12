﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ToolsLib.UserClasses
{
    public class User
    {
        [JsonProperty("name")]
        private readonly string _name;
        [JsonProperty("publicKey")]
        private readonly string _publicKey;
        [JsonProperty("userDirectory")]
        private UDirectory _userDirectory;

        public List<User> Friends;

        public User()
        {
            Friends = new List<User>();
            _userDirectory = new UDirectory();
        }

        public User(string name)
        {
            _name = name;
            _publicKey = GeneratePublicKey();
            Friends = new List<User>();
            _userDirectory = new UDirectory();
        }
        public User(string name, UDirectory dir)
        {
            _name = name;
            _publicKey = GeneratePublicKey();
            Friends = new List<User>();
            _userDirectory = dir;
        }
        public User(string name, string publicKey)
        {
            _name = name;
            _publicKey = publicKey;
            Friends = new List<User>();
            _userDirectory = new UDirectory();
        }

        public User(string name, string publicKey, UDirectory dir)
        {
            _name = name;
            _publicKey = publicKey;
            Friends = new List<User>();
            _userDirectory = dir;
        }

        private string GeneratePublicKey()
        {
            var random = new Random();
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, 42)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        public string PublicKey
        {
            get
            {
                return _publicKey;
            }
        }

        public string Name
        {
            get
            {
                return _name;
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
