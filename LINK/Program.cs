using System;

namespace LINK
{
    class Program
    {
        static void Main(string[] args)
        {
            // Instantiate the Samples ViewModel
            // SamplesViewModel vm = new SamplesViewModel
            SalesSampleModelView vm = new SalesSampleModelView
            {
                // Use Query or Method Syntax?
                UseQuerySyntax = true
            };

            // Call a sample method
            vm.Concat();

            // Display Product Collection
            foreach (var item in vm.Products)
            {
                Console.Write(item.ToString());
            }

            // Display Result Text
            Console.WriteLine(vm.ResultText);
        }
    }
}
