using Entity;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace GraphQLApi.Resp
{
    public class ApiRequest : IApiRequest
    {
        private const string _baseUrl = "https://localhost:5011/api/sql";
        public ApiRequest()
        {

        }

        public async Task<IEnumerable<Document>> GetDocuments()
        {
            using (HttpClient client = new HttpClient())
            using (HttpResponseMessage res = await client.GetAsync(_baseUrl))
            using (HttpContent content = res.Content)
            {
                string data = await content.ReadAsStringAsync();
                if (data != null)
                {
                    var documents = JsonConvert.DeserializeObject<List<Document>>(data);
                    return documents;
                }
            }
            return null;
        }


        public async Task<Document> GetDocument(int documentId)
        {
            using (HttpClient client = new HttpClient())
            using (HttpResponseMessage res = await client.GetAsync($"{_baseUrl}/{documentId}"))
            using (HttpContent content = res.Content)
            {
                string data = await content.ReadAsStringAsync();
                if (data != null)
                {
                    return JsonConvert.DeserializeObject<Document>(data);
                }
            }
            return null;
        }

        public async Task<IEnumerable<Document>> GetDocumentByUserName(string userName)
        {
            using (HttpClient client = new HttpClient())
            using (HttpResponseMessage res = await client.GetAsync($"{_baseUrl}/username/{userName}")) 
            using (HttpContent content = res.Content)
            {
                string data = await content.ReadAsStringAsync();
                if (data != null)
                {
                    return JsonConvert.DeserializeObject<List<Document>>(data);
                }
            }
            return null;
        }
    }
}
