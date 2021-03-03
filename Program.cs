using System;
using design_patterns_udemy.Builder.NormalBuilder;

namespace design_patterns_udemy
{
    class Program
    {
        static void Main(string[] args)
        {
            // Builder
            var builder = new HtmlBuilder("ul");
            builder.AddChild("li", "Hello");
            builder.AddChild("li", "World");
            Console.WriteLine(builder.ToString());
        }
    }
}
