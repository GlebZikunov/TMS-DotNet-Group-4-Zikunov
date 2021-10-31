using System;
using System.Threading;
using TMS_DotNet_Group_4_CashManager.Models;

namespace TMS_DotNet_Group_4_CashManager
{
    class Program
    {
        static void Main(string[] args)
        {
            var shop = new Shop();

            shop.Start();
        }
    }
}
