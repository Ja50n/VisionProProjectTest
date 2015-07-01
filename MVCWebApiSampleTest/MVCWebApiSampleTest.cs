using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GCCA.Utilities.V2.HttpClientManager;
using MVCWebApiSample.Structs;
using Newtonsoft.Json;

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
            string url = "http://localhost:50622/api/";
            HttpClientManager httpClientConnector = new HttpClientManager();
            string responseJsonFromWebApi = httpClientConnector.Post(url, "test", dataInfoJson);
            WebApiResponse response = JsonConvert.DeserializeObject<WebApiResponse>(responseJsonFromWebApi);
            Assert.IsTrue(response.Success);
            Assert.AreEqual("Got it", response.Message);
        }
    }
}
