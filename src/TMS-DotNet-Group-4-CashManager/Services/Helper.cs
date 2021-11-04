using Bogus;
using System;
using System.Collections.Generic;
using TMS_DotNet_Group_4_CashManager.Models;

namespace TMS_DotNet_Group_4_CashManager.Services
{
    public class Helper : DataSet
    {
        public static int GetRandomValue(int minValue, int maxValue)
        {
            var random = new Random();
            return random.Next(minValue, maxValue);
        }

        public IEnumerable<Product> GetRandomProducts()
        {
            string[] inventories = { "bag", "cart", "basket" };
            string inventory = this.Random.ArrayElement(inventories);

            int maxRandomValue = default;
            switch (inventory)
            {
                case "bag":
                    maxRandomValue = 1;
                    break;

                case "cart":
                    maxRandomValue = 5;
                    break;

                case "basket":
                    maxRandomValue = 10;
                    break;
            }
            var random = new Random();
            var product = new[] { "fruits", "meat", "vegetables", "milk", "meat" };

            var productFaker = new Faker<Product>()
               .RuleFor(product => product.Name, faker => faker.PickRandom(product))
               .RuleFor(product => product.Price, faker => faker.Random.Number(10, 50));

            var result = productFaker.Generate(random.Next(1, maxRandomValue));

            return result;
        }

        public static IEnumerable<Customer> GetRandomCustomers()
        {
            var random = new Random();
            var result = new List<Customer>();

            for (int i = 0; i < random.Next(1, 10); i++)
            {
                result.Add(new Customer());
            }

            return result;
        }
    }
}