using System;

namespace DecoratorAssignment
{
    // The base component
    abstract class Beverage
    {
        public virtual string? Description { get; set; }

        public abstract double Cost();
    }

    // Concrete components (different coffee types)
    class HouseBlend : Beverage
    {
        public HouseBlend()
        {
            Description = "House Blend Coffee";
        }

        public override double Cost()
        {
            return 0.89;
        }
    }
    class DarkRoast : Beverage
    {
        public DarkRoast()
        {
            Description = "Dark Roast Coffee";
        }

        public override double Cost()
        {
            return 0.99;
        }
    }
    class Decaf : Beverage
    {
        public Decaf()
        {
            Description = "Decaf Coffee";
        }
        public override double Cost()
        {
            return 1.05;
        }
    }
    class Espresso : Beverage
    {
        public Espresso()
        {
            Description = "Espresso Coffee";
        }
        public override double Cost()
        {
            return 1.99;
        }
    }

    // Decorator base class
    abstract class CondimentDecorator : Beverage
    {
    }

    // Concrete decorators (condiments)
    class Milk : CondimentDecorator
    {
        private Beverage _beverage;

        public Milk(Beverage beverage)
        {
            _beverage = beverage;
        }

        public override string Description => _beverage.Description + ",Steamed Milk";

        public override double Cost()
        {
            return _beverage.Cost() + 0.20;
        }
    }

    class Mocha : CondimentDecorator
    {
        private Beverage _beverage;

        public Mocha(Beverage beverage)
        {
            _beverage = beverage;
        }

        public override string Description => _beverage.Description + ", Mocha";

        public override double Cost()
        {
            return _beverage.Cost() + 0.20;
        }
    }
    class Soy : CondimentDecorator
    {
        private Beverage _beverage;
        public Soy(Beverage beverage)
        {
            _beverage = beverage;
        }
        public override string? Description => _beverage.Description + ", Soy";

        public override double Cost()
        {
            return _beverage.Cost() + 0.15;
        }
    }
    class WhippedCream : CondimentDecorator
    {
        private Beverage _beverage;
        public WhippedCream(Beverage beverage)
        {
            _beverage = beverage;
        }
        public override string? Description => _beverage.Description + ", Whipped cream";

        public override double Cost()
        {
            return _beverage.Cost() + 0.10;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Starbuzz Coffee!");

            Console.WriteLine("Please select your coffee:");
            Console.WriteLine("1. House Blend Coffee");
            Console.WriteLine("2. Dark Roast Coffee");
            Console.WriteLine("3. Decaf Coffee");
            Console.WriteLine("4. Espresso Coffee");

            int coffeeChoice = int.Parse(Console.ReadLine());

            Beverage beverage = null;

            switch (coffeeChoice)
            {
                case 1:
                    beverage = new HouseBlend();
                    break;
                case 2:
                    beverage = new DarkRoast();
                    break;
                case 3:
                    beverage = new Decaf();
                    break;
                case 4:
                    beverage = new Espresso();
                    break;
                default:
                    Console.WriteLine("Invalid coffee choice. Exiting...");
                    return;
            }

            Console.WriteLine("Please select condiments :");
            Console.WriteLine("1. Milk (0.20)");
            Console.WriteLine("2. Mocha (0.20)");
            Console.WriteLine("3. Soy (0.15)");
            Console.WriteLine("4. Whipped cream (0.10)");

            string[] condimentChoices = Console.ReadLine().Split(',');

            foreach (var choice in condimentChoices)
            {
                switch (choice.Trim())
                {
                    case "1":
                        beverage = new Milk(beverage);
                        break;
                    case "2":
                        beverage = new Mocha(beverage);
                        break;
                    case "3":
                        beverage = new Soy(beverage);
                        break;
                    case "4":
                        beverage = new WhippedCream(beverage);
                        break;
                    default:
                        Console.WriteLine($"Invalid condiment choice: {choice}");
                        break;
                }
            }

            Console.WriteLine("Your order: " + beverage.Description);
            Console.WriteLine("Total cost: " + beverage.Cost());
        }
        
    }
}
