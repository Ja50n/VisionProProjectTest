using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCWebApiSample.Structs
{
    public class MatrixDataInfo
    {
        public string accessOrderInProductBatch;//個別產件在該批檢測產件的序號(若每批檢測產件為11個，則序號為1~11，在code無法被正常取得時用以追蹤產件)，
        public string expectedDataMatrixCenter;
        public string actualDataMatrixCenter;
        public string offsetOfDataMatrixCenter;
        public string actualDataMatrixSize;
        public string differenceOfDataMatrixSize;
        public string codeOfDataMatrix;
        public string resultOfDataMatrixInspection;
    }
}