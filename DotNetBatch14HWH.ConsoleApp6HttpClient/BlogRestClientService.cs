using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace DotNetBatch14HWH.ConsoleApp6HttpClient;

public class BlogRestClientService
{
    private readonly string endpoint = "https://localhost:7184/api/blog";
    private readonly RestClient _restClient;

    public BlogRestClientService()
    {
        _restClient = new RestClient();
    }
    //NewtonSoft.Json 
    // Json to C# Deseri
    //C# to json seri
    public async Task<BlogListResponseModel> GetBlogs()
    {
        RestRequest request = new RestRequest(endpoint, Method.Get);
        var response = await _restClient.ExecuteAsync(request);
        string json = response.Content!;//json or content
        return JsonConvert.DeserializeObject<BlogListResponseModel>(json)!;
    }

    public async Task<BlogResponseMode> GetBlog(string id)
    {
        RestRequest request = new RestRequest($"{endpoint}/id", Method.Get);
        var response = await _restClient.ExecuteAsync(request);

        string json = response.Content!;
        return JsonConvert.DeserializeObject<BlogResponseMode>(json)!;
    }

    public async Task<BlogResponseMode> CreateBlog(BlogModel requestModel)
    {
        RestRequest request = new RestRequest(endpoint, Method.Post);
        request.AddJsonBody(requestModel);
        var response = await _restClient.ExecuteAsync(request);

        string content = response.Content!;
        return JsonConvert.DeserializeObject<BlogResponseMode>(content)!;
    }

    public async Task<BlogResponseMode> UpdateBlog(BlogModel requestModel)
    {
        RestRequest request = new RestRequest($"{endpoint}/{requestModel.BlogId}", Method.Patch);
        request.AddJsonBody(requestModel);
        var response = await _restClient.ExecuteAsync(request);

        string content = response.Content!;
        Console.Write(content);
        Console.WriteLine("");
        return JsonConvert.DeserializeObject<BlogResponseMode>(content)!;
    }

    public async Task<BlogResponseMode> DeleteBlog(string id)
    {
        RestRequest request = new RestRequest($"{endpoint}/id", Method.Delete);
        var response = await _restClient.ExecuteAsync(request);
        string json = response.Content!;
        Console.Write(json);
        Console.WriteLine("");
        return JsonConvert.DeserializeObject<BlogResponseMode>(json)!;
    }

}
