using System;
using System.Collections.Generic;
using System.Linq;

namespace design_patterns_udemy.Builder.FunctionalBuilder
{
    public class Person2 {
        public string Name, Position;
    }

    // extending
    public static class PersonBuilderExtensions{
        public static PersonBuilder2 WorksAs
            (this PersonBuilder2 builder, string position)
            => builder.Do(p => p.Position = position);
    }

    // force the OCP principle
    public sealed class PersonBuilder2
    {
        private readonly List<Func<Person2, Person2>> actions 
             = new List<Func<Person2, Person2>>();

        public PersonBuilder2 Called(string name)
            => Do(p => p.Name = name);

        public PersonBuilder2 Do(Action<Person2> action)
            => AddAction(action);

        public Person2 Build()
            => actions.Aggregate(new Person2(), (p, f) => f(p));

        private PersonBuilder2 AddAction(Action<Person2> action)
        {
            actions.Add(p => { action(p); 
                            return p;
                        });
            return this;            
        }
    }
}
