﻿using System;
using design_patterns_udemy.Builder;
using design_patterns_udemy.Builder.NormalBuilder;

namespace design_patterns_udemy
{
    class Program
    {
        static void Main(string[] args)
        {
            // Builder
            var builder = new HtmlBuilder("ul");
            builder.AddChild("li", "Hello").AddChild("li", "World");
            Console.WriteLine(builder.ToString());

            // working with inheritance of fluent interfaces
            var builder2 = new PersonJobBuilder();
            // builder2.Called("John").WorkAs("baker"); // Error
                
        }
    }
}
