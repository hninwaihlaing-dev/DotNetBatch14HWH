// See https://aka.ms/new-console-template for more information
using DotNetBatch14HWH.ConsoleApp6HttpClient;
using DotNetBatch14HWH.ConsoleApp6HttpClient.ArtGallery;
using DotNetBatch14HWH.ConsoleApp6HttpClient.JsonPlaceHolderExample;
using System.Data;

Console.WriteLine("Hello, World!");

//string endpoint = "https://localhost:7184/api/blog";
//HttpClient client = new HttpClient();
//HttpResponseMessage response = await client.GetAsync(endpoint);
//if (response.IsSuccessStatusCode)
//{
//    string json = await response.Content.ReadAsStringAsync();// json or content
//    Console.WriteLine(json);
//}

//BlogRestClientService rest = new BlogRestClientService();
//var result = rest.CreateBlog(new BlogModel()
//{
//    BlogAuthor = "a",
//    BlogContent = "c",
//    BlogTitle = "t"
//});

//Console.WriteLine(result);
//Console.WriteLine("");
//Console.ReadLine();



//Start JsonPlaceHolder
JsonRefitClientService servie = new JsonRefitClientService();
var Jsonlst = await servie.GetData();
foreach (var Json in Jsonlst)
{ 
    Console.WriteLine("Id : " + Json.id + "/nUserId :" + Json.userId + "\nTitle : " + Json.title + "\nBody : " + Json.body);
}
Console.WriteLine("---------------------------------------------");

var JsonItem = await servie.GetDataById(3);
Console.WriteLine("Id : " + JsonItem.id + "/nUserId :" + JsonItem.userId + "\nTitle : " + JsonItem.title + "\nBody : " + JsonItem.body);

Console.WriteLine("---------------------------------------------");
var ResponseModel = await servie.CreateData(new JsonPlaceHolderDataModel()
{
    title = "Hey",
    body = "Hey"
});
Console.WriteLine("Id : " + ResponseModel.id + "/nUserId :" + ResponseModel.userId + "\nTitle : " + ResponseModel.title + "\nBody : " + ResponseModel.body);

Console.WriteLine("---------------------------------------------");

var Response = await servie.UpdateData(5, new JsonPlaceHolderDataModel()
{
    title = "Hey",
    body = "Hey"
});
Console.WriteLine("Id : " + Response.id + "/nUserId :" + Response.userId + "\nTitle : " + Response.title + "\nBody : " + Response.body);

Console.WriteLine("---------------------------------------------");

var Reply = await servie.DeleteData(2);
if(Reply != null)
{

    Console.WriteLine("Id : " + Reply.id + "/nUserId :" + Reply.userId + "\nTitle : " + Reply.title + "\nBody : " + Reply.body);

    Console.WriteLine("---------------------------------------------");
}


Console.ReadLine();

//End JsonPlaceHolder


//Start Art Gallery
IRefitClientService Refit = new HttpClientService();
var GalleryList = await Refit.GetArtGallery();
foreach(var GalleryItem in GalleryList)
{
    Console.WriteLine(GalleryItem.ArtId + "\t" + GalleryItem.ArtName + "\t" + GalleryItem.ArtDescription + "\t" + GalleryItem.ArtImageUrl);

}

var ArtItem = await Refit.GetArtGalleryById(24);
var ArtistModel = ArtItem.Artist;
var Arts = ArtItem.Arts;
Console.WriteLine(ArtistModel.ArtistId + "\t" + ArtistModel.ArtistName + "\t" + ArtistModel.Social[0] + "\t" + ArtistModel.Social[1]);
foreach(var Art in Arts)
{
    Console.WriteLine(Art.ArtId + "\t" + Art.ArtName + "\t" + Art.ArtDescription + "\t" + Art.ArtImageUrl);
}

Console.ReadLine();
//End Art Gallery


BlogRefitClientService refit = new BlogRefitClientService();
var lst = await refit.GetBlogs();
var Data = lst.Data;
foreach (var row in Data)
{
    Console.WriteLine("BlogId : " + row.BlogId + " BlogTitle :" + row.BlogTitle
        + " Blog Author : " + row.BlogAuthor + " BlogContent : " + row.BlogContent);
}


Console.WriteLine("//////////");
var item = await refit.GetBlog("18975EE1-D54D-4DD8-85CE-D0FF722D27A8");
var data = item.Data;
Console.WriteLine("BlogId : " + data.BlogId + " BlogTitle :" + data.BlogTitle
    + " Blog Author : " + data.BlogAuthor + " BlogContent : " + data.BlogContent);
Console.WriteLine("//////////");

var model = await refit.CreateBlog(new BlogModel()
{
    BlogTitle = "model",
    BlogAuthor = "model",
    BlogContent = "model",
});
Console.WriteLine(model.IsSuccess + "\n" + model.Message);
Console.WriteLine("//////////");

var UpdateModel = await refit.PatchBlog("11B6E2A9-250A-417A-ACF6-9FA02EA41C19", new BlogModel()
{
    BlogTitle = "model",
    BlogAuthor = "model",
    BlogContent = "model",
});
Console.WriteLine(UpdateModel.IsSuccess + "\n" + UpdateModel.Message);

var DeleteModel = await refit.DeleteBlog("11B6E2A9-250A-417A-ACF6-9FA02EA41C19");
Console.WriteLine(DeleteModel.IsSuccess + "\n" + DeleteModel.Message);

Console.ReadLine();






