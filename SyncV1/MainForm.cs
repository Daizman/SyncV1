using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ToolsLib;
using ToolsLib.UserClasses;

namespace SyncV1
{
    public partial class MainForm : Form
    {
        private User _user;
        public MainForm()
        {
            InitializeComponent();
            var file = GetUserBackupFile();
            if (file == "")
            {
                GenerateUser();
            }
            else
            {
                RestoreUser(file);
            }
        }

        private void DirsList_SelectedIndexChanged(object sender, EventArgs e)
        {
            OpenDir.Enabled = true;
            AllowToDir.Enabled = true;
        }

        private void RestoreUser(string file)
        {
            var restJson = UDumper.Restore(file);
            _user = JsonConvert.DeserializeObject<User>(restJson);
        }

        private void GenerateUser()
        {
            _user = new User();
        }

        private string GetUserBackupFile()
        {
            var allDirFiles = Directory.GetFiles(Environment.CurrentDirectory);
            var fileExtenTemplate = UserSet.Default.UserDataExt;
            foreach (var file in allDirFiles)
            {
                if (file.Contains(fileExtenTemplate))
                {
                    return file;
                }
            }
            return "";
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (_user is null)
            {
                return;
            }
            UDumper.Dump(JsonConvert.SerializeObject(_user), "User" + UserSet.Default.UserDataExt);
        }
    }
}
