
namespace DotNetBatch14HWH.ConsoleApp6HttpClient.ArtGallery;

internal interface IRefitClientService
{
    Task<List<ArtGalleryModel>> GetArtGallery();
    Task<DetailArtGallery> GetArtGalleryById(int id);
}