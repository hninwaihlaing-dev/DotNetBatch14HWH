using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DotNetBatch14HWH.ConsoleApp6HttpClient.ArtGallery.RefitClientService;

namespace DotNetBatch14HWH.ConsoleApp6HttpClient.JsonPlaceHolderExample;

internal class JsonRefitClientService
{
    private readonly string endpoint = "https://jsonplaceholder.typicode.com/";
    public readonly IJsonPlaceHolderApi _api;

    public JsonRefitClientService()
    {
        _api = RestService.For<IJsonPlaceHolderApi>(endpoint);
    }

    public async Task<JsonPlaceHolderDataModel> CreateData(JsonPlaceHolderDataModel RequestModel)
    {
        var model = await _api.CreateData(RequestModel);
        return model;
    }

    public async Task<JsonPlaceHolderDataModel> DeleteData(int id)
    {
        var model = await _api.DeleteData(id);
        return model;
    }

    public async Task<List<JsonPlaceHolderDataModel>> GetData()
    {
        var model = await _api.GetData();
        return model;
    }

    public async Task<JsonPlaceHolderDataModel> GetDataById(int id)
    {
        var model = await _api.GetDataById(id);
        return model;
    }

    public async Task<JsonPlaceHolderDataModel> UpdateData(int id, JsonPlaceHolderDataModel RequestModel)
    {
        var model = await _api.UpdateData(id, RequestModel);
        return model;
    }    
}

public interface IJsonPlaceHolderApi
{
    [Get("/posts")]
    Task<List<JsonPlaceHolderDataModel>> GetData();

    [Get("/posts/{id}")]
    Task<JsonPlaceHolderDataModel> GetDataById(int id);

    [Post("/posts")]
    Task<JsonPlaceHolderDataModel> CreateData(JsonPlaceHolderDataModel RequestModel);

    [Patch("/posts/{id}")]
    Task<JsonPlaceHolderDataModel> UpdateData(int id, JsonPlaceHolderDataModel RequestModel);

    [Delete("/posts")]
    Task<JsonPlaceHolderDataModel> DeleteData(int id);
}



