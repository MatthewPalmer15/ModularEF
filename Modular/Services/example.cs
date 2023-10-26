using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modular.Core.Services
{
    public class example
    {
        async Task MainAsync()
        {
            Task task1 = Function1(); // Run Function1 asynchronously
            Task<bool> task2 = Function2(); // Run Function2 asynchronously

            await task2; // Wait for Function2 to finish

            if (task2.Result) // Check the result of Function2
            {
                Task<string> task3 = Function3(); // Run Function3 asynchronously
                Task<int> task4 = Function4(); // Run Function4 asynchronously

                await Task.WhenAll(task3, task4); // Wait for both Function3 and Function4 to finish

                string result3 = await task3; // Get the result of Function3
                int result4 = await task4; // Get the result of Function4
            }
        }

        async Task Function1()
        {
            // Your asynchronous code for Function1
        }

        async Task<bool> Function2()
        {
            // Your asynchronous code for Function2
            return true; // Replace with the actual result
        }

        async Task<string> Function3()
        {
            // Your asynchronous code for Function3
            return "Result from Function3"; // Replace with the actual result
        }

        async Task<int> Function4()
        {
            // Your asynchronous code for Function4
            return 42; // Replace with the actual result
        }

    }
}
