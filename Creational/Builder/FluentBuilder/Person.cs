using System;

namespace design_patterns_udemy.Builder
{
    public class Person
    {
        public string Name;
        public string Position;

        public class Builder: PersonJobBuilder<Builder>
        {
        }
        public static Builder New => new Builder();

        public override string ToString()
        {
            return $"{nameof(Name)}: {Name}, {nameof(Position)}: {Position}";
        }
    }

    // fix the problem for fluent inheritance classes with builder
    public abstract class PersonBuilder {
        protected Person person = new Person();
        
        public Person Build() 
        { 
            return person; 
        }
    }

    // Fluent
    public class PersonInfoBuilder<SELF>
        : PersonBuilder
        where SELF : PersonInfoBuilder<SELF> // creating a restriction
    {
        public SELF Called(string name){
            person.Name = name;
            return (SELF) this;
        }
    }

    // class with additional functionality
    public class PersonJobBuilder<SELF>
        : PersonInfoBuilder<PersonJobBuilder<SELF>> 
        where SELF : PersonJobBuilder<SELF>
    {
        public SELF WorkAsA(string position){
            person.Position = position;
            return (SELF) this;
        }
    }
}
