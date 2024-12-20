using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetBatch14HWH.ConsoleApp6HttpClient.JsonPlaceHolderExample;

internal class JsonRestClientService
{
    private readonly string endpoint = "https://jsonplaceholder.typicode.com/posts";
    public readonly RestClient _client;

    public JsonRestClientService()
    {
        _client = new RestClient();
    }

    public async Task<List<JsonPlaceHolderDataModel>> GetData()
    {
        RestRequest request = new RestRequest(endpoint, Method.Get);
        var response = await _client.GetAsync(request);
        string content = response.Content!;

        return JsonConvert.DeserializeObject<List<JsonPlaceHolderDataModel>>(content)!;
    }

    public async Task<JsonPlaceHolderDataModel> GetDataById(int id)
    {
        RestRequest request = new RestRequest($"{endpoint}/{id}", Method.Get);
        var response = await _client.GetAsync(request);
        string content = response.Content!;

        return JsonConvert.DeserializeObject<JsonPlaceHolderDataModel>(content)!;
    }

    public async Task<JsonPlaceHolderDataModel> CreateData(JsonPlaceHolderDataModel RequestModel)
    {
        RestRequest request = new RestRequest(endpoint, Method.Post);
        request.AddJsonBody(RequestModel);
        var response = await _client.PostAsync(request);
        string content = response.Content!;

        return JsonConvert.DeserializeObject<JsonPlaceHolderDataModel>(content)!;
    }

    public async Task<JsonPlaceHolderDataModel> UpdateData(int id, JsonPlaceHolderDataModel RequestModel)
    {
        RestRequest request = new RestRequest($"{endpoint}/{id}", Method.Patch);
        request.AddJsonBody(RequestModel);
        var response = await _client.PatchAsync(request);
        string content = response.Content!;

        return JsonConvert.DeserializeObject<JsonPlaceHolderDataModel>(content)!;
    }

    public async Task<JsonPlaceHolderDataModel> DeleteData(int id)
    {
        RestRequest request = new RestRequest($"{endpoint}/{id}", Method.Delete);
        var response = await _client.DeleteAsync(request);
        string content = response.Content!;

        return JsonConvert.DeserializeObject<JsonPlaceHolderDataModel>(content)!;
    }
}
