using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace MobilePractices.OpenFileDialogEx
{
    // This is a normal menu item except it has a Tag property that
    // allows us to associate arbitrary data with the menu item.
    internal class MenuItemWithTag<T> : MenuItem
    {
        private T tag;

        public T Tag
        {
            get { return tag; }
            set { tag = value; }
        }
    }
}
