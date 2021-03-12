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
using CreateFolderWindow;

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
            PublicKey.Text = _user.PublicKey;
            ButtonsBind();
        }

        private void DirsList_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void RestoreUser(string file)
        {
            try
            {
                var restJson = UDumper.Restore(file);
                _user = JsonConvert.DeserializeObject<User>(restJson);
            }
            catch
            {
                GenerateUser();
            }
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

        private void AddDirBtn_Click(object sender, EventArgs e)
        {
            var addFolderDialog = new CreateFolderWindow.MainForm();
            if (addFolderDialog.ShowDialog() == DialogResult.OK)
            {
                _user.UserDirectory.Path = addFolderDialog.SelectedPath;
                ButtonsBind();
            }
        }

        private void ButtonsBind()
        {
            AddDirBtn.Enabled = _user.UserDirectory.Path == "";
            AllowToDir.Enabled = _user.UserDirectory.Path != "";
        }
    }
}
