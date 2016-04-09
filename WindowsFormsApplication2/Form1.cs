using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using World;
using World.Object;
using World.TextProcessor;

namespace WindowsFormsApplication2
{
    public partial class Form1 : Form
    {
        List<string> mLastContents = new List<string>();
        int mCurIndex = 0;
        public Form1()
        {
            InitializeComponent();
            StoreWordType.onAdd += onAddWordType;
            StoreWordType.onRemove += onRemoveWordType;

            StoreWord.onAdd += onAddWord;
            StoreWord.onRemove += onRemoveWord;

            List<string> nameList = Linker.GetProcesseres();
            nameList.ForEach((item) => this.treeView3.Nodes.Add(item, item));

            World.Scene.Instance.Initialize();
            Myself.Instance.outHandler += OnTalk;
        }

        private void onRemoveWordType(string k)
        {
            this.treeView1.Nodes.RemoveByKey(k);
        }

        private void onAddWordType(string k, WordType v)
        {
            this.treeView1.Nodes.Add(k, k);
        }

        private void onRemoveWord(string k)
        {
            this.treeView2.Nodes.RemoveByKey(k);
        }

        private void onAddWord(string k, Word v)
        {
            this.treeView2.Nodes.Add(k, k);
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

                if (
                    (mLastContents.Count > 0 && mLastContents[mLastContents.Count - 1] != content)
                    || (mLastContents.Count == 0)
                    )
                {
                    mLastContents.Add(content);
                    mCurIndex = mLastContents.Count;
                }
            }
            else if (e.KeyCode == Keys.Up)
            {
                if (mLastContents.Count > 0)
                {
                    mCurIndex--;
                    if (mCurIndex < 0)
                        mCurIndex = mLastContents.Count + mCurIndex;
                    this.textBox2.Text = mLastContents[mCurIndex];
                }
            }
            else if (e.KeyCode == Keys.Down)
            {
                if (mLastContents.Count > 0)
                {
                    mCurIndex++;
                    if (mCurIndex >= mLastContents.Count)
                        mCurIndex = mCurIndex - mLastContents.Count;
                    this.textBox2.Text = mLastContents[mCurIndex];
                }
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

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Myself.Instance.Save();
        }
    }
}
