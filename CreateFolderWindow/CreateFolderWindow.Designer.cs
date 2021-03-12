
namespace CreateFolderWindow
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
            this.FBDPath = new System.Windows.Forms.FolderBrowserDialog();
            this.LBPath = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.BCreate = new System.Windows.Forms.Button();
            this.BCancel = new System.Windows.Forms.Button();
            this.BChangePath = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // LBPath
            // 
            this.LBPath.AutoSize = true;
            this.LBPath.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LBPath.Location = new System.Drawing.Point(0, 0);
            this.LBPath.Name = "LBPath";
            this.LBPath.Size = new System.Drawing.Size(0, 13);
            this.LBPath.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.BChangePath);
            this.panel1.Controls.Add(this.BCancel);
            this.panel1.Controls.Add(this.BCreate);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 72);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(435, 42);
            this.panel1.TabIndex = 2;
            // 
            // BCreate
            // 
            this.BCreate.Dock = System.Windows.Forms.DockStyle.Left;
            this.BCreate.Location = new System.Drawing.Point(0, 0);
            this.BCreate.Name = "BCreate";
            this.BCreate.Size = new System.Drawing.Size(122, 42);
            this.BCreate.TabIndex = 0;
            this.BCreate.Text = "Создать";
            this.BCreate.UseVisualStyleBackColor = true;
            this.BCreate.Click += new System.EventHandler(this.BCreate_Click);
            // 
            // BCancel
            // 
            this.BCancel.Dock = System.Windows.Forms.DockStyle.Right;
            this.BCancel.Location = new System.Drawing.Point(313, 0);
            this.BCancel.Name = "BCancel";
            this.BCancel.Size = new System.Drawing.Size(122, 42);
            this.BCancel.TabIndex = 1;
            this.BCancel.Text = "Выход";
            this.BCancel.UseVisualStyleBackColor = true;
            this.BCancel.Click += new System.EventHandler(this.BCancel_Click);
            // 
            // BChangePath
            // 
            this.BChangePath.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BChangePath.Location = new System.Drawing.Point(122, 0);
            this.BChangePath.Name = "BChangePath";
            this.BChangePath.Size = new System.Drawing.Size(191, 42);
            this.BChangePath.TabIndex = 2;
            this.BChangePath.Text = "Указать путь";
            this.BChangePath.UseVisualStyleBackColor = true;
            this.BChangePath.Click += new System.EventHandler(this.BChangePath_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(435, 114);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.LBPath);
            this.Name = "MainForm";
            this.Text = "Введите путь до папки";
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FolderBrowserDialog FBDPath;
        private System.Windows.Forms.Label LBPath;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button BChangePath;
        private System.Windows.Forms.Button BCancel;
        private System.Windows.Forms.Button BCreate;
    }
}

