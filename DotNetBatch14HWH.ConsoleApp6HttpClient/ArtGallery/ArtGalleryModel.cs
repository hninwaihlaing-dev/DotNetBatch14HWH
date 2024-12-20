using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetBatch14HWH.ConsoleApp6HttpClient.ArtGallery;

public class ArtGalleryModel
{
    public int ArtId { get; set; }
    public string ArtName { get; set; }
    public string ArtDescription { get; set; }
    public string ArtImageUrl { get; set; }
}


public class DetailArtGallery
{
    public ArtistModel Artist { get; set; }
    public ArtGalleryModel[] Arts { get; set; }
}

public class ArtistModel
{
    public int ArtistId { get; set; }
    public string ArtistName { get; set; }
    public SocialModel[] Social { get; set; }
    public string ArtistImageUrl { get; set; }
}

public class SocialModel
{
    public string Name { get; set; }
    public string Link { get; set; }
}
