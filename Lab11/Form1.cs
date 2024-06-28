using Lab1;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Forms;
using System.Text.Json;

namespace Lab11
{
    public partial class Form1 : Form
    {
        private Dictionary<int, Furniture> furniture = new Dictionary<int, Furniture>();
        private int furn_counter = 0;
        private List<Detail> equipment = new List<Detail>();

        Thread thread;
        CancellationTokenSource ct;

        bool dispose_fl = false;

        private TCPclient client;

        public Form1()
        {
            InitializeComponent();

            client = new TCPclient();
            thread = new Thread(client_worker);
            ct = new CancellationTokenSource();
            ct.Cancel();
            thread.Start();
        }

        private void addItemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            furn_counter++;
            furniture.Add(furn_counter, new Furniture(furn_counter));

            ListViewItem it = new ListViewItem(furn_counter.ToString());
            it.SubItems.Add(furniture[furn_counter].GetId().ToString());
            it.SubItems.Add(furniture[furn_counter].GetName());
            listView1.Items.Add(it);
        }
        private void removeItemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem i in listView1.SelectedItems)
            {
                listView1.Items.RemoveAt(i.Index);
                int id = Int32.Parse(i.SubItems[1].Text);
                furniture.Remove(id);
            }
        }
        private void editItemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 0)
            {
                MessageBox.Show("Select one item", "No selected items", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (listView1.SelectedItems.Count > 1)
            {
                MessageBox.Show("Select one item", "Several items selected", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                int selected = Int32.Parse(listView1.SelectedItems[0].Text);
                Form dlg = new Form();
                dlg.Text = "Edit item";
                dlg.Size = new Size(300, 500);

                Label label_name = new Label();
                label_name.Text = "Name: ";
                label_name.Bounds = new Rectangle(new Point(0, 0), new Size(60, 30));
                dlg.Controls.Add(label_name);

                Label label_id = new Label();
                label_id.Text = "ID: ";
                label_id.Bounds = new Rectangle(new Point(0, 30), new Size(60, 30));
                dlg.Controls.Add(label_id);

                Label label_type = new Label();
                label_type.Text = "Type: ";
                label_type.Bounds = new Rectangle(new Point(0, 60), new Size(60, 30));
                dlg.Controls.Add(label_type);

                System.Windows.Forms.TextBox tb_name = new System.Windows.Forms.TextBox();
                tb_name.Text = furniture[selected].GetName();
                tb_name.Bounds = new Rectangle(new Point(60, 0), new Size(200, 30));
                dlg.Controls.Add(tb_name);

                System.Windows.Forms.TextBox tb_id = new System.Windows.Forms.TextBox();
                tb_id.Text = furniture[selected].GetId().ToString();
                tb_id.TextChanged += idTextBoxChanged;
                tb_id.Bounds = new Rectangle(new Point(60, 30), new Size(200, 30));
                dlg.Controls.Add(tb_id);

                System.Windows.Forms.TextBox tb_type = new System.Windows.Forms.TextBox();
                tb_type.Text = furniture[selected].GetProductType();
                tb_type.Bounds = new Rectangle(new Point(60, 60), new Size(200, 30));
                dlg.Controls.Add(tb_type);

                Label label_eq = new Label();
                label_eq.Text = "Equipment: ";
                label_eq.Bounds = new Rectangle(new Point(0, 90), new Size(150, 30));
                dlg.Controls.Add(label_eq);

                listView2.Items.Clear();
                listView2.Bounds = new Rectangle(new Point(10, 120), new Size(200, 200));
                foreach (Detail dd in furniture[selected].GetEquipment()) 
                { listView2.Items.Add(dd.GetName()); }
                dlg.Controls.Add(listView2);

                Label label_id_eq = new Label();
                label_id_eq.Text = "ID";
                label_id_eq.Bounds = new Rectangle(new Point(0, 330), new Size(30, 30));
                dlg.Controls.Add(label_id_eq);

                System.Windows.Forms.TextBox tb_id_eq = new System.Windows.Forms.TextBox();
                tb_id_eq.Bounds = new Rectangle(new Point(0, 360), new Size(30, 30));
                dlg.Controls.Add(tb_id_eq);

                Label label_name_eq = new Label();
                label_name_eq.Text = "Name";
                label_name_eq.Bounds = new Rectangle(new Point(30, 330), new Size(100, 30));
                dlg.Controls.Add(label_name_eq);

                System.Windows.Forms.TextBox tb_name_eq = new System.Windows.Forms.TextBox();
                tb_name_eq.Bounds = new Rectangle(new Point(30, 360), new Size(100, 30));
                dlg.Controls.Add(tb_name_eq);

                Label label_type_eq = new Label();
                label_type_eq.Text = "Type";
                label_type_eq.Bounds = new Rectangle(new Point(130, 330), new Size(100, 30));
                dlg.Controls.Add(label_type_eq);

                System.Windows.Forms.TextBox tb_type_eq = new System.Windows.Forms.TextBox();
                tb_type_eq.Bounds = new Rectangle(new Point(130, 360), new Size(100, 30));
                dlg.Controls.Add(tb_type_eq);

                System.Windows.Forms.Button bt_equip = new System.Windows.Forms.Button();
                bt_equip.Text = "Add equipment";
                bt_equip.Bounds = new Rectangle(new Point(0, 390), new Size(150, 30));
                bt_equip.Tag = new List<System.Windows.Forms.TextBox>() { tb_id_eq, tb_name_eq, tb_type_eq };
                equipment = furniture[selected].GetEquipment();
                bt_equip.Click += equipmentButtonClicked;
                dlg.Controls.Add(bt_equip);

                System.Windows.Forms.Button btr_equip = new System.Windows.Forms.Button();
                btr_equip.Text = "Remove equip";
                btr_equip.Bounds = new Rectangle(new Point(150, 390), new Size(150, 30));
                btr_equip.Tag = listView2;
                btr_equip.Click += equipmentRButtonClicked;
                dlg.Controls.Add(btr_equip);

                System.Windows.Forms.Button bt_save = new System.Windows.Forms.Button();
                bt_save.Text = "Save";
                bt_save.Bounds = new Rectangle(new Point(0, 420), new Size(100, 30));
                bt_save.Tag = new List<System.Windows.Forms.TextBox>() { tb_name, tb_id, tb_type };
                bt_save.Click += saveButtonClicked;
                dlg.Controls.Add(bt_save);

                dlg.ShowDialog();
            }
        }
        private void equipmentButtonClicked(object sender, EventArgs e)
        {
            List<System.Windows.Forms.TextBox> x = (List<System.Windows.Forms.TextBox>)((System.Windows.Forms.Button)sender).Tag;
            if (x[0].Text == "") { MessageBox.Show("Fill equipment id", "Empty id", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            else
            {
                int id_eq = Int32.Parse(x[0].Text);
                string name_eq = x[1].Text;
                string type_eq = x[2].Text;

                equipment.Add(new Detail(name_eq, id_eq, type_eq));

                listView2.Items.Add(name_eq);
            }
        }
        private void equipmentRButtonClicked(object sender, EventArgs e)
        {
            foreach (ListViewItem it in listView2.SelectedItems)
            {
                equipment.RemoveAt(it.Index);
                listView2.Items.Remove(it);
            }
        }
        private void saveButtonClicked(object sender, EventArgs e)
        {
            List<System.Windows.Forms.TextBox> x = (List<System.Windows.Forms.TextBox>)((System.Windows.Forms.Button)(sender)).Tag;
            if (x[1].BackColor == Color.Red) { MessageBox.Show("Write unique id", "Not unique id", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            else
            {
                Form dlg1 = new Form();

                Label label1 = new Label();
                label1.Text = "Save changes";
                label1.Size = new Size(300, 100);
                label1.Font = new Font("Arial", 20);
                dlg1.Controls.Add(label1);

                System.Windows.Forms.Button bb = new System.Windows.Forms.Button();
                bb.Text = "Yes";
                bb.Bounds = new Rectangle(new Point(0, 200), new Size(100, 50));
                bb.Tag = x;
                bb.Click += saveYesButtonClicked;
                dlg1.Controls.Add(bb);

                System.Windows.Forms.Button b = new System.Windows.Forms.Button();
                b.Text = "No";
                b.Tag = dlg1;
                b.Click += saveNoButtonClicked;
                b.Bounds = new Rectangle(new Point(100, 200), new Size(100, 50));
                dlg1.Controls.Add(b);

                dlg1.ShowDialog();
            }
        }
        private void saveYesButtonClicked(object sender, EventArgs e)   
        {
            List<System.Windows.Forms.TextBox> x = (List<System.Windows.Forms.TextBox>)((System.Windows.Forms.Button)(sender)).Tag;
            int selected = Int32.Parse(listView1.SelectedItems[0].Text);
            Form form = ((System.Windows.Forms.Button)(sender)).FindForm();

            string name = x[0].Text;
            int id;
            bool id_ch = Int32.TryParse(x[1].Text, out id);
            if (!id_ch) { id = furniture[selected].GetId(); }
            string type = x[2].Text;


            furniture[selected].SetType(type);
            furniture[selected].SetName(name);
            furniture[selected].SetId(id);
            furniture[selected].SetEquipment(equipment);

            ListViewItem it = listView1.SelectedItems[0];
            it.SubItems.Clear();
            it.Text = selected.ToString();
            it.SubItems.Add(id.ToString());
            it.SubItems.Add(name);

            form.Close();
        }
        private void saveNoButtonClicked(object sender, EventArgs e)
        {
            Form x = (Form)((System.Windows.Forms.Button)sender).Tag;
            x.Close();
        }
        private void idTextBoxChanged(object sender, EventArgs e)
        {
            System.Windows.Forms.TextBox x = (System.Windows.Forms.TextBox)sender;
            if (x.Text == "") { x.BackColor = Color.White; }
            else
            {
                int id = 0;
                int selected = Int32.Parse(listView1.SelectedItems[0].Text);
                bool id_ch = Int32.TryParse(x.Text, out id);
                if (!id_ch || id < 0) { x.BackColor = Color.Red; MessageBox.Show("Use positive integers only", "Invalid id", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                else if (id == 0) { x.BackColor = Color.Red; }
                else if (id == furniture[Int32.Parse(listView1.SelectedItems[0].Text)].GetId()) { x.BackColor = Color.White; }
                else if (id == furniture[selected].GetId()) { x.BackColor = Color.White; }
                else
                {
                    foreach (Furniture f in furniture.Values)
                    {
                        if (id == f.GetId()) { x.BackColor = Color.Red; break; }
                        else { x.BackColor = Color.Green; }
                    }
                }
            }
        }
        private void showItemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form dlg3 = new Form();

            if (listView1.SelectedItems.Count == 0) { MessageBox.Show("Select one item", "No selected items", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            else if (listView1.SelectedItems.Count > 1) { MessageBox.Show("Select one item", "Several items selected", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            else
            {
                int selected = Int32.Parse(listView1.SelectedItems[0].Text);

                Label ln = new Label();
                ln.Text = "Name: " + furniture[selected].GetName();
                ln.AutoSize = true;
                ln.Location = new Point(0, 0);
                dlg3.Controls.Add(ln);

                Label lid = new Label();
                lid.Text = "ID: " + furniture[selected].GetId().ToString();
                lid.AutoSize = true;
                lid.Location = new Point(0, 30);
                dlg3.Controls.Add(lid);

                Label lt = new Label();
                lt.Text = "Type: " + furniture[selected].GetProductType();
                lt.AutoSize = true;
                lt.Location = new Point(0, 60);
                dlg3.Controls.Add(lt);

                Label leq = new Label();
                leq.Text = "Equipment: ";
                leq.AutoSize = true;
                leq.Location = new Point(0, 90);
                dlg3.Controls.Add(leq);

                int counter = 0;
                foreach (Detail dd in furniture[selected].GetEquipment())
                {
                    Label l = new Label();
                    l.Text = dd.GetId().ToString() + ", " + dd.GetName() + ", " + dd.GetProductType();
                    l.AutoSize = true;
                    l.Location = new Point(0, 120 + counter*30);
                    dlg3.Controls.Add(l);
                    counter++;
                }

                dlg3.ShowDialog();
            }
        }
        private void aboutItemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form dlg4 = new Form();

            Label l = new Label();
            l.Text = "Version: 1.1\n" +
                "Author: Maria Butsickina\n" +
                "Email: mary.dovlatova16@gmail.com\n" +
                "Last update: 26.06.2024 02:06";
            l.Font = new Font("Arial", 14);
            l.AutoSize = true;
            dlg4.Controls.Add(l);

            dlg4.AutoSize = true;
            dlg4.ShowDialog();
        }
        private void addInfoItemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form dlg4 = new Form();

            Label l = new Label();
            l.Text = "Adds new furniture item into the collection.\n" +
                "Sets default parameters to the item:\n" +
                "Name - empty string\n" +
                "Type - empty string\n" +
                "ID - item number in the collection";
            l.Font = new Font("Arial", 14);
            l.AutoSize = true;
            dlg4.Controls.Add(l);

            dlg4.AutoSize = true;
            dlg4.ShowDialog();
        }
        private void removeInfoItemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form dlg4 = new Form();

            Label l = new Label();
            l.Text = "Removes selected items from the collection.\n";
            l.Font = new Font("Arial", 14);
            l.AutoSize = true;
            dlg4.Controls.Add(l);

            dlg4.AutoSize = true;
            dlg4.ShowDialog();
        }
        private void editInfoItemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form dlg4 = new Form();

            Label l = new Label();
            l.Text = "Opens a dialog window with the item parameters.\n" +
                "Furniture ID must be unique.\n" +
                "ID must be a positive integer.\n" +
                "The field will be colored red, if your id is not unique.\n" +
                "The field will be colored green, if your id is valid and unique.\n" +
                "The field will be colored red and an error message will be thrown up\n" +
                "if your ID is not valid.\n";
            l.Font = new Font("Arial", 14);
            l.AutoSize = true;
            dlg4.Controls.Add(l);

            dlg4.AutoSize = true;
            dlg4.ShowDialog();
        }
        private void showInfoItemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form dlg4 = new Form();

            Label l = new Label();
            l.Text = "Opens a dialog window with the item info.";
            l.Font = new Font("Arial", 14);
            l.AutoSize = true;
            dlg4.Controls.Add(l);

            dlg4.AutoSize = true;
            dlg4.ShowDialog();
        }

        private void settings(object sender, EventArgs e)
        {
            Label l = new Label();
            l.Text = $"ID: {client.client_id.ToString()}";
            l.AutoSize = true;
            set.Controls.Add(l);

            Label l2 = new Label();
            l2.Text = "IP: ";
            l2.Size = new Size(50, 30);
            l2.Location = new Point(0, 30);
            set.Controls.Add(l2);

            set.Show();
        }

        private void connect(object sender, EventArgs e)
        {
            bool res = client.Connect();
            if (res) { ((ToolStripMenuItem)sender).BackColor = Color.LightGreen; ct = new CancellationTokenSource(); }
            else { MessageBox.Show("Connection failed", "Connection failed", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
        private void disconnect(object sender, EventArgs e)
        {
            client.Disconnect();
            tcpToolStripMenuItem.DropDownItems[0].BackColor = Color.White;
            ct.Cancel();
        }
        private void others(object sender, EventArgs e)
        {
            bool res = client.Send("1112");
        }

        private void senfOthers(object sender, EventArgs e)
        {
            client.Send("1113");
            int x = (Int32)lboth.SelectedItems[0];
            Thread.Sleep(10);
            client.Send(x.ToString());

            Random rand = new Random();
            int i1 = rand.Next(0, furniture.Count());
            int i2 = rand.Next(0, furniture.Count());

            List<int> keys = new List<int>();
            foreach (int i in furniture.Keys) { keys.Add(i); }

            var options = new JsonSerializerOptions { IncludeFields = true };
            string ff1 = JsonSerializer.Serialize(furniture[keys[i1]], options);
            string ff2 = JsonSerializer.Serialize(furniture[keys[i2]], options);

            client.Send(ff1);
            Thread.Sleep(10);
            client.Send(ff2);
            Thread.Sleep(10);
            client.Send("0000");
        }

        private void client_worker()
        {
            string msg;
            while (true)
            {
                if (dispose_fl) { break; }
                if (ct.Token.IsCancellationRequested) { Thread.Sleep(50); continue; }
                if (!client.tcpClient.Connected) { Thread.Sleep(50); continue; }
                msg = client.Receive(4);

                if (msg == "1111")
                {
                    msg = client.Receive(4);
                    client.client_id = Int32.Parse(msg);
                }
                else if (msg == "1112")
                {
                    List<int> others = new List<int>();
                    msg = client.Receive(4);
                    while (msg != "0000")
                    {
                        others.Add(Int32.Parse(msg));
                        msg = client.Receive(4);
                    }
                    Action act1 = () => showOthers(others);
                    Invoke(act1);
                }
                else if (msg == "1113")
                {
                    msg = client.Receive(4);
                    int sender = Int32.Parse(msg);

                    List<Furniture> lf = new List<Furniture>();

                    msg = client.Receive(1024);
                    msg = msg.TrimEnd(new char[] { '\0' });
                    while (msg != "0000" && msg != "")
                    {
                        var options = new JsonSerializerOptions { IncludeFields = true };
                        Furniture f = JsonSerializer.Deserialize<Furniture>(msg, options);

                        lf.Add(f);
                        msg = client.Receive(1024);
                        msg = msg.TrimEnd(new char[] { '\0' });
                    }

                    Action act2 = () => showFurniture(lf);
                    Invoke(act2);
                }
            }
        }

        private void showOthers(List<int> others)
        {
            foreach (int id in others) { lboth.Items.Add(id); }
            oth.Controls.Add(lboth);

            oth.Show();
        }
        private void showFurniture(List<Furniture> l)
        {
            foreach (Furniture f in l)
            {
                string eq = "";
                foreach (Detail d in f.equipment) { eq += d.name + " "; }

                listBox1.Items.Add($"ID: {f.id}, Name: {f.name}, Type: {eq}");
            }
            listBox1.AutoSize = true;
            dlg3.Controls.Add(listBox1);

            dlg3.Size = new Size(listBox1.Width, listBox1.Height);
            dlg3.Show();
        }
    }
}