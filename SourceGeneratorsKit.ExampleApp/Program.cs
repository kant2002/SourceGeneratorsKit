using System;

namespace SourceGeneratorsKit.ExampleApp
{
    class Program
    {
        [Magic]
        static void Main(string[] args)
        {
            Console.WriteLine("Magic methods: {0}!", Magic.GetMagicMethods());
        }

        [Magic]
        static void CustomMethod()
        {
            // do nothing. Just for attribute magic.
        }
    }
}
