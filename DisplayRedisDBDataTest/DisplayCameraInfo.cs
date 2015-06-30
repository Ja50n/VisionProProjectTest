using GCCA.Utilities.V2.Redis;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DisplayRedisDBDataTest
{
    class DisplayCameraInfo : IDisplayCameraInfo
    {
        void IDisplayCameraInfo.DisplayCameraInfo(DataGridView dataGridView)
        {
            int dbNum = 0;
            string serialNumber = "camera1";
            RedisDBConnector db0 = RedisDBConnector.GetInstance(dbNum);
            DataTable cameraInfoDataTable = new DataTable();
            cameraInfoDataTable.Columns.Add("SerialNumber");
            cameraInfoDataTable.Columns.Add("PhysicalLocation");
            string cameraInfoStringGetFromDB = db0.Get(serialNumber);
            if (cameraInfoStringGetFromDB == null)
            {
                CameraInfo initialCameraInfo = new CameraInfo()
                {
                    SerialNumber = serialNumber
                };
                string jsonStringOfCameraInfo = JsonConvert.SerializeObject(initialCameraInfo);
                bool resultOfAddOrUpdateDBData = false;
                resultOfAddOrUpdateDBData = db0.AddOrUpdate(initialCameraInfo.SerialNumber, jsonStringOfCameraInfo);
            }
            cameraInfoStringGetFromDB = db0.Get(serialNumber);
            CameraInfo cameraInfoGetFromDB = JsonConvert.DeserializeObject<CameraInfo>(cameraInfoStringGetFromDB);
            //dataGridView.Rows.Add(cameraInfoGetFromDB.SerialNumber, cameraInfoGetFromDB.PhysicalLocation);
            DataRow cameraInfoDataRow = cameraInfoDataTable.NewRow();
            string[] dataRowDatas = { cameraInfoGetFromDB.SerialNumber, cameraInfoGetFromDB.PhysicalLocation };
            cameraInfoDataRow.ItemArray = dataRowDatas;
            cameraInfoDataTable.Rows.Add(cameraInfoDataRow);
            cameraInfoDataTable.AcceptChanges();
            dataGridView.DataSource = cameraInfoDataTable;
        }
    }
}
