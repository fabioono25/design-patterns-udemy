using System;

namespace design_patterns_udemy.Behavioral.Strategy.Basic
{
    // context class: reference to the strategy. Contains all behaviors
    // calls the execution method on the linked strategy object each time it needs to run the algorithm
    // the strategy is associated at runtime through the setters (it could be by constructor or via DI)
    public abstract class Duck
    {
        internal FlyBehavior flyBehavior;
        internal QuackBehavior quackBehavior;

        public Duck() {
        }

        public void setFlyBehavior(FlyBehavior fb) {
            flyBehavior = fb;
        }

        public void setQuackBehavior(QuackBehavior qb) {
            quackBehavior = qb;
        }

        public abstract void display();

        public void performFly() {
            flyBehavior.fly();
        }

        public void performQuack() {
            quackBehavior.quack();
        }

        public void swim() {
            Console.WriteLine("All ducks float, even decoys!");
        }
    }

    // strategy: declares a method the context uses to execute a strategy
    public interface QuackBehavior
    {
        void quack();
    }



    public interface FlyBehavior
    {
        void fly();
    }

    // concrete strategies: implement different variations of an algorithm the context uses
    public class FlyWithWings: FlyBehavior {
        public void fly() {
            Console.WriteLine("I'm flying!!");
        }
    }

    public class FlyNoway: FlyBehavior {
        public void fly() {
            Console.WriteLine("I can't fly!!");
        }
    }    

    public class FlyRocket: FlyBehavior {
        public void fly() {
            Console.WriteLine("I can fly like a rocket!!");
        }
    }      

    public class Quack: QuackBehavior {
        public void quack() {
            Console.WriteLine("Quack!!");
        }
    }      
    public class MuteQuack: QuackBehavior {
        public void quack() {
            Console.WriteLine("<<silence>>");
        }
    }      
    public class Squeak: QuackBehavior {
        public void quack() {
            Console.WriteLine("Squeak");
        }
    }    

    // client: create the specific strategy object and passes it to the context
    // the client expose a setter which lets clients replace the strategy associated with the context at runtime
    public class MallardDuck: Duck {

        public MallardDuck()
        {
            quackBehavior = new Quack();
            flyBehavior = new FlyWithWings();

        }

        public override void display() {
            Console.WriteLine("I'm a real Mallard duck");
        }
    }    
    public class ReadHeadDuck: Duck {

        public ReadHeadDuck()
        {
            quackBehavior = new Quack();
            flyBehavior = new FlyWithWings();

        }

        public override void display() {
            Console.WriteLine("I'm a real Read Headed duck");
        }
    }    
    public class RubberDuck: Duck {
        public RubberDuck()
        {
            quackBehavior = new Squeak();
            flyBehavior = new FlyNoway();
        }

        public override void display() {
            Console.WriteLine("I'm a real Mallard duck");
        }
    }  
}
