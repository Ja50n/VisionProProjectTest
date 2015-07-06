using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GCCA.Utilities.V2.HttpClientManager;
using MVCWebApiSample.Structs;
using Newtonsoft.Json;
using System.Configuration;

namespace MVCWebApiSampleTest
{
    [TestClass]
    public class MVCWebApiSampleTest
    {
        [TestMethod]
        public void PostDataToWebApi()
        {
            DataMatrixInfo dataInfoForWebApi = new DataMatrixInfo()
            {
                AccessOrderInProductBatch = 2,
                ExpectedDataMatrixCenter = new Coordinate() { XAxis = 3, YAxis = 4 },
                ActualDataMatrixCenter = new Coordinate() { XAxis = 3.001, YAxis = 4.001 },
                ExpectedDataMatrixSize = new DataMatrixSize() { Width = 5, Height = 5 },
                ActualDataMatrixSize = new DataMatrixSize() { Width = 5.001, Height = 5.002 },
                ActualDifferenceOfDataMatrixSize = new DataMatrixSize() { Width = 0.001, Height = 0.002 },
                ActualOffsetOfDataMatrixCenter = new Coordinate() { XAxis = 0.001, YAxis = 0.001 },
                AllowedDifferenceOfDataMatrixSize = new DataMatrixSize() { Width = 0.002, Height = 0.003 },
                AllowedOffsetOfDataMatrixCenter = new Coordinate() { XAxis = 0.002, YAxis = 0.004 },
                CodeOfDataMatrix = "TestCode",
                SucessOfDataMatrixInspection = true
            };
            string dataInfoJson = JsonConvert.SerializeObject(dataInfoForWebApi);
            string url = ConfigurationManager.AppSettings["apiUrl"];
            DataMatrixInfoWebApiDataModel dataMatrixWebApi = new DataMatrixInfoWebApiDataModel(url);
            AddDataMatrixInfoResponse response = dataMatrixWebApi.Add(dataInfoForWebApi);
            Assert.IsTrue(response.Success);
            Assert.AreEqual("Got it", response.Message);
        }
    }
}
