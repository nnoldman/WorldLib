using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using World.Object;

namespace WindowsFormsApplication2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            World.Scene.Instance.Initialize();
            Myself.Instance.outHandler += OnTalk;
        }

        void OnTalk(string text)
        {
            this.textBox1.Text += "\n" + text;
        }

        private void onKeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                string content = this.textBox2.Text;
                if (string.IsNullOrEmpty(content))
                    return;
                Myself.Instance.Input(content.Trim('\r', '\n'));
                this.textBox2.Clear();
            }
        }

        private void Form1_Activated(object sender, EventArgs e)
        {
            this.textBox2.Focus();
        }

        private void onFormKeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                Application.Exit();
            }
        }
    }
}
