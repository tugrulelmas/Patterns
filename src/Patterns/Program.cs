using System;

namespace Patterns
{
    class Program
    {
        static void Main(string[] args) {
            IPizza pizza = new Ham(new Mozzeralla(new PlainPizza()));
            Console.WriteLine(pizza.Description);
            Console.WriteLine(pizza.Cost);

            Console.ReadLine();
        }
    }
}
