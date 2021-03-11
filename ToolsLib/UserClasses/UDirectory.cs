using System;

namespace ToolsLib.UserClasses
{
    public class UDirectory
    {
        private string _path;

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
                if (_path != "")
                {
                    throw new InvalidOperationException("Нельзя изменять путь до папки");
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
