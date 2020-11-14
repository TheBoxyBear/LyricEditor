using System;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace LyricEditor
{
    partial class frmEditor
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.ToolStripSeparator fileMenu_ExitSeperator;
            this.menu = new System.Windows.Forms.MenuStrip();
            this.fileMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.fileMenu_Open = new System.Windows.Forms.ToolStripMenuItem();
            this.fileMenu_Reload = new System.Windows.Forms.ToolStripMenuItem();
            this.fileMenu_Save = new System.Windows.Forms.ToolStripMenuItem();
            this.fileMenu_SaveAs = new System.Windows.Forms.ToolStripMenuItem();
            this.fileMenu_Exit = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsMenu_DarkMode = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.helpMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.rtxtLyrics = new System.Windows.Forms.RichTextBox();
            fileMenu_ExitSeperator = new System.Windows.Forms.ToolStripSeparator();
            this.menu.SuspendLayout();
            this.SuspendLayout();
            // 
            // fileMenu_ExitSeperator
            // 
            fileMenu_ExitSeperator.Name = "fileMenu_ExitSeperator";
            fileMenu_ExitSeperator.Size = new System.Drawing.Size(183, 6);
            // 
            // menu
            // 
            this.menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileMenu,
            this.optionsMenu,
            this.aboutMenu,
            this.helpMenu});
            this.menu.Location = new System.Drawing.Point(0, 0);
            this.menu.Name = "menu";
            this.menu.Size = new System.Drawing.Size(800, 24);
            this.menu.TabIndex = 1;
            this.menu.Text = "menuStrip1";
            // 
            // fileMenu
            // 
            this.fileMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileMenu_Open,
            this.fileMenu_Reload,
            this.fileMenu_Save,
            this.fileMenu_SaveAs,
            fileMenu_ExitSeperator,
            this.fileMenu_Exit});
            this.fileMenu.Name = "fileMenu";
            this.fileMenu.Size = new System.Drawing.Size(37, 20);
            this.fileMenu.Text = "File";
            // 
            // fileMenu_Open
            // 
            this.fileMenu_Open.Name = "fileMenu_Open";
            this.fileMenu_Open.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.fileMenu_Open.Size = new System.Drawing.Size(186, 22);
            this.fileMenu_Open.Text = "Open";
            // 
            // fileMenu_Reload
            // 
            this.fileMenu_Reload.Enabled = false;
            this.fileMenu_Reload.Name = "fileMenu_Reload";
            this.fileMenu_Reload.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.R)));
            this.fileMenu_Reload.Size = new System.Drawing.Size(186, 22);
            this.fileMenu_Reload.Text = "Reload";
            // 
            // fileMenu_Save
            // 
            this.fileMenu_Save.Enabled = false;
            this.fileMenu_Save.Name = "fileMenu_Save";
            this.fileMenu_Save.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.fileMenu_Save.Size = new System.Drawing.Size(186, 22);
            this.fileMenu_Save.Text = "Save";
            // 
            // fileMenu_SaveAs
            // 
            this.fileMenu_SaveAs.Enabled = false;
            this.fileMenu_SaveAs.Name = "fileMenu_SaveAs";
            this.fileMenu_SaveAs.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.S)));
            this.fileMenu_SaveAs.Size = new System.Drawing.Size(186, 22);
            this.fileMenu_SaveAs.Text = "Save As";
            // 
            // fileMenu_Exit
            // 
            this.fileMenu_Exit.Name = "fileMenu_Exit";
            this.fileMenu_Exit.Size = new System.Drawing.Size(186, 22);
            this.fileMenu_Exit.Text = "Exit";
            // 
            // optionsMenu
            // 
            this.optionsMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.optionsMenu_DarkMode});
            this.optionsMenu.Name = "optionsMenu";
            this.optionsMenu.Size = new System.Drawing.Size(61, 20);
            this.optionsMenu.Text = "Options";
            // 
            // optionsMenu_DarkMode
            // 
            this.optionsMenu_DarkMode.CheckOnClick = true;
            this.optionsMenu_DarkMode.Name = "optionsMenu_DarkMode";
            this.optionsMenu_DarkMode.Size = new System.Drawing.Size(132, 22);
            this.optionsMenu_DarkMode.Text = "Dark mode";
            // 
            // aboutMenu
            // 
            this.aboutMenu.Name = "aboutMenu";
            this.aboutMenu.Size = new System.Drawing.Size(52, 20);
            this.aboutMenu.Text = "About";
            // 
            // helpMenu
            // 
            this.helpMenu.Name = "helpMenu";
            this.helpMenu.Size = new System.Drawing.Size(44, 20);
            this.helpMenu.Text = "Help";
            // 
            // rtxtLyrics
            // 
            this.rtxtLyrics.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtxtLyrics.Location = new System.Drawing.Point(0, 24);
            this.rtxtLyrics.Name = "rtxtLyrics";
            this.rtxtLyrics.Size = new System.Drawing.Size(800, 426);
            this.rtxtLyrics.TabIndex = 2;
            this.rtxtLyrics.Text = "";
            this.rtxtLyrics.WordWrap = false;
            // 
            // frmEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.rtxtLyrics);
            this.Controls.Add(this.menu);
            this.MainMenuStrip = this.menu;
            this.Name = "frmEditor";
            this.Text = "defaultTitle";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmEditor_FormClosing);
            this.menu.ResumeLayout(false);
            this.menu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menu;
        private System.Windows.Forms.ToolStripMenuItem fileMenu;
        private System.Windows.Forms.ToolStripMenuItem fileMenu_Open;
        private System.Windows.Forms.RichTextBox rtxtLyrics;
        private ToolStripMenuItem fileMenu_Exit;
        private ToolStripMenuItem fileMenu_Save;
        private ToolStripMenuItem fileMenu_SaveAs;
        private ToolStripMenuItem aboutMenu;
        private ToolStripMenuItem fileMenu_Reload;
        private ToolStripMenuItem helpMenu;
        private ToolStripMenuItem optionsMenu;
        private ToolStripMenuItem optionsMenu_DarkMode;
    }
}

