using Newtonsoft.Json;
using System.Collections.Generic;

namespace ToolsLib.UserClasses
{
    public class Friends
    {
        [JsonProperty("users")]
        public List<User> Users { get; set; }

        public Friends() { }

        public Friends(List<User> users)
        {
            Users = users;
        }
    }
}
