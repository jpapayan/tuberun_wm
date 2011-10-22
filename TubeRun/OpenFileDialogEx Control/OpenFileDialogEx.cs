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

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Runtime.InteropServices;

namespace MobilePractices.OpenFileDialogEx
{
	/// <summary>
	/// This is a custom implementation of OpenFileDialog
	/// allowing the user to browse the full filesystem.
	/// </summary>
	public partial class OpenFileDialogEx : Form
	{
		// Some constants here
		const string ROOT = "\\";
		const string GOBACK = "..";

		// state
		private string currentPath = ROOT;
		private bool updating = false;
        // configuration
		private string filter = string.Empty;
		private string fileName = string.Empty;
        private string initialDirectory = ROOT;
        // helpers
        private ShellIconCache shellIconCache;
        private BackKeyHandler backKeyHandler;
       
		// Only the basic constructor is implemented
		// Feel free to implement your own overrides
		public OpenFileDialogEx()
		{
			InitializeComponent();

            shellIconCache = new ShellIconCache(FileSystemIcons);
		}

		protected override void OnLoad(EventArgs e)
		{
			base.OnLoad(e);

            // Hide some of the UI elements when we are
            // running on a Smartphone device.
            if (Platform.IsWindowsMobileStandard)
            {
                // Smart phone
                BottomPanel.Visible = false;
                PathSelectorComboBox.Visible = false;

                // Remove the cancel option from the right
                // soft key popup menu
                softKey2Menu.MenuItems.Remove(menuItemCancel);
            }
            else
            {
                // Pocket PC
                BottomPanel.Visible = true;
                PathSelectorComboBox.Visible = true;

                // Replace the right soft key with a
                // Cancel menu item.
                mainMenu1.MenuItems.Remove(softKey2Menu);
                mainMenu1.MenuItems.Add(menuItemCancel);
            }

            // Update the controls
			ChangeDirectory(initialDirectory);
		}

        /// <summary>
        /// Sets/Gets the directory initially viewed
        /// when the Open File dialog is displayed.
        /// </summary>
        public string InitialDirectory
        {
            get { return initialDirectory; }
            set { initialDirectory = value; }
        }

		/// <summary>
		/// Sets/Gets the file search pattern. 
		/// You can use values like "*.*" or "*.txt"
		/// </summary>
		public string Filter
		{
			set { filter = value; }
			get { return filter; }
		}

		/// <summary>
		/// Sets/Gets the selected file name to open.
		/// This is the full path.
		/// </summary>
		public string FileName
		{
			set { fileName = value; }
			get { return fileName; }
		}

		// Refill the Combo box and Menu with the path
		// step by step
		private void UpdateSelector()
		{
            // Remove the existing menu items and combo
            // box entries
            softKey2Menu.MenuItems.Clear();
            PathSelectorComboBox.Items.Clear();

			// Split directories
			string[] pathParts = (currentPath == ROOT ? string.Empty : currentPath).Split(Path.DirectorySeparatorChar);

			// Build new items
			MenuItemWithTag<string> newItem;
			string partialPath = string.Empty;
			foreach (string part in pathParts)
			{
				newItem = new MenuItemWithTag<string>();
				if (part == string.Empty)
					newItem.Text = "\\";
				else
					newItem.Text = part;
				newItem.Click += new EventHandler(pathStepMenuItemClicked);
				partialPath = Path.Combine(partialPath, newItem.Text);

                newItem.Tag = partialPath;
   
    			softKey2Menu.MenuItems.Add(newItem);
                PathSelectorComboBox.Items.Add(newItem.Text);
			}

            // Disable the "Up" softkey (and back key) if
            // we are in the root directory.
            menuItem1.Enabled = (softKey2Menu.MenuItems.Count > 1);

            // Select the current item in the combo box
            PathSelectorComboBox.SelectedIndex = pathParts.Length - 1;
		}

        // Sort by filename in ascending order
        private int SortByNameAsc(string entry1, string entry2)
        {
            return entry1.CompareTo(entry2);
        }

        // Sort by file extension then name in ascending order
        private int SortByExtensionAsc(string entry1, string entry2)
        {
            string extension1 = Path.GetExtension(entry1);
            string extension2 = Path.GetExtension(entry2);

            int order = extension1.CompareTo(extension2);
            if (order == 0)
                order = SortByNameAsc(entry1, entry2);

            return order;
        }

        private string[] OrderEnteries(string[] enteries)
        {
            Array.Sort(enteries, SortByNameAsc);
            return enteries;
        }

		// Refill the file list
		private void UpdateList()
		{
			fileListView.SuspendLayout();

			// 1) Clear the list and normalize the current path
			fileListView.Items.Clear();

			if (currentPath == string.Empty)
				currentPath = ROOT;

			// 2) Add 'Back' if needed
			if (currentPath != ROOT && !Platform.IsWindowsMobileStandard)
			{
				ListViewItem item = new ListViewItem(GOBACK);
                item.ImageIndex = 0;
                item.Tag = Path.GetDirectoryName(currentPath);
				fileListView.Items.Add(item);
			}

			// 3) Add directories and/or Storage Cards
			foreach (string entry in OrderEnteries(Directory.GetDirectories(currentPath)))
			{
				ListViewItem item = new ListViewItem(Path.GetFileName(entry));
                item.ImageIndex = shellIconCache[entry];
                item.Tag = entry;
				fileListView.Items.Add(item);
			}

			// 4) Add Files using filter search pattern
			foreach (string entry in OrderEnteries(Directory.GetFiles(currentPath, filter)))
			{
				ListViewItem item = new ListViewItem(Path.GetFileName(entry));
                item.ImageIndex = shellIconCache[entry];
                item.Tag = entry;
				fileListView.Items.Add(item);
			}

			this.ResumeLayout();
		}

		//When the user activates an item
		//we can browse the directory or open the file....
		private void fileListView_ItemActivate(object sender, EventArgs e)
		{
			ListView list = sender as ListView;

			//We'll continue only if there is a selected item
			if (list != null && list.SelectedIndices.Count > 0)
			{
				ListViewItem currentItem = list.Items[list.SelectedIndices[0]];

				//If it's not a file we should change the current path
                if (Directory.Exists((string)currentItem.Tag))
				{
					ChangeDirectory((string)currentItem.Tag);
				}
				else
				{
					//If it's a file, we should return the selected filename
                    fileName = (string)currentItem.Tag;
					EndOk();
				}
			}
		}

		// We can change the current path using the Menu
		void pathStepMenuItemClicked(object sender, EventArgs e)
		{
			MenuItemWithTag<string> menuItem = sender as MenuItemWithTag<string>;
			if (menuItem != null)
			{
				//Only do this if the view is not being updated
				if (!updating)
				{
					//1) Change to the new directory
					ChangeDirectory(menuItem.Tag);
				}
			}
		}

		//Update the dialog!
		private void ChangeDirectory(string newPath)
		{
            currentPath = newPath;

            // TODO - find a better place for this..
            if (backKeyHandler != null)
                backKeyHandler.Dispose();
            backKeyHandler = new BackKeyHandler();
            backKeyHandler.BackKeyPress += new EventHandler(BackKeyPress);

			if (updating)
                return;

			updating = true;
			try
			{
				Cursor.Current = Cursors.WaitCursor;
				UpdateList();
				UpdateSelector();
			}
			finally
			{
				updating = false;
				Cursor.Current = Cursors.Default;
			}
		}


		//Returns OK
		private void EndOk()
		{
			DialogResult = DialogResult.OK;
			this.Close();
		}

		//UP
		//Go to the parent folder by softkey1
        private void menuItem1_Click(object sender, EventArgs e)
        {
            MenuItemWithTag<string> menuItem = (MenuItemWithTag<string>)softKey2Menu.MenuItems[softKey2Menu.MenuItems.Count - 2];
            ChangeDirectory(menuItem.Tag);
        }

        private void BackKeyPress(object sender, EventArgs e)
        {
            if (menuItem1.Enabled)
            {
                // Determine the path to the parent directory
                // and update the dialog
                MenuItemWithTag<string> mnu = (MenuItemWithTag<string>)softKey2Menu.MenuItems[softKey2Menu.MenuItems.Count - 2];
                ChangeDirectory(mnu.Tag);
            }
            else
            {
                // Cancel the dialog
                DialogResult = DialogResult.Cancel;
                this.Close();
            }
        }

		//CANCEL
		//Cancel by menu
		private void menuItemCancel_Click(object sender, EventArgs e)
		{
			DialogResult = DialogResult.Cancel;
			this.Close();
		}

        // We can change the current path using the PathSelectorComboBox
        private void PathSelectorComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Only do this if the view is not being updated
            if (!updating)
            {
                //1) Build the new path
                currentPath = string.Empty;
                for (int i = 0; i <= (sender as ComboBox).SelectedIndex; i++)
                {
                    currentPath = Path.Combine(currentPath, PathSelectorComboBox.Items[i].ToString());
                }

                //2) Update the dialog!
                ChangeDirectory(currentPath);
            }
        }

        //We shoud react when the user press ENTER
        private void FilenameTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            //When the user press ENTER it could be:
            // 1. Entering the filename to be attached to the current path
            // 2. Entering a new full path (starting with '\' )
            // In both cases it can be a file or a directory, if it's a directory
            // we need to stay on the dialog but showing that directory

            // This is a risky code because we cannot be sure that the user has entered
            // a valid path. Try / Catch for any problem with that.
            if (e.KeyChar == '\r')
            {
                try
                {
                    string tempPath = FilenameTextBox.Text.Trim(); //Clear white-spaces

                    if (!tempPath.StartsWith("\\"))
                    {
                        tempPath = Path.Combine(currentPath, tempPath);
                    }

                    //Check whether is a file or a directory
                    if (Directory.Exists(tempPath))
                    {
                        //if it's a directory/storagecard
                        //try to change the current path
                        FilenameTextBox.Text = "";
                        ChangeDirectory(tempPath);
                    }
                    else if (File.Exists(tempPath))
                    {
                        //if it's a file, set the filename and return ok!
                        fileName = tempPath;
                        EndOk();
                    }
                }
                catch
                { }
            }
        }
	}
}