using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    class cars
    {
        public string color = "red";
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("{1} and {0}" ,byte.MinValue , byte.MaxValue);
            cars mycar = new cars();
            Console.WriteLine(mycar.color);
        }
    }   
}