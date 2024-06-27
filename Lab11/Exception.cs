using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    public class WrongNameException : Exception
    {
        public WrongNameException() : base() { }
        public WrongNameException(string message) : base(message) { }
        public WrongNameException(string message, Exception innerException) : base(message, innerException) { }
    }

    public class WrongIdException : Exception
    {
        public WrongIdException() : base() { }
        public WrongIdException(string message) : base(message) { }
        public WrongIdException(string message, Exception innerException) : base(message, innerException) { }
    }

    public class WrongTypeException : Exception
    {
        public WrongTypeException() : base() { }
        public WrongTypeException(string message) : base(message) { }
        public WrongTypeException(string message, Exception innerException) : base(message, innerException) { }

    }

    public class NotUniqueID : Exception
    {
        public NotUniqueID() : base() { }
        public NotUniqueID(string message) : base(message) { }
        public NotUniqueID(string message, Exception innerException) : base(message, innerException) { }
    }

    public class MultuipleEdit : Exception
    {
        public MultuipleEdit() : base() { }
        public MultuipleEdit(string message) : base(message) { }
        public MultuipleEdit(string message, Exception innerException) : base(message, innerException) { }
    }
}
//this.listView1.FullRowSelect = true;
//this.listView1.Columns.Add("N", 30);
//this.listView1.Columns.Add("ID", 30);
//this.listView1.Columns.Add("Name", 300);
//ContextMenuStrip contextMenuStrip = new ContextMenuStrip();
//ToolStripMenuItem addMenuItem = new ToolStripMenuItem("add");
//ToolStripMenuItem removeMenuItem = new ToolStripMenuItem("remove");
//ToolStripMenuItem editMenuItem = new ToolStripMenuItem("edit");
//ToolStripMenuItem showMenuItem = new ToolStripMenuItem("show");
//contextMenuStrip.Items.AddRange(new[] { addMenuItem, removeMenuItem, editMenuItem, showMenuItem });
//listView1.ContextMenuStrip = contextMenuStrip;