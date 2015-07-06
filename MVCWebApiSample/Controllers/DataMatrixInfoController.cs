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
        public AddDataMatrixInfoResponse Add()
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
                //DataMatrixInfo matrixDataFromClient = JsonConvert.DeserializeObject<DataMatrixInfo>(jsonConvertFromRequest);
                string contentToSave = jsonConvertFromRequest;

                File.WriteAllText(ConfigurationManager.AppSettings["saveFilePath"], contentToSave);

                AddDataMatrixInfoResponse response = new AddDataMatrixInfoResponse()
                {
                    Message = "Got it",
                    Success = true
                };
                return response;
            }
            catch (Exception ex)
            {
                return new AddDataMatrixInfoResponse()
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
