using System;
using design_patterns_udemy.Behavioral.Strategy.Basic;
using design_patterns_udemy.Builder;
using design_patterns_udemy.Builder.FunctionalBuilder;
using design_patterns_udemy.Builder.NormalBuilder;

namespace design_patterns_udemy
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
                Strategy:
            */
            var mallardDuck = new MallardDuck();
            mallardDuck.swim();
            mallardDuck.display();
            mallardDuck.performFly();
            mallardDuck.performQuack();            

            var rubberDuck = new RubberDuck();
            mallardDuck.swim();
            rubberDuck.display();
            rubberDuck.performFly();
            rubberDuck.performQuack();            
            rubberDuck.setFlyBehavior(new FlyRocket());
            rubberDuck.performFly();

            /* 
                Builder
            */
            var builder = new HtmlBuilder("ul");
            builder.AddChild("li", "Hello").AddChild("li", "World");
            Console.WriteLine(builder.ToString());

            // working with inheritance of fluent interfaces
            // var builder2 = new PersonJobBuilder();
            // builder2.Called("John").WorkAs("baker"); // Error
            // using recursive generics   
            var p = Person.New
                .Called("John")            
                .WorkAsA("baker")
                .Build();
            Console.WriteLine(p);

            // using Functional Builder
            var person = new PersonBuilder2()
                .Called("Sarah")
                .WorksAs("developer")
                .Build();

            // Functional Builder
           var person2 = new PersonBuilder3()
                .Called("Sarah")
                .WorksAs2("developer")
                .Build();                
        }
    }
}
