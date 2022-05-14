using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DBUploader.View;
using DBUploader.Presenter;
using System.Threading;

namespace DBUploader
{
    public partial class Form1 : Form,IRecipeParamUploadView, IPpidListView
    {
        PpidPresenter ppidPresenter;
        SecsGemPresenter secsGemPresenter;

        public Form1()
        {
            InitializeComponent();
            this.ppidPresenter = new PpidPresenter(this);
            this.secsGemPresenter = new SecsGemPresenter(this);
            try
            {
                this.ppidPresenter.PrintAllPpid();
            }
            catch
            {
                MessageBox.Show("DB config file not found");
            }

        }

        public string[] Ppid 
        {
            set
            {
                lv_ppidList.Items.Add(new ListViewItem(value));
            }
        }
        public string[] RecipeParam
        {
            set
            {
                lv_uploadHistory.Items.Add(new ListViewItem(value));
            }
        }

        public string[] UploadParams
        {
            get
            {
                int i = 0;
                string[] param = new string[lv_updateList.Items.Count];
                foreach (ListViewItem item in lv_updateList.Items)
                {
                    param[i] = item.SubItems[1].Text;
                }
                return param;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            ListView.SelectedListViewItemCollection selectedItem = lv_ppidList.SelectedItems;
            foreach(ListViewItem item in selectedItem)
            {
                lv_updateList.Items.Add((ListViewItem)item.Clone());
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ListView.SelectedListViewItemCollection selectedItem = lv_updateList.SelectedItems;
            foreach (ListViewItem item in selectedItem)
            {
                lv_updateList.Items.Remove(item);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in lv_ppidList.Items)
            {
                lv_updateList.Items.Add((ListViewItem)item.Clone());
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int i = 0;
            string[] param = new string[lv_updateList.Items.Count];
            foreach (ListViewItem item in lv_updateList.Items)
            {
                param[i] = item.SubItems[1].Text;
                i++;
            }
            Thread t = new Thread(() => secsGemPresenter.SecsGemParamRequest(param));
            t.Start();
        }
    }
}
