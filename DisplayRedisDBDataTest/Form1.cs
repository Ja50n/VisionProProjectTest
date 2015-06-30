using GCCA.Utilities.V2.Redis;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DisplayRedisDBDataTest
{
    public partial class Form1 : Form
    {
        IDisplayCameraInfo displayCameraInfo = new DisplayCameraInfo();
        public Form1()
        {
            InitializeComponent();
            displayCameraInfo.DisplayCameraInfo(this.dataGridView1);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int dbNum = 0;
            RedisDBConnector db0 = RedisDBConnector.GetInstance(dbNum);
            DataTable cameraInfoDataTable = (DataTable)this.dataGridView1.DataSource;
            foreach (DataRow dataRow in cameraInfoDataTable.Rows)
            {
                if (dataRow.RowState == DataRowState.Modified)
                {
                    CameraInfo initialCameraInfo = new CameraInfo()
                    {
                        SerialNumber = (string)dataRow["SerialNumber"],
                        PhysicalLocation = (string)dataRow["PhysicalLocation"]
                    };
                    string jsonStringOfCameraInfo = JsonConvert.SerializeObject(initialCameraInfo);
                    bool resultOfAddOrUpdateDBData = false;
                    resultOfAddOrUpdateDBData = db0.AddOrUpdate("camera1", jsonStringOfCameraInfo);
                }      
            }
            cameraInfoDataTable.AcceptChanges();
        }
    }
}
