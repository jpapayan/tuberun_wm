//-----------------------------------------------------------------------
// 
//  Copyright (C) MOBILE PRACTICES.  All rights reserved.
//  http://www.mobilepractices.com/
//
// THIS CODE AND INFORMATION ARE PROVIDED AS IS WITHOUT WARRANTY OF ANY
// KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE
// IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
// PARTICULAR PURPOSE.
//-----------------------------------------------------------------------

namespace MobilePractices.OpenFileDialogEx
{
    partial class OpenFileDialogEx
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.MainMenu mainMenu1;

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OpenFileDialogEx));
            this.mainMenu1 = new System.Windows.Forms.MainMenu();
            this.menuItem1 = new System.Windows.Forms.MenuItem();
            this.softKey2Menu = new System.Windows.Forms.MenuItem();
            this.menuItemCancel = new System.Windows.Forms.MenuItem();
            this.fileListView = new System.Windows.Forms.ListView();
            this.FileSystemIcons = new System.Windows.Forms.ImageList();
            this.PathSelectorComboBox = new System.Windows.Forms.ComboBox();
            this.BottomPanel = new System.Windows.Forms.Panel();
            this.FilenameTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.BottomPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainMenu1
            // 
            this.mainMenu1.MenuItems.Add(this.menuItem1);
            this.mainMenu1.MenuItems.Add(this.softKey2Menu);
            // 
            // menuItem1
            // 
            this.menuItem1.Text = "Up";
            this.menuItem1.Click += new System.EventHandler(this.menuItem1_Click);
            // 
            // softKey2Menu
            // 
            this.softKey2Menu.MenuItems.Add(this.menuItemCancel);
            this.softKey2Menu.Text = "Menu";
            // 
            // menuItemCancel
            // 
            this.menuItemCancel.Text = "Cancel";
            this.menuItemCancel.Click += new System.EventHandler(this.menuItemCancel_Click);
            // 
            // fileListView
            // 
            this.fileListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fileListView.Location = new System.Drawing.Point(0, 22);
            this.fileListView.Name = "fileListView";
            this.fileListView.Size = new System.Drawing.Size(240, 206);
            this.fileListView.SmallImageList = this.FileSystemIcons;
            this.fileListView.TabIndex = 4;
            this.fileListView.View = System.Windows.Forms.View.SmallIcon;
            this.fileListView.ItemActivate += new System.EventHandler(this.fileListView_ItemActivate);
            // 
            // FileSystemIcons
            // 
            this.FileSystemIcons.ImageSize = new System.Drawing.Size(32, 32);
            this.FileSystemIcons.Images.Clear();
            this.FileSystemIcons.Images.Add(((System.Drawing.Image)(resources.GetObject("resource"))));
            // 
            // PathSelectorComboBox
            // 
            this.PathSelectorComboBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.PathSelectorComboBox.Location = new System.Drawing.Point(0, 0);
            this.PathSelectorComboBox.Name = "PathSelectorComboBox";
            this.PathSelectorComboBox.Size = new System.Drawing.Size(240, 22);
            this.PathSelectorComboBox.TabIndex = 5;
            this.PathSelectorComboBox.SelectedIndexChanged += new System.EventHandler(this.PathSelectorComboBox_SelectedIndexChanged);
            // 
            // BottomPanel
            // 
            this.BottomPanel.Controls.Add(this.FilenameTextBox);
            this.BottomPanel.Controls.Add(this.label1);
            this.BottomPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.BottomPanel.Location = new System.Drawing.Point(0, 228);
            this.BottomPanel.Name = "BottomPanel";
            this.BottomPanel.Size = new System.Drawing.Size(240, 40);
            // 
            // FilenameTextBox
            // 
            this.FilenameTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.FilenameTextBox.Location = new System.Drawing.Point(0, 19);
            this.FilenameTextBox.Name = "FilenameTextBox";
            this.FilenameTextBox.Size = new System.Drawing.Size(240, 21);
            this.FilenameTextBox.TabIndex = 1;
            this.FilenameTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.FilenameTextBox_KeyPress);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(0, 2);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(240, 16);
            this.label1.Text = "Filename:";
            // 
            // OpenFileDialogEx
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(240, 268);
            this.ControlBox = false;
            this.Controls.Add(this.fileListView);
            this.Controls.Add(this.BottomPanel);
            this.Controls.Add(this.PathSelectorComboBox);
            this.KeyPreview = true;
            this.Menu = this.mainMenu1;
            this.MinimizeBox = false;
            this.Name = "OpenFileDialogEx";
            this.Text = "OpenFileDialogEx";
            this.BottomPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

		private System.Windows.Forms.ListView fileListView;
		private System.Windows.Forms.ImageList FileSystemIcons;
		private System.Windows.Forms.MenuItem menuItem1;
		private System.Windows.Forms.MenuItem softKey2Menu;
		private System.Windows.Forms.MenuItem menuItemCancel;
        private System.Windows.Forms.ComboBox PathSelectorComboBox;
        private System.Windows.Forms.Panel BottomPanel;
        private System.Windows.Forms.TextBox FilenameTextBox;
        private System.Windows.Forms.Label label1;
    }
}