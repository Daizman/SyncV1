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
using ToolsLib.Interfaces;
using System.Threading;
using System.Net;
using AddUserToDir;

namespace SyncV1
{
    public partial class MainForm : Form, IMessageHandler
    {
        private User _user;
        private readonly CancellationTokenSource _cancellationToken;
        private readonly object _locker;
        private string _ipString;
        private UDPChecker _checker;
        private IPAddress _ip;
        private int _port = 11000;
        private string _searchedPublicKey;
        public MainForm()
        {
            InitializeComponent();
            _locker = new object();
            _cancellationToken = new CancellationTokenSource();
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
            RunServ();
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
            try
            {
                StopServ();
            }
            finally
            { 
            }
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
            if(OFDialog.ShowDialog() == DialogResult.OK)
            {
                var lastPt = OFDialog.FileName.Split('\\').Last();
                File.Copy(OFDialog.FileName, Path.Combine(_user.UserDirectory.Path, lastPt), true);
            }
            ButtonsBind();
        }

        private void BDelFile_Click(object sender, EventArgs e)
        {
            var file = DirsList.SelectedItem;
            File.Delete((string)file);
            ButtonsBind();
        }

        public void HandleMessage(string msg)
        {

        }
        private void RunServ()
        {
            var host = Dns.GetHostName();
            _ip = Dns.GetHostEntry(host).AddressList[0];
            _ipString = _ip.ToString();
            _checker = new UDPChecker(_ip, _port);
            _checker.Run(this, _cancellationToken.Token);
        }

        private void StopServ()
        {
            _cancellationToken.Cancel();
        }

        private void SendSocketAsync()
        {
            var addrTemplate = "192.168.0.";
            for (var i = 0; i < 256; i++)
            {

            }
        }

        private void AllowToDir_ClickAsync(object sender, EventArgs e)
        {
            var addUserToDir = new AddUserToDirWindow();
            addUserToDir.ShowDialog();
            if (addUserToDir.DialogResult == DialogResult.OK)
            {
                _searchedPublicKey = addUserToDir.AddedUserPublicKey;
                SendSocketAsync();
            }
        }
    }
}
