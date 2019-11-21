using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace SimpleRdfConsole.Examples.Rest
{
    internal class SolidRestClient
    {
        private readonly string _webId;

        public SolidRestClient(string webId)
        {
            _webId = webId;
        }

        public async Task<string> GetAsync(string resource)
        {
            using (var client = new HttpClient())
            {
                var url = $"{_webId}/{resource}";

                var requestMessage = new HttpRequestMessage(HttpMethod.Get, url);

                // Set the expected Mime Type
                requestMessage.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("text/turtle"));


                var responseMessage = await client.SendAsync(requestMessage, 
                    HttpCompletionOption.ResponseHeadersRead);

                var responseText = await responseMessage.Content.ReadAsStringAsync();

                if (responseMessage.StatusCode != System.Net.HttpStatusCode.OK)
                {
                    //var json = await getResponse.Content.ReadAsStringAsync();
                    //dynamic obj = (dynamic)JsonConvert.DeserializeObject(json);

                    //throw new FindMyRelativesBusinessException(string.Format("{0} - {1}", obj.error, obj.error_description));
                }

                return responseText;
            }
        }
    }
}
