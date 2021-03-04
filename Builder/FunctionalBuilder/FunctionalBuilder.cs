using System;
using System.Collections.Generic;
using System.Linq;

namespace design_patterns_udemy.Builder.FunctionalBuilder
{
    public abstract class FunctionalBuilder<TSubject, TSelf>
        where TSelf : FunctionalBuilder<TSubject, TSelf>
        where TSubject: new()
    {
        private readonly List<Func<Person2, Person2>> actions 
             = new List<Func<Person2, Person2>>();

        public TSelf Do(Action<Person2> action)
            => AddAction(action);

        public Person2 Build()
            => actions.Aggregate(new Person2(), (p, f) => f(p));

        private TSelf AddAction(Action<Person2> action)
        {
            actions.Add(p => { action(p); 
                            return p;
                        });
            return (TSelf) this;            
        }
    }

    public sealed class PersonBuilder3
        : FunctionalBuilder<Person2, PersonBuilder3>
    {
        public PersonBuilder3 Called(string name)
            => Do(p => p.Name = name);
    }

    // extending
    public static class PersonBuilderExtensions2{
        public static PersonBuilder3 WorksAs2
            (this PersonBuilder3 builder, string position)
            => builder.Do(p => p.Position = position);
    }
}
