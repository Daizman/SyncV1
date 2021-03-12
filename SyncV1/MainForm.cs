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
            if (_user.UserDirectory.Path != "")
            {
                SetWatcher();
                FillDirectoryInfo();
            }
        }

        private void DirsList_SelectedIndexChanged(object sender, EventArgs e)
        {
            ButtonsBind();
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

        private void FillDirectoryInfo()
        {
            if (_user.UserDirectory.Path == "")
            {
                return;
            }
            DirsList.Items.Clear();
            var allDirFiles = Directory.GetFiles(_user.UserDirectory.Path);
            foreach (var file in allDirFiles)
            {
                DirsList.Items.Add(file);
            }
        }

        private void SetWatcher()
        {
            FSWatcher.Path = _user.UserDirectory.Path;
            FSWatcher.NotifyFilter = NotifyFilters.Attributes
                                 | NotifyFilters.CreationTime
                                 | NotifyFilters.DirectoryName
                                 | NotifyFilters.FileName
                                 | NotifyFilters.LastAccess
                                 | NotifyFilters.LastWrite
                                 | NotifyFilters.Security
                                 | NotifyFilters.Size;

            FSWatcher.Changed += FSWatcher_Changed;
            FSWatcher.Created += FSWatcher_Changed;
            FSWatcher.Deleted += FSWatcher_Changed;
            FSWatcher.Renamed += FSWatcher_Changed;

            FSWatcher.IncludeSubdirectories = true;
            FSWatcher.EnableRaisingEvents = true;
        }

        private void AddDirBtn_Click(object sender, EventArgs e)
        {
            var addFolderDialog = new CreateFolderWindow.MainForm();
            if (addFolderDialog.ShowDialog() == DialogResult.OK)
            {
                _user.UserDirectory.Path = addFolderDialog.SelectedPath;
                SetWatcher();
                FillDirectoryInfo();
                ButtonsBind();
            }
        }

        private void ButtonsBind()
        {
            AddDirBtn.Enabled = _user.UserDirectory.Path == "";
            AllowToDir.Enabled = _user.UserDirectory.Path != "";
            BAddFile.Enabled = _user.UserDirectory.Path != "";
            BDelFile.Enabled = _user.UserDirectory.Path != "" && DirsList.SelectedIndex != -1;
        }

        private void FSWatcher_Changed(object sender, FileSystemEventArgs e)
        {
            FillDirectoryInfo();
        }

        private void BAddFile_Click(object sender, EventArgs e)
        {

            ButtonsBind();
        }

        private void BDelFile_Click(object sender, EventArgs e)
        {
            var file = DirsList.SelectedItem;
            File.Delete((string)file);
            ButtonsBind();
        }
    }
}
