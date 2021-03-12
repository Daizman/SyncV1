using Newtonsoft.Json;
using System;

namespace ToolsLib.UserClasses
{
    public class UDirectory
    {
        [JsonProperty("path")]
        private string _path = "";

        public UDirectory()
        {
        }

        public UDirectory(string path)
        {
            _path = path;
        }

        public string Path
        {
            set
            {
                if (value is null)
                {
                    _path = "";
                }
                else
                {
                    _path = value.Trim();
                }
            }
            get
            {
                return _path;
            }
        }
    }
}
