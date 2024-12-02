using DotNetBatch14HWH.ContosoPizza.Data;
using DotNetBatch14HWH.ContosoPizza.Models;
using System.Diagnostics;
using ContosoPizzaContext context = new ContosoPizzaContext();

//Product veggieSpecial = new Product()
//{
//    Name = "Veggie Special Pizza",
//    Price = 9.99M
//};
//context.Products.Add(veggieSpecial);

//Product deluxeMeat = new Product()
//{
//    Name = "Deluxe Meat Pizza",
//    Price = 9.99M
//};
//context.Products.Add(deluxeMeat);

//context.SaveChanges();


var productlist = context.Products.Where(x => x.Price < 10M).OrderBy(x => x.Name);

    foreach(var product in productlist)
    {
        Console.WriteLine("Product Id "+product.Id);
        Console.WriteLine("Product Name "+ product.Name);
        Console.WriteLine("Product Price " + product.Price);
        Console.WriteLine("-------");
    }

Console.ReadLine();