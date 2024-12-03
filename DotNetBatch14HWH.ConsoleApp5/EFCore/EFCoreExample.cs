using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetBatch14HWH.ConsoleApp5.EFCore;

public class EFCoreExample
{
    AppDbContext _db = new AppDbContext();

    public void Read()
    {
        var lst = _db.Blogs.ToList();

        if (lst.Count == 0)
        {
            Console.WriteLine("No record found");
            return;
        }
        else if (lst.Count > 0)
        {
            foreach (var item in lst)
            {
                Console.WriteLine(item.BlogId);
                Console.WriteLine(item.BlogTitle);
                Console.WriteLine(item.BlogAuthor);
                Console.WriteLine(item.BlogContent + "\n");
            }
        }
    }

    public void Edit(string id)
    {
        var item = _db.Blogs.Where(x => x.BlogId == id).FirstOrDefault();

        if (item is null)
        {
            Console.WriteLine("No record found");
            return;
        }
        else if (item is not null)
        {
            Console.WriteLine(item.BlogId);
            Console.WriteLine(item.BlogTitle);
            Console.WriteLine(item.BlogAuthor);
            Console.WriteLine(item.BlogContent + "\n");
        }
    }

    public void Create(string title, string author, string content)
    {
        var item = new BlogDto()
        {
            BlogId = Guid.NewGuid().ToString(),
            BlogTitle = title,
            BlogAuthor = author,
            BlogContent = content
        };
        _db.Blogs.Add(item);
        int result = _db.SaveChanges();
        string message = result > 0 ? "Create success" : "Create fail";
        Console.WriteLine(message); 
    }

    public void Update(string id, string title, string author, string content)
    {
        var item = _db.Blogs.Where(x => x.BlogId == id).FirstOrDefault();

        if (item is null)
        {
            Console.WriteLine("No record found");
            return;
        }
        else if (item is not null)
        {
            item.BlogAuthor = author;
            item.BlogContent = content;
            item.BlogTitle = title;

            _db.Entry(item).State = EntityState.Modified;
            int result = _db.SaveChanges();

            string message = result > 0 ? "Update success" : "Update fail";
            Console.WriteLine(message);
        }
    }
    public void Delete(string id)
    {
        var item = _db.Blogs.Where(x => x.BlogId == id).FirstOrDefault();
        if (item is null)
        {
            Console.WriteLine("No Record found");
        }
        _db.Entry(item).State = EntityState.Deleted;
        int result = _db.SaveChanges();

        string message = result > 0 ? "Delete success" : "Delete fail";
        Console.WriteLine(message);
    }
}

