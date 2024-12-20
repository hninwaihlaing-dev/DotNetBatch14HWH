using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetBatch14HWH.ConsoleApp6HttpClient.ArtGallery;

internal class RefitClientService : IRefitClientService
{
    private readonly string endpoint = "https://burma-project-ideas.vercel.app/";
    private readonly IArtGalleryApi _api;

    public RefitClientService()
    {
        _api = RestService.For<IArtGalleryApi>(endpoint);
    }

    public async Task<List<ArtGalleryModel>> GetArtGallery()
    {
        var model = await _api.GetArtGallery();
        return model;
    }

    public async Task<DetailArtGallery> GetArtGalleryById(int id)
    {
        var model = await _api.GetArtGalleryById(id);
        return model;
    }
}


public interface IArtGalleryApi
{
    [Get("/art-gallery")]
    Task<List<ArtGalleryModel>> GetArtGallery();

    [Get("/art-gallery/{id}")]
    Task<DetailArtGallery> GetArtGalleryById(int id);
}