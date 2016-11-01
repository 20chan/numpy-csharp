using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ArrayManager
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            foreach (var i in Enumerable.Range(1, Program.Length).Shuffle())
                this.listView1.Items.Add(i.ToString());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            listView2.Items.Clear();
            int width = (int)numericUpDown1.Value;
            int height = (int)Math.Ceiling(Program.Length / (float)width);
            var result = Enumerable.Range(1, Program.Length).Fill(-1, width * height - Program.Length).ReshapeJagged(width, height);
            
            
            for (int i = 0; i < width; i++) {
                var re = result[i].Where(x => x > 0).ToArray();
                Array.Sort(re);
                this.listView2.Items.Add(
                        new ListViewItem(new string[] {
                            i.ToString() + "조",
                            string.Join(", ", re.Select(x => x.ToString())) }));
                }
        }
    }
}
