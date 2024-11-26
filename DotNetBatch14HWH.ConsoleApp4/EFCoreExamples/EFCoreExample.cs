using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetBatch14HWH.ConsoleApp4.EFCoreExamples
{
    public class EFCoreExample
    {
        private readonly AppDbContext _db = new AppDbContext();

        public void Read()
        {
            var lst = _db.blogs.ToList();

            if (lst.Count < 1)
            {
                Console.WriteLine("No Record found");
            }
            else
            {
                foreach (var item in lst)
                {

                    Console.WriteLine(item.Id);
                    Console.WriteLine(item.Title);
                    Console.WriteLine(item.Author);
                    Console.WriteLine(item.Content);
                    Console.WriteLine("");
                }
            }
            Console.ReadLine();
        }

        public void Edit(string id)
        {
            var item = _db.blogs.AsNoTracking().Where(x => x.Id == id).FirstOrDefault();
            if (item is null)
            {
                Console.WriteLine("No Record found");
            }
            else
            {
                Console.WriteLine(item.Id);
                Console.WriteLine(item.Title);
                Console.WriteLine(item.Author);
                Console.WriteLine(item.Content);
                Console.WriteLine("");

            }
            Console.ReadLine();
        }

        public void Create(string title, string author, string content)
        {
            var b = new TblBlog { Id = Guid.NewGuid().ToString(), Title = title, Author = author, Content = content };
            _db.Add(b);
            var result = _db.SaveChanges() ;

            if (result > 0)
            {
                Console.WriteLine("create success");
            }
            else
            {
                Console.WriteLine("create fail");
            }
            Console.ReadLine();
        }

        public void Update(string id, string title, string author, string content)
        {
            var item = _db.blogs.AsNoTracking().FirstOrDefault(x => x.Id == id);

            Console.WriteLine(_db.Entry(item).State);
            if (item is null)
            {
                Console.WriteLine("No data found.");
                return;
            }

            item.Title = title;
            item.Author = author;
            item.Content = content;

            _db.Entry(item).State = EntityState.Modified;
            var result = _db.SaveChanges();

            string message = result > 0 ? "Updating Successful." : "Updating Failed.";
            Console.WriteLine(message);
        }
        public void Delete(string id) 
        { 
            var item = _db.blogs.AsNoTracking().Where(x => x.Id == id).FirstOrDefault();
            if (item is null)
            {
                Console.WriteLine("No Record found");
            }
            _db.Entry(item).State = EntityState.Deleted;
            var result = _db.SaveChanges();

            if (result > 0)
            {
                Console.WriteLine("delete success");
            }
            else
            {
                Console.WriteLine("delete fail");
            }
            Console.ReadLine();
        }

    }
}

