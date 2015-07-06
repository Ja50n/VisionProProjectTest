using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCWebApiSample.Structs
{
    public class DataMatrixInfo
    {
        public int AccessOrderInProductBatch; //個別產件在該批檢測產件的序號(若每批檢測產件為11個，則序號為1~11，在code無法被正常取得時用以追蹤產件)
        public Coordinate ExpectedDataMatrixCenter; //預期的DataMatrix中心點位於影像之座標
        public Coordinate ActualDataMatrixCenter; //實際的DataMatrix中心點位於影像之座標
        public Coordinate AllowedOffsetOfDataMatrixCenter;//DataMatrix中心點實際值與預期值在x,y軸的預期最大可容許差值
        public Coordinate ActualOffsetOfDataMatrixCenter;//DataMatrix中心點實際值與預期值在x,y軸的實際差值
        public DataMatrixSize ExpectedDataMatrixSize;//預期的DataMatrix大小(寬度與高度)
        public DataMatrixSize ActualDataMatrixSize;//實際的DataMatrix大小
        public DataMatrixSize AllowedDifferenceOfDataMatrixSize;// DataMatrix大小實際值與預期值的預期最大可容許差值
        public DataMatrixSize ActualDifferenceOfDataMatrixSize;// DataMatrix大小實際值與預期值的實際差值
        public string CodeOfDataMatrix; //解析DataMatrix後取得之Code
        public bool SucessOfDataMatrixInspection; //DataMatrix驗證結果，只要DataMatrix中心點偏移量、大小超出預期容許範圍，或DataMatrix的code無法正常取得，即為false

        public static DataMatrixInfo ToObject(string json)
        {
            return null;
        }

        public static string ToJson(DataMatrixInfo data)
        {
            return null;
        }
    }
}