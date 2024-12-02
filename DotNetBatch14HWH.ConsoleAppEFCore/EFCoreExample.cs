using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetBatch14HWH.ConsoleAppEFCore
{
    internal class EFCoreExample
    {
        private readonly AppDbContext db = new AppDbContext();
        public void Read()
        {
            var productlist = db.Products.ToList();

            if (productlist.Count < 1)
            {
                Console.WriteLine("No record found");
                return;
            }
            foreach (var product in productlist)
            {
                Console.WriteLine("Prodcut ID : " + product.Id);
                Console.WriteLine("Prodcut Name : " + product.Name);
                Console.WriteLine("Price : " + product.Price);
                Console.WriteLine("Quantity :" + product.Quantity);
            }
            Console.WriteLine("\n");
        }
        public void Edit(int id)
        {
            var item = db.Products.FirstOrDefault(x => x.Id == id);

            if (item is null)
            {
                Console.WriteLine("No record found");
                return;
            }
            Console.WriteLine("Prodcut ID : " + item.Id);
            Console.WriteLine("Prodcut Name : " + item.Name);
            Console.WriteLine("Price : " + item.Price);
            Console.WriteLine("Quantity :" + item.Quantity);


            Console.WriteLine("\n");
        }

        public void Create(string name, double price, int qty)
        {
            var pt = new Product {Name = name, Price = price, Quantity = qty };

            db.Products.Add(pt);
            var result = db.SaveChanges();

            if (result > 0)
            {
                Console.WriteLine("create success\n");
            }
            else
            {
                Console.WriteLine("create faile\n");
            }
        }

        public void Update(int id, string name, double price, int qty)
        {
            var item = db.Products.FirstOrDefault(x => x.Id == id);

            if (item is null)
            {
                Console.WriteLine("No record found");
                return;
            }

            item.Name = name; 
            item.Price = price; 
            item.Quantity = qty;

            db.Entry(item).State = EntityState.Modified;
            var result = (int)db.SaveChanges();

            string msg = result > 0? "Update success" : "Update Fail";

            Console.WriteLine(msg +"\n");
        }

        public void Delete(int id)
        {
            var item = db.Products.FirstOrDefault(x => x.Id == id);

            if (item is null)
            {
                Console.WriteLine("No record found");
                return;
            }
            db.Entry(item).State = EntityState.Deleted;
            var result = (int)db.SaveChanges();

            string msg = result > 0 ? "Delete success" : "Delete Fail";

            Console.WriteLine(msg +"\n");
        }
    }
}

