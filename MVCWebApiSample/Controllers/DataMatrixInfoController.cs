using MVCWebApiSample.Structs;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Web.Http;

namespace MVCWebApiSample.Controllers
{
    public class DataMatrixInfoController : ApiController
    {
        // GET api/DataMatrixInfo
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/DataMatrixInfo/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/DataMatrixInfo/Add
        [HttpPost]
        public WebApiResponse Add()
        {
            try
            {
                //取得Request的傳送內容
                Stream requestInputStream = HttpContext.Current.Request.InputStream;
                byte[] dataByteArray = new byte[requestInputStream.Length];
                requestInputStream.Read(dataByteArray, 0, dataByteArray.Length);
                requestInputStream.Position = 0;
                string jsonConvertFromRequest = Encoding.UTF8.GetString(dataByteArray);

                //將Request的傳送內容進行jsonDeserialize
                MatrixDataInfo matrixDataFromClient = JsonConvert.DeserializeObject<MatrixDataInfo>(jsonConvertFromRequest);
                string contentToSave = matrixDataFromClient.accessOrderInProductBatch + Environment.NewLine
                    + matrixDataFromClient.actualDataMatrixCenter + Environment.NewLine
                    + matrixDataFromClient.actualDataMatrixSize + Environment.NewLine
                    + matrixDataFromClient.codeOfDataMatrix + Environment.NewLine
                    + matrixDataFromClient.differenceOfDataMatrixSize + Environment.NewLine
                    + matrixDataFromClient.expectedDataMatrixCenter + Environment.NewLine
                    + matrixDataFromClient.offsetOfDataMatrixCenter + Environment.NewLine
                    + matrixDataFromClient.resultOfDataMatrixInspection + Environment.NewLine;

                File.WriteAllText(ConfigurationManager.AppSettings["saveFilePath"], contentToSave);

                WebApiResponse response = new WebApiResponse()
                {
                    Message = "Got it",
                    Success = true
                };
                return response;
            }
            catch (Exception ex)
            {
                return new WebApiResponse()
                {
                    Message = "Didn't Got it",
                    Success = false
                };
            }
        }

        // PUT api/DataMatrixInfo/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/DataMatrixInfo/5
        public void Delete(int id)
        {
        }
    }
}
