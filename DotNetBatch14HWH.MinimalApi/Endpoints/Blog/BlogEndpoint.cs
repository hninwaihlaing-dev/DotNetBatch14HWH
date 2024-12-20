using DotNetBatch14HWH.Shared;
using Microsoft.Identity.Client;
using System.Diagnostics.CodeAnalysis;

namespace DotNetBatch14HWH.MinimalApi.Endpoints.Blog
{
    public static class BlogEndpoint
    {
        public static void UseBlogEndPoint(this IEndpointRouteBuilder app)
        {
            app.MapGet("/api/blog", () =>
            {
                BlogEFCoreService blogEFCoreService = new BlogEFCoreService();
                var model = blogEFCoreService.GetBlogs();

                return Results.Ok(model);
            })
            .WithName("GetBlogs")
            .WithOpenApi();

            app.MapGet("/api/blog/{id}", (string id) =>
            {
                BlogEFCoreService blogEFCoreService = new BlogEFCoreService();
                var model = blogEFCoreService.GetBlog(id);

                return Results.Ok(model);
            })
            .WithName("GetBlog")
            .WithOpenApi();


            app.MapPost("/api/blog", (BlogModel RequestModle) =>
            {
                BlogEFCoreService blogEFCoreService = new BlogEFCoreService();
                var model = blogEFCoreService.CreateBlog(RequestModle);

                return Results.Ok(model);
            })
            .WithName("CreateBlog")
            .WithOpenApi();


            app.MapPatch("/api/blog/{id}", (string id, BlogModel RequestModle) =>
            {
                RequestModle.BlogId = id;
                BlogEFCoreService blogEFCoreService = new BlogEFCoreService();
                var model = blogEFCoreService.UpdateBlog(RequestModle);

                return Results.Ok(model);
            })
            .WithName("UpdateBlog")
            .WithOpenApi();


            app.MapDelete("/api/blog/{id}", (string id) =>
            {
                BlogEFCoreService blogEFCoreService = new BlogEFCoreService();
                var model = blogEFCoreService.DeleteBlog(id);

                return Results.Ok(model);
            })
            .WithName("DeleteBlog")
            .WithOpenApi();
        }


        //Way to write Extension
        //public static void MapDelete(this IEndpointRouteBuilder endpoints)
        //{

        //}

        //public static IEndpointConventionBuilder MapHee(this IEndpointRouteBuilder endpoints, [StringSyntax("Route")] string pattern, RequestDelegate requestDelegate)
        //{
        //    return null;
        //}
    }



    //public static class DevCode
    //{
    //    public static decimal ToDecimal(this string value)
    //    {
    //        try
    //        {
    //            return Convert.ToDecimal(value);
    //        }
    //        catch (Exception ex) 
    //        {
    //            return 0;
    //        } 
    //    } 
    //}
}
