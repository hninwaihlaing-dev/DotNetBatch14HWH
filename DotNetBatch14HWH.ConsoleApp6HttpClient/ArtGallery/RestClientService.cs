using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetBatch14HWH.ConsoleApp6HttpClient.ArtGallery;

internal class RestClientService : IRefitClientService
{
    private readonly string endpoint = "https://burma-project-ideas.vercel.app/art-gallery";
    public RestClient _client;

    public RestClientService()
    {
        _client = new RestClient();
    }

    public async Task<List<ArtGalleryModel>> GetArtGallery()
    {
        RestRequest request = new RestRequest(endpoint, Method.Get);
        var response = await _client.ExecuteAsync(request);

        string content = response.Content!;
        return JsonConvert.DeserializeObject<List<ArtGalleryModel>>(content)!;
    }

    public async Task<DetailArtGallery> GetArtGalleryById(int id)
    {
        RestRequest request = new RestRequest($"{endpoint}/{id}", Method.Get);
        var response = await _client.ExecuteAsync(request);

        string content = response.Content!;
        return JsonConvert.DeserializeObject<DetailArtGallery>(content)!;
    }
}
