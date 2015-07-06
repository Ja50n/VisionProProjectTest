using MVCWebApiSample.Structs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCWebApiSampleTest
{
    interface IDataMatrixInfoDataModel
    {
        AddDataMatrixInfoResponse Add(DataMatrixInfo data);
    }
}
