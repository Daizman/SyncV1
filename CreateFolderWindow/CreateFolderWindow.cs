using System;
using System.Windows.Forms;

namespace CreateFolderWindow
{
    public partial class MainForm : Form
    {
        public string SelectedPath;
        public MainForm()
        {
            InitializeComponent();
        }

        private void BChangePath_Click(object sender, EventArgs e)
        {
            if (FBDPath.ShowDialog() == DialogResult.OK)
            {
                SelectedPath = FBDPath.SelectedPath;
                LBPath.Text = SelectedPath;
            }
        }

        private void BCreate_Click(object sender, EventArgs e)
        {
            if (SelectedPath != null && SelectedPath != "")
            {
                DialogResult = DialogResult.OK;
                Close();
            }
            else
            {
                MessageBox.Show("Укажите путь");
            }
        }

        private void BCancel_Click(object sender, EventArgs e)
        {
            SelectedPath = "";
            LBPath.Text = SelectedPath;
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
