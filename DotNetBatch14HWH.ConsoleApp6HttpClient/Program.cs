// See https://aka.ms/new-console-template for more information
using DotNetBatch14HWH.ConsoleApp6HttpClient;

Console.WriteLine("Hello, World!");

//string endpoint = "https://localhost:7184/api/blog";
//HttpClient client = new HttpClient();
//HttpResponseMessage response = await client.GetAsync(endpoint);
//if (response.IsSuccessStatusCode)
//{
//    string json = await response.Content.ReadAsStringAsync();// json or content
//    Console.WriteLine(json);
//}

BlogRestClientService rest = new BlogRestClientService();
var result = rest.CreateBlog(new BlogModel()
{
    BlogAuthor = "a",
    BlogContent = "c",
    BlogTitle = "t"
});

Console.WriteLine(result);
Console.WriteLine("");
Console.ReadLine();