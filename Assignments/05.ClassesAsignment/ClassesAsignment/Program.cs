using System;


//Class hierarchy of real world model
namespace ClassesAsignment
{
    class Program
    {
        static void Main(string[] args)
        {
            Animal bison = new Bison { Legs = 4 };
            bison.Move(); // overriden method from Animal, but with Bison class message

            Animal kangooro = new Kangaroo(2);
            kangooro.Move(); // overriden method from animal with Kangaroo class method message and with a field value given in constructor

            Animal amBison = new AmericanBison();
            amBison.Move(); // overriden method from Animal, but with AmericanBison class message
        }
    }

    // a) & d) Creating classes hierarchy of real world model
    class Animal
    {
        public virtual void Move()
        {
            Console.WriteLine("Animal is moving");
        }
    }

    class Bison : Animal
    {
        public int Legs { get; set; }
        public override void Move()
        {
            Console.WriteLine("Bison is walking");
            Console.WriteLine("The bison have "+ this.Legs + " legs.");
        }
    }

    class Kangaroo : Animal
    {
        private int legs; // make a field private, but its value could be set with class instantiation

        public Kangaroo(int legs)
        {
            this.legs = legs;
        }
        public override void Move()
        {
            Console.WriteLine("Kangaroo is jumping");
            Console.WriteLine("The Kangaroo have "+legs+" legs.");
        }

    }

    class AmericanBison : Bison
    {
        public override void Move()
        {
            Console.WriteLine("American bison is a type of bison.");
        }
    }
}
