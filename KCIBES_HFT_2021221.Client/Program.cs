using KCIBES_HFT_2021221.Data;
using KCIBES_HFT_2021221.Repository;
using System;

namespace KCIBES_HFT_2021221.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            F1DbContext ctx = new F1DbContext();
            DriverRepository drepo = new DriverRepository(ctx);

            foreach (var item in drepo.GetAll())
            {
                Console.WriteLine(item.Name);
            }
            drepo.DeleteOne(1);

            Console.WriteLine("---------------");

            foreach (var item in drepo.GetAll())
            {
                Console.WriteLine(item.Name);
            }
        }
    }
}
