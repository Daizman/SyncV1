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
using ToolsLib.UserClasses;

namespace SyncV1
{
    public partial class MainForm : Form
    {
        private User _user;
        public MainForm()
        {
            InitializeComponent();
        }

        private void DirsList_SelectedIndexChanged(object sender, EventArgs e)
        {
            OpenDir.Enabled = true;
            AllowToDir.Enabled = true;
        }

        private void RestoreUser()
        {

        }

        private void GenerateUser()
        { 
            
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
    }
}
