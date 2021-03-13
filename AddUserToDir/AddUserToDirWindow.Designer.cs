
namespace AddUserToDir
{
    partial class AddUserToDirWindow
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
            this.PTools = new System.Windows.Forms.Panel();
            this.BClose = new System.Windows.Forms.Button();
            this.BAdd = new System.Windows.Forms.Button();
            this.LPublicKey = new System.Windows.Forms.Label();
            this.TBPublicKey = new System.Windows.Forms.TextBox();
            this.PTools.SuspendLayout();
            this.SuspendLayout();
            // 
            // PTools
            // 
            this.PTools.Controls.Add(this.BClose);
            this.PTools.Controls.Add(this.BAdd);
            this.PTools.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.PTools.Location = new System.Drawing.Point(0, 243);
            this.PTools.Name = "PTools";
            this.PTools.Size = new System.Drawing.Size(534, 72);
            this.PTools.TabIndex = 0;
            // 
            // BClose
            // 
            this.BClose.Dock = System.Windows.Forms.DockStyle.Right;
            this.BClose.Location = new System.Drawing.Point(280, 0);
            this.BClose.Name = "BClose";
            this.BClose.Size = new System.Drawing.Size(254, 72);
            this.BClose.TabIndex = 1;
            this.BClose.Text = "Отмена";
            this.BClose.UseVisualStyleBackColor = true;
            this.BClose.Click += new System.EventHandler(this.BClose_Click);
            // 
            // BAdd
            // 
            this.BAdd.Dock = System.Windows.Forms.DockStyle.Left;
            this.BAdd.Location = new System.Drawing.Point(0, 0);
            this.BAdd.Name = "BAdd";
            this.BAdd.Size = new System.Drawing.Size(263, 72);
            this.BAdd.TabIndex = 0;
            this.BAdd.Text = "Добавить";
            this.BAdd.UseVisualStyleBackColor = true;
            this.BAdd.Click += new System.EventHandler(this.BAdd_Click);
            // 
            // LPublicKey
            // 
            this.LPublicKey.AutoSize = true;
            this.LPublicKey.Dock = System.Windows.Forms.DockStyle.Top;
            this.LPublicKey.Location = new System.Drawing.Point(0, 0);
            this.LPublicKey.Name = "LPublicKey";
            this.LPublicKey.Size = new System.Drawing.Size(94, 13);
            this.LPublicKey.TabIndex = 1;
            this.LPublicKey.Text = "Публичный ключ:";
            // 
            // TBPublicKey
            // 
            this.TBPublicKey.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TBPublicKey.Location = new System.Drawing.Point(0, 13);
            this.TBPublicKey.Multiline = true;
            this.TBPublicKey.Name = "TBPublicKey";
            this.TBPublicKey.Size = new System.Drawing.Size(534, 230);
            this.TBPublicKey.TabIndex = 2;
            this.TBPublicKey.TextChanged += new System.EventHandler(this.TBPublicKey_TextChanged);
            // 
            // AddUserToDirWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(534, 315);
            this.Controls.Add(this.TBPublicKey);
            this.Controls.Add(this.LPublicKey);
            this.Controls.Add(this.PTools);
            this.Name = "AddUserToDirWindow";
            this.Text = "Добавить пользователя к директории";
            this.PTools.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel PTools;
        private System.Windows.Forms.Button BClose;
        private System.Windows.Forms.Button BAdd;
        private System.Windows.Forms.Label LPublicKey;
        private System.Windows.Forms.TextBox TBPublicKey;
    }
}

