using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modular.Core.Services
{
    public class example
    {

        public async Task Function1()
        {
            // Do Something
        }

        public async Task<bool> Function2()
        {
            // Do Something
            return true;
        }

        public async Task<string> Function3()
        {
            // Do Something
            return "Hello World";
        }

        public async void Test()
        {
            Function1(); // Runs this in separate thread, but does not wait for it to finish

            bool test = await Function2(); // Runs this in separate thread, and waits for it to finish

            if (test)
            {
                string test2 = await Function3(); // Runs this in separate thread, and waits for it to finish
            }
        }

    }
}
