using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SaltNPepa.Data;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using SaltNPepa.Data.Models;
using SaltNPepa.Data.Models.Enum;

namespace Sandbox
{
    public static class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.WriteLine($"{typeof(Program).Namespace} ({string.Join(" ", args)}) starts working...");
            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);
            IServiceProvider serviceProvider = serviceCollection.BuildServiceProvider(true);

            using (var serviceScope = serviceProvider.CreateScope())
            {
                serviceProvider = serviceScope.ServiceProvider;
                SandboxCode(serviceProvider);
            }
        }

        private static void SandboxCode(IServiceProvider serviceProvider)
        {
            // TODO: code here
            SeedEnums(serviceProvider);
            SeedProducts(serviceProvider);
        }

        private static void SeedProducts(IServiceProvider serviceProvider)
        {
            const int NUMBER_OF_PRODUCTS_TO_SEED = 7;

            var db = serviceProvider.GetService<SaltNPepaContext>();

            var drinksCategory = db.Categories.FirstOrDefault(x => x.Name == ProductType.Drinks);
            var saladsCategory = db.Categories.FirstOrDefault(x => x.Name == ProductType.Salads);
            var startersCategory = db.Categories.FirstOrDefault(x => x.Name == ProductType.Starters);
            var burgersCategory = db.Categories.FirstOrDefault(x => x.Name == ProductType.Burgers);
            var chickenCategory = db.Categories.FirstOrDefault(x => x.Name == ProductType.Chicken);
            var pastaCategory = db.Categories.FirstOrDefault(x => x.Name == ProductType.Pasta);
            var dessertsCategory = db.Categories.FirstOrDefault(x => x.Name == ProductType.Desserts);

            if (!db.Products.Any(x=>x.Category==saladsCategory))
            {
                var salads = new List<Product>();

                for (int i = 1; i <= NUMBER_OF_PRODUCTS_TO_SEED; i++)
                {
                    Product salad = new Product()
                    {
                        Picture = $"https://res.cloudinary.com/dbnssecqq/image/upload/v1546998771/Menu/Salads/{i}.png",
                        Category = saladsCategory
                    };
                    if (i==1)
                    {
                        salad.Name = "SHOPSKA SALAD";
                        salad.Details = "Tomatoes, cucumbers, cheese, red onions, parsley, olive oil.";
                        salad.Price = 5.59m;
                    }
                    if (i == 2)
                    {
                        salad.Name = "CESAR SALAD";
                        salad.Details = "Green salad, yellow cheese, croutons, crispy chicken, parmesan, Ceaser sauce with anchovies.";
                        salad.Price = 6.99m;
                    }
                    if (i == 3)
                    {
                        salad.Name = "HEALTHY SALAD";
                        salad.Details = "Spinach, carrots, beetroot, tomatoes, sesame, soy - mustard dressing,  Philadelphia mousse with dill.";
                        salad.Price = 7.59m;
                    }
                    if (i == 4)
                    {
                        salad.Name = "SALAD WITH AVOCADO";
                        salad.Details = "Einkorn, peeled tomatoes, arugula, avocado, balsamic soy - mustard dressing.";
                        salad.Price = 6.29m;
                    }
                    if (i == 5)
                    {
                        salad.Name = "GREEK SALAD";
                        salad.Details = "Tomatoes, cucumbers, cheese, red onions, parsley, olive oil.";
                        salad.Price = 5.99m;
                    }
                    if (i == 6)
                    {
                        salad.Name = "SALAD WITH CINOA";
                        salad.Details = "Quinoa, white fish, green salad, tomatoes, egg, roasted pepper, white cheese, croutons and soy-mustard dressing.";
                        salad.Price = 7.59m;
                    }
                    if (i == 7)
                    {
                        salad.Name = "SALAD WITH TUNA";
                        salad.Details = "Green salad, tomatoes, cucumbers, tuna fish, egg, olives, corn, sauce Vinegar and Feta.";
                        salad.Price = 6.99m;
                    }
                    salads.Add(salad);
                }
                db.Products.AddRange(salads);
                db.SaveChanges();
            }


        }

        private static void SeedEnums(IServiceProvider serviceProvider)
        {
            var db = serviceProvider.GetService<SaltNPepaContext>();
            
            if (!db.Categories.Any())
            {
                var productTypes = new List<ProductType>()
                {
                    ProductType.Drinks,
                    ProductType.Salads,
                    ProductType.Starters,
                    ProductType.Chicken,
                    ProductType.Burgers,
                    ProductType.Pasta,
                    ProductType.Desserts
                };

                var categories = new List<Category>();

                foreach (var type in productTypes.OrderBy(x=>x.GetTypeCode()))
                {
                    Category category = new Category()
                    {
                        Name = type
                    };
                    categories.Add(category);
                }

                db.Categories.AddRange(categories);
                db.SaveChanges();
            }

            if (!db.Cities.Any())
            {
                var cityNames = new List<CityName>()
                {
                CityName.Burgas,
                CityName.Plovdiv,
                CityName.Sofia,
                CityName.StaraZagora,
                CityName.Varna
                };

                var cities = new List<City>();

                foreach (var cityName in cityNames)
                {
                    City city = new City()
                    {
                        Name = cityName
                    };
                    cities.Add(city);
                }

                db.Cities.AddRange(cities);
                db.SaveChanges();
            }

            if (!db.Statuses.Any())
            {
                var deliveryStatuses = new List<DeliveryStatus>()
                {
                    DeliveryStatus.Approved,
                    DeliveryStatus.AwaitingАpproval,
                    DeliveryStatus.CookingProcess,
                    DeliveryStatus.Delivered,
                    DeliveryStatus.Delivery,
                    DeliveryStatus.QualityCheck
                };

                var statuses = new List<Status>();

                foreach (var deliveryStatus in deliveryStatuses)
                {
                    Status status = new Status()
                    {
                        StatusName = deliveryStatus
                    };
                    statuses.Add(status);
                }

                db.Statuses.AddRange(statuses);
                db.SaveChanges();
            }
        }

        private static void ConfigureServices(ServiceCollection serviceCollection)
        {
            var configuration = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
                   .AddJsonFile("appsettings.json", false, true)
                   .AddEnvironmentVariables()
                   .Build();

            serviceCollection.AddDbContext<SaltNPepaContext>(options =>
                options.UseSqlServer(
                    configuration.GetConnectionString("DefaultConnection")));
        }
    }
}
