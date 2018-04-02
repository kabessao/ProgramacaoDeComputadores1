using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Timers;

namespace Testes
{
    class Program
    {
        
        static void Main(string[] args)
        {
            Timer timer = new Timer();
            timer.Interval = 1;
            timer.Elapsed += (s, e) => Console.WriteLine(System.Environment.TickCount);
            timer.Start();
        }
    }
}
