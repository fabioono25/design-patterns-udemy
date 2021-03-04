using System;

namespace design_patterns_udemy.Builder
{
    public class Person
    {
        public string Name;
        public string Position;

        public override string ToString()
        {
            return $"{nameof(Name)}: {Name}, {nameof(Position)}: {Position}";
        }
    }

    // Fluent
    public class PersonInfoBuilder 
    {
        protected Person person = new Person();

        public PersonInfoBuilder Called(string name){
            person.Name = name;
            return this;
        }
    }

    // class with additional functionality
    public class PersonJobBuilder: PersonInfoBuilder {
        public PersonJobBuilder WorkAsA(string position){
            person.Position = position;
            return this;
        }
    }
}
