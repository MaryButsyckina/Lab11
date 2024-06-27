namespace Lab11
{
    partial class Form1
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
            this.menuStrip2 = new System.Windows.Forms.MenuStrip();
            this.addItemToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeItemToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.changeItemToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listView1 = new System.Windows.Forms.ListView();
            this.menuStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip2
            // 
            this.menuStrip2.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addItemToolStripMenuItem,
            this.removeItemToolStripMenuItem,
            this.changeItemToolStripMenuItem,
            this.showToolStripMenuItem,
            this.aboutToolStripMenuItem,});
            this.menuStrip2.Location = new System.Drawing.Point(0, 0);
            this.menuStrip2.Name = "menuStrip2";
            this.menuStrip2.Size = new System.Drawing.Size(800, 28);
            this.menuStrip2.TabIndex = 1;
            this.menuStrip2.Text = "menuStrip2";
            // 
            // addItemToolStripMenuItem
            // 
            this.addItemToolStripMenuItem.Name = "addItemToolStripMenuItem";
            this.addItemToolStripMenuItem.Size = new System.Drawing.Size(85, 24);
            this.addItemToolStripMenuItem.Text = "Add item";
            this.addItemToolStripMenuItem.Click += new System.EventHandler(this.addItemToolStripMenuItem_Click);
            // 
            // removeItemToolStripMenuItem
            // 
            this.removeItemToolStripMenuItem.Name = "removeItemToolStripMenuItem";
            this.removeItemToolStripMenuItem.Size = new System.Drawing.Size(111, 24);
            this.removeItemToolStripMenuItem.Text = "Remove item";
            this.removeItemToolStripMenuItem.Click += new System.EventHandler(this.removeItemToolStripMenuItem_Click);
            // 
            // changeItemToolStripMenuItem
            // 
            this.changeItemToolStripMenuItem.Name = "changeItemToolStripMenuItem";
            this.changeItemToolStripMenuItem.Size = new System.Drawing.Size(107, 24);
            this.changeItemToolStripMenuItem.Text = "Edit item";
            this.changeItemToolStripMenuItem.Click += new System.EventHandler(this.editItemToolStripMenuItem_Click);
            // 
            // showToolStripMenuItem
            // 
            this.showToolStripMenuItem.Name = "showToolStripMenuItem";
            this.showToolStripMenuItem.Size = new System.Drawing.Size(54, 24);
            this.showToolStripMenuItem.Text = "Show";
            this.showToolStripMenuItem.Click += new System.EventHandler(this.showItemToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(64, 24);
            this.aboutToolStripMenuItem.Text = "Help";
            this.aboutToolStripMenuItem.DropDownItems.Add("Add item");
            this.aboutToolStripMenuItem.DropDownItems.Add("Remove item");
            this.aboutToolStripMenuItem.DropDownItems.Add("Edit item");
            this.aboutToolStripMenuItem.DropDownItems.Add("Show");
            this.aboutToolStripMenuItem.DropDownItems.Add("About");
            this.aboutToolStripMenuItem.DropDownItems[0].Click += addInfoItemToolStripMenuItem_Click;
            this.aboutToolStripMenuItem.DropDownItems[1].Click += removeInfoItemToolStripMenuItem_Click;
            this.aboutToolStripMenuItem.DropDownItems[2].Click += editInfoItemToolStripMenuItem_Click;
            this.aboutToolStripMenuItem.DropDownItems[3].Click += showInfoItemToolStripMenuItem_Click;
            this.aboutToolStripMenuItem.DropDownItems[4].Click += aboutItemToolStripMenuItem_Click;
            // 
            // listView1
            // 
            this.listView1.FullRowSelect = true;
            this.listView1.Location = new System.Drawing.Point(0, 31);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(788, 420);
            this.listView1.TabIndex = 2;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.FullRowSelect = true;
            this.listView1.Columns.Add("N", 30);
            this.listView1.Columns.Add("ID", 30);
            this.listView1.Columns.Add("Name", 300);
            ContextMenuStrip contextMenuStrip = new ContextMenuStrip();
            ToolStripMenuItem addMenuItem = new ToolStripMenuItem("add");
            ToolStripMenuItem removeMenuItem = new ToolStripMenuItem("remove");
            ToolStripMenuItem editMenuItem = new ToolStripMenuItem("edit");
            ToolStripMenuItem showMenuItem = new ToolStripMenuItem("show");
            contextMenuStrip.Items.AddRange(new[] { addMenuItem, removeMenuItem, editMenuItem, showMenuItem });
            listView1.ContextMenuStrip = contextMenuStrip;

            addMenuItem.Click += addItemToolStripMenuItem_Click;
            removeMenuItem.Click += removeItemToolStripMenuItem_Click;
            editMenuItem.Click += editItemToolStripMenuItem_Click;
            showMenuItem.Click += showItemToolStripMenuItem_Click;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.menuStrip2);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Form1";
            this.menuStrip2.ResumeLayout(false);
            this.menuStrip2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private MenuStrip menuStrip2;
        private ToolStripMenuItem addItemToolStripMenuItem;
        private ToolStripMenuItem removeItemToolStripMenuItem;
        private ToolStripMenuItem changeItemToolStripMenuItem;
        private ToolStripMenuItem aboutToolStripMenuItem;
        private ToolStripMenuItem showToolStripMenuItem;
        private ListView listView1;
        private System.Windows.Forms.ListView listView2 = new System.Windows.Forms.ListView();
    }
}