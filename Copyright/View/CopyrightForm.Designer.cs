using System;

namespace Copyright.View
{
    partial class CopyrightForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.файлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ВходToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.сохранитьКакToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.расширениеФайлаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.txtToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ccppToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.всеФайлыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.button1 = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.файлToolStripMenuItem,
            this.расширениеФайлаToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip";
            // 
            // файлToolStripMenuItem
            // 
            this.файлToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ВходToolStripMenuItem,
            this.сохранитьКакToolStripMenuItem});
            this.файлToolStripMenuItem.Name = "file";
            this.файлToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
            this.файлToolStripMenuItem.Text = "Файл";
            // 
            // входToolStripMenuItem
            // 
            this.ВходToolStripMenuItem.Name = "sourcePath";
            this.ВходToolStripMenuItem.Size = new System.Drawing.Size(129, 22);
            this.ВходToolStripMenuItem.Text = "Вход";
            this.ВходToolStripMenuItem.Click += new System.EventHandler(this.SourcePath_Click);
            // 
            // результатToolStripMenuItem
            // 
            this.сохранитьКакToolStripMenuItem.Name = "finalPath";
            this.сохранитьКакToolStripMenuItem.Size = new System.Drawing.Size(129, 22);
            this.сохранитьКакToolStripMenuItem.Text = "Результат";
            this.сохранитьКакToolStripMenuItem.Click += new System.EventHandler(this.FinalPath_Click);
            // 
            // типФайлаToolStripMenuItem
            // 
            this.расширениеФайлаToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.txtToolStripMenuItem,
            this.ccppToolStripMenuItem,
            this.всеФайлыToolStripMenuItem});
            this.расширениеФайлаToolStripMenuItem.Name = "typeFile";
            this.расширениеФайлаToolStripMenuItem.Size = new System.Drawing.Size(131, 20);
            this.расширениеФайлаToolStripMenuItem.Text = "Тип файла";
            // 
            // txtToolStripMenuItem
            // 
            this.txtToolStripMenuItem.Name = "txtToolStripMenuItem";
            this.txtToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.txtToolStripMenuItem.Text = "(*.txt)";
            this.txtToolStripMenuItem.Click += new System.EventHandler(this.Txt_Click);
            // 
            // ccppToolStripMenuItem
            // 
            this.ccppToolStripMenuItem.Name = "c_cppToolStripMenuItem";
            this.ccppToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.ccppToolStripMenuItem.Text = "(*.c;*.cpp)";
            this.ccppToolStripMenuItem.Click += new System.EventHandler(this.C_cpp_Click);
            // 
            // всеФайлыToolStripMenuItem
            // 
            this.всеФайлыToolStripMenuItem.Name = "allFileToolStripMenuItem";
            this.всеФайлыToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.всеФайлыToolStripMenuItem.Text = "(*.*)";
            this.всеФайлыToolStripMenuItem.Click += new System.EventHandler(this.AllFile_Click);
            // 
            // richTextBox
            // 
            this.richTextBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBox1.Location = new System.Drawing.Point(0, 24);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(800, 426);
            this.richTextBox1.TabIndex = 1;
            this.richTextBox1.Text = "";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(297, 0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "Обработка";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Processed_Click);
            // 
            // Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            //this.ClientSize = new System.Drawing.Size(800, 450);
            this.ClientSize = new System.Drawing.Size(400, 250);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form";
            this.Text = "Copyright";
            //this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem файлToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ВходToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem сохранитьКакToolStripMenuItem;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.ToolStripMenuItem расширениеФайлаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem txtToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ccppToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem всеФайлыToolStripMenuItem;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Button button1;
    }
}