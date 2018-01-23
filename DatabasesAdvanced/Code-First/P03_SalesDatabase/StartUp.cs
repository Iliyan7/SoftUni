using Microsoft.EntityFrameworkCore;
using P03_SalesDatabase.Data.Models;
using System;

namespace P03_SalesDatabase
{
    public class Program
    {
        public static void Main()
        {
            using (var db = new SalesContext())
            {
                try
                {
                    db.Database.Migrate();

                    Console.WriteLine("Database successfully created/updated!");

                    //SeedDB(db);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }

        private static void SeedDB(SalesContext db)
        {
            SeedProduct(db);
            SeedCustomer(db);
            SeedStore(db);
            SeedSale(db);
        }

        private static void SeedProduct(SalesContext db)
        {
            db.Prodcuts.Add(new Product() { Name = "Kola", Quantity = 5, Price = 1.2M });
            db.Prodcuts.Add(new Product() { Name = "Vafla borec", Quantity = 10, Price = 0.5M });
            db.Prodcuts.Add(new Product() { Name = "Qica ot chafka", Quantity = 30, Price = 5.0M });

            db.SaveChanges();
        }

        private static void SeedCustomer(SalesContext db)
        {
            db.Customers.Add(new Customer() { Name = "Ivancheto", Email = "ivanka@gmail.com", CreditCardNumber = "423142873181331" });
            db.Customers.Add(new Customer() { Name = "Todor", Email = "ttodor@gmail.com", CreditCardNumber = "121401393190310" });

            db.SaveChanges();
        }

        private static void SeedStore(SalesContext db)
        {
            db.Stores.Add(new Store() { Name = "Magazina na bay ganio" });
            db.Stores.Add(new Store() { Name = "24h e-mag" });

            db.SaveChanges();

        }
        private static void SeedSale(SalesContext db)
        {
            db.Sales.Add(new Sale() { ProductId = 1, CustomerId = 1, StoreId = 1 });
            db.Sales.Add(new Sale() { ProductId = 1, CustomerId = 1, StoreId = 2 });
            db.Sales.Add(new Sale() { ProductId = 2, CustomerId = 2, StoreId = 1 });
            db.Sales.Add(new Sale() { ProductId = 3, CustomerId = 2, StoreId = 1 });

            db.SaveChanges();
        }
    }
}
