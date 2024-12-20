using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace DotNetBatch14HWH.ConsoleApp6HttpClient.JsonPlaceHolderExample;

internal class JsonHttpClientService
{
    private readonly string endpoint = "https://jsonplaceholder.typicode.com/posts";
    public readonly HttpClient _client;

    public JsonHttpClientService()
    {
        _client = new HttpClient();
    }

    public async Task<List<JsonPlaceHolderDataModel>> GetData()
    {
        var response = await _client.GetAsync(endpoint);
        string content = await response.Content.ReadAsStringAsync();

        return JsonConvert.DeserializeObject<List<JsonPlaceHolderDataModel>>(content)!;
    }

    public async Task<JsonPlaceHolderDataModel> GetDataById(int id)
    {
        var response = await _client.GetAsync($"{endpoint}/{id}");
        string content = await response.Content.ReadAsStringAsync();

        return JsonConvert.DeserializeObject<JsonPlaceHolderDataModel>(content)!;
    }

    public async Task<JsonPlaceHolderDataModel> CreateData(JsonPlaceHolderDataModel RequestModel)
    {
        string Json = JsonConvert.SerializeObject(RequestModel);
        var StringContent = new StringContent(Json, Encoding.UTF8, Application.Json);

        HttpResponseMessage response = await _client.PostAsync(endpoint, StringContent);
        string content = await response.Content.ReadAsStringAsync();

        return JsonConvert.DeserializeObject<JsonPlaceHolderDataModel>(content)!;
    }

    public async Task<JsonPlaceHolderDataModel> UpdateData(int id, JsonPlaceHolderDataModel RequestModel)
    {
        RequestModel.id = id;
        string Json = JsonConvert.SerializeObject(RequestModel);
        var StringContent = new StringContent(Json, Encoding.UTF8, Application.Json);

        HttpResponseMessage response = await _client.PatchAsync(endpoint, StringContent);
        string content = await response.Content.ReadAsStringAsync();

        return JsonConvert.DeserializeObject<JsonPlaceHolderDataModel>(content)!;
    }

    public async Task<JsonPlaceHolderDataModel> DeleteData(int id)
    {
        string Json = JsonConvert.SerializeObject(id);
        var StringContent = new StringContent(Json, Encoding.UTF8, Application.Json);

        HttpResponseMessage response = await _client.DeleteAsync(endpoint);
        string content = await response.Content.ReadAsStringAsync();

        return JsonConvert.DeserializeObject<JsonPlaceHolderDataModel>(content)!;
    }
}
