
namespace SyncV1
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuPanel = new System.Windows.Forms.Panel();
            this.OpenDir = new System.Windows.Forms.Button();
            this.AllowToDir = new System.Windows.Forms.Button();
            this.AddDirBtn = new System.Windows.Forms.Button();
            this.PublicKeyLabel = new System.Windows.Forms.Label();
            this.PublicKey = new System.Windows.Forms.Label();
            this.AllowedLabel = new System.Windows.Forms.Label();
            this.AllowedToDirList = new System.Windows.Forms.ListView();
            this.dirsPanel = new System.Windows.Forms.Panel();
            this.DirsList = new System.Windows.Forms.ListBox();
            this.menuPanel.SuspendLayout();
            this.dirsPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuPanel
            // 
            this.menuPanel.Controls.Add(this.OpenDir);
            this.menuPanel.Controls.Add(this.AllowToDir);
            this.menuPanel.Controls.Add(this.AddDirBtn);
            this.menuPanel.Controls.Add(this.PublicKeyLabel);
            this.menuPanel.Controls.Add(this.PublicKey);
            this.menuPanel.Controls.Add(this.AllowedLabel);
            this.menuPanel.Controls.Add(this.AllowedToDirList);
            this.menuPanel.Dock = System.Windows.Forms.DockStyle.Right;
            this.menuPanel.Location = new System.Drawing.Point(560, 0);
            this.menuPanel.Name = "menuPanel";
            this.menuPanel.Size = new System.Drawing.Size(240, 208);
            this.menuPanel.TabIndex = 0;
            // 
            // OpenDir
            // 
            this.OpenDir.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.OpenDir.Enabled = false;
            this.OpenDir.Location = new System.Drawing.Point(0, 3);
            this.OpenDir.Name = "OpenDir";
            this.OpenDir.Size = new System.Drawing.Size(240, 23);
            this.OpenDir.TabIndex = 6;
            this.OpenDir.Text = "Открыть директорию";
            this.OpenDir.UseVisualStyleBackColor = true;
            // 
            // AllowToDir
            // 
            this.AllowToDir.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.AllowToDir.Enabled = false;
            this.AllowToDir.Location = new System.Drawing.Point(0, 26);
            this.AllowToDir.Name = "AllowToDir";
            this.AllowToDir.Size = new System.Drawing.Size(240, 23);
            this.AllowToDir.TabIndex = 5;
            this.AllowToDir.Text = "Предоставить доступ";
            this.AllowToDir.UseVisualStyleBackColor = true;
            // 
            // AddDirBtn
            // 
            this.AddDirBtn.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.AddDirBtn.Location = new System.Drawing.Point(0, 49);
            this.AddDirBtn.Name = "AddDirBtn";
            this.AddDirBtn.Size = new System.Drawing.Size(240, 23);
            this.AddDirBtn.TabIndex = 4;
            this.AddDirBtn.Text = "Создать директорию";
            this.AddDirBtn.UseVisualStyleBackColor = true;
            // 
            // PublicKeyLabel
            // 
            this.PublicKeyLabel.AutoSize = true;
            this.PublicKeyLabel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.PublicKeyLabel.Location = new System.Drawing.Point(0, 72);
            this.PublicKeyLabel.Name = "PublicKeyLabel";
            this.PublicKeyLabel.Size = new System.Drawing.Size(94, 13);
            this.PublicKeyLabel.TabIndex = 3;
            this.PublicKeyLabel.Text = "Публичный ключ:";
            // 
            // PublicKey
            // 
            this.PublicKey.AutoSize = true;
            this.PublicKey.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.PublicKey.Location = new System.Drawing.Point(0, 85);
            this.PublicKey.Name = "PublicKey";
            this.PublicKey.Size = new System.Drawing.Size(141, 13);
            this.PublicKey.TabIndex = 2;
            this.PublicKey.Text = "Публичный ключ значение";
            // 
            // AllowedLabel
            // 
            this.AllowedLabel.AutoSize = true;
            this.AllowedLabel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.AllowedLabel.Location = new System.Drawing.Point(0, 98);
            this.AllowedLabel.Name = "AllowedLabel";
            this.AllowedLabel.Size = new System.Drawing.Size(140, 13);
            this.AllowedLabel.TabIndex = 1;
            this.AllowedLabel.Text = "Пользователи с доступом";
            // 
            // AllowedToDirList
            // 
            this.AllowedToDirList.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.AllowedToDirList.HideSelection = false;
            this.AllowedToDirList.Location = new System.Drawing.Point(0, 111);
            this.AllowedToDirList.Name = "AllowedToDirList";
            this.AllowedToDirList.Size = new System.Drawing.Size(240, 97);
            this.AllowedToDirList.TabIndex = 0;
            this.AllowedToDirList.UseCompatibleStateImageBehavior = false;
            // 
            // dirsPanel
            // 
            this.dirsPanel.Controls.Add(this.DirsList);
            this.dirsPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dirsPanel.Location = new System.Drawing.Point(0, 0);
            this.dirsPanel.Name = "dirsPanel";
            this.dirsPanel.Size = new System.Drawing.Size(560, 208);
            this.dirsPanel.TabIndex = 1;
            // 
            // DirsList
            // 
            this.DirsList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DirsList.FormattingEnabled = true;
            this.DirsList.Location = new System.Drawing.Point(0, 0);
            this.DirsList.Name = "DirsList";
            this.DirsList.Size = new System.Drawing.Size(560, 208);
            this.DirsList.TabIndex = 0;
            this.DirsList.SelectedIndexChanged += new System.EventHandler(this.DirsList_SelectedIndexChanged);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 208);
            this.Controls.Add(this.dirsPanel);
            this.Controls.Add(this.menuPanel);
            this.Name = "MainForm";
            this.Text = "Sync";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.menuPanel.ResumeLayout(false);
            this.menuPanel.PerformLayout();
            this.dirsPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel menuPanel;
        private System.Windows.Forms.Panel dirsPanel;
        private System.Windows.Forms.ListView AllowedToDirList;
        private System.Windows.Forms.Label PublicKeyLabel;
        private System.Windows.Forms.Label PublicKey;
        private System.Windows.Forms.Label AllowedLabel;
        private System.Windows.Forms.Button AddDirBtn;
        private System.Windows.Forms.Button AllowToDir;
        private System.Windows.Forms.Button OpenDir;
        private System.Windows.Forms.ListBox DirsList;
    }
}

