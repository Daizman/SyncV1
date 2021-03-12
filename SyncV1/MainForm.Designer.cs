
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
            this.AllowToDir = new System.Windows.Forms.Button();
            this.AddDirBtn = new System.Windows.Forms.Button();
            this.PublicKeyLabel = new System.Windows.Forms.Label();
            this.AllowedLabel = new System.Windows.Forms.Label();
            this.AllowedToDirList = new System.Windows.Forms.ListView();
            this.dirsPanel = new System.Windows.Forms.Panel();
            this.DirsList = new System.Windows.Forms.ListBox();
            this.PublicKey = new System.Windows.Forms.TextBox();
            this.FSWatcher = new System.IO.FileSystemWatcher();
            this.menuPanel.SuspendLayout();
            this.dirsPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.FSWatcher)).BeginInit();
            this.SuspendLayout();
            // 
            // menuPanel
            // 
            this.menuPanel.Controls.Add(this.PublicKey);
            this.menuPanel.Controls.Add(this.AllowToDir);
            this.menuPanel.Controls.Add(this.AddDirBtn);
            this.menuPanel.Controls.Add(this.PublicKeyLabel);
            this.menuPanel.Controls.Add(this.AllowedLabel);
            this.menuPanel.Controls.Add(this.AllowedToDirList);
            this.menuPanel.Dock = System.Windows.Forms.DockStyle.Right;
            this.menuPanel.Location = new System.Drawing.Point(560, 0);
            this.menuPanel.Name = "menuPanel";
            this.menuPanel.Size = new System.Drawing.Size(240, 285);
            this.menuPanel.TabIndex = 0;
            // 
            // AllowToDir
            // 
            this.AllowToDir.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.AllowToDir.Enabled = false;
            this.AllowToDir.Location = new System.Drawing.Point(0, 129);
            this.AllowToDir.Name = "AllowToDir";
            this.AllowToDir.Size = new System.Drawing.Size(240, 23);
            this.AllowToDir.TabIndex = 5;
            this.AllowToDir.Text = "Предоставить доступ";
            this.AllowToDir.UseVisualStyleBackColor = true;
            // 
            // AddDirBtn
            // 
            this.AddDirBtn.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.AddDirBtn.Location = new System.Drawing.Point(0, 152);
            this.AddDirBtn.Name = "AddDirBtn";
            this.AddDirBtn.Size = new System.Drawing.Size(240, 23);
            this.AddDirBtn.TabIndex = 4;
            this.AddDirBtn.Text = "Создать директорию";
            this.AddDirBtn.UseVisualStyleBackColor = true;
            this.AddDirBtn.Click += new System.EventHandler(this.AddDirBtn_Click);
            // 
            // PublicKeyLabel
            // 
            this.PublicKeyLabel.AutoSize = true;
            this.PublicKeyLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.PublicKeyLabel.Location = new System.Drawing.Point(0, 0);
            this.PublicKeyLabel.Name = "PublicKeyLabel";
            this.PublicKeyLabel.Size = new System.Drawing.Size(94, 13);
            this.PublicKeyLabel.TabIndex = 3;
            this.PublicKeyLabel.Text = "Публичный ключ:";
            // 
            // AllowedLabel
            // 
            this.AllowedLabel.AutoSize = true;
            this.AllowedLabel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.AllowedLabel.Location = new System.Drawing.Point(0, 175);
            this.AllowedLabel.Name = "AllowedLabel";
            this.AllowedLabel.Size = new System.Drawing.Size(140, 13);
            this.AllowedLabel.TabIndex = 1;
            this.AllowedLabel.Text = "Пользователи с доступом";
            // 
            // AllowedToDirList
            // 
            this.AllowedToDirList.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.AllowedToDirList.HideSelection = false;
            this.AllowedToDirList.Location = new System.Drawing.Point(0, 188);
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
            this.dirsPanel.Size = new System.Drawing.Size(560, 285);
            this.dirsPanel.TabIndex = 1;
            // 
            // DirsList
            // 
            this.DirsList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DirsList.FormattingEnabled = true;
            this.DirsList.Location = new System.Drawing.Point(0, 0);
            this.DirsList.Name = "DirsList";
            this.DirsList.Size = new System.Drawing.Size(560, 285);
            this.DirsList.TabIndex = 0;
            this.DirsList.SelectedIndexChanged += new System.EventHandler(this.DirsList_SelectedIndexChanged);
            // 
            // PublicKey
            // 
            this.PublicKey.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PublicKey.Enabled = false;
            this.PublicKey.Location = new System.Drawing.Point(0, 13);
            this.PublicKey.Multiline = true;
            this.PublicKey.Name = "PublicKey";
            this.PublicKey.Size = new System.Drawing.Size(240, 116);
            this.PublicKey.TabIndex = 6;
            // 
            // FSWatcher
            // 
            this.FSWatcher.EnableRaisingEvents = true;
            this.FSWatcher.SynchronizingObject = this;
            this.FSWatcher.Changed += new System.IO.FileSystemEventHandler(this.FSWatcher_Changed);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 285);
            this.Controls.Add(this.dirsPanel);
            this.Controls.Add(this.menuPanel);
            this.Name = "MainForm";
            this.Text = "Sync";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.menuPanel.ResumeLayout(false);
            this.menuPanel.PerformLayout();
            this.dirsPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.FSWatcher)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel menuPanel;
        private System.Windows.Forms.Panel dirsPanel;
        private System.Windows.Forms.ListView AllowedToDirList;
        private System.Windows.Forms.Label PublicKeyLabel;
        private System.Windows.Forms.Label AllowedLabel;
        private System.Windows.Forms.Button AddDirBtn;
        private System.Windows.Forms.Button AllowToDir;
        private System.Windows.Forms.ListBox DirsList;
        private System.Windows.Forms.TextBox PublicKey;
        private System.IO.FileSystemWatcher FSWatcher;
    }
}

