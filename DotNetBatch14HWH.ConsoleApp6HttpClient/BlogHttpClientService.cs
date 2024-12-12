using Newtonsoft.Json;
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

public class BlogHttpClientService
{
    private readonly string endpoint = "https://localhost:7184/api/blog";
    private readonly HttpClient _httpClient;

    public BlogHttpClientService()
    {
        _httpClient = new HttpClient();
    }
    //NewtonSoft.Json 
    // Json to C# Deseri
    //C# to json seri
    public async Task<BlogListResponseModel> GetBlogs()
    {
        //HttpClient client = new HttpClient();
        HttpResponseMessage response = await _httpClient.GetAsync(endpoint);
        string json = await response.Content.ReadAsStringAsync();//json or content
        Console.Write(json);
        return JsonConvert.DeserializeObject<BlogListResponseModel>(json)!;
    }

    public async Task<BlogResponseMode> GetBlog(string id)
    {
        //HttpClient client = new HttpClient();
        HttpResponseMessage response = await _httpClient.GetAsync($"{endpoint}/id");

        string json = await response.Content.ReadAsStringAsync();
        Console.Write(json);
        return JsonConvert.DeserializeObject<BlogResponseMode>(json)!;
    }

    public async Task<BlogResponseMode> CreateBlog(BlogModel requestModel)
    {
        string json = JsonConvert.SerializeObject(requestModel);
        var stringContent = new StringContent(json, Encoding.UTF8, Application.Json);
        HttpResponseMessage response = await _httpClient.PostAsync(endpoint, stringContent);

        string content = await response.Content.ReadAsStringAsync();
        return JsonConvert.DeserializeObject<BlogResponseMode>(content)!;
    }

    public async Task<BlogResponseMode> UpdateBlog(BlogModel requestModel)
    {
        string json = JsonConvert.SerializeObject(requestModel);
        var stringContent = new StringContent(json, Encoding.UTF8, Application.Json);
        HttpResponseMessage response = await _httpClient.PatchAsync($"{endpoint}/{requestModel.BlogId}", stringContent);

        string content = await response.Content.ReadAsStringAsync();
        return JsonConvert.DeserializeObject<BlogResponseMode>(content)!;
    }

    public async Task<BlogResponseMode> DeleteBlog(string id)
    {
        HttpResponseMessage response = await _httpClient.DeleteAsync("{endpoint}/id");
        string json = await response.Content.ReadAsStringAsync();
        return JsonConvert.DeserializeObject<BlogResponseMode>(json)!;
    }

}
