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
            MatrixDataInfo dataInfoForWebApi = new MatrixDataInfo()
            {
                accessOrderInProductBatch = "accessOrderInProductBatchTest",
                actualDataMatrixCenter = "actualDataMatrixCenterTest",
                actualDataMatrixSize = "actualDataMatrixSizeTest",
                codeOfDataMatrix = "codeOfDataMatrixTest",
                differenceOfDataMatrixSize = "differenceOfDataMatrixSizeTest",
                expectedDataMatrixCenter = "expectedDataMatrixCenterTest",
                offsetOfDataMatrixCenter = "offsetOfDataMatrixCenterTest",
                resultOfDataMatrixInspection = "resultOfDataMatrixInspectionTest"
            };
            string dataInfoJson = JsonConvert.SerializeObject(dataInfoForWebApi);
            string url = ConfigurationManager.AppSettings["apiUrl"];
            DataMatrixInfoWebApiDataModel dataMatrixWebApi = new DataMatrixInfoWebApiDataModel(url);
            WebApiResponse response = dataMatrixWebApi.Add(dataInfoForWebApi);
            Assert.IsTrue(response.Success);
            Assert.AreEqual("Got it", response.Message);
        }
    }
}
