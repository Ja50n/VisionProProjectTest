using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DisplayRealTimeDataAtTableSample
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<IPCamInfo> IPCamInfos = new List<IPCamInfo>();
            for (int i = 0; i < 10; i++)
            {
                string serialNumber = "serialNumber" + i;
                string location = "location" + i;
                IPCamInfo IPcamInfo = new IPCamInfo(i, serialNumber, location);
                IPCamInfos.Add(IPcamInfo);
            }

            for (int i = 0; i < 10; i++)
            {
                IPCamInfo IPCamInfo = IPCamInfos[i];
                if (i<5)
                {
                    this.dataGridView1.Rows.Add(IPCamInfo.ID, IPCamInfo.serialNumber, IPCamInfo.location);
                    int lastRowIndex = this.dataGridView1.Rows.Count - 2;
                    this.dataGridView1.Rows[lastRowIndex].HeaderCell.Value = i.ToString();
                }
                else 
                {
                    //Thread.Sleep(1000);
                    this.dataGridView1.Rows.RemoveAt(0);
                    this.dataGridView1.Rows.Add(IPCamInfo.ID, IPCamInfo.serialNumber, IPCamInfo.location);
                    int lastRowIndex = this.dataGridView1.Rows.Count - 2;
                    this.dataGridView1.Rows[lastRowIndex].HeaderCell.Value = i.ToString();
                }
                
                
            }

        }
    }
}
