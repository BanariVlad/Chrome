using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chrome
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private int i;

        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
            NewTab(tabControl1);
        }

        private void SetTitle(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            tabControl1.SelectedTab.Text = ((WebBrowser) tabControl1.SelectedTab.Controls[0]).DocumentTitle;
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            if (toolStripTextBox1.Text != null)
            {
                ((WebBrowser)tabControl1.SelectedTab.Controls[0]).Navigate(toolStripTextBox1.Text);
            }
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ((WebBrowser) tabControl1.SelectedTab.Controls[0]).GoBack();
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            ((WebBrowser) tabControl1.SelectedTab.Controls[0]).GoForward();
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            ((WebBrowser)tabControl1.SelectedTab.Controls[0]).Refresh();
        }

        private void toolStripMenuItem6_Click(object sender, EventArgs e)
        {
            if (tabControl1.TabPages.Count > 1)
            {
                tabControl1.TabPages.RemoveAt(tabControl1.SelectedIndex);
                tabControl1.SelectTab(tabControl1.TabPages.Count - 1);
                i--;
            }
        }

        private void NewTab(TabControl tabControl)
        {
            var web = new WebBrowser{Visible = true, ScriptErrorsSuppressed = false, Dock = DockStyle.Fill};
            web.DocumentCompleted += SetTitle;
            tabControl.TabPages.Add("New tab");
            tabControl.SelectTab(i);
            tabControl.SelectedTab.Controls.Add(web);
            i++;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            NewTab(tabControl1);
            ((WebBrowser) tabControl1.SelectedTab.Controls[0]).Navigate("google.com");
        }
    }
}