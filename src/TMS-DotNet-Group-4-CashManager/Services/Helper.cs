using Bogus;
using System;
using System.Collections.Generic;
using TMS_DotNet_Group_4_CashManager.Models;

namespace TMS_DotNet_Group_4_CashManager.Services
{
    public class Helper
    {
        public static int GetRandomValue(int minValue, int maxValue)
        {
            var random = new Random();
            return random.Next(minValue, maxValue);
        }

        public static IEnumerable<Product> GetRandomProducts()
        {
            var random = new Random();
            var fruit = new[] { "apple", "banana", "orange", "strawberry", "kiwi" };

            var productFaker = new Faker<Product>()
               .RuleFor(product => product.Name, faker => faker.PickRandom(fruit))
               .RuleFor(product => product.Price, faker => faker.Random.Number(10, 50));

            var result = productFaker.Generate(random.Next(1, 20));
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
