using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetBatch14HWH.ConsoleApp6HttpClient.ArtGallery;

internal class HttpClientService : IRefitClientService
{
    private readonly string endpoint = "https://burma-project-ideas.vercel.app/art-gallery";
    public readonly HttpClient _client;

    public HttpClientService() 
    {
        _client = new HttpClient();
    }

    public async Task<List<ArtGalleryModel>> GetArtGallery()
    {
        HttpResponseMessage response = await _client.GetAsync(endpoint);
        string content = await response.Content.ReadAsStringAsync();

        return JsonConvert.DeserializeObject<List<ArtGalleryModel>>(content)!;
    }

    public async Task<DetailArtGallery> GetArtGalleryById(int id)
    {
        HttpResponseMessage response = await _client.GetAsync($"{endpoint}/{id}");
        string content = await response.Content.ReadAsStringAsync();

        return JsonConvert.DeserializeObject<DetailArtGallery>(content)!;
    }
}
