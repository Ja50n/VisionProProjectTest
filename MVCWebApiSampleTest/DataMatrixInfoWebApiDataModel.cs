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

        public AddDataMatrixInfoResponse Add(DataMatrixInfo data)
        {
            try
            {
                string dataInfoJson = JsonConvert.SerializeObject(data);
                HttpClientManager httpClientConnector = new HttpClientManager();
                string responseJsonFromWebApi = httpClientConnector.Post(url, "/DataMatrixInfo/Add", dataInfoJson);
                AddDataMatrixInfoResponse response = JsonConvert.DeserializeObject<AddDataMatrixInfoResponse>(responseJsonFromWebApi);
                return response;
            }
            catch(Exception ex)
            {
                AddDataMatrixInfoResponse response = new AddDataMatrixInfoResponse()
                {
                    Message = ex.Message,
                    Success = false
                };
                return response;
            }
        }
    }
}
