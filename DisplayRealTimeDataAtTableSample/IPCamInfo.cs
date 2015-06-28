using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisplayRealTimeDataAtTableSample
{
    class IPCamInfo
    {
        public int ID;
        public string serialNumber;
        public string location;

        public IPCamInfo(int ID, string serialNumber, string location)
        {
            this.ID = ID;
            this.serialNumber = serialNumber;
            this.location = location;
        }
    }
}
