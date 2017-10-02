using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public class SearchOedQuery : ISearchOedQuery
    {
        private const string Language = "en";
        private readonly IHttpClientFactory _clientFactory;

        public SearchOedQuery(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory ?? throw new ArgumentNullException(nameof(clientFactory));
        }

        public OedSearchResultsModel Execute(OedSearchResultsModel model)
        {
            if (model == null)
                throw new ArgumentNullException(nameof(model));
            if (model.Query == null)
                throw new ArgumentNullException(nameof(model.Query));

            return ExecuteAsync(model).Result;
        }

        public async Task<OedSearchResultsModel> ExecuteAsync(OedSearchResultsModel model)
        {
            if (model.Query == null)
                throw new ArgumentNullException(nameof(model));

            var client = _clientFactory.CreateClient();

            string wordId = model.Query.ToLower();
            var response = await client.GetAsync($"search/{Language}?q={wordId}");
            if (!response.IsSuccessStatusCode)
            {
                throw new HttpRequestException(
                    $"Error calling service at '{client.BaseAddress}', status code is '{response.StatusCode}', content is '{response.Content.ReadAsStringAsync().Result}'");
            }
            var json = response.Content.ReadAsStringAsync().Result;
            var result = JsonConvert.DeserializeObject<OedSearchResults>(json);

            return model;
        }

    }
}




