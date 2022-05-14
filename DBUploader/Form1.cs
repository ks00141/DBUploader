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
        }

        public string[] Ppid 
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                lv_ppidList.Items.Add(new ListViewItem(value));
            }
        }
        public string[] RecipeParam
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {

            }
        }
        public string Result
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {

            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.ppidPresenter.PrintAllPpid();
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
    }
}
