using SB.CarsCatalog.Api.Models;
using System.Collections.Generic;
using System.Linq;

namespace SB.CarsCatalog.Api.Data
{
    /// <summary>
    /// Helper to generate start data
    /// </summary>
    public class DataGenerator
    {
        /// <summary>
        /// Generate data
        /// </summary>
        /// <param name="context">db context</param>
        public static void Generate(CarsCatalogDbContext context, IUserService userService)
        {
            // Check if data already seeded
            if (context.Brands.Any())
                return;

            // Generate car Brands
            context.Brands.AddRange(
                new Brand()
                {
                    Founder = "Franz Josef Popp",
                    Founded = 1916,
                    Headquarters = "Munich, Bavaria, Germany",
                    Title = "BMW",
                    Overview = "BMW is a German multinational company which currently produces automobiles and motorcycles."
                },
                new Brand()
                {
                   Founded = 1903,
                   Founder = "Henry Ford",
                   Headquarters = "Dearborn, Michigan, United States",
                   Overview = "Ford Motor Company is an American multinational automaker.",
                   Title = "Ford"
                },
                new Brand()
                {
                    Headquarters = "Minato, Tokyo, Japan",
                    Founder = "Soichiro Honda",
                    Founded = 1948,
                    Overview = "Honda Motor Company Ltd. is a Japanese public multinational conglomerate corporation.",
                    Title = "Honda",
                    Models = new List<Model>()
                    {
                        new Model()
                        {
                            BodyStyle = BodyStyle.Minivan,
                            BrandId = 2,
                            Power = 110,
                            TopSpeed = 120,
                            Title = "Odyssey"
                        },
                        new Model()
                        {
                            BodyStyle = BodyStyle.Sedan,
                            BrandId = 2,
                            Power = 130,
                            TopSpeed = 140,
                            Title = "Accord"
                        }
                    }
                },
                new Brand()
                {
                    Founded = 1937,
                    Founder = "German Labour Front",
                    Headquarters = "Wolfsburg, Germany",
                    Overview = "Volkswagen, shortened to VW, is a German automaker founded on 28 May 1937 by the German Labour Front",
                    Title = "Volkswagen"
                },
                new Brand()
                {
                    Founded = 1926,
                    Founder = "Karl Benz",
                    Headquarters = "Stuttgart, Germany",
                    Overview = "Mercedes-Benz is a global automobile marque and a division of the German company Daimler AG.",
                    Title = "Mercedes-Benz"
                },
                new Brand()
                {
                    Founded = 1902,
                    Founder = "Henry M. Leland",
                    Headquarters = "New York, United States",
                    Overview = "Cadillac, formally the Cadillac Motor Car Division, is a division of the U.S.-based General Motors (GM) that markets luxury vehicles worldwide.",
                    Title = "Cadillac"
                }
                );

            context.SaveChanges();
        }
    }
}
