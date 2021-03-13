using System;
using System.Windows.Forms;

namespace AddUserToDir
{
    public partial class AddUserToDirWindow : Form
    {
        public string AddedUserPublicKey;
        public AddUserToDirWindow()
        {
            InitializeComponent();
        }

        private void BAdd_Click(object sender, EventArgs e)
        {
            if (TBPublicKey.Text.Trim() != "")
            {
                DialogResult = DialogResult.OK;
                Close();
            }
            else
            {
                MessageBox.Show("Введите значение публичного ключа");
            }
        }

        private void BClose_Click(object sender, EventArgs e)
        {
            AddedUserPublicKey = "";
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void TBPublicKey_TextChanged(object sender, EventArgs e)
        {
            AddedUserPublicKey = TBPublicKey.Text.Trim();
        }
    }
}
