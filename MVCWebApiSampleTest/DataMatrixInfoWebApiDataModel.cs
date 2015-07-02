using GCCA.Utilities.V2.HttpClientManager;
using MVCWebApiSample.Structs;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCWebApiSampleTest
{
    public class DataMatrixInfoWebApiDataModel : IDataMatrixInfoDataModel
    {
        private string url;
        public DataMatrixInfoWebApiDataModel(string url)
        {
            this.url = url;
        }

        public WebApiResponse Add(MatrixDataInfo data)
        {
            try
            {
                string dataInfoJson = JsonConvert.SerializeObject(data);
                HttpClientManager httpClientConnector = new HttpClientManager();
                string responseJsonFromWebApi = httpClientConnector.Post(url, "/DataMatrixInfo/Add", dataInfoJson);
                WebApiResponse response = JsonConvert.DeserializeObject<WebApiResponse>(responseJsonFromWebApi);
                return response;
            }
            catch(Exception ex)
            {
                WebApiResponse response = new WebApiResponse()
                {
                    Message = ex.Message,
                    Success = false
                };
                return response;
            }
        }
    }
}
